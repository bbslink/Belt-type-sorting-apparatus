using HalconDotNet;
using SXViewROI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SXModelsControl
{
    
    internal class ModelControlUtil
    {

        /// <summary>
        /// 序列化ROI
        /// </summary>
        /// <param name="myObject"></param>
        internal static bool SerializeROIFile(Object myObject, string filePath,out string errMsg)
        {
            bool thisResult = true;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, myObject);
                stream.Close();

                thisResult = true;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = ex.Message;
            }
            return thisResult;
        }

        /// <summary>
        /// 反序列化ROI
        /// </summary>
        /// <returns></returns>
        internal static bool AntiSerializeROIFile(string filePath, out object obj, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                if (!File.Exists(filePath))
                {
                    errMsg = "文件不存在";
                    thisResult = false;
                    obj = null;
                }
                else
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
                    object myObj = (object)formatter.Deserialize(stream);
                    stream.Close();
                    obj = myObj;
                    errMsg = "";
                }
            }
            catch (Exception ex)
            {
                thisResult = false;
                obj = null;
                errMsg = ex.Message;
            }
            return thisResult;
        }

        /// <summary>
        /// 反序列化ROI
        /// </summary>
        /// <returns></returns>
        internal static bool AntiSerializeROIFile(string filePath, out ROI obj, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                if (!File.Exists(filePath))
                {
                    errMsg = "文件不存在";
                    thisResult = false;
                    obj = null;
                }
                else
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
                    ROI myObj = (ROI)formatter.Deserialize(stream);
                    stream.Close();
                    obj = myObj;
                    errMsg = "";
                }
            }
            catch (Exception ex)
            {
                thisResult = false;
                obj = null;
                errMsg = ex.Message;
            }
            return thisResult;
        }

        /// <summary>
        /// 反序列化文件
        /// </summary>
        /// <returns></returns>
        internal static bool AntiSerializeROIFile(string filePath, out HObject obj, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                if (!File.Exists(filePath))
                {
                    errMsg = "文件不存在";
                    thisResult = false;
                    obj = null;
                }
                else
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
                    HObject myObj = (HObject)formatter.Deserialize(stream);
                    stream.Close();
                    obj = myObj;
                    errMsg = "";
                }
            }
            catch (Exception ex)
            {
                thisResult = false;
                obj = null;
                errMsg = ex.Message;
            }
            return thisResult;
        }

        /// <summary>
        /// 创建匹配模板
        /// </summary>
        /// <param name="hv_ModelXLD">轮廓</param>
        /// <param name="hv_NumLevels">最大金字塔层数</param>
        /// <param name="hv_AngleStart">模板匹配起始角度</param>
        /// <param name="hv_AngleExtent">模板匹配角度范围</param>
        /// <param name="hv_MinContrast">最小阈值</param>
        /// <param name="hv_ModelPath">模板保存路径</param>
        /// <param name="ho_ShapeModelID">模板句柄</param>
        /// <param name="errMsg">返回错误信息</param>
        /// <returns></returns>
        internal static bool CreateShapeModelXld(HObject hv_ModelXLD, HTuple hv_NumLevels, HTuple hv_AngleStart, HTuple hv_AngleExtent, HTuple hv_MinContrast,
            HTuple hv_ModelPath, out HTuple ho_ShapeModelID, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                HOperatorSet.CreateShapeModelXld(hv_ModelXLD, hv_NumLevels, hv_AngleStart, hv_AngleExtent,
                    "auto", "point_reduction_high", "ignore_global_polarity", hv_MinContrast, out ho_ShapeModelID);
                HOperatorSet.WriteShapeModel(ho_ShapeModelID, hv_ModelPath);
                thisResult = true;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                ho_ShapeModelID = null;
                errMsg = ex.Message;
            }
            return thisResult;
        }

        /// <summary>
        /// 读取匹配模板
        /// </summary>
        /// <param name="hv_ModelPath">模板保存路径</param>
        /// <param name="ho_ModelModelID">模板句柄</param>
        /// <param name="errMsg">返回错误信息</param>
        /// <returns></returns>
        internal static bool ReadShapeModel(HTuple hv_ModelPath, out HTuple ho_ShapeModelID, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                HOperatorSet.ReadShapeModel(hv_ModelPath, out ho_ShapeModelID);
                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                ho_ShapeModelID = null;
                errMsg = ex.Message;
                thisResult = false;
            }
            return thisResult;
        }

        /// <summary>
        /// 模板匹配
        /// </summary>
        /// <param name="hv_ModelImage">要检测的图像</param>
        /// <param name="ho_ShapeModelID">模板句柄</param>
        /// <param name="thisROI">ROI区域</param>
        /// <param name="hv_WindowHandle">要显示结果的窗体句柄</param>
        /// <param name="hv_AngleStart">模板匹配其实角度</param>
        /// <param name="hv_AngleExtent">模板匹配角度范围</param>
        /// <param name="hv_MinScore">模板匹配最小相似度</param>
        /// <param name="hv_NumMatch">模板匹配数量</param>
        /// <param name="hv_NumLevels">最大金字塔层数</param>
        /// <param name="ho_CheckRow">匹配结果 横坐标</param>
        /// <param name="ho_CheckColumn">匹配结果 纵坐标</param>
        /// <param name="ho_CheckAngle">匹配结果 角度</param>
        /// <param name="ho_CheckScore">匹配结果 实际相似度</param>
        /// <param name="errMsg">返回错误信息</param>
        /// <returns></returns>
        internal static bool ReduceAndFindShapeModel(HObject hv_ModelImage, HTuple ho_ShapeModelID, ROI thisROI, HTuple hv_WindowHandle, HTuple hv_AngleStart, HTuple hv_AngleExtent,
            HTuple hv_MinScore, HTuple hv_NumMatch, HTuple hv_NumLevels, HTuple hv_Greediness, out HTuple ho_CheckRow, out HTuple ho_CheckColumn,
            out HTuple ho_CheckAngle, out HTuple ho_CheckScore, out string errMsg)
        {
            bool thisResult = true;
            HObject ho_ReduceImg, ho_CrossXld, ho_ModelXld, ho_ModelXldTrans;
            HTuple checkRow, checkColumn, checkAngle, checkScore;
            HTuple curRow = new HTuple(), curColumn = new HTuple(), curAngle = new HTuple(), curScore = new HTuple();
            HTuple homMat2D = new HTuple();
            HOperatorSet.GenEmptyObj(out ho_ReduceImg);
            HOperatorSet.GenEmptyObj(out ho_CrossXld);

            try
            {
                HOperatorSet.SetSystem("clip_region", "false");
                HOperatorSet.ReduceDomain(hv_ModelImage, thisROI.getRegion(), out ho_ReduceImg);
                HOperatorSet.FindShapeModel(ho_ReduceImg, ho_ShapeModelID, hv_AngleStart, hv_AngleExtent, hv_MinScore, hv_NumMatch,
                    0.5, "least_squares_high", hv_NumLevels, hv_Greediness, out checkRow, out checkColumn, out checkAngle, out checkScore);
                if (checkRow.Length > 0)
                {
                    HOperatorSet.GenCrossContourXld(out ho_CrossXld, checkRow, checkColumn, 100, checkAngle);
                    HOperatorSet.SetColor(hv_WindowHandle, "red");
                    HOperatorSet.DispObj(ho_CrossXld, hv_WindowHandle);
                }
                if (checkRow.Length > 0)
                {
                    HOperatorSet.GetShapeModelContours(out ho_ModelXld, ho_ShapeModelID, 1);
                    for (int j = 0; j < checkColumn.Length; j++)
                    {
                        HOperatorSet.VectorAngleToRigid(0, 0, 0, checkRow[j], checkColumn[j], checkAngle[j], out homMat2D);
                        HOperatorSet.AffineTransContourXld(ho_ModelXld, out ho_ModelXldTrans, homMat2D);
                        HOperatorSet.DispObj(ho_ModelXldTrans, hv_WindowHandle);
                        HOperatorSet.SetLineWidth(hv_WindowHandle, 1);
                        HOperatorSet.WriteString(hv_WindowHandle, checkAngle[j] + ":" + checkScore[j] + ";");
                    }
                }
                curRow = curRow.TupleConcat(checkRow);
                curColumn = curColumn.TupleConcat(checkColumn);
                curAngle = curAngle.TupleConcat(checkAngle);
                curScore = curScore.TupleConcat(checkScore);

                ho_CheckRow = curRow;
                ho_CheckColumn = curColumn;
                ho_CheckAngle = curAngle;
                ho_CheckScore = curScore;

                ho_ReduceImg.Dispose();
                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                ho_CheckRow = -1;
                ho_CheckColumn = -1;
                ho_CheckAngle = -1;
                ho_CheckScore = -1;
                ho_ReduceImg.Dispose();
                errMsg = ex.Message;
                thisResult = false;
            }
            return thisResult;
        }

        

        #region INI文件操作工具
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
        internal static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        /// <summary>
        /// 写section值
        /// </summary>
        /// <param name="section"></param>
        /// <param name="val"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32", EntryPoint = "WritePrivateProfileSectionW", CharSet = CharSet.Auto)]
        internal static extern bool setSectionValue(string section, string val, string filePath);
        /// <summary>
        /// 删除指定的key
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        internal static bool DelIniFileKey(string section, string key, string filePath)
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
        internal static bool DelIniFileSection(string section, string filePath)
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
        internal static string[] INIGetAllSectionNames(string iniFile)
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
        internal static string GetStringValue(string iniFile, string section, string key, string defaultValue)
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
        internal static double GetDoubleValue(string iniFile, string section, string key, double defaultValue)
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
        internal static int GetIntValue(string iniFile, string section, string key, int defaultValue)
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
        #endregion
    }

    /// <summary>
    /// 模板参数类
    /// </summary>
    [Serializable]
    public class ModelParam
    {
        HTuple angleStart;//起始角度
        HTuple angleExtent;//角度范围
        HTuple minThreshold;//最小色差
        HTuple minScore;//最小相似度
        HTuple numMatch;//匹配数量
        HTuple numLevel;//金字塔层数
        HTuple greedIness;//贪婪度
        string modelPath;//模板保存路径
        public ModelParam() { }
        public ModelParam(HTuple hv_angleStart, HTuple hv_angleExtent, HTuple hv_minThreshold, HTuple hv_minScore,
            HTuple hv_numMatch, HTuple hv_numLevel, HTuple hv_greedIness, string hv_modelPath)
        {
            angleStart = hv_angleStart;
            angleExtent = hv_angleExtent;
            minThreshold = hv_minThreshold;
            minScore = hv_minScore;
            numMatch = hv_numMatch;
            numLevel = hv_numLevel;
            greedIness = hv_greedIness;
            modelPath = hv_modelPath;
        }
        public HTuple AngleStart
        {
            get { return angleStart; }
            set { angleStart = value; }
        }
        public HTuple AngleExtent
        {
            get { return angleExtent; }
            set { angleExtent = value; }
        }
        public HTuple MinThreshold
        {
            get { return minThreshold; }
            set { minThreshold = value; }
        }
        public HTuple MinScore
        {
            get { return minScore; }
            set { minScore = value; }
        }
        public HTuple NumMatch
        {
            get { return numMatch; }
            set { numMatch = value; }
        }
        public HTuple NumLevel
        {
            get { return numLevel; }
            set { numLevel = value; }
        }
        public HTuple GreedIness
        {
            get { return greedIness; }
            set { greedIness = value; }
        }
        public string ModelPath
        {
            get { return modelPath; }
            set { modelPath = value; }
        }
    }
}
