using HalconDotNet;
using SXViewROI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SXModelsControl
{
    /// <summary>
    /// 模板匹配工具
    /// </summary>
    public class ShapeModelUtil
    {
        
        /// <summary>
        ///  函数模板  DLL内部使用
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        private static bool ReadVisionModelsNoOrder(HTuple hv_ModelsDir, out List<HTuple> ho_ModelIDs, out List<ROI> ho_ModelRegions, out string errMsg)
        {
            bool thisResult = true;
            errMsg = "";
            
            ho_ModelIDs = new List<HTuple>();
            ho_ModelRegions = new List<ROI>();
            try
            {
                if (!Directory.Exists(hv_ModelsDir))
                {
                    thisResult = false;
                    errMsg = "路径不存在";
                }
                else
                {
                    string[] pros = Directory.GetDirectories(hv_ModelsDir, "*.*", SearchOption.TopDirectoryOnly);
                    foreach (string item in pros)  //依次读取各个模板
                    {
                        string[] curFiles = Directory.GetFiles(item);
                        if (curFiles.Length != 2)
                        {
                            string modelName = item.Substring(item.LastIndexOf('\\') + 1);
                            errMsg += "模板【" + modelName + "】读取失败,文件数量错误";
                            thisResult = false;
                            break;
                        }
                        else
                        {
                            string suffixStr1 = curFiles[0].Substring(curFiles[0].LastIndexOf('.') + 1);
                            string suffixStr2 = curFiles[1].Substring(curFiles[1].LastIndexOf('.') + 1);
                            if ((suffixStr1 == "roi" && suffixStr2 == "sx") || suffixStr1 == "sx" && suffixStr2 == "roi")
                            {
                                for (int i = 0; i < curFiles.Length; i++)
                                {
                                    string suffixStr = curFiles[i].Substring(curFiles[i].LastIndexOf('.') + 1);
                                    switch (suffixStr)
                                    {
                                        case "roi":
                                            {
                                                ROI curReadROI = null;
                                                ModelControlUtil.AntiSerializeROIFile(curFiles[i], out curReadROI, out errMsg);
                                                ho_ModelRegions.Add(curReadROI);
                                            }
                                            break;
                                        case "sx":
                                            {
                                                HTuple curReadModelID = null;
                                                HOperatorSet.ReadShapeModel(curFiles[i], out curReadModelID);
                                                ho_ModelIDs.Add(curReadModelID);
                                            }
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                errMsg += ";" + "模板【" + item + "】读取失败,文件类型错误";
                                thisResult = false;
                                break;
                            }
                        }
                    }
                    if (thisResult)
                    {
                        if (ho_ModelRegions.Count != ho_ModelIDs.Count || ho_ModelRegions.Count == 0)
                        {
                            errMsg = "模板读取失败！ROI数量与模板数量不一致";
                            thisResult = false;
                        }
                        else
                        {
                            errMsg = "";
                            thisResult = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ho_ModelIDs = null;
                ho_ModelRegions = null;
                errMsg = "异常！" + ex.Message;
                thisResult = false;
            }
            return thisResult;
        }

        /// <summary>
        /// 读取视觉模板
        /// </summary>
        /// <param name="hv_ModelsDir">模板所在文件夹</param>
        /// <param name="ho_ModelIDs">读出的模板ID列表</param>
        /// <param name="ho_ModelRegions">读出的ROI列表</param>
        /// <param name="errMsg">返回的错误信息</param>
        /// <returns></returns>
        public static bool ReadVisionModels(HTuple hv_ModelsDir, out List<HTuple> ho_ModelIDs, out List<ROI> ho_ModelRegions, out List<ModelParam> ho_ModelParams, out string errMsg)
        {
            bool thisResult = true;
            errMsg = "";
            
            ho_ModelIDs = new List<HTuple>();
            ho_ModelRegions = new List<ROI>();
            ho_ModelParams = new List<ModelParam>();

            try
            {
                if (!Directory.Exists(hv_ModelsDir))
                {
                    thisResult = false;
                    errMsg = "模板读取失败，模板路径不存在";
                    return thisResult;
                }
                string orderFile = hv_ModelsDir + "\\order.ini";
                if (!File.Exists(orderFile))
                {
                    thisResult = false;
                    errMsg = "模板读取失败，模板顺序路径不存在";
                    return thisResult;
                }
                string[] sections = ModelControlUtil.INIGetAllSectionNames(orderFile);
                for (int i = 0; i < sections.Length; i++)
                {
                    string curModel = ModelControlUtil.GetStringValue(orderFile, i.ToString(), "model", "");
                    string[] curFiles = Directory.GetFiles(hv_ModelsDir + "\\" + curModel);//读取当前模板下所有文件
                    if (curFiles.Length != 4)
                    {
                        errMsg = "模板【" + curModel + "】读取失败,文件数量错误";
                        return false;
                    }
                    string suffixStr1 = curFiles[0].Substring(curFiles[0].LastIndexOf('.') + 1);
                    string suffixStr2 = curFiles[1].Substring(curFiles[1].LastIndexOf('.') + 1);
                    string suffixStr3 = curFiles[2].Substring(curFiles[2].LastIndexOf('.') + 1);
                    string suffixStr4 = curFiles[3].Substring(curFiles[3].LastIndexOf('.') + 1);
                    string[] suffixStrs = new string[] { suffixStr1, suffixStr2, suffixStr3, suffixStr4 };
                    //文件格式不正确  要包含一个roi和一个sx文件
                    if (!(suffixStrs.Contains("sx") && suffixStrs.Contains("roi") && suffixStrs.Contains("bmp") && suffixStrs.Contains("sxp")))
                    {
                        errMsg += ";" + "模板【" + curModel + "】读取失败,文件类型错误";
                        return false;
                    }
                    //依次读取模板文件
                    for (int j = 0; j < curFiles.Length; j++)
                    {
                        string suffixStr = curFiles[j].Substring(curFiles[j].LastIndexOf('.') + 1);
                        switch (suffixStr)
                        {
                            case "roi":
                                {
                                    ROI curReadROI = null;
                                    ModelControlUtil.AntiSerializeROIFile(curFiles[j], out curReadROI, out errMsg);
                                    ho_ModelRegions.Add(curReadROI);
                                }
                                break;
                            case "sx":
                                {
                                    HTuple curReadModelID = null;
                                    HOperatorSet.ReadShapeModel(curFiles[j], out curReadModelID);
                                    ho_ModelIDs.Add(curReadModelID);
                                }
                                break;
                            case "sxp":
                                {
                                    object modelObj = null;
                                    ModelControlUtil.AntiSerializeROIFile(hv_ModelsDir + "\\" + curModel + "\\param.sxp", out modelObj, out errMsg);
                                    ho_ModelParams.Add((ModelParam)modelObj);
                                }
                                break;
                        }
                    }
                }
                if (thisResult)
                {
                    if (ho_ModelRegions.Count != ho_ModelIDs.Count || ho_ModelRegions.Count == 0)
                    {
                        errMsg = "模板读取失败！ROI数量与模板数量不一致";
                        thisResult = false;
                    }
                    else
                    {
                        errMsg = "";
                        thisResult = true;
                    }
                    return thisResult;
                }
            }
            catch (Exception ex)
            {
                ho_ModelIDs = null;
                ho_ModelRegions = null;
                ho_ModelParams = null;
                errMsg = "异常！" + ex.Message;
                thisResult = false;
            }
            return thisResult;
        }

        public static bool ReadVisionModels(HTuple hv_ModelsDir, out List<HTuple> ho_ModelIDs, out List<ArrayList> ho_ModelRegions, out List<ModelParam> ho_ModelParams, out string errMsg)
        {
            bool thisResult = true;
            errMsg = "";

            ho_ModelIDs = new List<HTuple>();
            ho_ModelRegions = new List<ArrayList>();
            ho_ModelParams = new List<ModelParam>();

            try
            {
                if (!Directory.Exists(hv_ModelsDir))
                {
                    thisResult = false;
                    errMsg = "模板读取失败，模板路径不存在";
                    return thisResult;
                }
                string orderFile = hv_ModelsDir + "\\order.ini";
                if (!File.Exists(orderFile))
                {
                    thisResult = false;
                    errMsg = "模板读取失败，模板顺序路径不存在";
                    return thisResult;
                }
                string[] sections = ModelControlUtil.INIGetAllSectionNames(orderFile);
                for (int i = 0; i < sections.Length; i++)
                {
                    string curModel = ModelControlUtil.GetStringValue(orderFile, i.ToString(), "model", "");
                    string[] curFiles = Directory.GetFiles(hv_ModelsDir + "\\" + curModel);//读取当前模板下所有文件
                    if (curFiles.Length != 4)
                    {
                        errMsg = "模板【" + curModel + "】读取失败,文件数量错误";
                        return false;
                    }
                    string suffixStr1 = curFiles[0].Substring(curFiles[0].LastIndexOf('.') + 1);
                    string suffixStr2 = curFiles[1].Substring(curFiles[1].LastIndexOf('.') + 1);
                    string suffixStr3 = curFiles[2].Substring(curFiles[2].LastIndexOf('.') + 1);
                    string suffixStr4 = curFiles[3].Substring(curFiles[3].LastIndexOf('.') + 1);
                    string[] suffixStrs = new string[] { suffixStr1, suffixStr2, suffixStr3, suffixStr4 };
                    //文件格式不正确  要包含一个roi和一个sx文件
                    if (!(suffixStrs.Contains("sx") && suffixStrs.Contains("rois") && suffixStrs.Contains("bmp") && suffixStrs.Contains("sxp")))
                    {
                        errMsg += ";" + "模板【" + curModel + "】读取失败,文件类型错误";
                        return false;
                    }
                    //依次读取模板文件
                    for (int j = 0; j < curFiles.Length; j++)
                    {
                        string suffixStr = curFiles[j].Substring(curFiles[j].LastIndexOf('.') + 1);
                        switch (suffixStr)
                        {
                            case "rois":
                                {
                                    object curReadROI = null;
                                    ModelControlUtil.AntiSerializeROIFile(curFiles[j], out curReadROI, out errMsg);
                                    ho_ModelRegions.Add((ArrayList)curReadROI);
                                }
                                break;
                            case "sx":
                                {
                                    HTuple curReadModelID = null;
                                    HOperatorSet.ReadShapeModel(curFiles[j], out curReadModelID);
                                    ho_ModelIDs.Add(curReadModelID);
                                }
                                break;
                            case "sxp":
                                {
                                    object modelObj = null;
                                    ModelControlUtil.AntiSerializeROIFile(hv_ModelsDir + "\\" + curModel + "\\param.sxp", out modelObj, out errMsg);
                                    ho_ModelParams.Add((ModelParam)modelObj);
                                }
                                break;
                        }
                    }
                }
                if (thisResult)
                {
                    if (ho_ModelRegions.Count != ho_ModelIDs.Count || ho_ModelRegions.Count == 0)
                    {
                        errMsg = "模板读取失败！ROI数量与模板数量不一致";
                        thisResult = false;
                    }
                    else
                    {
                        errMsg = "";
                        thisResult = true;
                    }
                    return thisResult;
                }
            }
            catch (Exception ex)
            {
                ho_ModelIDs = null;
                ho_ModelRegions = null;
                ho_ModelParams = null;
                errMsg = "异常！" + ex.Message;
                thisResult = false;
            }
            return thisResult;
        }
        
        #region 不使用ModelParam参数
        
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
        public static bool FindShapeModel(HObject hv_ModelImage, HTuple ho_ShapeModelID, ROI thisROI, HTuple hv_WindowHandle, HTuple hv_AngleStart, HTuple hv_AngleExtent,
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
                HOperatorSet.DispObj(hv_ModelImage, hv_WindowHandle);
                HOperatorSet.SetSystem("clip_region", "false");
                HOperatorSet.ReduceDomain(hv_ModelImage, thisROI.getRegion(), out ho_ReduceImg);
                HOperatorSet.FindShapeModel(ho_ReduceImg, ho_ShapeModelID, hv_AngleStart, hv_AngleExtent, hv_MinScore, hv_NumMatch,
                    0.5, "least_squares_high", hv_NumLevels, hv_Greediness, out checkRow, out checkColumn, out checkAngle, out checkScore);
                if (checkRow.Length > 0)
                {
                    HOperatorSet.GenCrossContourXld(out ho_CrossXld, checkRow, checkColumn, 60, checkAngle);
                    HOperatorSet.SetColor(hv_WindowHandle, "red");
                    //HOperatorSet.DispObj(ho_CrossXld, hv_WindowHandle);
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
        /// <param name="ho_CheckModelIdx">匹配结果 返回模板ID序号</param>
        /// <param name="errMsg">返回错误信息</param>
        /// <returns></returns>
        public static bool FindShapeModels(HObject hv_ModelImage, List<HTuple> hv_ModelList, List<ROI> hv_RoiList, HTuple hv_WindowHandle, HTuple hv_AngleStart, HTuple hv_AngleExtent,
            HTuple hv_MinScore, HTuple hv_NumMatch, HTuple hv_NumLevels, HTuple hv_Greediness, out HTuple ho_CheckRow, out HTuple ho_CheckColumn,
            out HTuple ho_CheckAngle, out HTuple ho_CheckScore, out HTuple ho_CheckModelIdx, out string errMsg)
        {
            bool thisResult = true;
            HObject ho_ReduceImg, ho_CrossXld, ho_ModelXlds, ho_ModelXldTrans;
            HTuple inputModelIDs = new HTuple();
            HTuple checkRow = new HTuple(), checkColumn = new HTuple(), checkAngle = new HTuple(), checkScore = new HTuple(), checkModeIdx = null;
            HTuple curRow = new HTuple(), curColumn = new HTuple(), curAngle = new HTuple(), curScore = new HTuple(), curModelidx = new HTuple();
            HTuple homMat2D = new HTuple();
            HOperatorSet.GenEmptyObj(out ho_ReduceImg);
            HOperatorSet.GenEmptyObj(out ho_CrossXld);
            try
            {
                if (hv_ModelList.Count != hv_RoiList.Count)
                {
                    ho_CheckRow = null;
                    ho_CheckColumn = null;
                    ho_CheckAngle = null;
                    ho_CheckScore = null;
                    ho_CheckModelIdx = null;
                    errMsg = "错误！模板数量与ROI数量不一致,请核实！";
                    thisResult = true;
                    return thisResult;
                }
                HOperatorSet.DispObj(hv_ModelImage, hv_WindowHandle);
                for (int i = 0; i < hv_ModelList.Count; i++)
                {
                    HOperatorSet.SetSystem("clip_region", "false");
                    HOperatorSet.ReduceDomain(hv_ModelImage, (hv_RoiList[i]).getRegion(), out ho_ReduceImg);
                    HOperatorSet.FindShapeModel(ho_ReduceImg, hv_ModelList[i], hv_AngleStart, hv_AngleExtent, hv_MinScore, hv_NumMatch,
                    0.5, "least_squares_high", hv_NumLevels, hv_Greediness, out checkRow, out checkColumn, out checkAngle, out checkScore);
                    checkModeIdx = new HTuple();
                    for (int modelidx = 0; modelidx < checkRow.Length; modelidx++)
                    {
                        checkModeIdx.Append(i);
                    }
                    if (checkRow.Length > 0)
                    {
                        HOperatorSet.GenCrossContourXld(out ho_CrossXld, checkRow, checkColumn, 60, checkAngle);
                        HOperatorSet.SetColor(hv_WindowHandle, "red");
                        //HOperatorSet.DispObj(ho_CrossXld, hv_WindowHandle);
                        HOperatorSet.GetShapeModelContours(out ho_ModelXlds, hv_ModelList[i], 1);
                        for (int j = 0; j < checkRow.Length; j++)
                        {
                            HOperatorSet.VectorAngleToRigid(0, 0, 0, checkRow[j], checkColumn[j], checkAngle[j], out homMat2D);
                            HOperatorSet.AffineTransContourXld(ho_ModelXlds, out ho_ModelXldTrans, homMat2D);
                            HOperatorSet.DispObj(ho_ModelXldTrans, hv_WindowHandle);
                        }
                    }
                    curRow = curRow.TupleConcat(checkRow);
                    curColumn = curColumn.TupleConcat(checkColumn);
                    curAngle = curAngle.TupleConcat(checkAngle);
                    curScore = curScore.TupleConcat(checkScore);
                    curModelidx = curModelidx.TupleConcat(checkModeIdx);
                }

                ho_CheckRow = curRow;
                ho_CheckColumn = curColumn;
                ho_CheckAngle = curAngle;
                ho_CheckScore = curScore;
                ho_CheckModelIdx = curModelidx;
                ho_ReduceImg.Dispose();
                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                ho_CheckRow = null;
                ho_CheckColumn = null;
                ho_CheckAngle = null;
                ho_CheckScore = null;
                ho_CheckModelIdx = null;
                ho_ReduceImg.Dispose();
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
        public static bool FindShapeModelsOrderBreak(HObject hv_ModelImage, List<HTuple> hv_ModelList, List<ROI> hv_RoiList, HTuple hv_WindowHandle, HTuple hv_AngleStart, HTuple hv_AngleExtent,
            HTuple hv_MinScore, HTuple hv_NumMatch, HTuple hv_NumLevels, HTuple hv_Greediness, out HTuple ho_CheckRow, out HTuple ho_CheckColumn,
            out HTuple ho_CheckAngle, out HTuple ho_CheckScore, out HTuple ho_CheckModelIdx, out string errMsg)
        {
            bool thisResult = true;
            HObject ho_ReduceImg, ho_CrossXld, ho_ModelXlds, ho_ModelXldTrans;
            HTuple inputModelIDs = new HTuple();
            HTuple checkRow = new HTuple(), checkColumn = new HTuple(), checkAngle = new HTuple(), checkScore = new HTuple(), checkModeIdx = null;
            HTuple curRow = new HTuple(), curColumn = new HTuple(), curAngle = new HTuple(), curScore = new HTuple(), curModelidx = new HTuple();
            HTuple homMat2D = new HTuple();
            HOperatorSet.GenEmptyObj(out ho_ReduceImg);
            HOperatorSet.GenEmptyObj(out ho_CrossXld);
            try
            {
                if (hv_ModelList.Count != hv_RoiList.Count)
                {
                    ho_CheckRow = null;
                    ho_CheckColumn = null;
                    ho_CheckAngle = null;
                    ho_CheckScore = null;
                    ho_CheckModelIdx = null;
                    errMsg = "错误！模板数量与ROI数量不一致,请核实！";
                    thisResult = true;
                    return thisResult;
                }
                HOperatorSet.DispObj(hv_ModelImage, hv_WindowHandle);
                for (int i = 0; i < hv_ModelList.Count; i++)
                {
                    HOperatorSet.SetSystem("clip_region", "false");
                    HOperatorSet.ReduceDomain(hv_ModelImage, (hv_RoiList[i]).getRegion(), out ho_ReduceImg);
                    HOperatorSet.FindShapeModel(ho_ReduceImg, hv_ModelList[i], hv_AngleStart, hv_AngleExtent, hv_MinScore, hv_NumMatch,
                    0.5, "least_squares_high", hv_NumLevels, hv_Greediness, out checkRow, out checkColumn, out checkAngle, out checkScore);
                    checkModeIdx = new HTuple();
                    for (int modelidx = 0; modelidx < checkRow.Length; modelidx++)
                    {
                        checkModeIdx.Append(i);
                    }
                    if (checkRow.Length > 0)
                    {
                        HOperatorSet.GenCrossContourXld(out ho_CrossXld, checkRow, checkColumn, 60, checkAngle);
                        HOperatorSet.SetColor(hv_WindowHandle, "red");
                        //HOperatorSet.DispObj(ho_CrossXld, hv_WindowHandle);
                        HOperatorSet.GetShapeModelContours(out ho_ModelXlds, hv_ModelList[i], 1);
                        for (int j = 0; j < checkRow.Length; j++)
                        {
                            HOperatorSet.VectorAngleToRigid(0, 0, 0, checkRow[j], checkColumn[j], checkAngle[j], out homMat2D);
                            HOperatorSet.AffineTransContourXld(ho_ModelXlds, out ho_ModelXldTrans, homMat2D);
                            HOperatorSet.DispObj(ho_ModelXldTrans, hv_WindowHandle);
                        }
                        curRow = curRow.TupleConcat(checkRow);
                        curColumn = curColumn.TupleConcat(checkColumn);
                        curAngle = curAngle.TupleConcat(checkAngle);
                        curScore = curScore.TupleConcat(checkScore);
                        curModelidx = curModelidx.TupleConcat(checkModeIdx);
                        break;
                    }
                }

                ho_CheckRow = curRow;
                ho_CheckColumn = curColumn;
                ho_CheckAngle = curAngle;
                ho_CheckScore = curScore;
                ho_CheckModelIdx = curModelidx;
                ho_ReduceImg.Dispose();
                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                ho_CheckRow = null;
                ho_CheckColumn = null;
                ho_CheckAngle = null;
                ho_CheckScore = null;
                ho_CheckModelIdx = null;
                ho_ReduceImg.Dispose();
                errMsg = ex.Message;
                thisResult = false;
            }
            return thisResult;
        }


        /// <summary>
        /// 模板匹配
        /// </summary>
        /// <param name="hv_ModelImage">要检测的图像</param>
        /// <param name="hv_ModelList">模板句柄列表</param>
        /// <param name="hv_ModelIDIdx">要匹配的模板索引号</param>
        /// <param name="thisROI">ROI区域</param>
        /// <param name="hv_WindowHandle">要显示结果的窗体句柄</param>
        /// <param name="hv_AngleStart">模板匹配其实角度</param>
        /// <param name="hv_AngleExtent">模板匹配角度范围</param>
        /// <param name="hv_MinScore">模板匹配最小相似度</param>
        /// <param name="hv_NumMatch">模板匹配数量</param>
        /// <param name="hv_NumLevels">最大金字塔层数</param>
        /// <param name="hv_Greediness">贪婪度</param>
        /// <param name="ho_CheckRow">匹配结果 横坐标</param>
        /// <param name="ho_CheckColumn">匹配结果 纵坐标</param>
        /// <param name="ho_CheckAngle">匹配结果 角度</param>
        /// <param name="ho_CheckScore">匹配结果 实际相似度</param>
        /// <param name="errMsg">返回错误信息</param>
        /// <returns></returns>
        public static bool FindShapeModelsIdx(HObject hv_ModelImage, List<HTuple> hv_ModelList, HTuple hv_ModelIDIdx, ROI thisROI, HTuple hv_WindowHandle, HTuple hv_AngleStart, HTuple hv_AngleExtent,
            HTuple hv_MinScore, HTuple hv_NumMatch, HTuple hv_NumLevels, HTuple hv_Greediness, out HTuple ho_CheckRow, out HTuple ho_CheckColumn,
            out HTuple ho_CheckAngle, out HTuple ho_CheckScore, out string errMsg)
        {
            bool thisResult = true;
            HObject ho_ReduceImg, ho_CrossXld, ho_ModelXld, ho_ModelXldTrans;
            HTuple checkRow, checkColumn, checkAngle, checkScore;
            HTuple curRow = new HTuple(), curColumn = new HTuple(), curAngle = new HTuple(), curScore = new HTuple();
            HTuple homMat2D = new HTuple();
            HTuple ho_SelectShapeModelID = new HTuple();
            HOperatorSet.GenEmptyObj(out ho_ReduceImg);
            HOperatorSet.GenEmptyObj(out ho_CrossXld);

            try
            {
                HOperatorSet.DispObj(hv_ModelImage, hv_WindowHandle);
                HOperatorSet.SetSystem("clip_region", "false");
                HOperatorSet.ReduceDomain(hv_ModelImage, thisROI.getRegion(), out ho_ReduceImg);
                ho_SelectShapeModelID = hv_ModelList[hv_ModelIDIdx];
                HOperatorSet.FindShapeModel(ho_ReduceImg, ho_SelectShapeModelID, hv_AngleStart, hv_AngleExtent, hv_MinScore, hv_NumMatch,
                    0.5, "least_squares_high", hv_NumLevels, hv_Greediness, out checkRow, out checkColumn, out checkAngle, out checkScore);
                if (checkRow.Length > 0)
                {
                    HOperatorSet.GenCrossContourXld(out ho_CrossXld, checkRow, checkColumn, 60, checkAngle);
                    HOperatorSet.SetColor(hv_WindowHandle, "red");
                    //HOperatorSet.DispObj(ho_CrossXld, hv_WindowHandle);
                }
                if (checkRow.Length > 0)
                {
                    HOperatorSet.GetShapeModelContours(out ho_ModelXld, ho_SelectShapeModelID, 1);
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

        #endregion

        #region 使用ModelParam参数
        /// <summary>
        /// 模板匹配
        /// </summary>
        /// <param name="hv_ModelImage">要检测的图像</param>
        /// <param name="ho_ShapeModelID">模板句柄</param>
        /// <param name="thisROI">ROI区域</param>
        /// <param name="hv_WindowHandle">要显示结果的窗体句柄</param>
        /// <param name="hv_ModelParam">要显示结果的窗体句柄</param>
        /// <param name="ho_CheckRow">匹配结果 横坐标</param>
        /// <param name="ho_CheckColumn">匹配结果 纵坐标</param>
        /// <param name="ho_CheckAngle">匹配结果 角度</param>
        /// <param name="ho_CheckScore">匹配结果 实际相似度</param>
        /// <param name="errMsg">返回错误信息</param>
        /// <returns></returns>
        public static bool FindShapeModel(HObject hv_ModelImage, HTuple ho_ShapeModelID, ROI thisROI, HTuple hv_WindowHandle, ModelParam hv_ModelParam,
            out HTuple ho_CheckRow, out HTuple ho_CheckColumn,
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
                
                HOperatorSet.DispObj(hv_ModelImage, hv_WindowHandle);
                HOperatorSet.SetSystem("clip_region", "false");
                HOperatorSet.ReduceDomain(hv_ModelImage, thisROI.getRegion(), out ho_ReduceImg);
                HOperatorSet.FindShapeModel(ho_ReduceImg, ho_ShapeModelID, hv_ModelParam.AngleStart, hv_ModelParam.AngleExtent, hv_ModelParam.MinScore, hv_ModelParam.NumMatch,
                    0.5, "least_squares_high", hv_ModelParam.NumLevel, hv_ModelParam.GreedIness, out checkRow, out checkColumn, out checkAngle, out checkScore);
                if (checkRow.Length > 0)
                {
                    HOperatorSet.GenCrossContourXld(out ho_CrossXld, checkRow, checkColumn, 60, checkAngle);
                    HOperatorSet.SetColor(hv_WindowHandle, "red");
                    //HOperatorSet.DispObj(ho_CrossXld, hv_WindowHandle);
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
        /// <param name="ho_CheckModelIdx">匹配结果 返回模板ID序号</param>
        /// <param name="errMsg">返回错误信息</param>
        /// <returns></returns>
        public static bool FindShapeModels(HObject hv_ModelImage, List<HTuple> hv_ModelList, List<ROI> hv_RoiList, HTuple hv_WindowHandle, List<ModelParam> hv_ModelParams,
            out HTuple ho_CheckRow, out HTuple ho_CheckColumn,
            out HTuple ho_CheckAngle, out HTuple ho_CheckScore, out HTuple ho_CheckModelIdx, out string errMsg)
        {
            bool thisResult = true;
            HObject ho_ReduceImg, ho_CrossXld, ho_ModelXlds, ho_ModelXldTrans;
            HTuple inputModelIDs = new HTuple();
            HTuple checkRow = new HTuple(), checkColumn = new HTuple(), checkAngle = new HTuple(), checkScore = new HTuple(), checkModeIdx = null;
            HTuple curRow = new HTuple(), curColumn = new HTuple(), curAngle = new HTuple(), curScore = new HTuple(), curModelidx = new HTuple();
            HTuple homMat2D = new HTuple();
            HOperatorSet.GenEmptyObj(out ho_ReduceImg);
            HOperatorSet.GenEmptyObj(out ho_CrossXld);
            try
            {
                
                if (hv_ModelList.Count != hv_RoiList.Count || hv_ModelList.Count != hv_ModelParams.Count)
                {
                    ho_CheckRow = null;
                    ho_CheckColumn = null;
                    ho_CheckAngle = null;
                    ho_CheckScore = null;
                    ho_CheckModelIdx = null;
                    errMsg = "错误！模板数量与ROI数量不一致,请核实！";
                    thisResult = true;
                    return thisResult;
                }
                HOperatorSet.DispObj(hv_ModelImage, hv_WindowHandle);
                for (int i = 0; i < hv_ModelList.Count; i++)
                {
                    HOperatorSet.SetSystem("clip_region", "false");
                    HOperatorSet.ReduceDomain(hv_ModelImage, (hv_RoiList[i]).getRegion(), out ho_ReduceImg);
                    HOperatorSet.FindShapeModel(ho_ReduceImg, hv_ModelList[i], hv_ModelParams[i].AngleStart, hv_ModelParams[i].AngleExtent,
                        hv_ModelParams[i].MinScore, hv_ModelParams[i].NumMatch, 0.5, "least_squares_high", hv_ModelParams[i].NumLevel,
                        hv_ModelParams[i].GreedIness, out checkRow, out checkColumn, out checkAngle, out checkScore);
                    checkModeIdx = new HTuple();
                    for (int modelidx = 0; modelidx < checkRow.Length; modelidx++)
                    {
                        checkModeIdx.Append(i);
                    }
                    if (checkRow.Length > 0)
                    {
                        HOperatorSet.GenCrossContourXld(out ho_CrossXld, checkRow, checkColumn, 60, checkAngle);
                        HOperatorSet.SetColor(hv_WindowHandle, "red");
                        //HOperatorSet.DispObj(ho_CrossXld, hv_WindowHandle);
                        HOperatorSet.GetShapeModelContours(out ho_ModelXlds, hv_ModelList[i], 1);
                        for (int j = 0; j < checkRow.Length; j++)
                        {
                            HOperatorSet.VectorAngleToRigid(0, 0, 0, checkRow[j], checkColumn[j], checkAngle[j], out homMat2D);
                            HOperatorSet.AffineTransContourXld(ho_ModelXlds, out ho_ModelXldTrans, homMat2D);
                            HOperatorSet.DispObj(ho_ModelXldTrans, hv_WindowHandle);
                        }
                        curRow = curRow.TupleConcat(checkRow);
                        curColumn = curColumn.TupleConcat(checkColumn);
                        curAngle = curAngle.TupleConcat(checkAngle);
                        curScore = curScore.TupleConcat(checkScore);
                        curModelidx = curModelidx.TupleConcat(checkModeIdx);
                    }
                }
                ho_CheckRow = curRow;
                ho_CheckColumn = curColumn;
                ho_CheckAngle = curAngle;
                ho_CheckScore = curScore;
                ho_CheckModelIdx = curModelidx;
                ho_ReduceImg.Dispose();
                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                ho_CheckRow = null;
                ho_CheckColumn = null;
                ho_CheckAngle = null;
                ho_CheckScore = null;
                ho_CheckModelIdx = null;
                ho_ReduceImg.Dispose();
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
        public static bool FindShapeModelsOrderBreak(HObject hv_ModelImage, List<HTuple> hv_ModelList, List<ROI> hv_RoiList, HTuple hv_WindowHandle, 
            List<ModelParam> hv_ModelParams,
            out HTuple ho_CheckRow, out HTuple ho_CheckColumn,
            out HTuple ho_CheckAngle, out HTuple ho_CheckScore, out HTuple ho_CheckModelIdx, out string errMsg)
        {
            bool thisResult = true;
            HObject ho_ReduceImg, ho_CrossXld, ho_ModelXlds, ho_ModelXldTrans;
            HTuple inputModelIDs = new HTuple();
            HTuple checkRow = new HTuple(), checkColumn = new HTuple(), checkAngle = new HTuple(), checkScore = new HTuple(), checkModeIdx = null;
            HTuple curRow = new HTuple(), curColumn = new HTuple(), curAngle = new HTuple(), curScore = new HTuple(), curModelidx = new HTuple();
            HTuple homMat2D = new HTuple();
            HOperatorSet.GenEmptyObj(out ho_ReduceImg);
            HOperatorSet.GenEmptyObj(out ho_CrossXld);
            try
            {
                if (hv_ModelList.Count != hv_RoiList.Count || hv_ModelList.Count != hv_ModelParams.Count)
                {
                    ho_CheckRow = null;
                    ho_CheckColumn = null;
                    ho_CheckAngle = null;
                    ho_CheckScore = null;
                    ho_CheckModelIdx = null;
                    errMsg = "错误！模板数量与ROI数量不一致,请核实！";
                    thisResult = true;
                    return thisResult;
                }
                HOperatorSet.DispObj(hv_ModelImage, hv_WindowHandle);
                for (int i = 0; i < hv_ModelList.Count; i++)
                {
                    HOperatorSet.SetSystem("clip_region", "false");
                    HOperatorSet.ReduceDomain(hv_ModelImage, (hv_RoiList[i]).getRegion(), out ho_ReduceImg);
                    HOperatorSet.FindShapeModel(ho_ReduceImg, hv_ModelList[i], hv_ModelParams[i].AngleStart, hv_ModelParams[i].AngleExtent,
                        hv_ModelParams[i].MinScore, hv_ModelParams[i].NumMatch,
                    0.5, "least_squares_high", hv_ModelParams[i].NumLevel, hv_ModelParams[i].GreedIness,
                    out checkRow, out checkColumn, out checkAngle, out checkScore);
                    checkModeIdx = new HTuple();
                    for (int modelidx = 0; modelidx < checkRow.Length; modelidx++)
                    {
                        checkModeIdx.Append(i);
                    }
                    if (checkRow.Length > 0)
                    {
                        HOperatorSet.GenCrossContourXld(out ho_CrossXld, checkRow, checkColumn, 60, checkAngle);
                        HOperatorSet.SetColor(hv_WindowHandle, "red");
                        //HOperatorSet.DispObj(ho_CrossXld, hv_WindowHandle);
                        HOperatorSet.GetShapeModelContours(out ho_ModelXlds, hv_ModelList[i], 1);
                        for (int j = 0; j < checkRow.Length; j++)
                        {
                            HOperatorSet.VectorAngleToRigid(0, 0, 0, checkRow[j], checkColumn[j], checkAngle[j], out homMat2D);
                            HOperatorSet.AffineTransContourXld(ho_ModelXlds, out ho_ModelXldTrans, homMat2D);
                            HOperatorSet.DispObj(ho_ModelXldTrans, hv_WindowHandle);
                        }
                        curRow = curRow.TupleConcat(checkRow);
                        curColumn = curColumn.TupleConcat(checkColumn);
                        curAngle = curAngle.TupleConcat(checkAngle);
                        curScore = curScore.TupleConcat(checkScore);
                        curModelidx = curModelidx.TupleConcat(checkModeIdx);
                        break;
                    }
                }

                ho_CheckRow = curRow;
                ho_CheckColumn = curColumn;
                ho_CheckAngle = curAngle;
                ho_CheckScore = curScore;
                ho_CheckModelIdx = curModelidx;
                ho_ReduceImg.Dispose();
                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                ho_CheckRow = null;
                ho_CheckColumn = null;
                ho_CheckAngle = null;
                ho_CheckScore = null;
                ho_CheckModelIdx = null;
                ho_ReduceImg.Dispose();
                errMsg = ex.Message;
                thisResult = false;
            }
            return thisResult;
        }

        /// <summary>
        /// 模板匹配
        /// </summary>
        /// <param name="hv_ModelImage">要检测的图像</param>
        /// <param name="hv_ModelList">模板句柄列表</param>
        /// <param name="hv_ModelIDIdx">要匹配的模板索引号</param>
        /// <param name="thisROI">ROI区域</param>
        /// <param name="hv_WindowHandle">要显示结果的窗体句柄</param>
        /// <param name="hv_AngleStart">模板匹配其实角度</param>
        /// <param name="hv_AngleExtent">模板匹配角度范围</param>
        /// <param name="hv_MinScore">模板匹配最小相似度</param>
        /// <param name="hv_NumMatch">模板匹配数量</param>
        /// <param name="hv_NumLevels">最大金字塔层数</param>
        /// <param name="hv_Greediness">贪婪度</param>
        /// <param name="ho_CheckRow">匹配结果 横坐标</param>
        /// <param name="ho_CheckColumn">匹配结果 纵坐标</param>
        /// <param name="ho_CheckAngle">匹配结果 角度</param>
        /// <param name="ho_CheckScore">匹配结果 实际相似度</param>
        /// <param name="errMsg">返回错误信息</param>
        /// <returns></returns>
        public static bool FindShapeModelsIdx(HObject hv_ModelImage, List<HTuple> hv_ModelList, HTuple hv_ModelIDIdx, List<ROI> roiList, 
            List<ModelParam> modelParams,
            HTuple hv_WindowHandle, out HTuple ho_CheckRow, out HTuple ho_CheckColumn,
            out HTuple ho_CheckAngle, out HTuple ho_CheckScore, out string errMsg)
        {
            bool thisResult = true;
            HObject ho_ReduceImg, ho_CrossXld, ho_ModelXld, ho_ModelXldTrans;
            HTuple checkRow, checkColumn, checkAngle, checkScore;
            HTuple curRow = new HTuple(), curColumn = new HTuple(), curAngle = new HTuple(), curScore = new HTuple();
            HTuple homMat2D = new HTuple();
            HTuple ho_SelectShapeModelID = new HTuple();
            HOperatorSet.GenEmptyObj(out ho_ReduceImg);
            HOperatorSet.GenEmptyObj(out ho_CrossXld);

            try
            {
               
                HOperatorSet.DispObj(hv_ModelImage, hv_WindowHandle);
                HOperatorSet.SetSystem("clip_region", "false");
                HOperatorSet.ReduceDomain(hv_ModelImage, roiList[hv_ModelIDIdx].getRegion(), out ho_ReduceImg);
                ho_SelectShapeModelID = hv_ModelList[hv_ModelIDIdx];
                HOperatorSet.FindShapeModel(ho_ReduceImg, ho_SelectShapeModelID, modelParams[hv_ModelIDIdx].AngleStart, modelParams[hv_ModelIDIdx].AngleExtent,
                    modelParams[hv_ModelIDIdx].MinScore, modelParams[hv_ModelIDIdx].NumMatch,
                    0.5, "least_squares_high", modelParams[hv_ModelIDIdx].NumLevel, modelParams[hv_ModelIDIdx].GreedIness,
                    out checkRow, out checkColumn, out checkAngle, out checkScore);
                if (checkRow.Length > 0)
                {
                    HOperatorSet.GenCrossContourXld(out ho_CrossXld, checkRow, checkColumn, 60, checkAngle);
                    HOperatorSet.SetColor(hv_WindowHandle, "red");
                    //HOperatorSet.DispObj(ho_CrossXld, hv_WindowHandle);
                }
                if (checkRow.Length > 0)
                {
                    HOperatorSet.GetShapeModelContours(out ho_ModelXld, ho_SelectShapeModelID, 1);
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
        
        /// <summary>
        /// 模板匹配
        /// </summary>
        /// <param name="hv_ModelImage">要检测的图像</param>
        /// <param name="ho_ShapeModelID">模板句柄</param>
        /// <param name="thisROI">ROI区域</param>
        /// <param name="hv_WindowHandle">要显示结果的窗体句柄</param>
        /// <param name="hv_ModelParam">要显示结果的窗体句柄</param>
        /// <param name="ho_CheckRow">匹配结果 横坐标</param>
        /// <param name="ho_CheckColumn">匹配结果 纵坐标</param>
        /// <param name="ho_CheckAngle">匹配结果 角度</param>
        /// <param name="ho_CheckScore">匹配结果 实际相似度</param>
        /// <param name="errMsg">返回错误信息</param>
        /// <returns></returns>
        public static bool FindShapeModel(HObject hv_ModelImage, HTuple ho_ShapeModelID, ROI thisROI, HTuple hv_WindowHandle, ModelParam hv_ModelParam,
             HTuple hv_CameraParam, HTuple hv_PoseParam,
            out HTuple ho_CheckRow, out HTuple ho_CheckColumn, out HTuple ho_CheckAngle, out HTuple ho_CheckScore,
             out double ho_DisRow, out double ho_DisCol,
            out string errMsg)
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
                HOperatorSet.DispObj(hv_ModelImage, hv_WindowHandle);
                HOperatorSet.SetSystem("clip_region", "false");
                HOperatorSet.ReduceDomain(hv_ModelImage, thisROI.getRegion(), out ho_ReduceImg);
                HOperatorSet.FindShapeModel(ho_ReduceImg, ho_ShapeModelID, hv_ModelParam.AngleStart, hv_ModelParam.AngleExtent, hv_ModelParam.MinScore, 1,
                    0.5, "least_squares_high", hv_ModelParam.NumLevel, hv_ModelParam.GreedIness, out checkRow, out checkColumn, out checkAngle, out checkScore);
                if (checkRow.Length > 0)
                {
                    HOperatorSet.GenCrossContourXld(out ho_CrossXld, checkRow, checkColumn, 60, checkAngle);
                    HOperatorSet.SetColor(hv_WindowHandle, "red");
                    //HOperatorSet.DispObj(ho_CrossXld, hv_WindowHandle);
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

                HTuple worldRowFind, worldColFind, worldRowCenter, worldColCenter;
                HTuple imgWidth, imgHeight;
                PointToWorld(hv_CameraParam, hv_PoseParam, curRow, curColumn, "mm", out worldRowFind, out worldColFind, out errMsg);
                HOperatorSet.GetImageSize(hv_ModelImage, out imgWidth, out imgHeight);
                PointToWorld(hv_CameraParam, hv_PoseParam, imgHeight / 2, imgWidth / 2, "mm", out worldRowCenter, out worldColCenter, out errMsg);
                ho_DisRow = (worldRowCenter - worldRowFind).D;
                ho_DisCol = (worldColCenter - worldColFind).D;

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
                ho_DisRow = -1;
                ho_DisCol = -1;
                ho_ReduceImg.Dispose();
                errMsg = ex.Message;
                thisResult = false;
            }
            return thisResult;
        }
        #endregion

        /// <summary>
        /// 将像素坐标转换为实际坐标
        /// </summary>
        /// <param name="hv_CameraParam">相机内参</param>
        /// <param name="hv_CameraPos">相机外参</param>
        /// <param name="hv_PointRow">像素点横坐标</param>
        /// <param name="hv_PointCol">像素点纵坐标</param>
        /// <param name="hv_Scale">单位 um,mm,cm,m </param>
        /// <param name="hv_WorldRow">转换结果 世界坐标系横坐标</param>
        /// <param name="hv_WorldCol">转换结果 世界坐标系纵坐标</param>
        /// <param name="errMsg">返回的错误信息</param>
        /// <returns></returns>
        public static bool PointToWorld(HTuple hv_CameraParam, HTuple hv_CameraPos, HTuple hv_PointRow, HTuple hv_PointCol, HTuple hv_Scale,
            out HTuple hv_WorldRow, out HTuple hv_WorldCol, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                HOperatorSet.ImagePointsToWorldPlane(hv_CameraParam, hv_CameraPos, hv_PointRow, hv_PointCol, hv_Scale, out hv_WorldRow, out hv_WorldCol);
                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                hv_WorldRow = -1;
                hv_WorldCol = -1;
                errMsg = ex.Message;
                thisResult = false;
            }
            return thisResult;
        }

       
        public static bool TransRoi(HTuple hv_ModelRow, HTuple hv_ModelColumn, HTuple hv_Row, 
            HTuple hv_Column, HTuple hv_Angle, HObject hv_Roi, out HObject hv_transRoi, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                HTuple homMate2d;
                HOperatorSet.VectorAngleToRigid(hv_ModelRow, hv_ModelColumn, 0, hv_Row, hv_Column, hv_Angle, out homMate2d);
                HOperatorSet.AffineTransRegion(hv_Roi, out hv_transRoi, homMate2d, "nearest_neighbor");
                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                hv_transRoi = null;
                thisResult = false;
            }
            return thisResult;
        }

        public static bool TransRoi(HTuple hv_ModelRow, HTuple hv_ModelColumn, HTuple hv_Row,
            HTuple hv_Column, HTuple hv_Angle, ArrayList hv_Rois, out ArrayList hv_transRoi, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                hv_transRoi = new ArrayList();
                HObject transRegion;
                HOperatorSet.GenEmptyObj(out transRegion);
                for (int i = 0; i < hv_Rois.Count; i++)
                {
                    transRegion.Dispose();
                    HTuple homMate2d;
                    HOperatorSet.VectorAngleToRigid(hv_ModelRow, hv_ModelColumn, 0, hv_Row, hv_Column, hv_Angle, out homMate2d);
                    HOperatorSet.AffineTransRegion((HObject)hv_Rois[i], out transRegion, homMate2d, "nearest_neighbor");
                    hv_transRoi[i] = transRegion.Clone();
                }
                transRegion.Dispose();
                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                hv_transRoi = null;
                thisResult = false;
            }
            return thisResult;
        }









        private static bool FuncModel(out string errMsg)
        {
            bool thisResult = true;
            try
            {
                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                thisResult = false;
            }
            return thisResult;
        }





    }
}
