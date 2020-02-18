using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus
{
    class CardMove
    {
        static public ushort cardID = CommonData.cardID;
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        //static ThreadControl threadControls = ThreadControl.GetThreadControl();

        #region 回原点相关

        /// <summary>
        /// 设置 ORG 原点信号
        /// </summary>
        /// <param name="logic">ORG 信号有效电平， 0： 低有效， 1： 高有效</param>
        public static void SetHomePIN(ushort axisNo, ushort logic)
        {
            try
            {
                short result = LTDMC.dmc_set_home_pin_logic(cardID, axisNo, logic, 0);
                if (result > 0)
                    throw new Exception();
            }
            catch (Exception)
            {
                sysEvent.showRealInfo("设置轴" + axisNo + "ORG原点信号异常！", CommonData.warnMess);
            }
        }

        ///// <summary>
        ///// 读取 ORG 原点信号
        ///// </summary>
        //public static ushort ReadHomePIN(ushort axisNo)
        //{
        //    try
        //    {
        //        ushort logic = 99;
        //        double filter = 0;
        //        short result = LTDMC.dmc_get_home_pin_logic(cardID, axisNo, ref logic, ref filter);
        //        if ((result > 0) || (logic == 99))
        //            throw new Exception();
        //        return logic;
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("读取设置的原点信号失败！");
        //        sysEvent.showRealInfo("读取轴" + axisNo + "ORG信号异常！", CommonData.warnMess);
        //        //threadControls.ReInitThread(9); threadControls.StartThread(9); while (true) ;
        //    }

        //}

        /// <summary>
        /// 设置指定轴的回原点模式
        /// </summary>
        /// <param name="direction">回零方向 0：负向，1：正向</param>
        /// <param name="velmode">回零速度模式 0：低速回零；1：高速回零</param>
        /// <param name="mode">回零模式  0：一次回零</param>
        public static void SetHomeMode(ushort axisNo, ushort direction, ushort velmode, ushort mode)
        {
            try
            {
                short result = LTDMC.dmc_set_homemode(cardID, axisNo, direction, velmode, mode, 0);
                if (result > 0)
                    throw new Exception();
            }
            catch (Exception)
            {
                sysEvent.showRealInfo("设置轴" + axisNo + "原点模式异常", CommonData.warnMess);
            }
        }

        /// <summary>
        /// //启动指定轴回零运动
        /// </summary>
        public static bool AxisGoHome(ushort axisNo)
        {
            try
            {
                short result = LTDMC.dmc_home_move(cardID, axisNo);

                if (result > 0)
                    throw new Exception();
                return true;
            }
            catch (Exception)
            {
                sysEvent.showRealInfo("轴" + axisNo + "回原点异常！", CommonData.warnMess);
                return false;
            }
        }

        #endregion


        #region 轴运动相关

        /// <summary>
        /// 设置单轴自动运动速度曲线
        /// </summary>
        public static void SetAutoProfile(ushort axisno)
        {
            try
            {
                short result = 0;
                //设置起始速度、运行速度、停止速度、加速时间、减速时间
                switch (axisno)
                {
                    case 0:
                        result= LTDMC.dmc_set_profile(cardID, axisno, CommonData.codeAndUser.axisX_dStartVel,
                        CommonData.codeAndUser.axisX_dMaxVel, CommonData.codeAndUser.axisX_dTacc,
                        CommonData.codeAndUser.axisX_dTdec, CommonData.codeAndUser.axisX_dStopVel);
                        LTDMC.dmc_set_s_profile(cardID, axisno, 0, CommonData.codeAndUser.axisX_dS_para);//设置S段速度参数
                        LTDMC.dmc_set_dec_stop_time(cardID, axisno, CommonData.codeAndUser.axisX_dTdec); //设置减速停止时间
                        break;
                    case 1:
                        result = LTDMC.dmc_set_profile(cardID, axisno, CommonData.codeAndUser.axisY_dStartVel,
                        CommonData.codeAndUser.axisY_dMaxVel, CommonData.codeAndUser.axisY_dTacc,
                        CommonData.codeAndUser.axisY_dTdec, CommonData.codeAndUser.axisY_dStopVel);
                        LTDMC.dmc_set_s_profile(cardID, axisno, 0, CommonData.codeAndUser.axisY_dS_para);//设置S段速度参数
                        LTDMC.dmc_set_dec_stop_time(cardID, axisno, CommonData.codeAndUser.axisY_dTdec); //设置减速停止时间
                        break;
                    case 2:
                        result = LTDMC.dmc_set_profile(cardID, axisno, CommonData.codeAndUser.axisS_dStartVel,
                        CommonData.codeAndUser.axisS_dMaxVel, CommonData.codeAndUser.axisS_dTacc,
                        CommonData.codeAndUser.axisS_dTdec, CommonData.codeAndUser.axisS_dStopVel);
                        LTDMC.dmc_set_s_profile(cardID, axisno, 0, CommonData.codeAndUser.axisS_dS_para);//设置S段速度参数
                        LTDMC.dmc_set_dec_stop_time(cardID, axisno, CommonData.codeAndUser.axisS_dTdec); //设置减速停止时间
                        break;
                    case 3:
                        result = LTDMC.dmc_set_profile(cardID, axisno, CommonData.codeAndUser.axisZ_dStartVel,
                        CommonData.codeAndUser.axisZ_dMaxVel, CommonData.codeAndUser.axisZ_dTacc,
                        CommonData.codeAndUser.axisZ_dTdec, CommonData.codeAndUser.axisZ_dStopVel);
                        LTDMC.dmc_set_s_profile(cardID, axisno, 0, CommonData.codeAndUser.axisZ_dS_para);//设置S段速度参数
                        LTDMC.dmc_set_dec_stop_time(cardID, axisno, CommonData.codeAndUser.axisZ_dTdec); //设置减速停止时间
                        break;
                    case 4:
                        result = LTDMC.dmc_set_profile(cardID, axisno, CommonData.codeAndUser.axisU_dStartVel,
                        CommonData.codeAndUser.axisU_dMaxVel, CommonData.codeAndUser.axisU_dTacc,
                        CommonData.codeAndUser.axisU_dTdec, CommonData.codeAndUser.axisU_dStopVel);
                        LTDMC.dmc_set_s_profile(cardID, axisno, 0, CommonData.codeAndUser.axisU_dS_para);//设置S段速度参数
                        LTDMC.dmc_set_dec_stop_time(cardID, axisno, CommonData.codeAndUser.axisU_dTdec); //设置减速停止时间
                        break;
                    case 5:
                        result = LTDMC.dmc_set_profile(cardID, axisno, CommonData.codeAndUser.axisC_dStartVel,
                        CommonData.codeAndUser.axisC_dMaxVel, CommonData.codeAndUser.axisC_dTacc,
                        CommonData.codeAndUser.axisC_dTdec, CommonData.codeAndUser.axisC_dStopVel);
                        LTDMC.dmc_set_s_profile(cardID, axisno, 0, CommonData.codeAndUser.axisC_dS_para);//设置S段速度参数
                        LTDMC.dmc_set_dec_stop_time(cardID, axisno, CommonData.codeAndUser.axisC_dTdec); //设置减速停止时间
                        break;
                    case 6:
                        result = LTDMC.dmc_set_profile(cardID, axisno, CommonData.codeAndUser.axisB_dStartVel,
                        CommonData.codeAndUser.axisB_dMaxVel, CommonData.codeAndUser.axisB_dTacc,
                        CommonData.codeAndUser.axisB_dTdec, CommonData.codeAndUser.axisB_dStopVel);
                        LTDMC.dmc_set_s_profile(cardID, axisno, 0, CommonData.codeAndUser.axisB_dS_para);//设置S段速度参数
                        LTDMC.dmc_set_dec_stop_time(cardID, axisno, CommonData.codeAndUser.axisB_dTdec); //设置减速停止时间
                        break;
                    case 7:
                        result = LTDMC.dmc_set_profile(cardID, axisno, CommonData.codeAndUser.axisM_dStartVel,
                        CommonData.codeAndUser.axisM_dMaxVel, CommonData.codeAndUser.axisM_dTacc,
                        CommonData.codeAndUser.axisM_dTdec, CommonData.codeAndUser.axisM_dStopVel);
                        LTDMC.dmc_set_s_profile(cardID, axisno, 0, CommonData.codeAndUser.axisM_dS_para);//设置S段速度参数
                        LTDMC.dmc_set_dec_stop_time(cardID, axisno, CommonData.codeAndUser.axisM_dTdec); //设置减速停止时间
                        break;
                }
                if (result > 0)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo("设置轴" + axisno + "运动曲线异常!", CommonData.warnMess);
                LogHelper.WriteExceptionLog(typeof(CardMove), ex);
            }
        }

       
        /// <summary>
        /// 指定轴定长运动
        /// </summary>
        /// <param name="distance">目标位置</param>
        public static bool AxisMove(ushort axisNo, int distance)
        {
            try
            {

                short result = LTDMC.dmc_pmove(cardID, axisNo, distance, CommonData.axisMoveMode);
                if (result > 0)
                    throw new Exception();
                return true;
            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo("轴" + axisNo + "定长运动异常！", CommonData.warnMess);
                LogHelper.WriteExceptionLog(typeof(CardMove), ex);
                return false;
            }
        }

        /// <summary>
        /// 指定轴连续运动
        /// </summary>
        /// <param name="axis">轴名称</param>
        /// <param name="direction">运动方向，0：负方向，1：正方向</param>
        public static bool AxisContinueMove(ushort axisNo, ushort direction)
        {
            try
            {
                short result = LTDMC.dmc_vmove(cardID, axisNo, direction);
                if (result > 0)
                    throw new Exception();
                return true;
            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo("轴" + axisNo + "连续运动异常！", CommonData.warnMess);
                LogHelper.WriteExceptionLog(typeof(CardMove), ex);
                return false;
            }
        }

        #endregion


        #region 运动状态检测及控制相关

        ///// <summary>
        ///// 读取一个轴运动速度
        ///// </summary>
        //public static double ReadAxisSpeed(ushort axisNo)
        //{
        //    try
        //    {
        //        return LTDMC.dmc_read_current_speed(cardID, axisNo);
        //    }
        //    catch
        //    {
        //        sysEvent.showRealInfo("读取轴" + axisNo + "运动速度异常!", CommonData.warnMess);
        //        //threadControls.ReInitThread(9); threadControls.StartThread(9); while (true) ;
        //    }

        //}

        /// <summary>
        /// 检测指定轴运行状态 0：运动中；1：停止状态；
        /// </summary>
        /// <returns>true 为停止状态      false 为运动状态</returns>
        public static short CheckRunState(ushort axisNo)
        {
            try
            {
                return LTDMC.dmc_check_done(cardID, axisNo);
            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo("检测轴" + axisNo + "运动状态异常！", CommonData.warnMess);
                LogHelper.WriteExceptionLog(typeof(CardMove), ex);
                return -1;
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
                sysEvent.showRealInfo("读取" + axisNo + "轴运动信号异常!", CommonData.warnMess);
                LogHelper.WriteExceptionLog(typeof(CardMove), ex);
                return null;
            }

        }

        /// <summary>
        /// 指定轴停止运动
        /// </summary>
        /// <param name="stopMode">制动方式，0：减速停止，1：立即停止</param>
        public static bool StopOneAxis(ushort axisNo, ushort stopMode)
        {
            try
            {
                short result = LTDMC.dmc_stop(cardID, axisNo, stopMode);
                if (result > 0)
                    throw new Exception();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("停止轴{0}异常！", axisNo);
                sysEvent.showRealInfo("停止" + axisNo + "轴异常", CommonData.warnMess);
                return false;
            }

        }

        /// <summary>
        /// 停止所有轴
        /// </summary>
        public static void StopALLAxis()
        {
            try
            {
                short result = LTDMC.dmc_emg_stop(cardID);
                if (result > 0)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("停止所有轴异常！");
                sysEvent.showRealInfo("停止所有轴异常！", CommonData.warnMess);
            }
        }

        #endregion


        #region 位置计数器相关

        /// <summary>
        /// 设置指定轴当前位置脉冲数
        /// </summary>
        /// <param name="curposition">指令脉冲位置</param>
        public static bool AxisSetPosition(ushort axisNo, int curposition)
        {
            try
            {
                short result = LTDMC.dmc_set_position(cardID, axisNo, curposition);
                if (result > 0)
                    throw new Exception();
                return true;
            }
            catch (Exception)
            {
                sysEvent.showRealInfo("设置轴" + axisNo + "当前位置脉冲异常！", CommonData.warnMess);
                return false;
            }

        }

        /// <summary>
        /// 读取一个轴当前位置
        /// </summary>
        public static int ReadAxisPosition(ushort axisNo)
        {
            return LTDMC.dmc_get_position(cardID, axisNo);
        }

        #endregion


        #region 伺服驱动相关

        /// <summary>
        /// 读取指定轴的伺服使能端口的电平
        /// </summary>
        public static short ReadOneAxisSevon(ushort axisNo)
        {
            try
            {
                return LTDMC.dmc_read_sevon_pin(cardID, axisNo);
            }
            catch
            {
                sysEvent.showRealInfo("读取" + axisNo + "轴伺服使能电平异常!", CommonData.warnMess);
                return -1;
            }

        }

        /// <summary>
        /// 控制指定轴的伺服使能端口的输出
        /// </summary>
        public static bool SetOneAxisSevon(ushort axis, ushort state)
        {
            try
            {
                short result = LTDMC.dmc_write_sevon_pin(cardID, axis, state);
                if (result > 0)
                    throw new Exception();
                return true;
            }
            catch (Exception)
            {
                sysEvent.showRealInfo("设置轴" + axis + "伺服控制器电平异常!", CommonData.warnMess);
                return false;
            }
        }

        /// <summary>
        /// 设置指定轴的报警模式
        /// </summary>
        public static void SetAlmMode(ushort axisNo, ushort enable, ushort logic)
        {
            try
            {
                short result = LTDMC.dmc_set_alm_mode(cardID, axisNo, enable, logic, 0);
                if (result > 0)
                    throw new Exception();
            }
            catch (Exception)
            {
                sysEvent.showRealInfo("设置轴" + axisNo + "报警模式设置异常!", CommonData.warnMess);
            }
        }

        /// <summary>
        /// 读取指定轴的 ERC 端口电平
        /// </summary>
        public static short ReadErcPin(ushort axisNo)
        {
            try
            {
                return LTDMC.dmc_read_erc_pin(cardID, axisNo);
            }
            catch
            {
                sysEvent.showRealInfo("读取" + axisNo + "轴ERC端口电平异常!", CommonData.warnMess);
                return -1;
            }

        }

        /// <summary>
        /// 控制指定轴的 ERC 信号输出
        /// </summary>
        /// <param name="sel">sel 输出电平， 0：低电平， 1：高电平</param>
        public static bool SetErcPin(ushort axisNo, ushort sel)
        {
            try
            {
                short result = LTDMC.dmc_write_erc_pin(cardID, axisNo, sel);
                if ((result > 0))
                    throw new Exception();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("设置轴{0}伺服报警复位异常！", axisNo);
                sysEvent.showRealInfo("设置" + axisNo + "轴ERC端口电平异常!", CommonData.warnMess);
                return false;

            }
        }

        #endregion


        #region 轴IO映射相关

        /// <summary>
        /// 设置轴 IO 映射关系
        /// </summary>
        /// <param name="ioType">指定轴的 IO 信号类型</param>
        /// <param name="mapIOType">轴 IO 映射类型</param>
        /// <param name="mapIOIndex">轴 IO 映射索引号</param>
        public static void AxisMapIO(ushort axisNo, ushort ioType, ushort mapIOType, ushort mapIOIndex)
        {
            try
            {
                short result = LTDMC.dmc_set_AxisIoMap(cardID, axisNo, ioType, mapIOType, mapIOIndex, 0);
                if (result > 0)
                    throw new Exception();
            }
            catch (Exception)
            {
                sysEvent.showRealInfo(axisNo + "轴IO映射异常!", CommonData.warnMess);
            }
        }

        #endregion


        #region 异常信号相关
        /// <summary>
        /// 设置所有轴急停信号模式
        /// </summary>
        /// <param name="enable">允许/禁止信号功能， 0： 禁止， 1： 允许</param>
        /// <param name="logic">EMG 信号有效电平， 0： 低有效， 1： 高有效</param>
        public static void SetEmgMode(ushort axisNo, ushort enable, ushort logic)
        {
            try
            {
                short result = LTDMC.dmc_set_emg_mode(cardID, axisNo, enable, logic);
                if (result > 0)
                    throw new Exception();
            }
            catch (Exception)
            {
                sysEvent.showRealInfo("设置" + axisNo + "轴急停信号模式异常!", CommonData.warnMess);
            }
        }

        #endregion


        #region 脉冲设置相关
        /// <summary>
        /// 设置指定轴的脉冲输出模式
        /// </summary>
        public static void SetPulseMode(ushort axisNo, ushort outmode)
        {
            try
            {
                short result = LTDMC.dmc_set_pulse_outmode(cardID, axisNo, outmode);
                if (result > 0)
                    throw new Exception();
            }
            catch (Exception)
            {
                sysEvent.showRealInfo("设置轴" + axisNo + "脉冲异常！", CommonData.warnMess);
            }
        }


        #endregion

        #region 板卡设置相关
        /// <summary>
        /// 板卡加载初始化
        /// </summary>
        public static short DMCardInit()
        {
            try
            {
                return LTDMC.dmc_board_init();
            }
            catch(Exception ex)
            {
                sysEvent.showRealInfo("板卡初始化异常!", CommonData.warnMess);
                LogHelper.WriteExceptionLog(typeof(InitSystem), ex);
                return -1;
            }

        }

        /// <summary>
        /// 获取当前卡ID号
        /// </summary>
        public static bool DMCardList(ref ushort cardNum, uint[] cardTypeList, ushort[] cardIDList)
        {
            try
            {
                short result = LTDMC.dmc_get_CardInfList(ref cardNum, cardTypeList, cardIDList);
                if (result > 0)
                    throw new Exception();
                return true;

            }
            catch (Exception)
            {
                sysEvent.showRealInfo("获取当前运动卡ID异常！", CommonData.warnMess);
                return false;
            }
        }
        #endregion


    }
}
