using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    public class CommonUtils
    {

        /// <summary>
        /// 文本框只允许输入整数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void IntegerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) || (e.KeyChar == 46))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 文本框只允许输入小数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void NumbericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 45))
            {
                e.Handled = true;
            }
            //小数点只能输入一次  
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text.IndexOf('.') != -1)
            {
                e.Handled = true;
            }
            //第一位不能为小数点  
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text == "")
            {
                e.Handled = true;
            }
            if (((TextBox)sender).SelectionLength != ((TextBox)sender).Text.Length)
            {
                //第一位是0，第二位必须为小数点  
                if (e.KeyChar != (char)('.') && (((TextBox)sender).Text == "0") && (e.KeyChar != 8))
                {
                    e.Handled = true;
                }
            }
        }



        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="myObject"></param>
        public static bool SerializeFile(Object myObject, string filePath)
        {
            try
            {
                //IFormatter formatter = new BinaryFormatter();
                //Stream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                //formatter.Serialize(stream, myObject);
                //stream.Close();

                MemoryStream ms = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, myObject);
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write)) // 使用UTF8编码格式 覆写已存在的文件
                {
                    byte[] buffer = ms.ToArray();
                    fs.Write(buffer, 0, buffer.GetLength(0));
                    fs.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(typeof(CommonUtils), ex);
                return false;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <returns></returns>
        public static Object AntiSerializeFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return null;
                }
                //IFormatter formatter = new BinaryFormatter();
                //Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
                //stream.Seek(0, SeekOrigin.Begin);
                //object myObj = (object)formatter.Deserialize(stream);
                //stream.Close();
                //return myObj;
                MemoryStream ms = new MemoryStream();
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[fs.Length];
                    int length = fs.Read(buffer, 0, (int)fs.Length);
                    fs.Close();
                    ms.Write(buffer, 0, length); // 将字节写入内存流以备序列化使用
                    ms.Flush();
                }
                BinaryFormatter formatter = new BinaryFormatter();
                ms.Position = 0;
                object myObj = formatter.Deserialize(ms);
                return myObj;

            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(typeof(CommonUtils), ex);
                return null;
            }
        }


        //INI文件操作

        /// <summary>  
        /// 获取所有节点名称
        /// </summary>  
        /// <param name="lpszReturnBuffer">存放节点名称的内存地址,每个节点之间用\0分隔</param>  
        /// <param name="nSize">内存大小(characters)</param>  
        /// <param name="lpFileName">Ini文件</param>  
        /// <returns>内容的实际长度,为0表示没有内容,为nSize-2表示内存大小不够</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer, uint nSize, string lpFileName);

        /// <summary>  
        /// 获取某个指定节点
        /// </summary>  
        /// <param name="lpAppName">节点名称</param>  
        /// <param name="lpReturnedString">返回值的内存地址,每个之间用\0分隔</param>  
        /// <param name="nSize">内存大小(characters)</param>  
        /// <param name="lpFileName">Ini文件</param>  
        /// <returns>内容的实际长度,为0表示没有内容,为nSize-2表示内存大小不够</returns>  
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileSection(string lpAppName, IntPtr lpReturnedString, uint nSize, string lpFileName);

        /// <summary>  
        /// 读取INI文件中指定的值  
        /// </summary>  
        /// <param name="lpAppName">节点名称。如果为null,则读取INI中所有节点名称,每个节点名称之间用\0分隔</param>  
        /// <param name="lpKeyName">Key名称。如果为null,则读取INI中指定节点中的所有KEY,每个KEY之间用\0分隔</param>  
        /// <param name="lpDefault">读取失败时的默认值</param>  
        /// <param name="lpReturnedString">读取的内容缓冲区，读取之后，多余的地方使用\0填充</param>  
        /// <param name="nSize">内容缓冲区的长度</param>  
        /// <param name="lpFileName">INI文件名</param>  
        /// <returns>实际读取到的长度</returns> 
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);
        /// <summary>
        /// 设定INI文件中的属性，如果section不存在，则自动创建该section，如果key不存在，则自动创建该key
        /// </summary>
        /// <param name="section">节</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filePath">INI文件的绝对地址</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        /// <summary>
        /// 写section值
        /// </summary>
        /// <param name="section"></param>
        /// <param name="val"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32", EntryPoint = "WritePrivateProfileSectionW", CharSet = CharSet.Auto)]
        public static extern bool setSectionValue(string section, string val, string filePath);
        /// <summary>
        /// 删除指定的key
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool DelIniFileKey(string section, string key, string filePath)
        {
            bool result = false;
            if (WritePrivateProfileString(section, key, null, filePath) != 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 删除指定的section
        /// </summary>
        /// <param name="section"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool DelIniFileSection(string section, string filePath)
        {
            bool result = false;
            if (WritePrivateProfileString(section, null, null, filePath) != 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>  
        /// 读取INI文件中指定INI文件中的所有节点名称(Section)  
        /// </summary>  
        /// <param name="iniFile">Ini文件</param>  
        /// <returns>所有节点,没有内容返回string[0]</returns>  
        public static string[] INIGetAllSectionNames(string iniFile)
        {
            uint MAX_BUFFER = 32767;    //默认为32767  

            string[] sections = new string[0]; //返回值  

            //申请内存  
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));
            uint bytesReturned = GetPrivateProfileSectionNames(pReturnedString, MAX_BUFFER, iniFile);
            if (bytesReturned != 0)
            {
                //读取指定内存的内容  
                string local = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned).ToString();
                //每个节点之间用\0分隔,末尾有一个\0  
                sections = local.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }

            //释放内存  
            Marshal.FreeCoTaskMem(pReturnedString);

            return sections;
        }
        /// <summary>  
        /// 读取INI文件中指定KEY的字符串型值  
        /// </summary>  
        /// <param name="iniFile">Ini文件</param>  
        /// <param name="section">节点名称</param>  
        /// <param name="key">键名称</param>  
        /// <param name="defaultValue">如果没此KEY所使用的默认值</param>  
        /// <returns>读取到的值</returns>  
        public static string GetStringValue(string iniFile, string section, string key, string defaultValue)
        {
            string value = defaultValue;
            const int SIZE = 1024 * 10;

            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("指定的section不存在。", "section");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("指定的key不存在。", "key");
            }
            StringBuilder sbtmp = new StringBuilder(SIZE);
            GetPrivateProfileString(section, key, "", sbtmp, SIZE, iniFile);
            if (sbtmp.ToString().Length == 0)
            {
                value = defaultValue;
            }
            else
            {
                value = sbtmp.ToString();
            }
            return value;
        }
        /// <summary>
        /// 读取INI文件中指定KEY的double型值  
        /// </summary>
        /// <param name="iniFile"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double GetDoubleValue(string iniFile, string section, string key, double defaultValue)
        {
            double value = defaultValue;
            const int SIZE = 1024 * 10;

            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("指定的section不存在。", "section");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("指定的key不存在。", "key");
            }
            StringBuilder sbtmp = new StringBuilder(SIZE);
            GetPrivateProfileString(section, key, "", sbtmp, SIZE, iniFile);
            if (sbtmp.ToString().Length == 0)
            {
                value = defaultValue;
            }
            else
            {
                value = Convert.ToDouble(sbtmp.ToString());
            }
            return value;
        }
        /// <summary>
        /// 读取INI文件中指定KEY的int型值  
        /// </summary>
        /// <param name="iniFile"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetIntValue(string iniFile, string section, string key, int defaultValue)
        {
            int value = defaultValue;
            const int SIZE = 1024 * 10;

            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("指定的section不存在。", "section");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("指定的key不存在。", "key");
            }
            StringBuilder sbtmp = new StringBuilder(SIZE);
            GetPrivateProfileString(section, key, "", sbtmp, SIZE, iniFile);
            if (sbtmp.ToString().Length == 0)
            {
                value = defaultValue;
            }
            else
            {
                value = Convert.ToInt32(sbtmp.ToString());
            }
            return value;
        }


        /// <summary>
        /// 复制文件夹及其子文件夹所有文件
        /// </summary>
        /// <param name="sourceFolderName">源文件夹目录</param>
        /// <param name="destFolderName">目标文件夹目录</param>
        /// <param name="overwrite">允许覆盖文件</param>
        public static void CopyDirectory(string sourceFolderName, string destFolderName, bool overwrite)
        {
            var sourceFilesPath = Directory.GetFileSystemEntries(sourceFolderName);

            for (int i = 0; i < sourceFilesPath.Length; i++)
            {
                var sourceFilePath = sourceFilesPath[i];
                var directoryName = Path.GetDirectoryName(sourceFilePath);
                var forlders = directoryName.Split('\\');
                var lastDirectory = forlders[forlders.Length - 1];
                var dest = Path.Combine(destFolderName, lastDirectory);

                if (File.Exists(sourceFilePath))
                {
                    var sourceFileName = Path.GetFileName(sourceFilePath);
                    if (!Directory.Exists(dest))
                    {
                        Directory.CreateDirectory(dest);
                    }
                    File.Copy(sourceFilePath, Path.Combine(dest, sourceFileName), overwrite);
                }
                else
                {
                    CopyDirectory(sourceFilePath, dest, overwrite);
                }
            }
        }


        #region 点位数据导出为Excel
        public static void DataGridViewExportToExcel(DataGridView dgv, string strTitle)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel 文件 (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.FileName = strTitle + ".xls";

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) //导出时，点击【取消】按钮
            {
                return;
            }

            Stream myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding(-0));

            string strHeaderText = "";

            try
            {
                //写标题
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        strHeaderText += "\t";
                    }

                    strHeaderText += dgv.Columns[i].HeaderText;
                }

                sw.WriteLine(strHeaderText);

                //写内容
                string strItemValue = "";

                for (int j = 0; j < dgv.RowCount; j++)
                {
                    strItemValue = "";

                    for (int k = 0; k < dgv.ColumnCount; k++)
                    {
                        if (k > 0)
                        {
                            strItemValue += "\t";
                        }
                        if (dgv.Rows[j].Cells[k].Value == null) strItemValue += "信息未知";
                        else strItemValue += dgv.Rows[j].Cells[k].Value.ToString();
                    }
                    sw.WriteLine(strItemValue); //把dgv的每一行的信息写为sw的每一行
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(typeof(CommonUtils), ex);
                MessageBox.Show("导出失败!" + ex.Message, "软件提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }
        #endregion


    }//class
}
