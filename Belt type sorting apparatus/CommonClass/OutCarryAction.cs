using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class OutCarryAction
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        public static void ActionStart()
        {
            try
            {
                while (true)
                {

                    IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderSuck, 0);
                    CheckSignal.WaitForALLTime(() => (CommonData.signal_PlatFrontThrow || CommonData.signal_PlatBehindThrow));
                    if (CommonData.signal_PlatFrontThrow)
                    {
                        CommonData.signal_PlatFrontThrow = false;
                       
                        CardControl.AxisMoveAndCheck(CommonData.axisProductOut_CarryMove, CommonData.saveData.ThrowProductDis[2], 1, CommonData.saveData.delay_CommonTime);

                        CheckSignal.WaitForALLTime(() => CommonData.signal_PlatFrontThrowArrived);
                        CommonData.signal_PlatFrontThrowArrived = false;
                        //下降
                        IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderDown, 0);
                        //下降到位检测
                        if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_LeaveCylinderDownTense) == 0), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("出料气缸检测下降到位超时！");
                        }
                      
                        //吸真空延时             
                        CheckSignal.CommonDelay(CommonData.saveData.delay_SuckTime);
                        CheckSignal.CommonDelay(300);

                        //检测真空
                        if (IOMonitor.ReadOneInBit(CommonData.in_LeaveCylinderVacuum) != 0)            //真空没达到
                        {
                            //throw new Exception("出料气缸吸取产品失败！请检查！");
                            MessageBox.Show("真空检测失败，请手动！");
                        }
                     
                        //关夹子夹紧
                        IOMonitor.SetOneOutBit(CommonData.out_FrontPlatformClipTight, 1);

                        //检测夹紧关闭
                        if (!CheckSignal.WaitSomeTime(() => ((IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipCloseTense_1) == 0) && (IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipOpenTense_1) == 0)
                     && (IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipCloseTense_2) == 0) && (IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipOpenTense_2) == 0)), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("检测前载具加紧关闭超时！");
                        }

                        //关夹子拉伸
                        IOMonitor.SetOneOutBit(CommonData.out_FrontPlatformExtendTight, 1);

                        //检测拉伸关闭
                        if (!CheckSignal.WaitSomeTime(() => ((IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipFrontTense_1) == 0) && (IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipFrontTense_2) == 0)
                         && (IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipFrontTense_3) == 0) && (IOMonitor.ReadOneInBit(CommonData.in_FrontPlatformClipFrontTense_4) == 0)), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("检测前载具拉伸关闭超时！");
                        }


                        //上升
                        IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderDown, 1);
                        //上升到位检测
                        if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_LeaveCylinderUpTense) == 0), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("出料气缸检测上升到位超时！");
                        }

                      
                        CommonData.signal_FrontReCheckOK = false;
                        CommonData.signal_CrabFrontProOK = true;

                        //去出盘平台
                        CardControl.AxisMoveAndCheck(CommonData.axisProductOut_CarryMove, CommonData.saveData.ThrowProductDis[1], 1, CommonData.saveData.delay_CommonTime);
                        if (CommonData.signal_FrontCheckResult == false)
                        {
                            CommonData.data_NGPut++;
                            CommonData.signal_FrontCheckResult = true;
                            IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderSuck, 1);
                            IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderPuff, 0);
                            CheckSignal.CommonDelay(CommonData.saveData.delay_PuffTime);
                            IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderPuff, 1);
                            MessageBox.Show("前载台产品检测NG不通过，请对照屏幕检查！确认完毕后按确认继续！");
                            CommonData.signal_FrontReCheckOK = true;
                            continue;
                        }
                        else
                        {
                            CommonData.signal_FrontReCheckOK = true;
                            CommonData.data_NumberPut++;
                        }
                      
                    }
                    else if(CommonData.signal_PlatBehindThrow)
                    {
                        CommonData.signal_PlatBehindThrow = false;

                        CardControl.AxisMoveAndCheck(CommonData.axisProductOut_CarryMove, CommonData.saveData.ThrowProductDis[3], 1, CommonData.saveData.delay_CommonTime);

                         CheckSignal.WaitForALLTime(() => CommonData.signal_PlatBehindThrowArrived);
                        CommonData.signal_PlatBehindThrowArrived = false;


                        //下降
                        IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderDown, 0);
                        //下降到位检测
                        if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_LeaveCylinderDownTense) == 0), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("出料气缸检测下降到位超时！");
                        }
                       
                        //吸真空延时             
                        CheckSignal.CommonDelay(CommonData.saveData.delay_SuckTime);
                        CheckSignal.CommonDelay(300);

                        //检测真空
                        if (IOMonitor.ReadOneInBit(CommonData.in_LeaveCylinderVacuum) != 0)            //真空没达到
                        {
                            //throw new Exception("出料气缸吸取产品失败！请检查！");
                            MessageBox.Show("真空检测失败，请手动！");
                        }
                       
                        //关夹子夹紧
                        IOMonitor.SetOneOutBit(CommonData.out_BehindPlatformClipTight, 1);

                        //检测夹紧关闭
                        if (!CheckSignal.WaitSomeTime(() => ((IOMonitor.ReadOneInBit(CommonData.in_BehindPlatformClipCloseTense_1) == 0) && (IOMonitor.ReadOneInBit(CommonData.in_BehindPlatformClipOpenTense_1) == 0)
                      && (IOMonitor.ReadOneInBit(CommonData.in_BehindPlatformClipCloseTense_2) == 0) && (IOMonitor.ReadOneInBit(CommonData.in_BehindPlatformClipOpenTense_2) == 0)), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("检测后载具加紧关闭超时！");
                        }

                        //关夹子拉伸
                        IOMonitor.SetOneOutBit(CommonData.out_BehindPlatformExtendTight, 1);

                        //检测拉伸关闭
                        if (!CheckSignal.WaitSomeTime(() => ((IOMonitor.ReadOneInBit(CommonData.in_BehindPlatformClipFrontTense_1) == 0) && (IOMonitor.ReadOneInBit(CommonData.in_BehindPlatformClipFrontTense_2) == 0)
                           && (IOMonitor.ReadOneInBit(CommonData.in_BehindPlatformClipFrontTense_3) == 0) && (IOMonitor.ReadOneInBit(CommonData.in_BehindPlatformClipFrontTense_4) == 0)), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("检测后载具拉伸关闭超时！");
                        }

                        //上升
                        IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderDown, 1);
                        //上升到位检测
                        if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_LeaveCylinderUpTense) == 0), CommonData.saveData.delay_CommonTime))
                        {
                            throw new Exception("出料气缸检测上升到位超时！");
                        }
                      
                        CommonData.signal_BehindReCheckOK = false;
                        CommonData.signal_CrabBehindProOK = true;

                        //去出盘平台
                        CardControl.AxisMoveAndCheck(CommonData.axisProductOut_CarryMove, CommonData.saveData.ThrowProductDis[1], 1, CommonData.saveData.delay_CommonTime);
                        if (CommonData.signal_BehindCheckResult == false)
                        {
                            CommonData.data_NGPut++;
                            CommonData.signal_BehindCheckResult = true;
                            IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderSuck, 1);
                            IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderPuff, 0);
                            CheckSignal.CommonDelay(CommonData.saveData.delay_PuffTime);
                            IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderPuff, 1);
                            MessageBox.Show("后载台产品检测NG不通过，请对照屏幕检查！确认完毕后按确认继续！");
                            CommonData.signal_BehindReCheckOK = true;
                            continue;
                        }
                        else
                        {
                            CommonData.signal_BehindReCheckOK = true;
                            CommonData.data_NumberPut++;
                        }
                       
                    }



                    CheckSignal.WaitForALLTime(() => CommonData.signal_OutProductArrived);
                    CommonData.signal_OutProductArrived = false;


                    //下降
                    IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderDown, 0);
                    //下降到位检测
                    if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_LeaveCylinderDownTense) == 0), CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("出料气缸检测下降到位超时！");
                    }

                    //关真空开破真空
                    IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderSuck, 1);
                    IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderPuff, 0);
                    CheckSignal.CommonDelay(CommonData.saveData.delay_PuffTime);

                    //上升
                    IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderDown, 1);
                    //上升到位检测
                    if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_LeaveCylinderUpTense) == 0), CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("出料气缸检测上升到位超时！");
                    }

                    IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderPuff, 1);


                    CommonData.signal_PlatThrowOK = true;
                    sysEvent.showRealInfo("出料完成", CommonData.infoMess);

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
