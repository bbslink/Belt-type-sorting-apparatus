using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class FileHandle
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="myObject"></param>
        public static void SerializeFile(Object myObject, string filePath)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, myObject);
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write)) // 使用UTF8编码格式 覆写已存在的文件
                {
                    byte[] buffer = ms.ToArray();
                    fs.Write(buffer, 0, buffer.GetLength(0));
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("错误0xFI001, 序列化文件失败\r" + ex.Message);
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
                throw new Exception("错误0xFI002, 反序列化文件失败\r" + ex.Message);
            }
        }


    }
}
