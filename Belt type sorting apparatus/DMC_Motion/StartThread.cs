using SXHikCam;
using SXOptCam;
using SXTisCam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class StartThread
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        static ThreadControl threadControls = ThreadControl.GetThreadControl();
        public static void ActionStart()
        {
            try
            {
                sysEvent.setButtonEnable(false, false, true, false, true, false, false, false, true, false, false);

                //开启真空泵
                IOMonitor.SetOneOutBit(CommonData.out_VacuumPower, 0);
                //IOMonitor.SetOneOutBit(CommonData.out_BehindPlatformClipTight, 1);
                //IOMonitor.SetOneOutBit(CommonData.out_FrontPlatformClipTight, 1);
                //IOMonitor.SetOneOutBit(CommonData.out_BehindPlatformExtendTight, 1);
                //IOMonitor.SetOneOutBit(CommonData.out_FrontPlatformExtendTight, 1);
                //初始化板卡参数
                for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
                {
                    CardControl.SetAutoProfile(axisno);
                }

                CommonData.CameraUp.PostFrameEvent += new TisCamera.PostFrameEventHandler(ImageProcess.StartActionA);
                //CommonData.CameraDown.PostFrameEvent += new TisCamera.PostFrameEventHandler(ImageProcess.StartActionA);

                FlagControl.Show1();
                FlagControl.Show2();
                FlagControl.Show3();
                FlagControl.Show4();
                FlagControl.Show5();
                FlagControl.Show6();
                WriteInfo.OpenAllStream();
                //开各线程
                threadControls.ReInitThread(6);    //上料平台
                threadControls.ReInitThread(7);    //抓料

                threadControls.ReInitThread(9);    //前检测
                threadControls.ReInitThread(11);    //后检测
                threadControls.ReInitThread(14);    //出料
                threadControls.ReInitThread(17);    //出料平台

                CommonData.signal_IsStartNow = true;
            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo("错误0xCA019,程序运行失败\r" + ex.Message, CommonData.warnMess);
                StopAction.QuickErrStop();
            }
        }
    }
}
