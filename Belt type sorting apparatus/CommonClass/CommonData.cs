using Belt_type_sorting_apparatus.CommonClass;
using HalconDotNet;
using SXHikCam;
using SXOptCam;
using SXTisCam;
using SXViewROI;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    class CommonData
    {

        public static SaveData saveData;//保存变量类对象
        public static SQLiteConnection Conn;//数据库类对象

        /// <summary>
        /// 正常信息
        /// </summary>
        public const int infoMess = 0;
        /// <summary>
        /// 报警信息
        /// </summary>
        public const int warnMess = 1;

        public static string[] allModel = { "前检测载台", "后检测载台", "上相机平移", "下相机平移", "上探高平移", "下探高平移", "上探高升降", "下探高升降", "进料平移", "出料平移","进料台升降","出料台升降"};

        public static string[] rightSelect = { "操作员", "管理员", "开发员" };

        /// <summary>
        /// 权限控制  1操作员 2管理员 3开发员
        /// </summary>
        public static int authorization = 1;
        /// <summary>
        /// 当前用户名
        /// </summary>
        public static string userName = "";
        /// <summary>
        /// 当前用户权限
        /// </summary>
        public static string userRight = "操作员";

        public static string proDir = Application.StartupPath + "\\product\\";
        //当前生产产品名称
        public static string CurProName;
        //初当前生产产品参数保存路径
        public static string CurProPath;//文件保存路径
        public static string CurProFile;//产品信息文件路径
        public static string CurProDxf;
        //INI配置文件参数路径
        public static string sysSetPath = Application.StartupPath + "\\set.ini";
        //数据库文件路径
        public static string FilePath = Application.StartupPath + "\\" + "Sqlite" + ".db";

        #region 运动控制卡相关参数

        /// <summary>
        /// 运动控制卡卡号
        /// </summary>
        public static ushort cardID = 0;
        /// <summary>
        /// 运动扩展卡轴个数
        /// </summary>
        public static ushort axisNum = 12;
        /// <summary>
        /// 扩展IO卡数量
        /// </summary>
        public static ushort nodeNum = 2;

        /////////////////////////////////////////////////////////////////////// 轴号 /////////////////////////////////////////////
        /// <summary>
        /// 前载具平台
        /// </summary>
        public static ushort axisProductReceive_Front = 0;
        /// <summary>
        /// 后载具平台
        /// </summary>
        public static ushort axisProductReceive_Behind = 1;
        /// <summary>
        /// 上相机检测轴
        /// </summary>
        public static ushort axisCameraUp = 2;
        /// <summary>
        /// 下相机检测轴
        /// </summary>
        public static ushort axisCameraDown = 3;
        /// <summary>
        /// 上探高平移检测轴
        /// </summary>
        public static ushort axisUpDepth_CheckMove = 4;
        /// <summary>
        /// 下探高平移检测轴
        /// </summary>
        public static ushort axisDownDepth_CheckMove = 5;
        /// <summary>
        /// 上探高升降轴
        /// </summary>
        public static ushort axisUpDepth_RiseAndDown= 6;
        /// <summary>
        /// 下探高升降轴
        /// </summary>
        public static ushort axisDownDepth_RiseAndDown = 7;
        /// <summary>
        /// 进料平移轴
        /// </summary>
        public static ushort axisProductCome_CarryMove = 8;
        /// <summary>
        /// 出料平移轴
        /// </summary>
        public static ushort axisProductOut_CarryMove = 9;
        /// <summary>
        /// 进料台升降
        /// </summary>
        public static ushort axisProductCome_RiseAndDown = 10;
        /// <summary>
        /// 出料台升降
        /// </summary>
        public static ushort axisProductOut_RiseAndDown = 11;


        /// <summary>
        /// 存储轴当前运动目标位置
        /// </summary>
        public static int[] axissTargetPosition;
        #endregion


        #region 系统IO

        #region 输入
        /// <summary>
        /// 急停信号
        /// </summary>
        public const ushort in_Scram = 0;
        /// <summary>
        /// 启动按键
        /// </summary>
        public const ushort in_StartButton = 1;
        /// <summary>
        /// 暂停按键
        /// </summary>
        public const ushort in_PauseButton = 2;
        /// <summary>
        /// 复位按键
        /// </summary>
        public const ushort in_ResetButton = 3;    
        /// <summary>
        /// 安全光栅
        /// </summary>
        public const ushort in_Raster = 4;
        /// <summary>
        /// 进料平台对射
        /// </summary>
        public const ushort in_ComePlatformBeam = 5;
        /// <summary>
        /// 进料平台载物感应
        /// </summary>
        public const ushort in_ComePlatformProductTense = 6;
        /// <summary>
        /// 出料平台对射
        /// </summary>
        public const ushort in_LeaveProductBeam = 7;
        /// <summary>
        /// 出料平台载物感应
        /// </summary>
        public const ushort in_LeavePlatformProductTense = 8;
        /// <summary>
        /// 进料气缸上位感应
        /// </summary>
        public const ushort in_ComeCylinderUpTense = 9;
        /// <summary>
        /// 进料气缸下位感应
        /// </summary>
        public const ushort in_ComeCylinderDownTense = 10;
        /// <summary>
        /// 进料气缸真空
        /// </summary>
        public const ushort in_ComeCylinderVacuum = 11;
        /// <summary>
        /// 出料气缸上位感应
        /// </summary>
        public const ushort in_LeaveCylinderUpTense = 12;
        /// <summary>
        /// 出料气缸下位感应
        /// </summary>
        public const ushort in_LeaveCylinderDownTense = 13;
        /// <summary>
        /// 出料气缸真空
        /// </summary>
        public const ushort in_LeaveCylinderVacuum = 14;
        /// <summary>
        /// 进料压力计
        /// </summary>
        public const ushort in_ComePiezometer = 15;
        /// <summary>
        /// 上探高气缸上位
        /// </summary>
        public const ushort in_UpNeedleCylinderUpTense = 100;
        /// <summary>
        /// 上探高气缸下位
        /// </summary>
        public const ushort in_UpNeedleCylinderDownTense = 101;
        /// <summary>
        /// 前接料上位
        /// </summary>
        public const ushort in_FrontReceiveUpTense = 102;
        /// <summary>
        /// 前接料下位
        /// </summary>
        public const ushort in_FrontReceiveDownTense = 103;
        /// <summary>
        /// 前接料真空
        /// </summary>
        public const ushort in_FrontReceiveVacuum = 104;
        /// <summary>
        /// 前载具夹开位1
        /// </summary>
        public const ushort in_FrontPlatformClipOpenTense_1 = 105;
        /// <summary>
        /// 前载具夹开位2
        /// </summary>
        public const ushort in_FrontPlatformClipOpenTense_2 = 106;
        /// <summary>
        /// 前载具夹闭位1
        /// </summary>
        public const ushort in_FrontPlatformClipCloseTense_1 = 107;
        /// <summary>
        /// 前载具夹闭位2
        /// </summary>
        public const ushort in_FrontPlatformClipCloseTense_2 = 108;
        /// <summary>
        /// 前载具夹前位1
        /// </summary>
        public const ushort in_FrontPlatformClipFrontTense_1 = 109;
        /// <summary>
        /// 前载具夹前位2
        /// </summary>
        public const ushort in_FrontPlatformClipFrontTense_2 = 110;
        /// <summary>
        /// 前载具夹前位3
        /// </summary>
        public const ushort in_FrontPlatformClipFrontTense_3 = 111;
        /// <summary>
        /// 前载具夹前位4
        /// </summary>
        public const ushort in_FrontPlatformClipFrontTense_4 = 112;
        /// <summary>
        /// 进料轴报警
        /// </summary>
        public const ushort in_ComeAxisAlarm = 113;
        /// <summary>
        /// 进料定位完成
        /// </summary>
        public const ushort in_ComeLocationOK = 114;
        /// <summary>
        /// 光栅2
        /// </summary>
        public const ushort in_Raster2   = 115;
        /// <summary>
        /// 下探高气缸上位
        /// </summary>
        public const ushort in_DownNeedleCylinderUpTense = 200;
        /// <summary>
        /// 下探高气缸下位
        /// </summary>
        public const ushort in_DownNeedleCylinderDownTense = 201;
        /// <summary>
        /// 后接料上位
        /// </summary>
        public const ushort in_BehindReceiveUpTense = 202;
        /// <summary>
        /// 后接料下位
        /// </summary>
        public const ushort in_BehindReceiveDownTense = 203;
        /// <summary>
        /// 后接料真空
        /// </summary>
        public const ushort in_BehindReceiveVacuum = 204;
        /// <summary>
        /// 后载具夹开位1
        /// </summary>
        public const ushort in_BehindPlatformClipOpenTense_1 = 205;
        /// <summary>
        /// 后载具夹开位2
        /// </summary>
        public const ushort in_BehindPlatformClipOpenTense_2 = 206;
        /// <summary>
        /// 后载具夹闭位1
        /// </summary>
        public const ushort in_BehindPlatformClipCloseTense_1 = 207;
        /// <summary>
        /// 后载具夹闭位2
        /// </summary>
        public const ushort in_BehindPlatformClipCloseTense_2 = 208;
        /// <summary>
        /// 后载具夹前位1
        /// </summary>
        public const ushort in_BehindPlatformClipFrontTense_1 = 209;
        /// <summary>
        /// 后载具夹前位2
        /// </summary>
        public const ushort in_BehindPlatformClipFrontTense_2 = 210;
        /// <summary>
        /// 后载具夹前位3
        /// </summary>
        public const ushort in_BehindPlatformClipFrontTense_3 = 211;
        /// <summary>
        /// 后载具夹前位4
        /// </summary>
        public const ushort in_BehindPlatformClipFrontTense_4 = 212;
        /// <summary>
        /// 出料轴报警
        /// </summary>
        public const ushort in_LeaveAxisAlarm = 213;
        /// <summary>
        /// 出料定位完成
        /// </summary>
        public const ushort in_LeaveLocationOK = 214;
        /// <summary>
        /// 安全门
        /// </summary>
        public const ushort in_SafeDoor = 215;
        #endregion

        #region 输出
        /// <summary>
        /// 伺服电源
        /// </summary>
        public const ushort out_ServoPower = 0;
        /// <summary>
        /// 进料平移使能
        /// </summary>
        public const ushort out_ComeMoveEnable = 1;
        /// <summary>
        /// 出料平移使能
        /// </summary>
        public const ushort out_LeaveMoveEnable = 2;
        /// <summary>
        /// 真空泵电源
        /// </summary>
        public const ushort out_VacuumPower = 3;
        /// <summary>
        /// 伺服故障报警复位
        /// </summary>
        public const ushort out_ServoErrorReset = 4;
        /// <summary>
        /// 上探高气缸降
        /// </summary>
        public const ushort out_UpNeedleCylinderDown = 5;
        /// <summary>
        /// 下探高气缸升
        /// </summary>
        public const ushort out_DownNeedleCylinderUp = 6;
        /// <summary>
        /// 进料气缸下降
        /// </summary>
        public const ushort out_ComeCylinderDown = 7;
        /// <summary>
        /// 进料吸真空
        /// </summary>
        public const ushort out_ComeCylinderSuck = 8;
        /// <summary>
        /// 进料破真空
        /// </summary>
        public const ushort out_ComeCylinderPuff = 9;
        /// <summary>
        /// 前接料平台上升
        /// </summary>
        public const ushort out_FrontReceiveCylinderUp = 10;
        /// <summary>
        /// 前接料平台吸真空
        /// </summary>
        public const ushort out_FrontReceiveCylinderSuck = 11;
        /// <summary>
        /// 前接料平台破真空
        /// </summary>
        public const ushort out_FrontReceiveCylinderPuff = 12;
        /// <summary>
        /// 后接料平台上升
        /// </summary>
        public const ushort out_BehindReceiveCylinderUp = 13;
        /// <summary>
        /// 上相机光源
        /// </summary>
        public const ushort out_UpLight = 14;//14
        /// <summary>
        /// 下相机光源
        /// </summary>
        public const ushort out_DownLight = 15;//15
        /// <summary>
        /// 出料气缸下降
        /// </summary>
        public const ushort out_LeaveCylinderDown = 100;
        /// <summary>
        /// 出料吸真空
        /// </summary>
        public const ushort out_LeaveCylinderSuck = 101;
        /// <summary>
        /// 出料破真空
        /// </summary>
        public const ushort out_LeaveCylinderPuff = 102;
        /// <summary>
        /// 前载具夹紧
        /// </summary>
        public const ushort out_FrontPlatformClipTight = 103;
        /// <summary>
        /// 前载具张紧
        /// </summary>
        public const ushort out_FrontPlatformExtendTight = 104;
        /// <summary>
        /// 后载具夹紧
        /// </summary>
        public const ushort out_BehindPlatformClipTight = 105;
        /// <summary>
        /// 后载具张紧
        /// </summary>
        public const ushort out_BehindPlatformExtendTight = 106;
        /// <summary>
        /// 后接料平台吸真空
        /// </summary>
        public const ushort out_BehindReceiveCylinderSuck = 107;
        /// <summary>
        /// 后接料平台破真空
        /// </summary>
        public const ushort out_BehindReceiveCylinderPuff = 108;
        /// <summary>
        /// 进出伺服复位
        /// </summary>
        public const ushort out_ComeAndLeaveServoReset = 109;
        /// <summary>
        /// 红灯
        /// </summary>
        public const ushort out_RedLight = 200;
        /// <summary>
        /// 绿灯
        /// </summary>
        public const ushort out_GreenLight = 201;
        /// <summary>
        /// 蜂鸣器
        /// </summary>
        public const ushort out_Buzzer = 202;
        /// <summary>
        /// 上探高刹车
        /// </summary>
        public const ushort out_UpNeedleStop = 203;
        /// <summary>
        /// 下探高刹车
        /// </summary>
        public const ushort out_DownNeedleStop = 204;

        #endregion

        #endregion


        #region 系统运行交换信号      
        /// <summary>
        /// 初始化完成信号
        /// </summary>
        public static bool signal_SysInitOK = false;
        /// <summary>
        /// 系统安全门启动信号
        /// </summary>
        public static bool signal_SafeEnable = false;
        /// <summary>
        /// 系统回原点完成信号
        /// </summary>
        public static bool signal_HomeStateNow = false;    
        /// <summary>
        /// 1:相机在定牌位置  2：相机在飞拍位置  3：相机在拍吸塑盒
        /// </summary>
        public static int signal_CameraNowPlace = 0;
        /// <summary>
        /// 飞拍相机处理完成
        /// </summary>
        public static bool signal_DownCameraOK = false;
        /// <summary>
        /// 定牌相机处理完成
        /// </summary>
        public static bool signal_UpCameraOK = false;
        /// <summary>
        /// 吸塑盒拍照处理完成
        /// </summary>
        public static bool signal_TrayCameraOK = false;
        /// <summary>
        /// 检测产品有无拍照处理完成
        /// </summary>
        public static bool signal_ProDuctCameraOK = false;
        /// <summary>
        /// 飞拍相机数据提取完成
        /// </summary>
        public static bool signal_DownCameraDataOK = true;
        /// <summary>
        /// 定牌相机数据提取完成
        /// </summary>
        public static bool signal_UpCameraDataOK = true;
        /// <summary>
        /// 吸塑盒拍照数据提取完成
        /// </summary>
        public static bool signal_TrayCameraDataOK = true;
        /// <summary>
        /// 标志拍照数据提取完成
        /// </summary>
        public static bool signal_SignCameraDataOK = true;
        /// <summary>
        /// 预处理是否完成
        /// </summary>
        public static bool signal_PredealDataOK = true;
        /// <summary>
        /// 上相机识别是否失败
        /// </summary>
        public static bool signal_CheckFalse = false;
        /// <summary>
        /// 前机要停止皮带信号
        /// </summary>
        public static bool signal_FrontAskBeltCanNotMove = true;
        /// <summary>
        /// 内部停止皮带信号
        /// </summary>
        public static bool signal_BeltCanNotMove = true;
        /// <summary>
        /// 复位按钮是否可按下
        /// </summary>
        public static bool signal_CanReset = false;
        /// <summary>
        /// 判断是否已经开始程序
        /// </summary>
        public static bool signal_IsStartNow = false;
        /// <summary>
        /// 进料平台产品是否上升到位
        /// </summary>
        public static bool signal_ProductRiseArrived = false;
        /// <summary>
        /// 进料平移轴是否抓起产品
        /// </summary>
        public static bool signal_CrabProductOK = true;
        /// <summary>
        /// 判断后载台是否需要产品
        /// </summary>
        public static bool signal_PlatBehindNeed = false;
        /// <summary>
        /// 判断产品是否在后载台放置完成
        /// </summary>
        public static bool signal_BehindPlatPutOK = false;
        /// <summary>
        /// 判断前载台是否需要产品
        /// </summary>
        public static bool signal_PlatFrontNeed = false;
        /// <summary>
        /// 判断产品是否在前载台放置完成
        /// </summary>
        public static bool signal_FrontPlatPutOK = false;
        /// <summary>
        /// 判断进料搬运轴是否可过来取料
        /// </summary>
        public static bool signal_MoveCarryCanGoToCarry = false;
        /// <summary>
        /// 前检测轴是否检测完准备出料
        /// </summary>
        public static bool signal_PlatFrontThrow = false;
        /// <summary>
        /// 后检测轴是否检测完准备出料
        /// </summary>
        public static bool signal_PlatBehindThrow = false;
        /// <summary>
        /// 前检测轴产品是否出料取走
        /// </summary>
        public static bool signal_CrabFrontProOK = false;
        /// <summary>
        /// 后检测轴产品是否出料取走
        /// </summary>
        public static bool signal_CrabBehindProOK = false;
        /// <summary>
        /// 前检测轴是否可以来平台取料
        /// </summary>
        public static bool signal_FrontCanComeTake = false;
        /// <summary>
        /// 后检测轴是否可以来平台取料
        /// </summary>
        public static bool signal_BehindCanComeTake = false;
        /// <summary>
        /// 前检测轴是否到达进料载台
        /// </summary>
        public static bool signal_FrontHaveArrived = false;
        /// <summary>
        /// 后检测轴是否到达进料载台
        /// </summary>
        public static bool signal_BehindHaveArrived = false;
        /// <summary>
        /// 前检测轴是否可以去开始检测
        /// </summary>
        public static bool signal_FrontCanGoCheck = false;
        /// <summary>
        /// 后检测轴是否可以去开始检测
        /// </summary>
        public static bool signal_BehindCanGoCheck = false;
        /// <summary>
        /// 上相机是否空闲
        /// </summary>
        public static bool signal_CameraUpFree = true;
        /// <summary>
        /// 下相机是否空闲
        /// </summary>
        public static bool signal_CameraDownFree = true;
        /// <summary>
        /// 是否可放出料平台
        /// </summary>
        public static bool signal_OutProductArrived = false;
        /// <summary>
        /// 是否在出料平台放置完成
        /// </summary>
        public static bool signal_PlatThrowOK = false;
        /// <summary>
        /// 探高是否空闲
        /// </summary>
        public static bool signal_DepthFree = true;


        public static bool signal_PlatFrontThrowArrived = false;
        public static bool signal_PlatBehindThrowArrived = false;

        public static bool signal_DepthOK = false;
        public static bool signal_DepthDataResult = false;
        public static bool signal_DepthDataOK = true;

        public static bool signal_curUpImageRusult = false;

        public static bool signal_BehindCheckResult = true;
        public static bool signal_FrontCheckResult = true;

        public static bool signal_BehindReCheckOK = true;
        public static bool signal_FrontReCheckOK = true;
        /// <summary>
        /// 放置计数
        /// </summary>
        public static int data_NumberPut = 0;

        public static int data_NGPut = 0;
        /// <summary>
        /// 急停开始延时
        /// </summary>
        public static int delay_EModeTime =15000;

        public static int delta_ProductX = 0;
        public static int delta_ProductY = 0;
        public static int delta_ProductR = 0;

        #endregion


        #region 视觉参数
        public static TisCamera CameraUp;
        public static TisCamera CameraDown;
        public static List<HTuple> ModelIDs;
        public static List<ROI> ModelRegions;
        public static List<SXModelsControl.ModelParam> modelParams;
        public static HTuple dispControlUp;
        public static HTuple dispControlDown;
        public static HTuple CameraParams;
        public static HTuple CameraPose;
        public static SXDispControl.DispControl camAControl;
        public static SXDispControl.DispControl camBControl;
        public static SXDispControl.DispControl camCControl;
        public static SXDispControl.DispControl camDControl;

        public static SXTisCam.CameraParam upParam = new SXTisCam.CameraParam();
        public static SXTisCam.CameraParam downParam = new SXTisCam.CameraParam();
        public static List<SXTisCam.CameraParam> cameraList = new List<SXTisCam.CameraParam>();
        public static int upfrontorbehind = 0;
        public static int downfrontorbehind = 0;
        public static int curBehindPosition = 0;
        public static int curFrontPosition = 0;

        public static int depthfrontorbehind = 0;
        public static HWindowControl flagController1 = new HWindowControl();
        public static HWindowControl flagController2 = new HWindowControl();
        public static HWindowControl flagController3 = new HWindowControl();
        public static HWindowControl flagController4 = new HWindowControl();
        public static HWindowControl flagController5 = new HWindowControl();
        public static HWindowControl flagController6 = new HWindowControl();

        #endregion

        #region TCP参数
        public static TCPClient tcpClient;
        public static bool signal_tcptest = false;
        public static string tcpAsk1 = "MS";
        #endregion


        public static double pix_mm = 11;
        public static double mm_pulse_x = 12;
        public static double mm_pulse_y = 12;

    }
}
