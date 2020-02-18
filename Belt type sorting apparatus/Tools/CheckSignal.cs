using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class CheckSignal
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        /// <summary>
        /// 循环等待某个信号
        /// </summary>
        public static void WaitForALLTime(Func<bool> fuc)
        {
            try
            {
                SpinWait.SpinUntil(() => fuc());
 
            }
            catch
            {
                throw new Exception("错误0xTM003,循环等待异常！");
            }
            
        }

        /// <summary>
        /// 等待信号一段时间
        /// </summary>
        public static bool WaitSomeTime(Func<bool> fuc, int waitTime)
        {
            try
            {
                SpinWait.SpinUntil(() => fuc(), waitTime);
                if(fuc()==false)
                    return false;
                else
                    return true;
            }
            catch(Exception ex)
            {
                LogHelper.WriteExceptionLog(typeof(ComeCarryAction), ex);
                throw new Exception("错误0xTM002, 延时等待异常！");
            }        
        }

       

        public static void CommonDelay(int waitTime)
        {
            try
            {
                SpinWait.SpinUntil(() => false, waitTime);
        
            }
            catch
            {
                throw new Exception("错误0xTM001,普通延时等待异常！");
            }
        }


    }
}
