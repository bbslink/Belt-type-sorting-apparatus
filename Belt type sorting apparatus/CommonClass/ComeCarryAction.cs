using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class ComeCarryAction
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        public static void ActionStart()
        {
            try
            {
                while (true)
                {
                    //等待是否可过来取
                    CheckSignal.WaitForALLTime(() => CommonData.signal_MoveCarryCanGoToCarry);
                    CommonData.signal_MoveCarryCanGoToCarry = false;

                    //前往抓料
                    CardControl.AxisMoveAndCheck(CommonData.axisProductCome_CarryMove, CommonData.saveData.CarryProductDis[1], 1, CommonData.saveData.delay_CommonTime);
                    //开吸真空
                    IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderSuck, 0);

                    //等待产品到位
                    CheckSignal.WaitForALLTime(() => CommonData.signal_ProductRiseArrived);
                    CommonData.signal_ProductRiseArrived = false;
               
                    //下降
                    IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderDown, 0);
                    //下降到位检测
                    if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_ComeCylinderDownTense) == 0), CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("进料气缸检测下降到位超时！");
                    }

                    //吸真空延时             
                    CheckSignal.CommonDelay(CommonData.saveData.delay_SuckTime);
                    CheckSignal.CommonDelay(CommonData.saveData.delay_SuckTime);
                    //上升
                    IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderDown, 1);
                    //上升到位检测
                    if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_ComeCylinderUpTense) == 0), CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("进料气缸检测上升到位超时！");
                    }


                    //检测真空
                    if (IOMonitor.ReadOneInBit(CommonData.in_ComeCylinderVacuum) != 0)            //真空没达到
                    {
                        //关真空开破真空
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderSuck, 1);
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderPuff, 0);
                        CheckSignal.CommonDelay(CommonData.saveData.delay_PuffTime);

                        //关破真空开吸真空
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderPuff, 1);
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderSuck, 0);
                        CheckSignal.CommonDelay(CommonData.saveData.delay_SuckTime);

                        //下降
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderDown, 0);
                        //下降到位检测
                        if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_ComeCylinderDownTense) == 0), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("进料气缸检测下降到位超时！");
                        }
                        CheckSignal.CommonDelay(CommonData.saveData.delay_SuckTime);

                        //真空检测
                        if (IOMonitor.ReadOneInBit(CommonData.in_ComeCylinderVacuum) != 0)
                        {
                            //throw new Exception("进料气缸抓取产品失败！请检查！");
                            MessageBox.Show("真空检测失败，请手动！");
                        }

                        //上升
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderDown, 1);
                        //上升到位检测
                        if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_ComeCylinderUpTense) == 0), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("进料气缸检测上升到位超时！");
                        }

                      
                    }


                    CommonData.signal_CrabProductOK = true;
                    sysEvent.showRealInfo("进料完成", CommonData.infoMess);

                    CheckSignal.WaitForALLTime(() => (CommonData.signal_PlatFrontNeed|| CommonData.signal_PlatBehindNeed));


                    if (CommonData.signal_PlatFrontNeed)
                    {
                        CommonData.signal_PlatFrontNeed = false;

                        //运动到第一个平台位置
                        CardControl.AxisMoveAndCheck(CommonData.axisProductCome_CarryMove, CommonData.saveData.CarryProductDis[2], 1, CommonData.saveData.delay_CommonTime);

                        //等待检测平台到位
                        CheckSignal.WaitForALLTime(() => CommonData.signal_FrontHaveArrived);
                        CommonData.signal_FrontHaveArrived = false;

                        //下降
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderDown, 0);

                      
                        //下降到位检测
                        if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_ComeCylinderDownTense) == 0), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("进料气缸检测下降到位超时！");
                        }

                        //关真空开破真空
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderSuck, 1);
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderPuff, 0);
                        CheckSignal.CommonDelay(CommonData.saveData.delay_PuffTime);
                        CheckSignal.CommonDelay(1000);
                        //上升
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderDown, 1);

                

                        //上升到位检测
                        if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_ComeCylinderUpTense) == 0), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("进料气缸检测上升到位超时！");
                        }
                     

                        CommonData.signal_FrontPlatPutOK = true;
                        //关破真空
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderPuff, 1);
                       
                      
                    }
                    else if (CommonData.signal_PlatBehindNeed)
                    {
                        CommonData.signal_PlatBehindNeed = false;

                        //运动到第一个平台位置
                        CardControl.AxisMoveAndCheck(CommonData.axisProductCome_CarryMove, CommonData.saveData.CarryProductDis[3], 1, CommonData.saveData.delay_CommonTime);

                        //等待检测平台到位
                        CheckSignal.WaitForALLTime(() => CommonData.signal_BehindHaveArrived);
                        CommonData.signal_BehindHaveArrived = false;

                        //下降
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderDown, 0);


                        //下降到位检测
                        if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_ComeCylinderDownTense) == 0), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("进料气缸检测下降到位超时！");
                        }

                        //关真空开破真空
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderSuck, 1);
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderPuff, 0);
                        CheckSignal.CommonDelay(CommonData.saveData.delay_PuffTime);
                        CheckSignal.CommonDelay(1000);
                        //上升
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderDown, 1);



                        //上升到位检测
                        if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_ComeCylinderUpTense) == 0), CommonData.saveData.delay_CommonTime))
                        {
                            
                            throw new Exception("进料气缸检测上升到位超时！");
                        }


                        CommonData.signal_BehindPlatPutOK = true;
                        //关破真空
                        IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderPuff, 1);
                    }
                    else
                        throw new Exception("闹鬼啊！");
                    


                    CheckSignal.CommonDelay(1); 
                }
            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo(ex.Message, CommonData.warnMess);
                StopAction.QuickErrStop();
            }
        }


    }
}
