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
    class CardControl
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        static public ushort axisNum = CommonData.axisNum;
        static public ushort cardID = CommonData.cardID;


        #region 运动控制相关处理

        /// <summary>
        /// 运动卡初始化相关流程
        /// </summary>
        public static void DMCardInit()
        {
            try
            {

                //加载运动卡
                short initersult = LTDMC.dmc_board_init();
                if (initersult <= 0 || initersult > 8)
                {
                    throw new Exception("错误OxCA001,加载运动卡轴号失败！");
                }
                ushort num = 0;
                uint[] cardtypes = new uint[8];
                ushort[] cardids = new ushort[8];

                //加载运动卡ID
                if (LTDMC.dmc_get_CardInfList(ref num, cardtypes, cardids) > 0)
                {
                    throw new Exception("错误OxCA002,未能加载运动控制卡ID!");
                }
                //***********************************************************************************************
                //获取运动卡ID
                CommonData.cardID = cardids[0];
                if (LTDMC.dmc_set_can_state(CommonData.cardID, CommonData.nodeNum, 1, 0) > 0)
                {
                    throw new Exception("错误OxCA003,设置扩展IO卡异常!");
                }

                //连接扩展IO卡
                ushort statiii = 0;
                LTDMC.dmc_get_can_state(CommonData.cardID, ref CommonData.nodeNum, ref statiii);
                if (statiii == 0 || statiii == 2)
                {
                    throw new Exception("错误OxCA004,未能加载扩展IO卡!");
                }
                //****************************************************************************************

                //加载运动卡初始化参数
                if (LTDMC.dmc_download_configfile(CommonData.cardID, Application.StartupPath + "\\MoveSet.ini") > 0)
                {
                    throw new Exception("错误OxCA005,未能加载运动卡参数文件");
                }

                //初始化板卡参数
                for (ushort axisno = 0; axisno < axisNum; axisno++)
                {
                    SetAutoProfile(axisno);                 
                }

                //初始化运行目标数组
                CommonData.axissTargetPosition = new int[axisNum];

                //关闭输出IO
                CloseImpIO();

                //检测机台气压
                if (IOMonitor.ReadOneInBit(CommonData.in_ComePiezometer) != 0)
                    throw new Exception("机台气压不够，将无法运行程序！");

                //开启伺服电机电源
                IOMonitor.SetOneOutBit(CommonData.out_ServoPower, 0);

                //伺服电机使能
                for (ushort axisno = 0; axisno < axisNum; axisno++)
                {
                    if (axisno >= 8)
                        break;
                    AxisSet(axisno, 0);
                }
                IOMonitor.SetOneOutBit(CommonData.out_ComeMoveEnable, 0);
                IOMonitor.SetOneOutBit(CommonData.out_LeaveMoveEnable, 0);

                CheckSignal.CommonDelay(500);

                //伺服ERC复位
                for (ushort axisno = 0; axisno < axisNum; axisno++)
                {
                    if (axisno >= 8)
                        break;
                    AxisALLErc(axisno);
                }
                IOMonitor.SetOneOutBit(CommonData.out_ComeAndLeaveServoReset, 0);
                IOMonitor.SetOneOutBit(CommonData.out_ServoErrorReset, 0);
                CheckSignal.CommonDelay(300);
                IOMonitor.SetOneOutBit(CommonData.out_ComeAndLeaveServoReset, 1);
                IOMonitor.SetOneOutBit(CommonData.out_ServoErrorReset, 1);

                //检测伺服报警
                for (ushort axisNo = 0; axisNo < axisNum; axisNo++)
                {
                    if (axisNo >= 8)
                        break;
                    if (CheckAxisALM(axisNo))
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

            }
            catch (Exception ex)
            {               
                throw new Exception("错误0xCA011,初始化运动控制卡失败\r" + ex.Message);
            }
        }

        /// <summary>
        /// 电机伺服使能/关闭
        /// </summary>
        public static void AxisSet(ushort axisNo,int state)
        {
            try
            {
                if (state == 0)//伺服电机使能
                {
                    if (LTDMC.dmc_write_sevon_pin(cardID, axisNo, 0) > 0)
                        throw new Exception("错误0xCA012,轴" + axisNo + "伺服使能异常");

                }
                else//伺服电机关闭
                {
                    if (LTDMC.dmc_write_sevon_pin(cardID, axisNo, 1) > 0)
                        throw new Exception("错误0xCA013,轴" + axisNo + "关闭伺服使能异常");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        ///<summary>
        ///输出伺服报警复位
        ///</summary>
        public static void AxisALLErc(ushort axisNo)
        {
            try
            {

                if (LTDMC.dmc_write_erc_pin(cardID, axisNo, 0) > 0)
                    throw new Exception("设置ERC为0失败");

                CheckSignal.CommonDelay(200);

                if (LTDMC.dmc_write_erc_pin(cardID, axisNo, 1) > 0)
                    throw new Exception("设置ERC为1失败");

            }
            catch (Exception ex)
            {
                throw new Exception("错误0xCA007,轴" + axisNo + "伺服报警复位异常\r" + ex.Message);
            }
        }

        /// <summary>
        /// 设置轴减速停止信号
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="enable">0 禁止   1允许</param>
        /// <param name="logic">0 低有效  1 高有效</param>
        public static void AxisSetDstp(ushort axisNo,ushort enable,ushort logic)
        {
            try
            {
                if (LTDMC.dmc_set_io_dstp_mode(cardID, axisNo, enable, logic) > 0)
                    throw new Exception("错误0xCA044，设置轴"+axisNo+"减速停止模式异常");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }

        /// <summary>
        /// 设置单轴自动运动速度曲线
        /// </summary>
        public static void SetAutoProfile(ushort axisNo)
        {
            try
            {
                short result = 0;
                //设置起始速度、运行速度、停止速度、加速时间、减速时间
                switch (axisNo)
                {
                    case 0:
                        result = LTDMC.dmc_set_profile(cardID, 0, CommonData.saveData.startSpeedAutoAxis0,
                            CommonData.saveData.runSpeedAutoAxis0, CommonData.saveData.accTimeAutoAxis0,
                            CommonData.saveData.decTimeAutoAxis0, CommonData.saveData.stopSpeedAutoAxis0);
                        break;
                    case 1:
                        result = LTDMC.dmc_set_profile(cardID, 1, CommonData.saveData.startSpeedAutoAxis1,
                           CommonData.saveData.runSpeedAutoAxis1, CommonData.saveData.accTimeAutoAxis1,
                    CommonData.saveData.decTimeAutoAxis1, CommonData.saveData.stopSpeedAutoAxis1);
                        break;
                    case 2:
                        result = LTDMC.dmc_set_profile(cardID, 2, CommonData.saveData.startSpeedAutoAxis2,
                            CommonData.saveData.runSpeedAutoAxis2, CommonData.saveData.accTimeAutoAxis2,
                            CommonData.saveData.decTimeAutoAxis2, CommonData.saveData.stopSpeedAutoAxis2);
                        break;
                    case 3:
                        result = LTDMC.dmc_set_profile(cardID, 3, CommonData.saveData.startSpeedAutoAxis3,
                            CommonData.saveData.runSpeedAutoAxis3, CommonData.saveData.accTimeAutoAxis3,
                            CommonData.saveData.decTimeAutoAxis3, CommonData.saveData.stopSpeedAutoAxis3);
                        break;
                    case 4:
                        result = LTDMC.dmc_set_profile(cardID, 4, CommonData.saveData.startSpeedAutoAxis4,
                            CommonData.saveData.runSpeedAutoAxis4, CommonData.saveData.accTimeAutoAxis4,
                            CommonData.saveData.decTimeAutoAxis4, CommonData.saveData.stopSpeedAutoAxis4);
                        break;
                    case 5:
                        result = LTDMC.dmc_set_profile(cardID, 5, CommonData.saveData.startSpeedAutoAxis5,
                            CommonData.saveData.runSpeedAutoAxis5, CommonData.saveData.accTimeAutoAxis5,
                            CommonData.saveData.decTimeAutoAxis5, CommonData.saveData.stopSpeedAutoAxis5);
                        break;
                    case 6:
                        result = LTDMC.dmc_set_profile(cardID, 6, CommonData.saveData.startSpeedAutoAxis6,
                            CommonData.saveData.runSpeedAutoAxis6, CommonData.saveData.accTimeAutoAxis6,
                            CommonData.saveData.decTimeAutoAxis6, CommonData.saveData.stopSpeedAutoAxis6);
                        break;
                    case 7:
                        result = LTDMC.dmc_set_profile(cardID, 7, CommonData.saveData.startSpeedAutoAxis7,
                            CommonData.saveData.runSpeedAutoAxis7, CommonData.saveData.accTimeAutoAxis7,
                            CommonData.saveData.decTimeAutoAxis7, CommonData.saveData.stopSpeedAutoAxis7);
                        break;
                    case 8:
                        result = LTDMC.dmc_set_profile(cardID, 8, CommonData.saveData.startSpeedAutoAxis8,
                            CommonData.saveData.runSpeedAutoAxis8, CommonData.saveData.accTimeAutoAxis8,
                            CommonData.saveData.decTimeAutoAxis8, CommonData.saveData.stopSpeedAutoAxis8);
                        break;
                    case 9:
                        result = LTDMC.dmc_set_profile(cardID, 9, CommonData.saveData.startSpeedAutoAxis9,
                            CommonData.saveData.runSpeedAutoAxis9, CommonData.saveData.accTimeAutoAxis9,
                            CommonData.saveData.decTimeAutoAxis9, CommonData.saveData.stopSpeedAutoAxis9);
                        break;
                    case 10:
                        result = LTDMC.dmc_set_profile(cardID, 10, CommonData.saveData.startSpeedAutoAxis10,
                            CommonData.saveData.runSpeedAutoAxis10, CommonData.saveData.accTimeAutoAxis10,
                            CommonData.saveData.decTimeAutoAxis10, CommonData.saveData.stopSpeedAutoAxis10);
                        break;


                }

                if (result > 0)
                    throw new Exception();
            }
            catch(Exception ex)
            {
                throw new Exception("错误OxCA006,设置轴" + axisNo + "自动运动速度参数异常\r"+ex.Message);
            }
        }

        /// <summary>
        /// 设置单轴手动运动速度曲线
        /// </summary>
        public static void SetManualProfile(ushort axisNo)
        {
            try
            {
                short result = 0;
                //设置起始速度、运行速度、停止速度、加速时间、减速时间
                switch (axisNo)
                {
                    case 0:
                        result = LTDMC.dmc_set_profile(CommonData.cardID, 0, CommonData.saveData.startSpeedMaualAxis0,
                            CommonData.saveData.runSpeedMaualAxis0, CommonData.saveData.accTimeMaualAxis0,
                            CommonData.saveData.decTimeMaualAxis0, CommonData.saveData.stopSpeedMaualAxis0);
                        break;
                    case 1:
                        result = LTDMC.dmc_set_profile(CommonData.cardID, 1, CommonData.saveData.startSpeedMaualAxis1,
                            CommonData.saveData.runSpeedMaualAxis1, CommonData.saveData.accTimeMaualAxis1,
                    CommonData.saveData.decTimeMaualAxis1, CommonData.saveData.stopSpeedMaualAxis1);
                        break;
                    case 2:
                        result = LTDMC.dmc_set_profile(CommonData.cardID, 2, CommonData.saveData.startSpeedMaualAxis2,
                            CommonData.saveData.runSpeedMaualAxis2, CommonData.saveData.accTimeMaualAxis2,
                            CommonData.saveData.decTimeMaualAxis2, CommonData.saveData.stopSpeedMaualAxis2);
                        break;
                    case 3:
                        result = LTDMC.dmc_set_profile(CommonData.cardID, 3, CommonData.saveData.startSpeedMaualAxis3,
                            CommonData.saveData.runSpeedMaualAxis3, CommonData.saveData.accTimeMaualAxis3,
                    CommonData.saveData.decTimeMaualAxis3, CommonData.saveData.stopSpeedMaualAxis3);
                        break;
                    case 4:
                        result = LTDMC.dmc_set_profile(CommonData.cardID, 4, CommonData.saveData.startSpeedMaualAxis4,
                            CommonData.saveData.runSpeedMaualAxis4, CommonData.saveData.accTimeMaualAxis4,
                            CommonData.saveData.decTimeMaualAxis4, CommonData.saveData.stopSpeedMaualAxis4);
                        break;
                    case 5:
                        result = LTDMC.dmc_set_profile(CommonData.cardID, 5, CommonData.saveData.startSpeedMaualAxis5,
                            CommonData.saveData.runSpeedMaualAxis5, CommonData.saveData.accTimeMaualAxis5,
                    CommonData.saveData.decTimeMaualAxis5, CommonData.saveData.stopSpeedMaualAxis5);
                        break;
                    case 6:
                        result = LTDMC.dmc_set_profile(CommonData.cardID, 6, CommonData.saveData.startSpeedMaualAxis6,
                            CommonData.saveData.runSpeedMaualAxis6, CommonData.saveData.accTimeMaualAxis6,
                            CommonData.saveData.decTimeMaualAxis6, CommonData.saveData.stopSpeedMaualAxis6);
                        break;
                    case 7:
                        result = LTDMC.dmc_set_profile(CommonData.cardID, 7, CommonData.saveData.startSpeedMaualAxis7,
                            CommonData.saveData.runSpeedMaualAxis7, CommonData.saveData.accTimeMaualAxis7,
                    CommonData.saveData.decTimeMaualAxis7, CommonData.saveData.stopSpeedMaualAxis7);
                        break;
                    case 8:
                        result = LTDMC.dmc_set_profile(CommonData.cardID, 8, CommonData.saveData.startSpeedMaualAxis8,
                            CommonData.saveData.runSpeedMaualAxis8, CommonData.saveData.accTimeMaualAxis8,
                    CommonData.saveData.decTimeMaualAxis8, CommonData.saveData.stopSpeedMaualAxis8);
                        break;
                    case 9:
                        result = LTDMC.dmc_set_profile(CommonData.cardID, 9, CommonData.saveData.startSpeedMaualAxis9,
                            CommonData.saveData.runSpeedMaualAxis9, CommonData.saveData.accTimeMaualAxis9,
                    CommonData.saveData.decTimeMaualAxis9, CommonData.saveData.stopSpeedMaualAxis9);
                        break;
                    case 10:
                        result = LTDMC.dmc_set_profile(CommonData.cardID, 10, CommonData.saveData.startSpeedMaualAxis10,
                            CommonData.saveData.runSpeedMaualAxis10, CommonData.saveData.accTimeMaualAxis10,
                    CommonData.saveData.decTimeMaualAxis10, CommonData.saveData.stopSpeedMaualAxis10);
                        break;
                }
                if (result > 0)
                    throw new Exception();
               
            }
            catch(Exception ex)
            {
                throw new Exception("错误OxCA024,设置轴" + axisNo + "手动运动速度参数异常\r"+ex.Message);
            }
           

        }

        #endregion


        #region 系统检测

        /// <summary>
        /// 检查安全门
        /// </summary>
        /// <returns>0 安全门打开 1安全门关闭</returns>
        public static bool CheckMagnet()
        {
            try
            {
                //IO检测，如果安全门被打开则提示
                //如
                if ((IOMonitor.ReadOneInBit(CommonData.in_SafeDoor) == 1))
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception("错误OxIO006,安全门检查异常\r"+ex.Message);
            }
          
        }

        /// <summary>
        /// 检测轴运动状态
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public static int CheckAxisDone(ushort axisNo)
        {
            try
            {
                return LTDMC.dmc_check_done(cardID, axisNo);
            }
            catch (Exception ex)
            {
                throw new Exception("错误0xCA027,检测轴" + axisNo + "运动状态异常\r" + ex.Message);
            }
        }

        /// <summary>
        /// 获取当前轴运动速度
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public static double GetCurSpeed(ushort axisNo)
        {
            try
            {
                return LTDMC.dmc_read_current_speed(cardID, axisNo);
            }
            catch(Exception ex)
            {
                throw new Exception("错误0xCA028，获取轴" + axisNo + "运动速度异常\r" + ex.Message);
            }
        }

        /// <summary>
        /// 设置当前轴指令位置
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="position"></param>
        public static void SetPosition(ushort axisNo,int position)
        {
            try
            {
                if (LTDMC.dmc_set_position(cardID, axisNo, position) > 0)
                    throw new Exception();
            }
            catch(Exception ex)
            {
                throw new Exception("错误0xCA029,设置轴指令位置异常！\r"+ex.Message);
            }
        }

        /// <summary>
        /// 检测单轴是否回到原点
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns>true 回到原点   false 没回到原点</returns>
        public static bool CheckOneAxisIsHome(ushort axisNo,int delay_time)
        {
            try
            {

                if (!CheckSignal.WaitSomeTime(() => (CheckAxisDone(axisNo) == 1), delay_time))
                {
                    if (CheckAxisDone(axisNo) != 1)//防止暂停
                        return false;
                }
                if (!CheckSignal.WaitSomeTime(() => (GetCurSpeed(axisNo) == 0), delay_time))
                {
                    if(GetCurSpeed(axisNo) != 0)//防止暂停
                        return false;
                }

                bool isHome = CheckAxisHome(axisNo);              
                if (isHome)
                {
                    SetPosition(axisNo, 0);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("错误0xCA031, 控制轴"+ axisNo + "回原点异常\r"+ex.Message);
            }

        }


        /// <summary>
        /// 检测单轴伺服器有无报警
        /// </summary>
        /// <returns>true 报警异常  false没报警 </returns>
        public static bool CheckAxisALM(ushort axisNo)
        {
            try
            {
                string axisInport = ReadAxisIOState(axisNo);                
                if (axisInport.Substring(11, 1) == "1")
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                throw new Exception("错误0xCA009,检测" + axisNo + "轴伺服报警状态异常!\r" + ex.Message);
            }
           
        }



        /// <summary>
        /// 检测单轴伺服器有无到正限位
        /// </summary>
        /// <returns>true 到极限  false没到极限 </returns>
        public static bool CheckAxisELPlus(ushort axisNo)
        {
            try
            {
                string axisInport = ReadAxisIOState(axisNo);
                if (axisInport.Substring(10, 1) == "1")
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                throw new Exception("错误0xCA039,检测" + axisNo + "轴是否到正限位异常!\r" + ex.Message);
            }
           
        }


        /// <summary>
        /// 检测单轴伺服器有无到负限位
        /// </summary>
        /// <returns>true 到极限  false没到极限 </returns>
        public static bool CheckAxisELMin(ushort axisNo)
        {
            try
            {
                string axisInport = ReadAxisIOState(axisNo);
                if (axisInport.Substring(9, 1) == "1")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("错误0xCA040,检测" + axisNo + "轴是负限位异常!\r" + ex.Message);
            }
        }

        /// <summary>
        /// 检测轴原点状态
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public static bool CheckAxisHome(ushort axisNo)
        {
            try
            {
                string axisInport = ReadAxisIOState(axisNo);
                if (axisInport.Substring(7, 1) == "1")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("错误0xCA041,检测" + axisNo + "轴原点状态异常!\r" + ex.Message);
            }
        }

        /// <summary>
        /// 定长运动  mode：0 相对 1绝对
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="distance"></param>
        /// <param name="mode"></param>
        public static void AxisPmove(ushort axisNo, int distance, ushort mode)
        {
            try
            {
                if (LTDMC.dmc_pmove(cardID, axisNo, distance, mode) > 0)
                    throw new Exception("错误0xCA032，轴" + axisNo + "定长运动异常！");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        /// <summary>
        /// 回原点运动
        /// </summary>
        /// <param name="axisNo"></param>
        public static void AxisGoHome(ushort axisNo)
        {
            try
            {
                if (LTDMC.dmc_home_move(cardID, axisNo)> 0)
                    throw new Exception("错误0xCA042,轴"+axisNo+"回原点异常！");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        /// <summary>
        /// 检查单轴运动和到位信号   mode：0 相对 1绝对
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="distance"></param>
        /// <param name="mode">0: 相对坐标  1：绝对坐标 </param>
        /// <returns></returns>
        public static void AxisMoveAndCheck(ushort axisNo, int distance, ushort mode, int time)
        {
            try
            {
                AxisPmove(axisNo, distance, mode);

                if (!CheckSignal.WaitSomeTime(() => (CheckAxisDone(axisNo) == 1),time))
                {
                    if(CheckAxisDone(axisNo) != 1)
                        throw new Exception("检测到位超时");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误0xCA033,轴"+axisNo+"指令运动失败,"+ex.Message);
            }
        }


        /// <summary>
        /// 检查多轴运动和到位信号
        /// </summary>
        public static void AxissMoveAndCheck(ushort[] axisNo, int[] distance, ushort[] mode)
        {
            try
            {
                for (int i = 0; i < axisNo.Length; i++)
                {
                    AxisPmove(axisNo[i], distance[i], mode[i]);
                }
                for (int i = 0; i < axisNo.Length; i++)
                {
                    if (!CheckSignal.WaitSomeTime(() => (CheckAxisDone(axisNo[i]) == 1), CommonData.saveData.delay_CommonTime))
                    {
                        if (CheckAxisDone(axisNo[i]) != 1)//防暂停
                            throw new Exception("检测到位超时");
                    }                      
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误0xCA034,多轴运动时,轴" + axisNo + "指令运动失败," + ex.Message);
            }

        }

        /// <summary>
        /// 获取当前轴指令位置
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public static int AxisNowPosition(ushort axisNo)
        {
            try
            {
                return LTDMC.dmc_get_position(cardID, axisNo);
            }
            catch
            {
                throw new Exception("错误0xCA043,获取当前轴"+axisNo+"位置异常");
            }
            
        }

        /// <summary>
        /// 单轴往返运动
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="distance"></param>
        /// <param name="mode"></param>
        public static void AxisMoveAndRebackCheck(ushort axisNo, int distance, ushort mode,ushort timer)
        {
            try
            {
                
                int temp = LTDMC.dmc_get_position(cardID, axisNo);
                AxisPmove(axisNo, distance, mode);
                if (!CheckSignal.WaitSomeTime(() => (CheckAxisDone(axisNo) == 1), CommonData.saveData.delay_CommonTime))
                {
                    if (CheckAxisDone(axisNo) != 1)
                        throw new Exception("检测到位超时");
                }
                CheckSignal.CommonDelay(timer);
                temp = temp - LTDMC.dmc_get_position(cardID, axisNo);
                AxisPmove(axisNo, temp, 0);
                if (!CheckSignal.WaitSomeTime(() => (CheckAxisDone(axisNo) == 1), CommonData.saveData.delay_CommonTime))
                {
                    if (CheckAxisDone(axisNo) != 1)
                        throw new Exception("检测到位超时");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误0xCA035,轴" + axisNo + "往返运动异常," + ex.Message);
            }

        }
        
        /// <summary>
       /// 单轴暂停
       /// </summary>
       /// <param name="axisNo"></param>
        public static void AxisPause(ushort axisNo)
        {
            try
            {                
                StopOneAxis(axisNo, CommonData.saveData.delay_CommonTime);
                int targetTemp = LTDMC.dmc_get_target_position(cardID, axisNo);
                CommonData.axissTargetPosition[axisNo] = targetTemp;
            }
            catch (Exception ex)
            {
                throw new Exception("错误0xCA036,轴" + axisNo + "暂停异常," + ex.Message);
            }
        }


        /// <summary>
        /// 单轴继续
        /// </summary>
        /// <param name="axisNo"></param>
        public static void AxisContiune(ushort axisNo)
        {
            try
            {               
                AxisMoveAndCheck(axisNo, CommonData.axissTargetPosition[axisNo], 1,CommonData.saveData.delay_CommonTime);
            }
            catch (Exception ex)
            {
                throw new Exception("错误0xCA037,轴" + axisNo + "继续异常," + ex.Message);
            }
        }

        /// <summary>
        /// 多轴继续
        /// </summary>
        /// <param name="axisNo"></param>
        public static void AxissContiune(ushort[] axisNo)
        {
            try
            {
                for (int i = 0; i < axisNo.Length; i++)
                {
                    AxisMoveAndCheck(axisNo[i], CommonData.axissTargetPosition[axisNo[i]], 1, CommonData.saveData.delay_CommonTime);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("错误0xCA038,多轴中轴" + axisNo + "继续异常," + ex.Message);
            }
        }

        /// <summary>
        /// 读取指定轴有关运动信号的状态
        /// </summary>
        public static string ReadAxisIOState(ushort axisNo)
        {
            try
            {
                uint cardResult = LTDMC.dmc_axis_io_status(cardID, axisNo);
                string cardResultStr = Convert.ToString(cardResult, 2);//如转化失败报出异常
                int cardResultLen = cardResultStr.Length;
                if (cardResultLen != 12)
                {
                    for (int i = 0; i < 12 - cardResultLen; i++)
                    {
                        cardResultStr = 0 + cardResultStr;
                    }
                }
                return cardResultStr;
            }
            catch (Exception ex)
            {
                throw new Exception("错误0xCA008,读取" + axisNo + "轴运动状态信号异常!\r" + ex.Message);
            }

        }

        #endregion

        /// <summary>
        /// 关闭必要IO
        /// </summary>
        public static void CloseImpIO()
        {
            try
            {
                IOMonitor.SetOneOutBit(CommonData.out_VacuumPower, 1);
                IOMonitor.SetOneOutBit(CommonData.out_BehindReceiveCylinderPuff, 1);
                IOMonitor.SetOneOutBit(CommonData.out_BehindReceiveCylinderSuck, 1);
                IOMonitor.SetOneOutBit(CommonData.out_BehindReceiveCylinderUp, 1);
                IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderDown, 1);
                IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderPuff, 1);
                IOMonitor.SetOneOutBit(CommonData.out_ComeCylinderSuck, 1);
                IOMonitor.SetOneOutBit(CommonData.out_DownNeedleCylinderUp, 1);
                IOMonitor.SetOneOutBit(CommonData.out_FrontReceiveCylinderPuff, 1);
                IOMonitor.SetOneOutBit(CommonData.out_FrontReceiveCylinderSuck, 1);
                IOMonitor.SetOneOutBit(CommonData.out_FrontReceiveCylinderUp, 1);
                IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderDown, 1);
                IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderPuff, 1);
                IOMonitor.SetOneOutBit(CommonData.out_LeaveCylinderSuck, 1);
                IOMonitor.SetOneOutBit(CommonData.out_UpNeedleCylinderDown, 1);
                IOMonitor.SetOneOutBit(CommonData.out_BehindPlatformClipTight, 1);
                IOMonitor.SetOneOutBit(CommonData.out_FrontPlatformClipTight, 1);
                IOMonitor.SetOneOutBit(CommonData.out_BehindPlatformExtendTight, 1);
                IOMonitor.SetOneOutBit(CommonData.out_FrontPlatformExtendTight, 1);

            }
            catch(Exception ex)
            {
                throw new Exception("错误OxIO001,关闭必要IO异常！\r"+ex.Message);
            }
           
        }

        public static  void StopOneAxis(ushort axisNo,int delay_time)
        {
            try
            {
                short s = LTDMC.dmc_stop(CommonData.cardID, axisNo, 0);
                if (s > 0)
                    throw new Exception("错误0xCA018,轴" + axisNo + "停止异常");


                if (!CheckSignal.WaitSomeTime(() => (CheckAxisDone(axisNo) == 1), delay_time))
                {
                    if (CheckAxisDone(axisNo) != 1)//防止暂停
                        throw new Exception("错误0xCA018,轴" + axisNo + "停止异常");
                }

                if (!CheckSignal.WaitSomeTime(() => (GetCurSpeed(axisNo) == 0), delay_time))
                {
                    if (GetCurSpeed(axisNo) != 0)//防止暂停
                        throw new Exception("错误0xCA018,轴" + axisNo + "停止异常");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// 控制轴连续运动 dir:  1-正方向  0-负方向
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="dir"></param>
        public static void VmoveOneAxiss(ushort axisNo,ushort dir)
        {
            try
            {
                short s = LTDMC.dmc_vmove(CommonData.cardID, axisNo, dir);
                if (s > 0)
                    throw new Exception("错误0xCA023,轴"+ axisNo + "连续运动异常");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 打开/关闭三色灯
        /// </summary>
        /// <param name="lightColor">灯的颜色；绿灯:Green;黄灯：Yellow；红灯:Red</param>
        /// <param name="lightState">灯的状态，true：打开; false：关闭</param>
        public static void TurnTheLight(Color lightColor, bool lightState)
        {
            try
            {
                if (lightState)//打开灯
                {
                    if (lightColor == Color.Green)
                    {
                        IOMonitor.SetOneOutBit(CommonData.out_GreenLight, 0);
                        IOMonitor.SetOneOutBit(CommonData.out_RedLight, 1);
                    }
                    else if (lightColor == Color.Red)
                    {
                        IOMonitor.SetOneOutBit(CommonData.out_GreenLight, 1);
                        IOMonitor.SetOneOutBit(CommonData.out_RedLight, 0);
                    }
                    else if (lightColor == Color.Yellow)
                    {
                        IOMonitor.SetOneOutBit(CommonData.out_GreenLight, 0);
                        IOMonitor.SetOneOutBit(CommonData.out_RedLight, 0);                   
                    }
                }
                else
                {
                    if (lightColor == Color.Green)
                    {
                        IOMonitor.SetOneOutBit(CommonData.out_GreenLight, 1);
                       
                    }
                    else if (lightColor == Color.Red)
                    {
                        IOMonitor.SetOneOutBit(CommonData.out_RedLight, 1);
                      
                    }
                    else if (lightColor == Color.Yellow)
                    {
                        IOMonitor.SetOneOutBit(CommonData.out_GreenLight, 1);
                        IOMonitor.SetOneOutBit(CommonData.out_RedLight, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误OxIO007," + lightColor.ToString() + "灯打开异常\r" + ex.Message);
            }
        }
    }
}
