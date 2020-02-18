using Belt_type_sorting_apparatus.CommonClass;
using SXHikCam;
using SXOptCam;
using SXTisCam;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus
{
    class StopAction
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        static ThreadControl threadControls = ThreadControl.GetThreadControl();

        public static void StopStart()
        {
            try
            {

                threadControls.AbortAllThreadWithoutEMIn();
                sysEvent.setButtonEnable(false, false, false, false, false, false, false, false, false, false, false);
                sysEvent.refreshCurState("设备停止", Color.Red);

                CommonData.CameraUp.PostFrameEvent -= new TisCamera.PostFrameEventHandler(ImageProcess.StartActionA);
                CommonData.CameraDown.PostFrameEvent -= new TisCamera.PostFrameEventHandler(ImageProcess.StartActionA);

                //轴停止
                for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
                {
                    CardControl.StopOneAxis(axisno,CommonData.saveData.delay_CommonTime);
                }

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

                //复位信号           
                CommonData.signal_HomeStateNow = false;
                CommonData.signal_CameraNowPlace = 0;
                CommonData.signal_DownCameraOK = false;
                CommonData.signal_UpCameraOK = false;
                CommonData.signal_TrayCameraOK = false;
                CommonData.signal_ProDuctCameraOK = false;
                CommonData.signal_DownCameraDataOK = true;
                CommonData.signal_UpCameraDataOK = true;
                CommonData.signal_TrayCameraDataOK = true;
                CommonData.signal_SignCameraDataOK = true;
                CommonData.signal_FrontAskBeltCanNotMove = true;
                CommonData.signal_BeltCanNotMove = true;
                CommonData.delta_ProductX = 0;
                CommonData.delta_ProductY = 0;
                CommonData.delta_ProductR = 0;
                CommonData.signal_PredealDataOK = true;
                CommonData.signal_CheckFalse = false;
                CommonData.signal_CanReset = false;
                CommonData.signal_IsStartNow = false;
                CommonData.signal_ProductRiseArrived = false;
   
                CommonData.signal_PlatThrowOK = false;
                CommonData.signal_OutProductArrived = false;
                CommonData.signal_CameraDownFree = true;
                CommonData.signal_CameraUpFree = true;
                CommonData.signal_BehindCanGoCheck = false;
                CommonData.signal_FrontCanGoCheck = false;
                CommonData.signal_BehindHaveArrived = false;
                CommonData.signal_FrontHaveArrived = false;
                CommonData.signal_BehindCanComeTake = false;
                CommonData.signal_FrontCanComeTake = false;
                CommonData.signal_CrabBehindProOK = false;
                CommonData.signal_CrabFrontProOK = false;
                CommonData.signal_PlatBehindThrow = false;
                CommonData.signal_PlatFrontThrow = false;
                CommonData.signal_MoveCarryCanGoToCarry = false;
                CommonData.signal_FrontPlatPutOK = false;
                CommonData.signal_PlatFrontNeed = false;
                CommonData.signal_PlatBehindNeed = false;
                CommonData.signal_CrabProductOK = true;
                CommonData.signal_BehindPlatPutOK = false;
                CommonData.signal_CameraUpFree = true;
                CommonData.signal_PlatFrontThrowArrived = false;
                CommonData.signal_PlatBehindThrowArrived = false;
                CommonData.signal_DepthOK = false;
                CommonData.signal_DepthDataResult = false;
                CommonData.signal_DepthDataOK = true;

                CommonData.signal_curUpImageRusult = false;
                CommonData.signal_FrontCheckResult = true;
                CommonData.signal_BehindCheckResult = true;

                CommonData.signal_BehindReCheckOK = true;
                CommonData.signal_FrontReCheckOK = true;
                CommonData.upfrontorbehind = 0;
                CommonData.downfrontorbehind = 0;
                CommonData.curBehindPosition = 0;
                CommonData.curFrontPosition = 0;
                CommonData.depthfrontorbehind = 0;
                CommonData.signal_DepthFree = true;
                WriteInfo.CloseAllStream();
                //打开红灯
                CardControl.TurnTheLight(Color.Red, true);
                sysEvent.showRealInfo("设备停止，请按复位回原点！", CommonData.warnMess);
                sysEvent.setButtonEnable(true, false, false, false, false, true, true, true, true, true, true);
            }
            catch(Exception ex)
            {
                sysEvent.showRealInfo("错误0xCA020,停止线程异常\r" + ex.Message, CommonData.warnMess);
                sysEvent.setButtonEnable(false, false, true, false, false, false, false, false, false, false, false);
            }
           
        }

        public static void QuickStopStart()
        {
            try
            {
                threadControls.AbortAllThreadWithoutEMIn();
                sysEvent.setButtonEnable(false, false, false, false, false, false, false, false, false, false, false);
                sysEvent.refreshCurState("设备停止", Color.Red);

                CommonData.CameraUp.PostFrameEvent -= new TisCamera.PostFrameEventHandler(ImageProcess.StartActionA);
                CommonData.CameraDown.PostFrameEvent -= new TisCamera.PostFrameEventHandler(ImageProcess.StartActionA);

                //轴停止
                for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
                {
                    CardControl.StopOneAxis(axisno,CommonData.saveData.delay_CommonTime);
                }

                //关闭必要IO
                CardControl.CloseImpIO();
                 
                //复位信号        
                CommonData.signal_CameraNowPlace = 0;
                CommonData.signal_DownCameraOK = false;
                CommonData.signal_UpCameraOK = false;
                CommonData.signal_TrayCameraOK = false;
                CommonData.signal_ProDuctCameraOK = false;
                CommonData.signal_DownCameraDataOK = true;
                CommonData.signal_UpCameraDataOK = true;
                CommonData.signal_TrayCameraDataOK = true;
                CommonData.signal_SignCameraDataOK = true;
     
                CommonData.signal_FrontAskBeltCanNotMove = true;
                CommonData.signal_BeltCanNotMove = true;
                CommonData.delta_ProductX = 0;
                CommonData.delta_ProductY = 0;
                CommonData.delta_ProductR = 0;
                CommonData.signal_PredealDataOK = true;
                CommonData.signal_CheckFalse = false;
                CommonData.signal_IsStartNow = false;
                CommonData.signal_ProductRiseArrived = false;

                CommonData.signal_PlatThrowOK = false;
                CommonData.signal_OutProductArrived = false;
                CommonData.signal_CameraDownFree = true;
                CommonData.signal_CameraUpFree = true;
                CommonData.signal_BehindCanGoCheck = false;
                CommonData.signal_FrontCanGoCheck = false;
                CommonData.signal_BehindHaveArrived = false;
                CommonData.signal_FrontHaveArrived = false;
                CommonData.signal_BehindCanComeTake = false;
                CommonData.signal_FrontCanComeTake = false;
                CommonData.signal_CrabBehindProOK = false;
                CommonData.signal_CrabFrontProOK = false;
                CommonData.signal_PlatBehindThrow = false;
                CommonData.signal_PlatFrontThrow = false;
                CommonData.signal_MoveCarryCanGoToCarry = false;
                CommonData.signal_FrontPlatPutOK = false;
                CommonData.signal_PlatFrontNeed = false;
                CommonData.signal_CrabProductOK = true;
                CommonData.signal_PlatBehindNeed = false;
                CommonData.signal_BehindPlatPutOK = false;
                CommonData.signal_CameraUpFree = true;
                CommonData.signal_PlatFrontThrowArrived = false;
                CommonData.signal_PlatBehindThrowArrived = false;
                CommonData.signal_DepthOK = false;
                CommonData.signal_DepthDataResult = false;
                CommonData.signal_DepthDataOK = true;

                CommonData.signal_curUpImageRusult = false;
                CommonData.signal_FrontCheckResult = true;
                CommonData.signal_BehindCheckResult = true;
                CommonData.signal_BehindReCheckOK = true;
                CommonData.signal_FrontReCheckOK = true;
                CommonData.upfrontorbehind = 0;
                CommonData.downfrontorbehind = 0;
                CommonData.curBehindPosition = 0;
                CommonData.curFrontPosition = 0;
                CommonData.depthfrontorbehind = 0;
                CommonData.signal_DepthFree = true;
                WriteInfo.CloseAllStream();
                //打开红灯
                CardControl.TurnTheLight(Color.Red, true);
                CommonData.signal_CanReset = true;
                sysEvent.showRealInfo("设备停止，可按复位快速回零！", CommonData.warnMess);
                sysEvent.setButtonEnable(true, false, false, false, false, true, true, true, true, true, true);
                
            }
            catch (Exception ex)
            {   
                sysEvent.showRealInfo("错误0xCA025,快速停止线程异常\r" + ex.Message, CommonData.warnMess);
                sysEvent.setButtonEnable(false, false, true, false, false, false, false, false, false, false, false);
            }
        }

        public static void ErrStop()
        {
            object obj = new object();

            lock (obj)
            {
                if (!ThreadControl.stopProcess.IsAlive)
                {
                    if (ThreadControl.quickStopProcess.IsAlive)
                    {
                        CheckSignal.WaitForALLTime(() => (ThreadControl.quickStopProcess.IsAlive == false));
                    }
                    threadControls.ReInitThread(10);
                }

            }
        }

        public static void QuickErrStop()
        {
            object obj = new object();

            lock (obj)
            {
                if (!ThreadControl.quickStopProcess.IsAlive)
                {
                    if(!ThreadControl.stopProcess.IsAlive)
                        threadControls.ReInitThread(15);
                }
            }
        }

    }
}
