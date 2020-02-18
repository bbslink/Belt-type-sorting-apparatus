using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Belt_type_sorting_apparatus.CommonClass
{
    class FrontCheckAction
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        static ArrayList curCheckPlace;
        static string errMsg;

        public static void ActionStart()
        {

            try
            {
                while (true)
                {
                    //打开平台真空
                    //IOMonitor.SetOneOutBit(CommonData.out_FrontReceiveCylinderSuck, 0);

                    //告知要料
                    CommonData.signal_PlatFrontNeed = true;                

                    //前往载台
                    CardControl.AxisMoveAndCheck(CommonData.axisProductReceive_Front, CommonData.saveData.FrontReceiveDis[1], 1, CommonData.saveData.delay_CommonTime);

                    //接料平台上升
                    IOMonitor.SetOneOutBit(CommonData.out_FrontReceiveCylinderUp, 0);

                    //检测到位
                    if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_FrontReceiveUpTense) == 0), CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("等待前载台上位超时！");
                    }

                    //告知可放
                    CommonData.signal_FrontHaveArrived = true;

                    //等待放完
                    CheckSignal.WaitForALLTime(() => CommonData.signal_FrontPlatPutOK);
                    CommonData.signal_FrontPlatPutOK = false;

                    //检测真空
                    if (IOMonitor.ReadOneInBit(CommonData.in_FrontReceiveVacuum) != 0)
                    {
                        System.Windows.Forms.MessageBox.Show("真空检测失败，请手动！");
                    }

                    //告知夹紧
                    IOMonitor.SetOneOutBit(CommonData.out_FrontPlatformClipTight, 0);

                    //检测夹紧
                    if (!CheckSignal.WaitSomeTime(() => ((IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipCloseTense_1) == 1) && (IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipOpenTense_1) == 1)
                        && (IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipCloseTense_2) == 1) && (IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipOpenTense_2) == 1)), CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("等待前载具加紧超时！");
                    }

                    //关载台吸真空
                    IOMonitor.SetOneOutBit(CommonData.out_FrontReceiveCylinderSuck, 1);
                    IOMonitor.SetOneOutBit(CommonData.out_FrontReceiveCylinderPuff, 0);
                    CheckSignal.CommonDelay(CommonData.saveData.delay_PuffTime);
                    IOMonitor.SetOneOutBit(CommonData.out_FrontReceiveCylinderPuff, 1);

                    //接料平台下降
                    IOMonitor.SetOneOutBit(CommonData.out_FrontReceiveCylinderUp, 1);

                    //检测到位
                    if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_FrontReceiveDownTense) == 0), CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("等待前载台下位超时！");
                    }

                    if (CommonData.saveData.signal_isLaShen)
                    {
                        //告知拉伸
                        IOMonitor.SetOneOutBit(CommonData.out_FrontPlatformExtendTight, 0);

                        //检测拉伸
                        if (!CheckSignal.WaitSomeTime(() => ((IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipFrontTense_1) == 1) && (IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipFrontTense_2) == 1)
                           && (IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipFrontTense_3) == 1) && (IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipFrontTense_4) == 1)), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("等待前载具拉伸超时！");
                        }
                    }

                    CheckSignal.CommonDelay(500);

                    //等待复查完毕
                    CheckSignal.WaitForALLTime(() => CommonData.signal_FrontReCheckOK);

                    //复位窗口
                    FlagControl.ReflashFront();
                    //等待选择相机
                    int selectCamera = CommonAction.SelectCamera();

                    sysEvent.showRealInfo("开始检测", CommonData.infoMess);


                    //判断先用哪个相机工作
                    if (selectCamera == 1)
                    {
                        CommonData.signal_CameraNowPlace = 1;
                        CommonData.signal_UpCameraDataOK = true;
                        CommonData.upfrontorbehind = 1;
                        //去Mark拍照位1
                        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraUp }, new int[] { 180950, 658564 }, new ushort[] { 1, 1 });
                        CheckSignal.CommonDelay(CommonData.saveData.cameraComeDelay);
                       CommonData.CameraUp.SnapShot(out errMsg);
                      // IOMonitor.SetOneBitReverse(CommonData.out_UpLight, 0.01);
                        if (!CheckSignal.WaitSomeTime(() => CommonData.signal_UpCameraOK, CommonData.saveData.delay_CommonTime))
                            throw new Exception("相机处理等待超时！");
                        CommonData.signal_UpCameraOK = false;
                        CommonData.signal_UpCameraDataOK = true;
                        CheckSignal.CommonDelay(CommonData.saveData.cameraLeaveDelay);

                        //去Mark拍照位2
                        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraUp }, new int[] { 219105, 682909 }, new ushort[] { 1, 1 });
                        CheckSignal.CommonDelay(CommonData.saveData.cameraComeDelay);
                       CommonData.CameraUp.SnapShot(out errMsg);
                       //IOMonitor.SetOneBitReverse(CommonData.out_UpLight, 0.01);
                        if (!CheckSignal.WaitSomeTime(() => CommonData.signal_UpCameraOK, CommonData.saveData.delay_CommonTime))
                            throw new Exception("相机处理等待超时！");
                        CommonData.signal_UpCameraOK = false;
                        CommonData.signal_UpCameraDataOK = true;
                        CheckSignal.CommonDelay(CommonData.saveData.cameraLeaveDelay);
                        //计算得到点位

                        CommonData.signal_CameraNowPlace = 2;
                        //根据得到点位，开始遍历
                        curCheckPlace = CommonData.saveData.PointModels["前载台上相机模板"].ModelPoints;
                        if (curCheckPlace == null||curCheckPlace.Count == 0 )
                        {
                            sysEvent.showRealInfo("模板数据为空，请检查！", CommonData.warnMess);
                        }
                        else
                        {
                            int tempi = 1;
                            //加载位置并运动
                            foreach (var curKV in curCheckPlace)
                            {
                                CheckSignal.CommonDelay(CommonData.saveData.cameraLeaveDelay);
                                CommonData.curFrontPosition = tempi;
                                string[] curArray = curKV.ToString().Split(' ');
                                CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraUp }, 
                                    new int[] { Convert.ToInt32(curArray[0]), Convert.ToInt32(curArray[1]) }, new ushort[] { 1, 1 });
                                CheckSignal.CommonDelay(CommonData.saveData.cameraComeDelay);
                              // IOMonitor.SetOneBitReverse(CommonData.out_UpLight, 0.01);
                               CommonData.CameraUp.SnapShot(out errMsg);
                                if (!CheckSignal.WaitSomeTime(() => CommonData.signal_UpCameraOK, CommonData.saveData.delay_CommonTime))
                                    throw new Exception("相机处理等待超时！");
                                CommonData.signal_UpCameraOK = false;

                                if (CommonData.signal_curUpImageRusult)
                                {
                                    sysEvent.showRealInfo("点位检测结果：OK", CommonData.infoMess);
                                    CommonData.flagController1.Invoke(new Action(() =>
                                    {
                                        if (CommonData.flagController1.Controls.Count > 0)
                                            ((TextBox)(CommonData.flagController1.Controls.Find(tempi++.ToString(), false)[0])).BackColor = Color.Green;
       
                                    }));
                                    
                                }                                  
                                else
                                {
                                    sysEvent.showRealInfo("点位检测结果：NG", CommonData.warnMess);
                                    CommonData.flagController1.Invoke(new Action(() =>
                                    {
                                        if (CommonData.flagController1.Controls.Count > 0)
                                            ((TextBox)(CommonData.flagController1.Controls.Find(tempi++.ToString(), false)[0])).BackColor = Color.Red;

                                    }));
                                    CommonData.signal_FrontCheckResult = false;
                                }

                                CommonData.signal_UpCameraDataOK = true;
                               
                            }
                        }

                        //上相机完成
                        CommonData.signal_CameraUpFree = true;
                     
                        //准备下相机
                        CheckSignal.WaitForALLTime(()=>CommonData.signal_CameraDownFree);
                        CommonData.signal_CameraDownFree = false;

                        CommonData.downfrontorbehind = 1;
                        ////去Mark拍照位1
                        //CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraDown }, new int[] { 207665, 571811 }, new ushort[] { 1, 1 });
                        //IOMonitor.SetOneBitReverse(CommonData.out_DownLight, 0.01);
                        ////去Mark拍照位2
                        //CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraDown }, new int[] { 199535, 670656 }, new ushort[] { 1, 1 });
                        //IOMonitor.SetOneBitReverse(CommonData.out_DownLight, 0.01);

                        //计算得到点位

                        //根据得到点位，开始遍历
                        curCheckPlace = CommonData.saveData.PointModels["前载台下相机模板"].ModelPoints;
                        if (curCheckPlace == null||curCheckPlace.Count == 0  )
                        {
                            sysEvent.showRealInfo("模板数据为空，请检查！", CommonData.warnMess);
                        }
                        else
                        {
                            //加载位置并运动
                            foreach (var curKV in curCheckPlace)
                            {
                                string[] curArray = curKV.ToString().Split(' ');
                                CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraDown },
                                    new int[] { Convert.ToInt32(curArray[0]), Convert.ToInt32(curArray[1]) }, new ushort[] { 1, 1 });
                                IOMonitor.SetOneBitReverse(CommonData.out_DownLight, 0.01);
                            }
                        }

                        //下相机完成
                        CommonData.signal_CameraDownFree = true;

                    }
                    else if (selectCamera == 2)
                    {
                        CommonData.downfrontorbehind = 1;

                        ////去Mark拍照位1
                        //CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraDown }, new int[] { 207665, 571811 }, new ushort[] { 1, 1 });
                        //IOMonitor.SetOneBitReverse(CommonData.out_DownLight, 0.01);
                        ////去Mark拍照位2
                        //CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraDown }, new int[] { 199535, 670656 }, new ushort[] { 1, 1 });
                        //IOMonitor.SetOneBitReverse(CommonData.out_DownLight, 0.01);

                        //计算得到点位


                        //根据得到点位，开始遍历
                        curCheckPlace = CommonData.saveData.PointModels["前载台下相机模板"].ModelPoints;
                        if (curCheckPlace == null||curCheckPlace.Count == 0  )
                        {
                            sysEvent.showRealInfo("模板数据为空，请检查！", CommonData.warnMess);
                        }
                        else
                        {
                            //加载位置并运动
                            foreach (var curKV in curCheckPlace)
                            {
                                string[] curArray = curKV.ToString().Split(' ');
                                CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraDown },
                                    new int[] { Convert.ToInt32(curArray[0]), Convert.ToInt32(curArray[1]) }, new ushort[] { 1, 1 });
                                IOMonitor.SetOneBitReverse(CommonData.out_DownLight, 0.01);
                            }
                        }




                        //下相机完成
                        CommonData.signal_CameraDownFree = true;
                        //准备上相机
                        CheckSignal.WaitForALLTime(()=>CommonData.signal_CameraUpFree);
                        CommonData.signal_CameraUpFree = false;

                        CommonData.signal_CameraNowPlace = 1;
                        CommonData.signal_UpCameraDataOK = true;
                        CommonData.upfrontorbehind = 1;
                        //去Mark拍照位1
                        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraUp }, new int[] { 180950, 658564 }, new ushort[] { 1, 1 });
                        CheckSignal.CommonDelay(CommonData.saveData.cameraComeDelay);
                      CommonData.CameraUp.SnapShot(out errMsg);
                        //IOMonitor.SetOneBitReverse(CommonData.out_UpLight, 0.01);
                        if (!CheckSignal.WaitSomeTime(() => CommonData.signal_UpCameraOK, CommonData.saveData.delay_CommonTime))
                            throw new Exception("相机处理等待超时！");
                        CommonData.signal_UpCameraOK = false;
                        CommonData.signal_UpCameraDataOK = true;
                        CheckSignal.CommonDelay(CommonData.saveData.cameraLeaveDelay);
                        //去Mark拍照位2
                        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraUp }, new int[] { 219105, 682909 }, new ushort[] { 1, 1 });
                        CheckSignal.CommonDelay(CommonData.saveData.cameraComeDelay);
                        CommonData.CameraUp.SnapShot(out errMsg);
                       // IOMonitor.SetOneBitReverse(CommonData.out_UpLight, 0.01);
                        if (!CheckSignal.WaitSomeTime(() => CommonData.signal_UpCameraOK, CommonData.saveData.delay_CommonTime))
                            throw new Exception("相机处理等待超时！");
                        CommonData.signal_UpCameraOK = false;
                        CommonData.signal_UpCameraDataOK = true;
                        CheckSignal.CommonDelay(CommonData.saveData.cameraLeaveDelay);
                        //计算得到点位

                        CommonData.signal_CameraNowPlace = 2;
                        //根据得到点位，开始遍历
                        curCheckPlace = CommonData.saveData.PointModels["前载台上相机模板"].ModelPoints;
                        if (curCheckPlace == null||curCheckPlace.Count == 0  )
                        {
                            sysEvent.showRealInfo("模板数据为空，请检查！", CommonData.warnMess);
                        }
                        else
                        {
                            int tempi = 1;
                            //加载位置并运动
                            foreach (var curKV in curCheckPlace)
                            {
                                CheckSignal.CommonDelay(CommonData.saveData.cameraLeaveDelay);
                                CommonData.curFrontPosition = tempi;
                                string[] curArray = curKV.ToString().Split(' ');
                                CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraUp },
                                    new int[] { Convert.ToInt32(curArray[0]), Convert.ToInt32(curArray[1]) }, new ushort[] { 1, 1 });
                                CheckSignal.CommonDelay(CommonData.saveData.cameraComeDelay);
                                CommonData.CameraUp.SnapShot(out errMsg);
                               // IOMonitor.SetOneBitReverse(CommonData.out_UpLight, 0.01);
                                if (!CheckSignal.WaitSomeTime(() => CommonData.signal_UpCameraOK, CommonData.saveData.delay_CommonTime))
                                    throw new Exception("相机处理等待超时！");
                                CommonData.signal_UpCameraOK = false;

                                if (CommonData.signal_curUpImageRusult)
                                {
                                    sysEvent.showRealInfo("点位检测结果：OK", CommonData.infoMess);
                                    CommonData.flagController1.Invoke(new Action(() =>
                                    {
                                        if (CommonData.flagController1.Controls.Count > 0)
                                            ((TextBox)(CommonData.flagController1.Controls.Find(tempi++.ToString(), false)[0])).BackColor = Color.Green;

                                    }));
                                    
                                }
                                else
                                {
                                    sysEvent.showRealInfo("点位检测结果：NG", CommonData.warnMess);
                                    CommonData.flagController1.Invoke(new Action(() =>
                                    {
                                        if (CommonData.flagController1.Controls.Count > 0)
                                            ((TextBox)(CommonData.flagController1.Controls.Find(tempi++.ToString(), false)[0])).BackColor = Color.Red;

                                    }));
                                
                                    CommonData.signal_FrontCheckResult = false;
                                }
                                   
                                CommonData.signal_UpCameraDataOK = true;
                               
                            }
                        }

                        //上相机完成
                        CommonData.signal_CameraUpFree = true;
                    }

                   
                    //根据上面计算，直接遍历检测探高
                    curCheckPlace = CommonData.saveData.PointModels["前载台探高模板"].ModelPoints;
                    if ( curCheckPlace == null||curCheckPlace.Count == 0 )
                    {
                        sysEvent.showRealInfo("模板数据为空，请检查！", CommonData.warnMess);
                    }
                    else
                    {
                        //等待探高可用
                        CommonAction.WaitDepth();
                        int tempi = 1;
                        CommonData.depthfrontorbehind = 1;
                        //加载位置并运动
                        foreach (var curKV in curCheckPlace)
                        {
                            CommonData.curFrontPosition = tempi;
                            string[] curArray = curKV.ToString().Split(' ');
                            CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisUpDepth_CheckMove,CommonData.axisDownDepth_CheckMove },
                                new int[] { Convert.ToInt32(curArray[0]), Convert.ToInt32(curArray[1]) ,Convert.ToInt32(curArray[2]) }, new ushort[] { 1, 1, 1 });

                            //开始探高
                            CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisUpDepth_RiseAndDown, CommonData.axisDownDepth_RiseAndDown }, new int[] { CommonData.saveData.UpDepthDis[1], CommonData.saveData.DownDepthDis[1] }, new ushort[] { 1, 1 });

                            //探高气缸
                            IOMonitor.SetOneOutBit(CommonData.out_UpNeedleCylinderDown, 0);
                            IOMonitor.SetOneOutBit(CommonData.out_DownNeedleCylinderUp, 0);

                            CheckSignal.CommonDelay(400);
                            //得到值判断结果
                            CommonAction.askDepthData();

                            if (!CheckSignal.WaitSomeTime(() => CommonData.signal_DepthOK, CommonData.saveData.delay_CommonTime))
                                throw new Exception("相机处理等待超时！");
                            CommonData.signal_DepthOK = false;

                            if (CommonData.signal_DepthDataResult)
                            {
                                sysEvent.showRealInfo("点位检测结果：OK", CommonData.infoMess);
                                CommonData.flagController3.Invoke(new Action(() =>
                                {
                                    if (CommonData.flagController3.Controls.Count > 0)
                                        ((TextBox)(CommonData.flagController3.Controls.Find(tempi++.ToString(), false)[0])).BackColor = Color.Green;

                                }));

                            }                                
                            else
                            {
                                sysEvent.showRealInfo("点位检测结果：NG", CommonData.warnMess);
                                CommonData.flagController3.Invoke(new Action(() =>
                                {
                                    if (CommonData.flagController3.Controls.Count > 0)
                                        ((TextBox)(CommonData.flagController3.Controls.Find(tempi++.ToString(), false)[0])).BackColor = Color.Red;

                                }));
                                CommonData.signal_FrontCheckResult = false;
                            }

                            CommonData.signal_DepthDataOK = true;
                            //关探高气缸
                            IOMonitor.SetOneOutBit(CommonData.out_UpNeedleCylinderDown, 1);
                            IOMonitor.SetOneOutBit(CommonData.out_DownNeedleCylinderUp, 1);
                            CheckSignal.CommonDelay(200);
                        }
                    }
                  
                   

                    CommonData.signal_PlatFrontThrow = true;

                    CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisUpDepth_RiseAndDown, CommonData.axisDownDepth_RiseAndDown }, new int[] { CommonData.saveData.UpDepthDis[0], CommonData.saveData.DownDepthDis[0] }, new ushort[] { 1, 1 });
                    CommonData.signal_DepthFree = true;


                    //去出盘位置
                    CardControl.AxisMoveAndCheck(CommonData.axisProductReceive_Front, CommonData.saveData.FrontReceiveDis[4], 1, CommonData.saveData.delay_CommonTime);

                    CommonData.signal_PlatFrontThrowArrived = true;


                    CheckSignal.WaitForALLTime(() => CommonData.signal_CrabFrontProOK);
                    CommonData.signal_CrabFrontProOK = false;

                    sysEvent.showRealInfo("结束检测", CommonData.infoMess);
                    CheckSignal.CommonDelay(1);
                }


            }
            catch(Exception ex)
            {

                sysEvent.showRealInfo(ex.Message, CommonData.warnMess);
                StopAction.QuickErrStop();
            }
        }



      
    }
}
