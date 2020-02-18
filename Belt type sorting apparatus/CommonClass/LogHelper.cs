using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Belt_type_sorting_apparatus.CommonClass
{
    class LogHelper
    {
        /// <summary>
        /// 输出异常日志
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        public static void WriteExceptionLog(Type t, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error("Error", ex);
        }

        /// <summary>
        /// 输出错误信息日志
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        public static void WriteErrorLog(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error(msg);
        }

        public static void WriteInfoLog(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Info(msg);
        }
    }
}
