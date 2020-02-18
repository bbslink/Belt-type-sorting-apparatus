
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus
{
    [Serializable]
    class RuntimeData
    {

        private static RuntimeData runtimeData;
        /// <summary>
        /// 创建运行数据对象
        /// </summary>
        public static RuntimeData GetRuntimeInstance()
        {
            if (runtimeData == null)
            {
                runtimeData = new RuntimeData();
            }
            return runtimeData;
        }

        /// <summary>
        /// 产品个数，行列，行距列据
        /// </summary>
        public int Product_Row_All = 9;//行数
        public int Product_Clo_All = 4;//列数 
        public int Product_Row = 3;//行数
        public int Product_Clo = 4;//列数
        public int Product_Row_Spacing = 20827;//行间隔
        public int Product_Clo_Spacing = 31200;//列间隔
        public int Product_Row_Spacing2 = 20827;//粗坐标行间隔
        public int Product_Clo_Spacing2 = 31200;//粗坐标列间隔
        public int First_Poduct_X = 11569;//第一个X坐标
        public int First_Poduct_Y = 159929;//第一个Y坐标
        public int stanby_Poduct_X = 1000;//备料第一个X坐标
        public int stanby_Poduct_Y = 1000;//备料第一个Y坐标
        public int MAYBE_FIRST_X= 1000;//疑似不良品第一个X坐标
        public int MAYBE_FIRST_Y = 1000;//疑似不良品第一个Y坐标
        public int MAYBE_FIRST_PUT = 50000;//疑似不良品盒第1位产品伸出的距离
        public int Product_Row_one = 3;//产品切分次数
        public int TimesOfPhotograph = 3;//拍照分几次
       
        //新阵列存储数组
        public int[,,] All_coordinates_date;//产品和备料盒的产品坐标
        public int[,] MayBe_coordinates_date;//疑是不良品盒的产品坐标
        public int[,,] old_coordinates_date;//用于保存旧数据
        public int[] data_order;//数据顺序
        public double [,,] TemporarySaveCoordinatesDate;//临时数组保存



        /// <summary>
        /// 坐标地址
        /// </summary>
        public int bad_product_place_X = 10000;//扔废料时要去的坐标
        public int bad_product_place_Y = 10000;//扔废料时要去的坐标
        public int get_Product_hight_Z = 2000;//产品盒吸产品高度
        public int get_Product_hight_Z_spare = 2000;//备料盒吸产品高度
        public int get_Product_hight_Z_mayBe = 2000;//疑是不良品盒吸产品高度

        public int Z_safe_hight_to_ProductBox = 2000;//来料盒安全高度
        public int Z_safe_hight_to_spareBox = 2000;//备料盒安全高度
        public int Z_safe_hight_to_mayBeBox = 2000;//疑似不良品盒安全高度


        public int up_theBox_hight = 2000;//支撑装置上升高度
        public int Get_MayBebadBox_place = 3000;//疑是不良品台伸出距离
        public int Mandarin_Board_Rotation_Angle = 3000;//鸳鸯板反放旋转角度

        /// <summary>
        /// 鸳鸯板反放产品第一位坐标
        /// </summary>
        public int ONE_SYMMETRY_X = 1000;
        public int ONE_SYMMETRY_Y = 1000;
        public int TWO_SYMMETRY_X = 1000;
        public int TWO_SYMMETRY_Y = 1000;
        public int THREE_SYMMETRY_X = 1000;
        public int THREE_SYMMETRY_Y = 1000;
        public int FOUR_SYMMETRY_X = 1000;
        public int FOUR_SYMMETRY_Y = 1000;


        /// <summary>
        /// 版块产品第一位坐标
        /// </summary>
        public int TWO_First_Poduct_X = 1000;
        public int TWO_First_Poduct_Y = 1000;
        public int THREE_First_Poduct_X = 1000;
        public int THREE_First_Poduct_Y = 1000;
        public int FOUR_First_Poduct_X = 1000;
        public int FOUR_First_Poduct_Y = 1000;


        /// <summary>
        /// 扔不良品上限
        /// </summary>
        public uint MaxNumberOfBadProduct = 500;


        /// <summary>
        /// 参数设置界面
        /// </summary>
        public int Number_Of_Plate_In_One_Box = 1;
        public bool Is_The_Mandarin_Board = false;//在参数设置窗口
        public bool Is_create_One_Times_Coordinates = false;//创建过一次点位坐标
        public int The_step = 1;


        // 相机曝光时间
        public int Exposure = 50000;

       

    }
    [Serializable]
    class CodeAndUser
    {
        private static CodeAndUser codeandUser;
        public static CodeAndUser GetCodeAndUser()
        {
            if (codeandUser == null)
            {
                codeandUser = new CodeAndUser();
            }
            return codeandUser;
        }

        /// <summary>
        /// 轴X的参数
        /// </summary>
        public double axisX_dStartVel = 10000;//起始速度
        public double axisX_dMaxVel = 30000;//运行速度
        public double axisX_dTacc = 0.1;//加速时间
        public double axisX_dTdec = 0.1;//减速时间0.02s
        public double axisX_dStopVel = 200;//停止速度
        public double axisX_dS_para = 0.02;//S段时间
        //料台X


        /// <summary>
        /// 轴Y的参数
        /// </summary>
        public double axisY_dStartVel = 10000;//起始速度
        public double axisY_dMaxVel = 30000;//运行速度
        public double axisY_dTacc = 0.1;//加速时间
        public double axisY_dTdec = 0.1;//减速时间
        public double axisY_dStopVel = 200;//停止速度
        public double axisY_dS_para = 0.02;//S段时间
        //料台Y


        /// <summary>
        /// 轴Z的参数
        /// </summary>
        public double axisZ_dStartVel = 3000;//起始速度
        public double axisZ_dMaxVel = 10000;//运行速度
        public double axisZ_dTacc = 0.1;//加速时间
        public double axisZ_dTdec = 0.1;//减速时间
        public double axisZ_dStopVel = 200;//停止速度
        public double axisZ_dS_para = 0.02;//S段时间
        //下压


        /// <summary>
        /// 轴U的参数
        /// </summary>
        public double axisU_dStartVel = 10000;//起始速度
        public double axisU_dMaxVel = 20000;//运行速度
        public double axisU_dTacc = 0.1;//加速时间
        public double axisU_dTdec = 0.1;//减速时间
        public double axisU_dStopVel = 100;//停止速度
        public double axisU_dS_para = 0.02;//S段时间
        //旋转

        /// <summary>
        /// 轴C的参数
        /// </summary>
        public double axisC_dStartVel = 400;//起始速度
        public double axisC_dMaxVel = 1000;//运行速度
        public double axisC_dTacc = 0.1;//加速时间
        public double axisC_dTdec = 0.1;//减速时间
        public double axisC_dStopVel = 100;//停止速度
        public double axisC_dS_para = 0.02;//S段时间


        /// <summary>
        /// 轴S的参数
        /// </summary>
        public double axisS_dStartVel = 400;//起始速度
        public double axisS_dMaxVel = 1000;//运行速度
        public double axisS_dTacc = 0.1;//加速时间
        public double axisS_dTdec = 0.1;//减速时间
        public double axisS_dStopVel = 100;//停止速度
        public double axisS_dS_para = 0.02;//S段时间


        /// <summary>
        /// 轴B的参数
        /// </summary>
        public double axisB_dStartVel = 400;//起始速度
        public double axisB_dMaxVel = 1000;//运行速度
        public double axisB_dTacc = 0.1;//加速时间
        public double axisB_dTdec = 0.1;//减速时间
        public double axisB_dStopVel = 100;//停止速度
        public double axisB_dS_para = 0.02;//S段时间



        /// <summary>
        /// 轴M的参数
        /// </summary>
        public double axisM_dStartVel = 400;//起始速度
        public double axisM_dMaxVel = 1000;//运行速度
        public double axisM_dTacc = 0.1;//加速时间
        public double axisM_dTdec = 0.1;//减速时间
        public double axisM_dStopVel = 100;//停止速度
        public double axisM_dS_para = 0.02;//S段时间

        /// <summary>
        /// 用户和密码
        /// </summary>
        public string[,] user = new string[11, 3];
        public short UserClass = 3;
    }
}
