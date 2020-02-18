using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class ResetAction
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        public static void  StartAction()
        {
            try
            {
                sysEvent.setButtonEnable(false, false, false, false, false, false, false, false, false, false, false);

                //关闭输出IO
                CardControl.CloseImpIO();

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

                ////////////////////////////////////////////////////////检测信号///////////////////////////////////////////
                //进料搬运上位检测
                if (!CheckSignal.WaitSomeTime(() => (IOMonitor.ReadOneInBit(CommonData.in_ComeCylinderUpTense) == 0), CommonData.saveData.delay_CommonTime))
                {
                    throw new Exception("进料搬运不在上位，请检查气缸！");
                }
                //出料搬运上位检测
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

                CardControl.AxisSetDstp(CommonData.axisProductCome_RiseAndDown, 0, 1);
                CardControl.AxisSetDstp(CommonData.axisProductOut_RiseAndDown, 0, 1);

                CardControl.AxissMoveAndCheck(new ushort[]{ CommonData.axisUpDepth_RiseAndDown,CommonData.axisDownDepth_RiseAndDown},new int[] { 0, 0 }, new ushort[] { 1, 1 });
                CardControl.AxissMoveAndCheck(new ushort[]{ CommonData.axisProductReceive_Front,CommonData.axisProductReceive_Behind,CommonData.axisCameraUp,CommonData.axisCameraDown,
                        CommonData.axisUpDepth_CheckMove,CommonData.axisDownDepth_CheckMove,CommonData.axisProductCome_CarryMove,CommonData.axisProductOut_CarryMove,CommonData.axisProductCome_RiseAndDown,CommonData.axisProductOut_RiseAndDown}, 
                        new int[] {0,0,0,0,0,0,0,0,0,0 }, new ushort[] {1,1,1,1,1,1,1,1,1,1});
                
                sysEvent.setButtonEnable(false, true, true, false, false, true, true, true, true, true, true);
                CommonData.signal_CanReset = false;
            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo("错误0xCA030,复位失败，请停止回原点重试\r" + ex.Message, CommonData.warnMess);
                StopAction.ErrStop();
            }
            
        }
    }
}
