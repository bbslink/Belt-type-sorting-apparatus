
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class BeltControl
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        public static void CardStartAction()
        {
            try
            {
                //while (true)
                //{
                //    if (CommonData.signal_FrontAskBeltCanNotMove || CommonData.signal_BeltCanNotMove)
                //    {
                //        CardControl.StopOneAxiss(CommonData.axisBelt,CommonData.saveData.delay_CommonTime);
                //        while (CommonData.signal_FrontAskBeltCanNotMove || CommonData.signal_BeltCanNotMove)
                //        {
                //            CheckSignal.CommonDelay(1);
                //        }
                //    }
                //    CardControl.VmoveOneAxiss(CommonData.axisBelt, 1);



                //    CheckSignal.CommonDelay(1);
                //}
            }
            catch(Exception ex)
            {
                sysEvent.showRealInfo("错误0xCA014,皮带轴控制线程异常\r" + ex.Message, CommonData.warnMess);
                StopAction.QuickErrStop();
            }
    

        }

        public static void IOStartAction()
        {
            try
            {
                //while (true)
                //{
                //    if (CommonData.signal_FrontAskBeltCanNotMove || CommonData.signal_BeltCanNotMove)
                //    {
                //        IOMonitor.SetOneOutBit(CommonData.out_BeltFront, 1);
                //        while (CommonData.signal_FrontAskBeltCanNotMove || CommonData.signal_BeltCanNotMove)
                //        {
                //            CheckSignal.CommonDelay(1);
                //        }
                //    }
                //    IOMonitor.SetOneOutBit(CommonData.out_BeltFront, 0);
                //    CheckSignal.CommonDelay(1);
                //}
            }
            catch(Exception ex)
            {
                sysEvent.showRealInfo("错误0xCA015,皮带IO控制线程异常\r" + ex.Message, CommonData.warnMess);
                StopAction.QuickErrStop();
            }
    

        }
    }
}
