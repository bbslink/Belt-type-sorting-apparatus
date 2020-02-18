using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class ThrowProductAction
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        public static void ActionStart()
        {
            try
            {
                while (true)
                {

                    CardControl.AxisSetDstp(CommonData.axisProductOut_RiseAndDown, 1, 1);
                    try
                    {
                        CardControl.VmoveOneAxiss(CommonData.axisProductOut_RiseAndDown, 1);
                    }
                    catch
                    {
                        sysEvent.showRealInfo("连续运动卡住", CommonData.warnMess);
                    }
                    CheckSignal.WaitForALLTime(() => (IOMonitor.ReadOneInBit(CommonData.in_LeaveProductBeam) == 1));

                    CommonData.signal_OutProductArrived = true;

                    //检测空盘已经放置
                    CheckSignal.WaitForALLTime(() => CommonData.signal_PlatThrowOK);
                    CommonData.signal_PlatThrowOK = false;

                    CardControl.AxisSetDstp(CommonData.axisProductOut_RiseAndDown, 0, 1);

                    if (CardControl.AxisNowPosition(CommonData.axisProductOut_RiseAndDown) <= 3000)
                    {
                        CardControl.AxisMoveAndCheck(CommonData.axisProductOut_RiseAndDown, 0, 1, CommonData.saveData.delay_CommonTime);
                        sysEvent.showRealInfo("空盘满了请取走！", CommonData.warnMess);
                        
                        CheckSignal.WaitForALLTime(() => (IOMonitor.ReadOneInBit(CommonData.in_LeavePlatformProductTense) == 0 && IOMonitor.ReadOneInBit(CommonData.in_SafeDoor) == 0));
                    }
                    else
                        CardControl.AxisMoveAndCheck(CommonData.axisProductOut_RiseAndDown, -3000, 0, CommonData.saveData.delay_CommonTime);

                    //if (IOMonitor.ReadOneInBit(CommonData.in_LeaveProductBeam) == 1)
                    //{
                    //    sysEvent.showRealInfo("空盘满了请取走！", CommonData.warnMess);
                    //    CheckSignal.WaitForALLTime(() => (IOMonitor.ReadOneInBit(CommonData.in_LeavePlatformProductTense) == 0 && IOMonitor.ReadOneInBit(CommonData.in_SafeDoor) == 0));
                    //}

                 

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
