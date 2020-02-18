using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class ButtonSerachThread
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        static ThreadControl threadControls = ThreadControl.GetThreadControl();
        public static void StartAction()
        {
            try
            {
                int buttonStart, buttonStop, buttonPause, buttonContiune, buttonReset;

                while (true)
                {
                    buttonStart = IOMonitor.ReadOneInBit(CommonData.in_StartButton);
                    //buttonStop = IOMonitor.ReadOneInBit(CommonData.in_Scram);
                    buttonPause = IOMonitor.ReadOneInBit(CommonData.in_PauseButton);
                    //buttonContiune = IOMonitor.ReadOneInBit(CommonData.in_Scram);
                    buttonReset = IOMonitor.ReadOneInBit(CommonData.in_ResetButton);

                    if (buttonStart == 0)
                    {
                        if (CommonData.signal_IsStartNow)
                        {
                            sysEvent.ButtonContiune();
                            CheckSignal.WaitForALLTime(() => IOMonitor.ReadOneInBit(CommonData.in_StartButton) == 1);
                        }
                        else
                        {
                            sysEvent.ButtonStart();
                            CheckSignal.WaitForALLTime(() => IOMonitor.ReadOneInBit(CommonData.in_StartButton) == 1);
                        }
                    }
                    //else if (buttonStop == 0)
                    //{                    
                    //    sysEvent.ButtonStop();
                    //    CheckSignal.WaitForALLTime(() => IOMonitor.ReadOneInBit(CommonData.in_Scram) == 1);
                    //}
                    else if (buttonPause == 0)
                    {
                        sysEvent.ButtonPause();
                        CheckSignal.WaitForALLTime(() => IOMonitor.ReadOneInBit(CommonData.in_PauseButton) == 1);
                    }
                    //else if (buttonContiune == 0)
                    //{                      
                    //    sysEvent.ButtonContiune();
                    //    CheckSignal.WaitForALLTime(() => IOMonitor.ReadOneInBit(CommonData.in_Scram) == 1);
                    //}
                    else if (buttonReset == 0)
                    {
                        if (CommonData.signal_CanReset)
                        {
                            if (!ThreadControl.buttonReset.IsAlive)
                            {
                                sysEvent.showRealInfo("开始快速复位", CommonData.infoMess);
                                threadControls.ReInitThread(16);
                            }
                        }
                        else
                        {
                            sysEvent.ButtonHome();
                        }
                        CheckSignal.WaitForALLTime(() => IOMonitor.ReadOneInBit(CommonData.in_ResetButton) == 1);
                    }


                    CheckSignal.CommonDelay(1);
                }
            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo("错误0xCA022,按钮线程异常\r" + ex.Message, CommonData.warnMess);
            }
        }
    }
}
