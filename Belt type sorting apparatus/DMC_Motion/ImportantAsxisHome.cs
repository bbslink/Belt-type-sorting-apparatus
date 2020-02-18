using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class ImportantAsxisHome
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();

        public static void GoHomeAction()
        {
            try
            {
                //轴停止
                for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
                {
                    CardControl.StopOneAxis(axisno,CommonData.saveData.delay_CommonTime);
                }

                //探高上下
                CardControl.AxisGoHome(CommonData.axisUpDepth_RiseAndDown);
                CardControl.AxisGoHome(CommonData.axisDownDepth_RiseAndDown);
                CardControl.AxisGoHome(CommonData.axisProductCome_RiseAndDown);
                CardControl.AxisGoHome(CommonData.axisProductOut_RiseAndDown);
                //固定延时
                CheckSignal.CommonDelay(200);

                if (!CardControl.CheckOneAxisIsHome(CommonData.axisUpDepth_RiseAndDown, CommonData.saveData.delay_CommonTime))
                {
                    //再次回零检测
                    CardControl.AxisGoHome(CommonData.axisUpDepth_RiseAndDown);
                    CheckSignal.CommonDelay(500);
                    if (!CardControl.CheckOneAxisIsHome(CommonData.axisUpDepth_RiseAndDown, CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("上探高升降轴回原点到位检测失败！硬件故障！");
                    }
                }

                if (!CardControl.CheckOneAxisIsHome(CommonData.axisDownDepth_RiseAndDown, CommonData.saveData.delay_CommonTime))
                {
                    //再次回零检测
                    CardControl.AxisGoHome(CommonData.axisDownDepth_RiseAndDown);
                    CheckSignal.CommonDelay(500);
                    if (!CardControl.CheckOneAxisIsHome(CommonData.axisDownDepth_RiseAndDown, CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("上探高升降轴回原点到位检测失败！硬件故障！");
                    }
                }

                //其余轴回零
                CardControl.AxisGoHome(CommonData.axisProductReceive_Front);
                CardControl.AxisGoHome(CommonData.axisProductReceive_Behind);
                CardControl.AxisGoHome(CommonData.axisCameraUp);
                CardControl.AxisGoHome(CommonData.axisCameraDown);
                CardControl.AxisGoHome(CommonData.axisUpDepth_CheckMove);
                CardControl.AxisGoHome(CommonData.axisDownDepth_CheckMove);
                CardControl.AxisGoHome(CommonData.axisProductCome_CarryMove);
                CardControl.AxisGoHome(CommonData.axisProductOut_CarryMove);
                //CardControl.AxisGoHome(CommonData.axisProductCome_RiseAndDown);
                //CardControl.AxisGoHome(CommonData.axisProductOut_RiseAndDown);

                //固定延时
                CheckSignal.CommonDelay(200);

                //轴检测原点到位异常
                if (!CardControl.CheckOneAxisIsHome(CommonData.axisProductReceive_Front, CommonData.saveData.delay_CommonTime))
                {
                    //再次回零检测
                    CardControl.AxisGoHome(CommonData.axisProductReceive_Front);
                    CheckSignal.CommonDelay(500);
                    if (!CardControl.CheckOneAxisIsHome(CommonData.axisProductReceive_Front, CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("前载具平台轴回原点到位检测失败！硬件故障！");
                    }
                }  

                if (!CardControl.CheckOneAxisIsHome(CommonData.axisProductReceive_Behind, CommonData.saveData.delay_CommonTime))
                {
                    //再次回零检测
                    CardControl.AxisGoHome(CommonData.axisProductReceive_Behind);
                    CheckSignal.CommonDelay(500);
                    if (!CardControl.CheckOneAxisIsHome(CommonData.axisProductReceive_Behind, CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("前载具平台轴回原点到位检测失败！硬件故障！");
                    }
                }

                if (!CardControl.CheckOneAxisIsHome(CommonData.axisCameraUp, CommonData.saveData.delay_CommonTime))
                {
                    //再次回零检测
                    CardControl.AxisGoHome(CommonData.axisCameraUp);
                    CheckSignal.CommonDelay(500);
                    if (!CardControl.CheckOneAxisIsHome(CommonData.axisCameraUp, CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("上相机检测轴回原点到位检测失败！硬件故障！");
                    }
                }

                if (!CardControl.CheckOneAxisIsHome(CommonData.axisCameraDown, CommonData.saveData.delay_CommonTime))
                {
                    //再次回零检测
                    CardControl.AxisGoHome(CommonData.axisCameraDown);
                    CheckSignal.CommonDelay(500);
                    if (!CardControl.CheckOneAxisIsHome(CommonData.axisCameraDown, CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("下相机检测轴回原点到位检测失败！硬件故障！");
                    }
                }

                if (!CardControl.CheckOneAxisIsHome(CommonData.axisUpDepth_CheckMove, CommonData.saveData.delay_CommonTime))
                {
                    //再次回零检测
                    CardControl.AxisGoHome(CommonData.axisUpDepth_CheckMove);
                    CheckSignal.CommonDelay(500);
                    if (!CardControl.CheckOneAxisIsHome(CommonData.axisUpDepth_CheckMove, CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("上探高平移轴回原点到位检测失败！硬件故障！");
                    }
                }

                if (!CardControl.CheckOneAxisIsHome(CommonData.axisDownDepth_CheckMove, CommonData.saveData.delay_CommonTime))
                {
                    //再次回零检测
                    CardControl.AxisGoHome(CommonData.axisDownDepth_CheckMove);
                    CheckSignal.CommonDelay(500);
                    if (!CardControl.CheckOneAxisIsHome(CommonData.axisDownDepth_CheckMove, CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("下探高平移轴回原点到位检测失败！硬件故障！");
                    }
                }

                if (!CardControl.CheckOneAxisIsHome(CommonData.axisProductCome_CarryMove, CommonData.saveData.delay_CommonTime))
                {
                    //再次回零检测
                    CardControl.AxisGoHome(CommonData.axisProductCome_CarryMove);
                    CheckSignal.CommonDelay(500);
                    if (!CardControl.CheckOneAxisIsHome(CommonData.axisProductCome_CarryMove, CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("进料平移轴回原点到位检测失败！硬件故障！");
                    }
                }

                if (!CardControl.CheckOneAxisIsHome(CommonData.axisProductOut_CarryMove, CommonData.saveData.delay_CommonTime))
                {
                    //再次回零检测
                    CardControl.AxisGoHome(CommonData.axisProductOut_CarryMove);
                    CheckSignal.CommonDelay(500);
                    if (!CardControl.CheckOneAxisIsHome(CommonData.axisProductOut_CarryMove, CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("出料平移轴回原点到位检测失败！硬件故障！");
                    }
                }

                if (!CardControl.CheckOneAxisIsHome(CommonData.axisProductCome_RiseAndDown, CommonData.saveData.delay_CommonTime))
                {
                    //再次回零检测
                    CardControl.AxisGoHome(CommonData.axisProductCome_RiseAndDown);
                    CheckSignal.CommonDelay(500);
                    if (!CardControl.CheckOneAxisIsHome(CommonData.axisProductCome_RiseAndDown, CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("进料台升降轴回原点到位检测失败！硬件故障！");
                    }
                }

                if (!CardControl.CheckOneAxisIsHome(CommonData.axisProductOut_RiseAndDown, CommonData.saveData.delay_CommonTime))
                {
                    //再次回零检测
                    CardControl.AxisGoHome(CommonData.axisProductOut_RiseAndDown);
                    CheckSignal.CommonDelay(500);
                    if (!CardControl.CheckOneAxisIsHome(CommonData.axisProductOut_RiseAndDown, CommonData.saveData.delay_CommonTime))
                    {
                        throw new Exception("出料台升降轴回原点到位检测失败！硬件故障！");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误0xCA026,各轴回原点异常\r"+ex.Message);               
            }
        }


    }
}
