using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class ThreadControl
    {

        public static Thread initProces;
        public static Thread checkEMode;
        public static Thread goHomeProcesss;
        public static Thread stopProcess;
        public static Thread quickStopProcess;
        public static Thread buttonProcess;
        public static Thread beltControl;
        public static Thread buttonReset;
        public static Thread startProcess;
        public static Thread giveProductProcess;
        public static Thread comeCarryProcess;
        public static Thread frontCheckProcess;
        public static Thread behindCheckProcess;
        public static Thread outCarryProcess;
        public static Thread throwProductProcess;
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();

        private static ThreadControl threadControls;
        /// <summary>
        /// 获取线程类实例化对象
        /// </summary>
        public static ThreadControl GetThreadControl()
        {
            if (threadControls == null)
            {
                threadControls = new ThreadControl();
            }
            return threadControls;
        }

        private ThreadControl()
        {
            checkEMode = new Thread(() => CheckEmode());
            checkEMode.IsBackground = true;
            initProces = new Thread(() => InitSystem.StartInit());
            initProces.IsBackground = true;
            goHomeProcesss = new Thread(() => GoHomeAction.ActionStart());
            goHomeProcesss.IsBackground = true;
            stopProcess = new Thread(() => StopAction.StopStart());
            quickStopProcess = new Thread(() => StopAction.QuickStopStart());
            beltControl = new Thread(() => BeltControl.CardStartAction());
            beltControl.IsBackground = true;
            buttonProcess=new Thread(() => ButtonSerachThread.StartAction());
            buttonProcess.IsBackground = true;
            buttonReset = new Thread(() => ResetAction.StartAction());
            buttonReset.IsBackground = true;
            startProcess = new Thread(() => StartThread.ActionStart());
            startProcess.IsBackground = true;
            giveProductProcess = new Thread(() => GiveProductAction.ActionStart());
            giveProductProcess.IsBackground = true;
            comeCarryProcess = new Thread(() => ComeCarryAction.ActionStart());
            comeCarryProcess.IsBackground = true;
           
            frontCheckProcess = new Thread(() => FrontCheckAction.ActionStart());
            frontCheckProcess.IsBackground = true;
            behindCheckProcess = new Thread(() => BehindCheckAction.ActionStart());
            behindCheckProcess.IsBackground = true;
           
            outCarryProcess = new Thread(() => OutCarryAction.ActionStart());
            outCarryProcess.IsBackground = true;
            throwProductProcess = new Thread(() => ThrowProductAction.ActionStart());
            throwProductProcess.IsBackground = true;
        }

        /// <summary>
        /// 生成并开始指定线程
        /// </summary>
        /// <param name="choose">选择线程</param>
        public void ReInitThread(int choose)
        {
            switch (choose)
            {
                case 1:
                    if (!checkEMode.IsAlive)
                    {
                        checkEMode = new Thread(() => CheckEmode());
                        checkEMode.IsBackground = true;
                        checkEMode.Start();
                    }
                    break;
                case 2:
                    if (!initProces.IsAlive)
                    {

                        initProces = new Thread(() => InitSystem.StartInit());
                        initProces.IsBackground = true;
                        initProces.Start();
                    }
                    break;
                case 3:
                    if (!goHomeProcesss.IsAlive)
                    {
                        goHomeProcesss = new Thread(() => GoHomeAction.ActionStart());
                        goHomeProcesss.IsBackground = true;
                        goHomeProcesss.Start();
                    }
                    break;
                case 4:
                    if (!buttonProcess.IsAlive)
                    {
                        buttonProcess = new Thread(() => ButtonSerachThread.StartAction());
                        buttonProcess.IsBackground = true;
                        buttonProcess.Start();
                    }
                    break;
                case 5:
                    if (!startProcess.IsAlive)
                    {
                        startProcess = new Thread(() => StartThread.ActionStart());
                        startProcess.IsBackground = true;
                        startProcess.Start();
                    }
                    break;
                case 6:
                    if (!giveProductProcess.IsAlive)
                    {
                        giveProductProcess = new Thread(() => GiveProductAction.ActionStart());
                        giveProductProcess.IsBackground = true;
                        giveProductProcess.Start();
                    }
                    
                    break;
                case 7:
                    if (!comeCarryProcess.IsAlive)
                    {
                        comeCarryProcess = new Thread(() => ComeCarryAction.ActionStart());
                        comeCarryProcess.IsBackground = true;
                        comeCarryProcess.Start();
                    }

                    break;
                case 8:
                    

                    break;
                case 9:
                    if (!frontCheckProcess.IsAlive)
                    {
                        frontCheckProcess = new Thread(() => FrontCheckAction.ActionStart());
                        frontCheckProcess.IsBackground = true;
                        frontCheckProcess.Start();
                    }
                    break;
                case 10:
                    if (!stopProcess.IsAlive)
                    {
                        stopProcess = new Thread(() => StopAction.StopStart());
                        stopProcess.Start();
                    }
                    break;
                case 11:
                    if (!behindCheckProcess.IsAlive)
                    {
                        behindCheckProcess = new Thread(() => BehindCheckAction.ActionStart());
                        behindCheckProcess.IsBackground = true;
                        behindCheckProcess.Start();
                    }

                    break;
                case 12:
                    if(!beltControl.IsAlive)
                    {
                        beltControl = new Thread(() => BeltControl.CardStartAction());
                        beltControl.IsBackground = true;
                        beltControl.Start();
                    }
                    break;
                case 13:
                    

                    break;
                case 14:
                   if (!outCarryProcess.IsAlive)
                    {
                        outCarryProcess = new Thread(() => OutCarryAction.ActionStart());
                        outCarryProcess.IsBackground = true;
                        outCarryProcess.Start();
                    }
                    break;
                case 15:
                    if (!quickStopProcess.IsAlive)
                    {
                        quickStopProcess = new Thread(() => StopAction.QuickStopStart());
                        quickStopProcess.Start();
                    }
                    break;
                case 16:
                    if(!buttonReset.IsAlive)
                    {
                        buttonReset = new Thread(() => ResetAction.StartAction());
                        buttonReset.IsBackground = true;
                        buttonReset.Start();
                    }
                   
                    break;
                case 17:
                    if (!throwProductProcess.IsAlive)
                    {
                        throwProductProcess = new Thread(() => ThrowProductAction.ActionStart());
                        throwProductProcess.IsBackground = true;
                        throwProductProcess.Start();
                    }

                    break;
                default: break;

            }
        }


        /// <summary>
        /// 停止重要线程
        /// </summary>
        public void AbortAllThreadWithoutEMIn()
        {
            if (goHomeProcesss.IsAlive)
            {
                if ((goHomeProcesss.ThreadState & ThreadState.Suspended) != 0)
                    goHomeProcesss.Resume();
                goHomeProcesss.Abort();
            }

            if (beltControl.IsAlive)
            {
                if ((beltControl.ThreadState & ThreadState.Suspended) != 0)
                    beltControl.Resume();
                beltControl.Abort();
            }

            if(buttonReset.IsAlive)
            {
                if ((buttonReset.ThreadState & ThreadState.Suspended) != 0)
                    buttonReset.Resume();
                buttonReset.Abort();
            }

            if (startProcess.IsAlive)
            {
                if ((startProcess.ThreadState & ThreadState.Suspended) != 0)
                    startProcess.Resume();
                startProcess.Abort();
            }

            if (giveProductProcess.IsAlive)
            {
                if ((giveProductProcess.ThreadState & ThreadState.Suspended) != 0)
                    giveProductProcess.Resume();
                giveProductProcess.Abort();
            }
            if (comeCarryProcess.IsAlive)
            {
                if ((comeCarryProcess.ThreadState & ThreadState.Suspended) != 0)
                    comeCarryProcess.Resume();
                comeCarryProcess.Abort();
            }
            
            if (frontCheckProcess.IsAlive)
            {
                if ((frontCheckProcess.ThreadState & ThreadState.Suspended) != 0)
                    frontCheckProcess.Resume();
                frontCheckProcess.Abort();
            }
            if (behindCheckProcess.IsAlive)
            {
                if ((behindCheckProcess.ThreadState & ThreadState.Suspended) != 0)
                    behindCheckProcess.Resume();
                behindCheckProcess.Abort();
            }
           
            if (outCarryProcess.IsAlive)
            {
                if ((outCarryProcess.ThreadState & ThreadState.Suspended) != 0)
                    outCarryProcess.Resume();
                outCarryProcess.Abort();
            }
            if (throwProductProcess.IsAlive)
            {
                if ((throwProductProcess.ThreadState & ThreadState.Suspended) != 0)
                    throwProductProcess.Resume();
                throwProductProcess.Abort();
            }
        }

        /// <summary>
        /// 暂停重要线程
        /// </summary>
        public void PauseAllThreadWithoutEMIn()
        {

            if (goHomeProcesss.IsAlive)
                goHomeProcesss.Suspend();
            if (beltControl.IsAlive)
                beltControl.Suspend();
            if (buttonReset.IsAlive)
                buttonReset.Suspend();
            if (giveProductProcess.IsAlive)
                giveProductProcess.Suspend();
            if (comeCarryProcess.IsAlive)
                comeCarryProcess.Suspend();
           
            if (frontCheckProcess.IsAlive)
                frontCheckProcess.Suspend();
            if (behindCheckProcess.IsAlive)
                behindCheckProcess.Suspend();
           
            if (outCarryProcess.IsAlive)
                outCarryProcess.Suspend();
            if (throwProductProcess.IsAlive)
                throwProductProcess.Suspend();
            

        }

        /// <summary>
        /// 继续重要线程
        /// </summary>
        public void ContiuneAllThreadWithoutEMIn()
        {

            if (goHomeProcesss.IsAlive)
            {
                if ((goHomeProcesss.ThreadState & ThreadState.Suspended) != 0)
                    goHomeProcesss.Resume();
            }

            if (beltControl.IsAlive)
            {
                if ((beltControl.ThreadState & ThreadState.Suspended) != 0)
                    beltControl.Resume();
            }

            if(buttonReset.IsAlive)
            {
                if ((buttonReset.ThreadState & ThreadState.Suspended) != 0)
                    buttonReset.Resume();
            }

            if (giveProductProcess.IsAlive)
            {
                if ((giveProductProcess.ThreadState & ThreadState.Suspended) != 0)
                    giveProductProcess.Resume();
            }
            if (comeCarryProcess.IsAlive)
            {
                if ((comeCarryProcess.ThreadState & ThreadState.Suspended) != 0)
                    comeCarryProcess.Resume();
            }
            
            if (frontCheckProcess.IsAlive)
            {
                if ((frontCheckProcess.ThreadState & ThreadState.Suspended) != 0)
                    frontCheckProcess.Resume();
            }
            if (behindCheckProcess.IsAlive)
            {
                if ((behindCheckProcess.ThreadState & ThreadState.Suspended) != 0)
                    behindCheckProcess.Resume();
            }
           
            if (outCarryProcess.IsAlive)
            {
                if ((outCarryProcess.ThreadState & ThreadState.Suspended) != 0)
                    outCarryProcess.Resume();
            }
            if (throwProductProcess.IsAlive)
            {
                if ((throwProductProcess.ThreadState & ThreadState.Suspended) != 0)
                    throwProductProcess.Resume();
            }
              
        }
        /// <summary>
        /// 停止所有进程
        /// </summary>
        public  void AbortAllThread()
        {

            if (goHomeProcesss.IsAlive)
            {
                if ((goHomeProcesss.ThreadState & ThreadState.Suspended) != 0)
                    goHomeProcesss.Resume();
                goHomeProcesss.Abort();
            }

            if (beltControl.IsAlive)
            {
                if ((beltControl.ThreadState & ThreadState.Suspended) != 0)
                    beltControl.Resume();
                beltControl.Abort();
            }

            if (initProces.IsAlive)
            {
                if ((initProces.ThreadState & ThreadState.Suspended) != 0)
                    initProces.Resume();
                initProces.Abort();
            }

            if (checkEMode.IsAlive)
            {
                if ((checkEMode.ThreadState & ThreadState.Suspended) != 0)
                    checkEMode.Resume();
                checkEMode.Abort();
            }

            if (stopProcess.IsAlive)
            {
                if ((stopProcess.ThreadState & ThreadState.Suspended) != 0)
                    stopProcess.Resume();
                stopProcess.Abort();
            }

            if (quickStopProcess.IsAlive)
            {
                if ((quickStopProcess.ThreadState & ThreadState.Suspended) != 0)
                    quickStopProcess.Resume();
                quickStopProcess.Abort();
            }

            if (buttonProcess.IsAlive)
            {
                if ((buttonProcess.ThreadState & ThreadState.Suspended) != 0)
                    buttonProcess.Resume();
                buttonProcess.Abort();
            }

            if (buttonReset.IsAlive)
            {
                if ((buttonReset.ThreadState & ThreadState.Suspended) != 0)
                    buttonReset.Resume();
                buttonReset.Abort();
            }

            if (startProcess.IsAlive)
            {
                if ((startProcess.ThreadState & ThreadState.Suspended) != 0)
                    startProcess.Resume();
                startProcess.Abort();
            }

            if (giveProductProcess.IsAlive)
            {
                if ((giveProductProcess.ThreadState & ThreadState.Suspended) != 0)
                    giveProductProcess.Resume();
                giveProductProcess.Abort();
            }

            if (comeCarryProcess.IsAlive)
            {
                if ((comeCarryProcess.ThreadState & ThreadState.Suspended) != 0)
                    comeCarryProcess.Resume();
                comeCarryProcess.Abort();
            }
           
            if (frontCheckProcess.IsAlive)
            {
                if ((frontCheckProcess.ThreadState & ThreadState.Suspended) != 0)
                    frontCheckProcess.Resume();
                frontCheckProcess.Abort();
            }
            if (behindCheckProcess.IsAlive)
            {
                if ((behindCheckProcess.ThreadState & ThreadState.Suspended) != 0)
                    behindCheckProcess.Resume();
                behindCheckProcess.Abort();
            }
           
            if (outCarryProcess.IsAlive)
            {
                if ((outCarryProcess.ThreadState & ThreadState.Suspended) != 0)
                    outCarryProcess.Resume();
                outCarryProcess.Abort();
            }
            if (throwProductProcess.IsAlive)
            {
                if ((throwProductProcess.ThreadState & ThreadState.Suspended) != 0)
                    throwProductProcess.Resume();
                throwProductProcess.Abort();
            }
           
           
        }




        /// <summary>
        /// 急停检测
        /// </summary>
        private void CheckEmode()
        {
            try
            {
                if (!CheckSignal.WaitSomeTime(() => CommonData.signal_SysInitOK, CommonData.delay_EModeTime))
                {
                    sysEvent.showRealInfo("初始化失败，急停线程不开启", CommonData.warnMess);
                    return;
                }

                sysEvent.showRealInfo("初始化成功，急停线程开启", CommonData.infoMess);


                short result, result2, result3, result4;
                while (true)
                {
                    result = IOMonitor.ReadOneInBit(CommonData.in_Scram);
                    result3 = IOMonitor.ReadOneInBit(CommonData.in_Raster);
                    result4 = IOMonitor.ReadOneInBit(CommonData.in_Raster2);
                    if (result == 1)
                    {
                        AbortAllThreadWithoutEMIn();
                        sysEvent.setButtonEnable(false, false, false, false, false, false, false, false, false, false, false);

                        //关使能
                        for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
                        {
                            if (axisno >= 8)
                                break;
                            CardControl.AxisSet(axisno, 1);
                        }
                        IOMonitor.SetOneOutBit(CommonData.out_ComeMoveEnable, 1);
                        IOMonitor.SetOneOutBit(CommonData.out_LeaveMoveEnable, 1);

                        //关闭必要IO
                        CardControl.CloseImpIO();
                        IOMonitor.SetOneOutBit(CommonData.out_UpNeedleStop, 1);
                        IOMonitor.SetOneOutBit(CommonData.out_DownNeedleStop, 1);


                        while (IOMonitor.ReadOneInBit(CommonData.in_Scram)==1)
                        {
                            MessageBox.Show("急停已经按下，请取消急停键重新开始", "错误");
                            CheckSignal.CommonDelay(1);
                        }
                        sysEvent.showRealInfo("急停已经按下，请按停止键重新开始！", CommonData.warnMess);
                        sysEvent.refreshCurState("急停", Color.Red);

                        sysEvent.setButtonEnable(false, false, true, false, false, false, false, false, false, false, false);

                    }
                    if (CommonData.signal_SafeEnable)
                    {
                        if(CommonData.signal_IsStartNow)
                        {
                            if (result3 == 1)
                            {
                                sysEvent.ButtonPause();
                                MessageBox.Show("碰到光栅，请远离后按确认键");
                                sysEvent.ButtonContiune();
                            }
                            if (result4 == 1)
                            {
                                sysEvent.ButtonPause();
                                MessageBox.Show("碰到光栅，请远离后按确认键");
                                sysEvent.ButtonContiune();
                            }




                        }
                       
                    }
                    Thread.Sleep(5);
                }
            }
            catch(Exception ex)
            {
                sysEvent.setButtonEnable(false, false, false, false, false, false, false, false, false, false, false);
                sysEvent.showRealInfo("错误0xCA021,急停线程异常，请远离机器，关闭电源，重启电脑\r"+ex.Message, CommonData.warnMess);
            }
  
        }



    }
}