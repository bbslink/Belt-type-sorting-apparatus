using Belt_type_sorting_apparatus.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus
{
    class IOMonitor
    {
        static ushort cardID = CommonData.cardID;//LTDMC默认卡号
       // static ushort cardNode = CommonData.cardNode;//LTDMC默认卡号
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();



        #region 系统IO设置

        /// <summary>
        /// 读取一个通用输入IO
        /// </summary>
        public static short ReadOneInBit(ushort bitNo)
        {
            try
            {
                if(bitNo<100)
                    return LTDMC.dmc_read_inbit(cardID, bitNo);
                else if(bitNo<200)
                    return LTDMC.dmc_read_can_inbit(cardID, 1, (ushort)(bitNo - 100));
                else
                    return LTDMC.dmc_read_can_inbit(cardID, 2, (ushort)(bitNo - 200));
            }
            catch
            {
                throw new Exception("错误0xIO004,读取输入IO口" + bitNo + "信号异常!");
            }

        }

        /// <summary>
        /// 读取一个通用输出IO
        /// </summary>
        public static short ReadOneOutBit(ushort bitNo)
        {
            try
            {
                if (bitNo < 100)
                    return LTDMC.dmc_read_outbit(cardID, bitNo);
                else if (bitNo < 200)
                    return LTDMC.dmc_read_can_outbit(cardID, 1, (ushort)(bitNo - 100));
                else
                    return LTDMC.dmc_read_can_outbit(cardID, 2, (ushort)(bitNo - 200));
            }
            catch
            {
                throw new Exception("错误0xIO010, 读取输出IO口" + bitNo + "信号异常!");
            }
        }

        /// <summary>
        /// 设置一个通用输出IO电平状态
        /// </summary>
        public static void SetOneOutBit(ushort bitNo, ushort state)
        {
            try
            {
                short result;
                if (bitNo<100)
                    result = LTDMC.dmc_write_outbit(cardID, bitNo, state);
                else if(bitNo<200)
                    result = LTDMC.dmc_write_can_outbit(cardID, 1, (ushort)(bitNo-100), state);
                else
                    result = LTDMC.dmc_write_can_outbit(cardID, 2, (ushort)(bitNo - 200), state);

                if (result > 0)
                    throw new Exception("错误0xIO002, 设置输出IO口" + bitNo + "信号异常!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 设置输出IO延时翻转
        /// </summary>
        public static void SetOneBitReverse(ushort bitNo, double time)
        {
            try
            {
               
                short result = LTDMC.dmc_reverse_outbit(cardID, bitNo, time);
              
                if (result > 0)
                    throw new Exception("错误0xIO008,设置输出IO口" + bitNo + "反转异常!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

    }
}
