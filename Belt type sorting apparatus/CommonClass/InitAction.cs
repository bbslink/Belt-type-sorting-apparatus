using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    class InitSystem
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        public static void InitSystemParam()
        {
            try
            {
                //获取系统参数
                GetSystemParameter();
                // 获取用户和轴参数
                GetUserParameter();
                //初始化运动卡
                if (CardControl.DMCardInit())
                {
                    sysEvent.showRealInfo("运动控制卡初始化成功！", CommonData.infoMess);
                    CommonData.sportCardInitSuccess = true;
                }
                
                
            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo(ex.Message, CommonData.warnMess);
                LogHelper.WriteExceptionLog(typeof(InitSystem), ex);
            }

        }

        /// <summary>
        /// 获取系统参数
        /// </summary>
        public static void GetSystemParameter()
        {
            try
            {
                //加载当前产品名称
                CommonData.CurProName = CommonUtils.GetStringValue(Application.StartupPath + "\\set.ini", "CurPro", "CurPro", "");
                CommonData.CurProFile = Application.StartupPath + "\\product\\" + CommonData.CurProName + "\\";
                //加载系统参数
                if (File.Exists(CommonData.CurProFile + CommonData.CurProName + ".SX"))
                {
                    CommonData.RunDataInstance = (RuntimeData)CommonUtils.AntiSerializeFile(CommonData.CurProFile + CommonData.CurProName + ".SX");
                    sysEvent.showRealInfo("加载系统参数成功！", CommonData.infoMess);
                }
                else
                {

                    sysEvent.showRealInfo("加载系统参数失败，启用系统默认参数！", CommonData.warnMess);
                    CommonData.RunDataInstance = RuntimeData.GetRuntimeInstance();
                    CommonData.RunDataInstance.data_order = new int[CommonData.RunDataInstance.Product_Clo * CommonData.RunDataInstance.Product_Row];
                    for (int i = 0; i < CommonData.RunDataInstance.Product_Clo * CommonData.RunDataInstance.Product_Row; i++)
                    {
                        CommonData.RunDataInstance.data_order[i] = -1;
                    }
                    CommonData.RunDataInstance.All_coordinates_date = new int[1, 1, 1];
                    CommonData.RunDataInstance.All_coordinates_date[0, 0, 0] = -100000;
                    if (!CommonUtils.SerializeFile(CommonData.RunDataInstance, CommonData.CurProFile + CommonData.CurProName + ".SX"))
                    {
                        sysEvent.showRealInfo("保存系统默认参数失败！", CommonData.warnMess);
                    }
                }
            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo(ex.Message, CommonData.warnMess);
                LogHelper.WriteExceptionLog(typeof(InitSystem), ex);
            }
            
        }

        /// <summary>
        /// 获取用户和轴参数
        /// </summary>
        public static bool GetUserParameter()
        {
            try
            {
                //加载用户跟密码参数
                if (File.Exists(Application.StartupPath + "\\SystemData\\" + "system.SX"))
                {
                    CommonData.codeAndUser = (CodeAndUser)CommonUtils.AntiSerializeFile(Application.StartupPath + "\\SystemData\\" + "system.SX");
                    return true;
                }
                else
                {
                    CommonData.codeAndUser = CodeAndUser.GetCodeAndUser();
                    CommonData.codeAndUser.user[10, 0] = "he";
                    CommonData.codeAndUser.user[10, 1] = "159753";
                    CommonData.codeAndUser.user[10, 2] = "user";
                    CommonData.codeAndUser.user[0, 0] = "administer";
                    CommonData.codeAndUser.user[0, 1] = "258369";
                    CommonData.codeAndUser.user[0, 2] = "user";
                    for (int i = 1; i < 10; i++)
                    {
                        CommonData.codeAndUser.user[i, 0] = "null";
                        CommonData.codeAndUser.user[i, 1] = "null";
                        CommonData.codeAndUser.user[i, 2] = "null";
                    }
                    if (!CommonUtils.SerializeFile(CommonData.codeAndUser, Application.StartupPath + "\\SystemData\\" + "system.SX"))
                    {
                        LogHelper.WriteErrorLog(typeof(InitSystem), "初始化用户失败！");
                    }
                    sysEvent.showRealInfo("加载登录信息失败，初始化登录密码！", CommonData.infoMess);
                    return false;
                }
            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo(ex.Message, CommonData.warnMess);
                LogHelper.WriteExceptionLog(typeof(InitSystem), ex);
                return false;
            }
        }
    }
}
