using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class CameraCheckAction
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        public static void ActionStart()
        {
            try
            {
                //if (CommonData.signal_CheckWhich == 1)
                //{
                //    for (int i = 0; i < S.Cout; i++)
                //    {
                //        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisCamera_X, CommonData.axisCamera_Y }, new int[] { }, new ushort[] { 1, 1 });
                //        CommonData.signal_CameraNowPlace = 1;
                //        IOMonitor.SetOneBitReverse(1, 0.01);
                //        if (!CheckSignal.WaitSomeTime(() => CommonData.signal_UpCameraOK, CommonData.saveData.delay_CommonTime))
                //        {
                //            throw new Exception("s");
                //        }
                //        CommonData.signal_UpCameraDataOK = true;
                //    }


                //    //数据处理


                //    foreach (var a in s)
                //    {
                //        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisCamera_X, CommonData.axisCamera_Y }, new int[] { }, new ushort[] { 1, 1 });
                //        CommonData.signal_CameraNowPlace = 2;
                //        IOMonitor.SetOneBitReverse(1, 0.01);
                //        if (!CheckSignal.WaitSomeTime(() => CommonData.signal_UpCameraOK, CommonData.saveData.delay_CommonTime))
                //        {
                //            throw new Exception("s");
                //        }
                //        CommonData.signal_UpCameraDataOK = true;
                //    }
                //}
                //else
                //{
                //    for (int i = 0; i < S.Cout; i++)
                //    {
                //        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisCamera_X, CommonData.axisCamera_Y }, new int[] { }, new ushort[] { 1, 1 });
                //        CommonData.signal_CameraNowPlace = 1;
                //        IOMonitor.SetOneBitReverse(1, 0.01);
                //        if (!CheckSignal.WaitSomeTime(() => CommonData.signal_UpCameraOK, CommonData.saveData.delay_CommonTime))
                //        {
                //            throw new Exception("s");
                //        }
                //        CommonData.signal_UpCameraDataOK = true;
                //    }


                //    //数据处理


                //    foreach (var a in s)
                //    {
                //        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisCamera_X, CommonData.axisCamera_Y }, new int[] { }, new ushort[] { 1, 1 });
                //        CommonData.signal_CameraNowPlace = 2;
                //        IOMonitor.SetOneBitReverse(1, 0.01);
                //        if (!CheckSignal.WaitSomeTime(() => CommonData.signal_UpCameraOK, CommonData.saveData.delay_CommonTime))
                //        {
                //            throw new Exception("s");
                //        }
                //        CommonData.signal_UpCameraDataOK = true;
                //    }
                //}
           
            }
            catch(Exception ex)
            {
                sysEvent.showRealInfo(ex.Message, CommonData.warnMess);
                StopAction.QuickErrStop();
            }
      
            
        }
    }
}
