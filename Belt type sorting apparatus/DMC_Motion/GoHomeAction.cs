using Belt_type_sorting_apparatus.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    class GoHomeAction
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();

        public static void ActionStart()
        {
            try
            {
                sysEvent.showRealInfo("系统正在回原点！", CommonData.infoMess);
                
                //状态刷新，按钮保护
                sysEvent.setButtonEnable(false, false, true, false, true, false, false, false, false, false, false);

                //关闭输出IO
                CardControl.CloseImpIO();

                //伺服使能
                for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
                {
                    if (axisno >= 8)
                        break;
                    CardControl.AxisSet(axisno, 0);
                }
                IOMonitor.SetOneOutBit(CommonData.out_ComeMoveEnable, 0);
                IOMonitor.SetOneOutBit(CommonData.out_LeaveMoveEnable, 0);

                CheckSignal.CommonDelay(500);

                //伺服报警清除
                for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
                {
                    if (axisno >= 8)
                        break;
                    CardControl.AxisALLErc(axisno);
                }

                IOMonitor.SetOneOutBit(CommonData.out_ComeAndLeaveServoReset, 0);
                IOMonitor.SetOneOutBit(CommonData.out_ServoErrorReset, 0);
                CheckSignal.CommonDelay(300);
                IOMonitor.SetOneOutBit(CommonData.out_ComeAndLeaveServoReset, 1);
                IOMonitor.SetOneOutBit(CommonData.out_ServoErrorReset, 1);

                //检测伺服报警
                for (ushort axisNo = 0; axisNo < CommonData.axisNum; axisNo++)
                {
                    if (axisNo >= 8)
                        break;
                    if (CardControl.CheckAxisALM(axisNo))
                    {
                        throw new Exception("错误0xCA010, 轴【" + axisNo + "】伺服器报警,请检查伺服电机");
                    }
                }
                if (IOMonitor.ReadOneInBit(CommonData.in_ComeAxisAlarm) == 1)
                {
                    throw new Exception("进料轴伺服报警！请检查伺服！");
                }
                if (IOMonitor.ReadOneInBit(CommonData.in_LeaveAxisAlarm) == 1)
                {
                    throw new Exception("出料轴伺服报警！请检查伺服！");
                }
                
                ////////////////////////////////////////////////////////检测信号//////////////////////////////
                //进料搬运上位检测
                if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_ComeCylinderUpTense) == 0), CommonData.saveData.delay_CommonTime))
                {
                    throw new Exception("进料搬运不在上位，请检查气缸！");
                }
                //后载台下位检测
                if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_LeaveCylinderUpTense) == 0), CommonData.saveData.delay_CommonTime))
                {
                    throw new Exception("出料搬运不在上位，请检查气缸！");
                }
                //前载台下位检测
                if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_FrontReceiveDownTense) == 0), CommonData.saveData.delay_CommonTime))
                {
                    throw new Exception("前载台不在下位，请检查气缸！");
                }
                //后载台下位检测
                if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_BehindReceiveDownTense) == 0), CommonData.saveData.delay_CommonTime))
                {
                    throw new Exception("后载台不在下位，请检查气缸！");
                }
                ////下探高下位检测
                //if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_DownNeedleCylinderDownTense) == 0), CommonData.saveData.delay_CommonTime))
                //{
                //    throw new Exception("下探高气缸不在下位，请检查气缸！");
                //}
                ////上探高上位检测
                //if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_UpNeedleCylinderUpTense) == 0), CommonData.saveData.delay_CommonTime))
                //{
                //    throw new Exception("上探高气缸不在上位，请检查气缸！");
                //}

                //打开刹车
                IOMonitor.SetOneOutBit(CommonData.out_UpNeedleStop, 0);
                IOMonitor.SetOneOutBit(CommonData.out_DownNeedleStop, 0);

                //关闭对射减速停止
                CardControl.AxisSetDstp(CommonData.axisProductCome_RiseAndDown, 0, 1);
                CardControl.AxisSetDstp(CommonData.axisProductOut_RiseAndDown, 0, 1);
                //各轴回原点                               
                ImportantAsxisHome.GoHomeAction();

                CommonData.signal_HomeStateNow = true;
                sysEvent.showRealInfo("回原点成功！", CommonData.infoMess);
                sysEvent.setButtonEnable(false, true, true, false, false, true, true, true, true, true, true);
            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo("错误0xCA017,回原点失败\r"+ex.Message, CommonData.warnMess);
                CommonData.signal_HomeStateNow = false;
                StopAction.ErrStop();
            }
        }

    }
}
