using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus.CommonClass
{
    [Serializable]
    class SaveData
    {
        /// <summary>
        /// 设置轴自动运行曲线
        /// </summary>
        public double startSpeedAutoAxis0 = 40000;//起始速度,默认500
        public double runSpeedAutoAxis0 = 900000;//运行速度,默认10000
        public double stopSpeedAutoAxis0 = 100;//停止速度,默认100
        public double accTimeAutoAxis0 = 0.1;//加速时间,默认0.1
        public double decTimeAutoAxis0 = 0.1;//减速时间,默认0.1

        public double startSpeedAutoAxis1 = 40000;//起始速度,默认500
        public double runSpeedAutoAxis1 = 900000;//运行速度,默认1000
        public double stopSpeedAutoAxis1 = 100;//停止速度,默认100
        public double accTimeAutoAxis1 = 0.1;//加速时间,默认0.1
        public double decTimeAutoAxis1 = 0.1;//减速时间,默认0.1

        public double startSpeedAutoAxis2 = 45000;//起始速度,默认500
        public double runSpeedAutoAxis2 = 650000;//运行速度,默认1000
        public double stopSpeedAutoAxis2 = 100;//停止速度,默认100
        public double accTimeAutoAxis2 = 0.1;//加速时间,默认0.1
        public double decTimeAutoAxis2 = 0.1;//减速时间,默认0.1

        public double startSpeedAutoAxis3 = 45000;//起始速度,默认500
        public double runSpeedAutoAxis3 = 650000;//运行速度,默认1000
        public double stopSpeedAutoAxis3 = 100;//停止速度,默认100
        public double accTimeAutoAxis3 = 0.1;//加速时间,默认0.1
        public double decTimeAutoAxis3 = 0.1;//减速时间,默认0.1

        public double startSpeedAutoAxis4 = 35000;//起始速度,默认500
        public double runSpeedAutoAxis4 = 600000;//运行速度,默认1000
        public double stopSpeedAutoAxis4 = 100;//停止速度,默认100
        public double accTimeAutoAxis4 = 0.1;//加速时间,默认0.1
        public double decTimeAutoAxis4 = 0.1;//减速时间,默认0.1

        public double startSpeedAutoAxis5 = 35000;//起始速度,默认500
        public double runSpeedAutoAxis5 = 600000;//运行速度,默认1000
        public double stopSpeedAutoAxis5 = 100;//停止速度,默认100
        public double accTimeAutoAxis5 = 0.1;//加速时间,默认0.1
        public double decTimeAutoAxis5 = 0.1;//减速时间,默认0.1

        public double startSpeedAutoAxis6 = 10000;//起始速度,默认500
        public double runSpeedAutoAxis6 = 400000;//运行速度,默认1000
        public double stopSpeedAutoAxis6 = 100;//停止速度,默认100
        public double accTimeAutoAxis6 = 0.1;//加速时间,默认0.1
        public double decTimeAutoAxis6 = 0.1;//减速时间,默认0.1

        public double startSpeedAutoAxis7 = 10000;//起始速度,默认500
        public double runSpeedAutoAxis7 = 400000;//运行速度,默认1000
        public double stopSpeedAutoAxis7 = 100;//停止速度,默认100
        public double accTimeAutoAxis7 = 0.1;//加速时间,默认0.1
        public double decTimeAutoAxis7 = 0.1;//减速时间,默认0.1

        public double startSpeedAutoAxis8 = 1000;//起始速度,默认500
        public double runSpeedAutoAxis8 = 20000;//运行速度,默认1000
        public double stopSpeedAutoAxis8 = 100;//停止速度,默认100
        public double accTimeAutoAxis8 = 0.1;//加速时间,默认0.1
        public double decTimeAutoAxis8 = 0.1;//减速时间,默认0.1

        public double startSpeedAutoAxis9 = 1000;//起始速度,默认500
        public double runSpeedAutoAxis9 = 20000;//运行速度,默认1000
        public double stopSpeedAutoAxis9 = 100;//停止速度,默认100
        public double accTimeAutoAxis9 = 0.1;//加速时间,默认0.1
        public double decTimeAutoAxis9 = 0.1;//减速时间,默认0.1

        public double startSpeedAutoAxis10 = 3500;//起始速度,默认500
        public double runSpeedAutoAxis10 = 15000;//运行速度,默认1000
        public double stopSpeedAutoAxis10 = 100;//停止速度,默认100
        public double accTimeAutoAxis10 = 0.1;//加速时间,默认0.1
        public double decTimeAutoAxis10 = 0.1;//减速时间,默认0.1

        public double startSpeedAutoAxis11 = 3500;//起始速度,默认500
        public double runSpeedAutoAxis11 = 15000;//运行速度,默认1000
        public double stopSpeedAutoAxis11 = 100;//停止速度,默认100
        public double accTimeAutoAxis11 = 0.1;//加速时间,默认0.1
        public double decTimeAutoAxis11 = 0.1;//减速时间,默认0.1




        /// <summary>
        /// 手动运行速度设置
        /// </summary>
        public double startSpeedMaualAxis0 = 40000;//起始速度,默认10000
        public double runSpeedMaualAxis0 = 40000;//运行速度,默认100000
        public double stopSpeedMaualAxis0 = 100;//停止速度,默认100
        public double accTimeMaualAxis0 = 0.1;//加速时间,默认0.1
        public double decTimeMaualAxis0 = 0.1;//减速时间,默认0.4

        public double startSpeedMaualAxis1 = 40000;//起始速度,默认1000
        public double runSpeedMaualAxis1 = 40000;//运行速度,默认20000
        public double stopSpeedMaualAxis1 = 100;//停止速度,默认100
        public double accTimeMaualAxis1 = 0.1;//加速时间,默认0.1
        public double decTimeMaualAxis1 = 0.1;//减速时间,默认0.1

        public double startSpeedMaualAxis2 = 45000;//起始速度,默认1000
        public double runSpeedMaualAxis2 = 45000;//运行速度,默认8000
        public double stopSpeedMaualAxis2 = 100;//停止速度,默认100
        public double accTimeMaualAxis2 = 0.1;//加速时间,默认0.1
        public double decTimeMaualAxis2 = 0.1;//减速时间,默认0.1

        public double startSpeedMaualAxis3 = 45000;//起始速度,默认500
        public double runSpeedMaualAxis3 = 45000;//运行速度,默认1000
        public double stopSpeedMaualAxis3 = 100;//停止速度,默认100
        public double accTimeMaualAxis3 = 0.1;//加速时间,默认0.1
        public double decTimeMaualAxis3 = 0.1;//减速时间,默认0.1

        public double startSpeedMaualAxis4 = 35000;//起始速度,默认500
        public double runSpeedMaualAxis4 = 35000;//运行速度,默认1000
        public double stopSpeedMaualAxis4 = 100;//停止速度,默认100
        public double accTimeMaualAxis4 = 0.1;//加速时间,默认0.1
        public double decTimeMaualAxis4 = 0.1;//减速时间,默认0.1

        public double startSpeedMaualAxis5 = 35000;//起始速度,默认500
        public double runSpeedMaualAxis5 = 35000;//运行速度,默认1000
        public double stopSpeedMaualAxis5 = 100;//停止速度,默认100
        public double accTimeMaualAxis5 = 0.1;//加速时间,默认0.1
        public double decTimeMaualAxis5 = 0.1;//减速时间,默认0.1

        public double startSpeedMaualAxis6 = 10000;//起始速度,默认500
        public double runSpeedMaualAxis6 = 10000;//运行速度,默认1000
        public double stopSpeedMaualAxis6 = 100;//停止速度,默认100
        public double accTimeMaualAxis6 = 0.1;//加速时间,默认0.1
        public double decTimeMaualAxis6 = 0.1;//减速时间,默认0.1

        public double startSpeedMaualAxis7 = 10000;//起始速度,默认500
        public double runSpeedMaualAxis7 = 10000;//运行速度,默认1000
        public double stopSpeedMaualAxis7 = 100;//停止速度,默认100
        public double accTimeMaualAxis7 = 0.1;//加速时间,默认0.1
        public double decTimeMaualAxis7 = 0.1;//减速时间,默认0.1


        public double startSpeedMaualAxis8 = 1000;//起始速度,默认500
        public double runSpeedMaualAxis8 = 1000;//运行速度,默认1000
        public double stopSpeedMaualAxis8 = 100;//停止速度,默认100
        public double accTimeMaualAxis8 = 0.1;//加速时间,默认0.1
        public double decTimeMaualAxis8 = 0.1;//减速时间,默认0.1

        public double startSpeedMaualAxis9 = 1000;//起始速度,默认500
        public double runSpeedMaualAxis9 = 1000;//运行速度,默认1000
        public double stopSpeedMaualAxis9 = 100;//停止速度,默认100
        public double accTimeMaualAxis9 = 0.1;//加速时间,默认0.1
        public double decTimeMaualAxis9 = 0.1;

        public double startSpeedMaualAxis10 = 3500;
        public double runSpeedMaualAxis10 = 15000;
        public double stopSpeedMaualAxis10 = 100;
        public double accTimeMaualAxis10 = 0.1;
        public double decTimeMaualAxis10 = 0.1;

        public double startSpeedMaualAxis11 = 3500;
        public double runSpeedMaualAxis11 = 15000;
        public double stopSpeedMaualAxis11 = 100;
        public double accTimeMaualAxis11 = 0.1;
        public double decTimeMaualAxis11 = 0.1;



        /// <summary>
        /// 前载台运动位置 1：接料位置 2：上Mark1 3：上Mark2  4：出料位   5：下Mark1 6：下Mark2
        /// </summary>
        public int[] FrontReceiveDis = { 0, 0, 0, 0 ,789648,0,0};
        /// <summary>
        /// 后载台运动位置 1：接料位置 2：Mark1 3：mark2  4 出料位   5：下Mark1 6：下Mark2
        /// </summary>
        public int[] BehindReceiveDis = { 0, 0, 0, 0 ,793730,0,0};
        /// <summary>
        /// 进料轴运动位置  1：取料位置 2：前放置位 3后放置位
        /// </summary>
        public int[] CarryProductDis = { 0, 20349, 11196, 20 };
        /// <summary>
        /// 进料轴运动位置  1：放料位置 2：前取走位置 3后取走位置
        /// </summary>
        public int[] ThrowProductDis = { 0, 20066, 11118,0 };

        public int[] UpDepthDis = { 0, 98424 };
        public int[] DownDepthDis = { 0, 143678 };

        /// <summary>
        /// 上相机运动位置  1：前Mark1  2：前Mark2 3:后Mark1  4:后Mark2
        /// </summary>
        public int[] UpCameraDis = { 0, 143678,999,999,999 };
        /// <summary>
        /// 下相机运动位置  1：前Mark1  2：前Mark2 3:后Mark1  4:后Mark2
        /// </summary>
        public int[] DownCameraDis = { 0, 143678,999,999,999};
        //产品模板
        public Dictionary<string, PointControl> PointModels = new Dictionary<string, PointControl>();

        public ArrayList standPoints = new ArrayList();//产品点位
       
        //检测标识
        public Dictionary<string, FlagTextBox> StandFlag = new Dictionary<string, FlagTextBox>();

        public double pre_Score = 0.6;
        public double product_Score = 0.85;


        public bool signal_isLaShen = false;

        #region 视觉模板相关
        public double upCameraExposureTime = 0.03;
        public double upCameraGainRaw = 0;
        public int upCameraContrast = 0;
        public uint upCameraBlackLevel = 0;
        public int upCameraBrightness = 0;

        public double downCameraExposureTime = 0.03;
        public double downCameraGainRaw = 0;
        public int downCameraContrast = 0;
        public uint downCameraBlackLevel = 0;
        public int downCameraBrightness = 0;

        public int cameraComeDelay =100;
        public int cameraLeaveDelay = 100;

        #endregion
        public string severTcp = "192.168.0.66";
        public int severPort = 64000;


        public  double commonRow = 0.870711261;
        public  double rowdelta = 0.17;
        public  double commonCol = 5.310736797;
        public  double coldelat = 0.1;
        public int depthMax = 20700;
        public int depthMin = 18000;
        public double commonAngel = 3.136;
        public double deltaAngel = 0.05;
        public int delay_SuckTime = 200;
        public int delay_CommonTime = 60000;
        public int delay_PuffTime = 50;
        public int delay_MannulHomeTime = 10000;

        public List<double> ho_RowList;
        public List<double> ho_ColList;
        public List<double> ho_RowDist;
        public List<double> ho_ColDist;
        public List<double> ho_StrightDist;
    }

    
}
