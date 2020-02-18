using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class IniFiles
    {
        SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        public string iniPath;

        private static IniFiles iniControl;
        /// <summary>
        /// 获取INI类实例化对象
        /// </summary>
        public static IniFiles GetiniControl()
        {
            if (iniControl == null)
            {
                iniControl = new IniFiles(CommonData.sysSetPath);
            }
            return iniControl;
        }
        //声明API函数

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary> 
        /// 构造方法 
        /// </summary> 
        /// <param name="INIPath">文件路径</param> 
        public IniFiles(string INIPath)
        {
            iniPath = INIPath;
        }

        /// <summary> 
        /// 写入INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        /// <param name="Value">值</param> 
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.iniPath);
        }
        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        public string IniReadValue(string Section, string Key)
        {
            if (!ExistINIFile())
            {
                MessageBox.Show("配置文件不存在！，创建默认文件并重启", "错误");
                IniWriteValue("CurPro", "CurPro", "default");
                Environment.Exit(0);
                return "";
            }
            else
            {
                StringBuilder temp = new StringBuilder(500);
                GetPrivateProfileString(Section, Key, "", temp, 500, this.iniPath);
                return temp.ToString();
            }
        }


        /// <summary> 
        /// 验证文件是否存在 
        /// </summary> 
        /// <returns>布尔值</returns> 
        public bool ExistINIFile()
        {
            return File.Exists(iniPath);
        }
    }
}
