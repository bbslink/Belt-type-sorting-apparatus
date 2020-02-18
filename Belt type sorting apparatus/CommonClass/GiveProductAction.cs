using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class GiveProductAction
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        public static void ActionStart()
        {
            try
            {
                while (true)
                {
                    //检测料盘已经抓走
                    CheckSignal.WaitForALLTime(() => CommonData.signal_CrabProductOK);
                    CommonData.signal_CrabProductOK = false;

                    CardControl.AxisSetDstp(CommonData.axisProductCome_RiseAndDown,0, 1);

                    //空盘台无料
                    if (IOMonitor.ReadOneInBit(CommonData.in_ComePlatformProductTense) != 0)
                    {
                        CommonData.signal_MoveCarryCanGoToCarry = false;
                        //回原点装料
                        CardControl.AxisMoveAndCheck(CommonData.axisProductCome_RiseAndDown, 0, 1, CommonData.saveData.delay_CommonTime);
                        sysEvent.showRealInfo("没有料啦，快加料！", CommonData.warnMess);

                        //上空盘台有无空盘检测和侧安全门关闭检测
                        CheckSignal.WaitForALLTime(() => (IOMonitor.ReadOneInBit(CommonData.in_ComePlatformProductTense) == 0 && IOMonitor.ReadOneInBit(CommonData.in_SafeDoor) == 0));

                        if (IOMonitor.ReadOneInBit(CommonData.in_ComePlatformBeam) == 1)
                        {
                            sysEvent.showRealInfo("开始空盘放的太多！请拿掉些料盘！", CommonData.warnMess);
                            CheckSignal.WaitForALLTime(() => (IOMonitor.ReadOneInBit(CommonData.in_ComePlatformBeam) == 0 && IOMonitor.ReadOneInBit(CommonData.in_SafeDoor) == 0));
                        }

                        CheckSignal.CommonDelay(300);
                        CommonData.signal_MoveCarryCanGoToCarry = true;
                    }
                    else
                    {
                        CommonData.signal_MoveCarryCanGoToCarry = true;
                        //if (!CardControl.CheckAxisHome(CommonData.axisProductCome_RiseAndDown))
                        if (CardControl.AxisNowPosition(CommonData.axisProductCome_RiseAndDown)>=3000)
                        {
                            //空盘台下降
                            CardControl.AxisMoveAndCheck(CommonData.axisProductCome_RiseAndDown, -3000, 0, CommonData.saveData.delay_CommonTime);
                            CheckSignal.CommonDelay(50);
                        }
         
                    }

                    //设置减速停止信号
                    CardControl.AxisSetDstp(CommonData.axisProductCome_RiseAndDown, 1, 1);
                    //轴连续运动
                    try
                    {
                        CardControl.VmoveOneAxiss(CommonData.axisProductCome_RiseAndDown, 1);
                    }
                    catch
                    {
                        sysEvent.showRealInfo("连续运动卡住", CommonData.warnMess);
                    }
                       
                     
                   
                    //检测运动到对射
                    CheckSignal.WaitForALLTime(() => (IOMonitor.ReadOneInBit(CommonData.in_ComePlatformBeam) == 1));
                    //告知产品上升到位
                    CommonData.signal_ProductRiseArrived = true;


                    CheckSignal.CommonDelay(1);
                }


            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(typeof(GiveProductAction), ex);
                sysEvent.showRealInfo(ex.Message, CommonData.warnMess);
                StopAction.QuickErrStop();
            }
        }
    }
}
