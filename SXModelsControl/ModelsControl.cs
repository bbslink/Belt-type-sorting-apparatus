using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SXModelMasking;
using HalconDotNet;
using SXViewROI;
using System.IO;
using System.Collections;

namespace SXModelsControl
{
    /// <summary>
    /// 模板制作控件
    /// </summary>
    public partial class ModelsControl : UserControl
    {
        /// <summary>
        /// 模板训练变量
        /// </summary>
        HObject maskResultXld = null;
        string errMsg = "";
        HObject curImage = null;//当前窗体图像
        HObject activeImage = null;//当前选中ROI截取的图像
        ROI activeROI;//当前选中的ROI
        HTuple ho_ShapeModel;//当前模板ID
        ROI curROI;//模板查找区域
        HTuple curWinHandle = null;//当前窗体句柄
        string lastOpenDir = "-1";//记录上次打开地址

        //相机内参
        static HTuple hv_CameraParam;
        //相机外参
        static HTuple hv_PoseParam;
        
        /// <summary>
        /// 相机设置变量
        /// </summary>
        public ModelsControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 触发相机拍照委托
        /// </summary>
        public delegate void CamSnapShotEventHandler(int camIdx);
        public CamSnapShotEventHandler CamSnapShotEvent;
        public void CamSnapShot(int camIdx)
        {
            if (CamSnapShotEvent != null)
            {
                CamSnapShotEvent(camIdx);
            }
        }

        /// <summary>
        /// 显示图像
        /// </summary>
        /// <param name="curFrame">要显示的图像</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns></returns>
        public bool DispImage(HObject curFrame, out string errMsg)
        {
            try
            {
                if (dispControl1.DisplayImage(curFrame, out errMsg))
                {
                    errMsg = "";
                    return true;
                }
                else
                {
                    return false; 
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        #region 模板训练函数

        private void btn_MaskModel_Click(object sender, EventArgs e)
        {
            if (cb_CurModels.SelectedIndex < 0)
            {
                MessageBox.Show("请选择要配置的模板");
                return;
            }
            dispControl1.GetActiveROI(out activeROI, out errMsg);
            dispControl1.GetWindowImage(out curImage, out errMsg);
            if (curImage == null)
            {
                MessageBox.Show("请先采集图像");
                return;
            }
            if (activeROI == null)
            {
                MessageBox.Show("请至少选中一个ROI");
                return;
            }
            dispControl1.GetActiveImage(out activeImage, out errMsg);
            FrmMask frmMask = new FrmMask(activeImage, "bmp");
            FrmMask.PostMaskResultEvent += new FrmMask.PostMaskResultEventHandler(GetResultXld);
            frmMask.ShowDialog();
        }

        private void GetResultXld(HObject resultXld)
        {
            FrmMask.PostMaskResultEvent -= new FrmMask.PostMaskResultEventHandler(GetResultXld);
            maskResultXld = resultXld;
        }

        private void btn_SaveROI_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_CurModels.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择要保存的模板");
                    return;
                }
                if (tb_SaveModelPath.Text.Trim() == "")
                {
                    MessageBox.Show("请选择模板保存路径");
                    return;
                }
                int activeIdx;
                dispControl1.GetActiveROIIdx(out activeIdx, out errMsg);
                if (activeIdx < 0)
                {
                    MessageBox.Show("请选中一个ROI");
                    return;
                }
                ROI activeROI;
                dispControl1.GetActiveROI(out activeROI, out errMsg);
                if (!ModelControlUtil.SerializeROIFile(activeROI, tb_SaveModelPath.Text + "\\" + cb_CurModels.Text + "\\ModelRegion.roi", out errMsg))
                {
                    MessageBox.Show("保存失败：" + errMsg);
                }
                else
                {
                    MessageBox.Show("保存成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常！" + ex.Message, "提示");
            }
        }
        private void btn_SaveROIs_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_CurModels.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择要保存的模板");
                    return;
                }
                if (tb_SaveModelPath.Text.Trim() == "")
                {
                    MessageBox.Show("请选择模板保存路径");
                    return;
                }
                int roiNum;
                dispControl1.GetROICount(out roiNum, out errMsg);
                if (MessageBox.Show("是否要将当前窗口中所有【"+roiNum+"】个ROI保存？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                ArrayList allRois;
                dispControl1.GetROIList(out allRois, out errMsg);
                //if (!ModelControlUtil.SerializeROIFile(allRois, tb_SaveModelPath.Text + "\\" + cb_CurModels.Text + "\\ModelRegion.rois", out errMsg))
                //{
                //    MessageBox.Show("保存失败：" + errMsg);
                //}
                if (!ModelControlUtil.SerializeROIFile(allRois, tb_SaveModelPath.Text + "\\" + cb_CurModels.Text + "\\ModelRegion.rois", out errMsg))
                {
                    MessageBox.Show("保存失败：" + errMsg);
                }
                else
                {
                    MessageBox.Show("保存成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常！" + ex.Message, "提示");
            }
        }

      
        private void btn_SaveModelPath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "选择模板保存路径";
                if (lastOpenDir != "-1")
                {
                    dialog.SelectedPath = lastOpenDir;
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(dialog.SelectedPath))
                    {
                        MessageBox.Show(this, "文件夹路径不能为空", "提示");
                        return;
                    }
                    tb_SaveModelPath.Text = dialog.SelectedPath;
                    lastOpenDir = tb_SaveModelPath.Text; 
                    QueryModelNames(tb_SaveModelPath.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常！" + ex.Message, "提示");
            }
        }
        
        private void btn_CreateModel_Click(object sender, EventArgs e)
        {
            if (cb_CurModels.SelectedIndex < 0)
            {
                MessageBox.Show("请选择要训练的模板");
                return;
            }
            if (maskResultXld == null)
            {
                MessageBox.Show("请先制作模板轮廓");
                return;
            }
            if (tb_AngleStart.Value.ToString().Trim() == "")
            {
                MessageBox.Show("请填写起始角度");
                return;
            }
            if (tb_AngleExtent.Value.ToString().Trim() == "")
            {
                MessageBox.Show("请填写角度范围");
                return;
            }
            if (tb_MinThreshold.Value.ToString().Trim() == "")
            {
                MessageBox.Show("请填写最小色差");
                return;
            }
            if (tb_SaveModelPath.Text.Trim() == "")
            {
                MessageBox.Show("请选择模板保存路径");
                return;
            }

            bool result = ModelControlUtil.CreateShapeModelXld(maskResultXld, 4, Convert.ToDouble(tb_AngleStart.Value),
                Convert.ToDouble(tb_AngleExtent.Value), Convert.ToDouble(tb_MinThreshold.Value),
                tb_SaveModelPath.Text + "\\" + cb_CurModels.Text + "\\Model.sx", out ho_ShapeModel, out errMsg);
            if (!result)
            {
                MessageBox.Show("训练失败,请核实");
            }
            else
            {
                MessageBox.Show("训练成功");
            }
        }

        private void btn_TestModelLoad_Click(object sender, EventArgs e)
        {
            TestModelButton(1);
        }

        private void btn_TestModelActive_Click(object sender, EventArgs e)
        {
            TestModelButton(2);
        }

        private void TestModelButton(int roiSource)
        {
            try
            {
                if (cb_CurModels.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择要测试的模板");
                    return;
                }
                dispControl1.GetWindowImage(out curImage, out errMsg);
                if (curImage == null)
                {
                    MessageBox.Show("请先加载图像");
                    return;
                }
                if (tb_MinScore.Value.ToString() == "")
                {
                    MessageBox.Show("请填写最小相似度");
                    return;
                }
                switch (roiSource)
                {
                    case 1:
                        {
                            if (!ModelControlUtil.AntiSerializeROIFile(tb_SaveModelPath.Text + "\\" + cb_CurModels.Text + "\\ModelRegion.roi", out curROI, out errMsg))
                            {
                                MessageBox.Show("模板【" + cb_CurModels.Text + "】ROI读取失败！" + errMsg);
                                return;
                            }
                        }
                        break;
                    case 2:
                        {
                            dispControl1.GetActiveROI(out curROI, out errMsg);
                            if (curROI == null)
                            {
                                MessageBox.Show("请至少选中一个ROI！");
                                return;
                            }
                        }
                        break;
                }
                
                if (!ModelControlUtil.ReadShapeModel(tb_SaveModelPath.Text + "\\" + cb_CurModels.Text + "\\Model.sx", out ho_ShapeModel, out errMsg))
                {
                    MessageBox.Show("模板【" + cb_CurModels.Text + "】读取失败！" + errMsg);
                    return;
                }
                HTuple ho_Row = null, ho_Col = null, ho_Angle = null, ho_Score = null;
                dispControl1.GetWindowHandle(out curWinHandle, out errMsg);
                dispControl1.DisplayROI(curROI, out errMsg);
                bool result = ModelControlUtil.ReduceAndFindShapeModel(curImage, ho_ShapeModel, ((ROI)curROI), curWinHandle, Convert.ToDouble(tb_AngleStart.Value),
                    Convert.ToDouble(tb_AngleExtent.Value), Convert.ToDouble(tb_MinScore.Value), Convert.ToDouble(tb_MatchNum.Value),
                    4, Convert.ToDouble(tb_Greediness.Value), out ho_Row, out ho_Col, out ho_Angle, out ho_Score, out errMsg);
                
                if (ho_Row == null || ho_Row.Length <= 0 || !result)
                {
                    tb_RealInfo.Text = "";
                    return;
                }
                else
                {
                    tb_RealInfo.Text = "";
                    for (int ii = 0; ii < ho_Row.Length; ii++)
                    {
                        tb_RealInfo.AppendText("Index:" + ii + "：\r\n");
                        tb_RealInfo.AppendText("Row:" + ho_Row[ii] + "\r\n");
                        tb_RealInfo.AppendText("Column:" + ho_Col[ii] + "\r\n");
                        HTuple angleSel = ho_Angle[ii];
                        tb_RealInfo.AppendText("Angle Rad:" + angleSel + "\r\n");
                        tb_RealInfo.AppendText("Angle Deg:" + angleSel.TupleDeg() + "\r\n");
                        tb_RealInfo.AppendText("Score:" + ho_Score[ii] + "\r\n");
                        //转换到世界坐标
                        if (hv_PoseParam == null || hv_CameraParam == null)
                        {
                            continue;
                        }
                        HTuple worldRow, worldCol;
                        PointToWorld(hv_CameraParam, hv_PoseParam, ho_Row[ii], ho_Col[ii], "mm", out worldRow, out worldCol, out errMsg);
                        tb_RealInfo.AppendText("WorldRow:" + worldRow + "\r\n");
                        tb_RealInfo.AppendText("WorldColumn:" + worldCol + "\r\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("测试异常！" + ex.Message);
            }
        }

        public bool SetCameraPoseParam(HTuple camparamPath,HTuple poseparamPath,out string errMsg)
        {
            try
            {
                HOperatorSet.ReadCamPar(camparamPath, out hv_CameraParam);
                HOperatorSet.ReadPose(poseparamPath, out hv_PoseParam);
                errMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

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

        /// <summary>
        /// 使用委托将结果传输出去
        /// </summary>
        /// <param name="attachedImage"></param>
        public delegate void PostModelResultEventHandler(ModelParam modelParam);
        public static PostModelResultEventHandler PostModelResultEvent;
        public void PostMaskResult(ModelParam modelParam)
        {
            if (PostModelResultEvent != null)
            {
                PostModelResultEvent(modelParam);
            }
        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_SaveModelPath.Text.Trim() == "")
                {
                    MessageBox.Show("请选择模板保存路径");
                    return;
                }
                if (tb_ModelsNoOrder.Items.Count > 0 && tb_ModelsOrder.Items.Count <= 0)
                {
                    MessageBox.Show("请配置模板顺序");
                    return;
                }
                if (cb_CurModels.Text == "")
                {
                    MessageBox.Show("请选择要保存的模板");
                    return;
                }
                string orderFile = tb_SaveModelPath.Text + "\\order.ini";
                if (File.Exists(orderFile))
                {
                    File.Delete(orderFile);
                }
                for (int i = 0; i < tb_ModelsOrder.Items.Count; i++)
                {
                    ModelControlUtil.WritePrivateProfileString(i.ToString(), "model", tb_ModelsOrder.Items[i].ToString(), orderFile);
                }
                ModelParam modelParam = new ModelParam(Convert.ToInt32(tb_AngleStart.Value), Convert.ToInt32(tb_AngleExtent.Value),
                    Convert.ToInt32(tb_MinThreshold.Value), float.Parse(tb_MinScore.Value.ToString()), Convert.ToInt32(tb_MatchNum.Value),
                    Convert.ToInt32(tb_NumLevel.Value), float.Parse(tb_Greediness.Value.ToString()), tb_SaveModelPath.Text);
                PostMaskResult(modelParam);
                dispControl1.GetWindowImage(out curImage, out errMsg);
                if (curImage == null)
                {
                    MessageBox.Show("请加载模板图像！");
                }
                HOperatorSet.WriteImage(curImage, "bmp", 0, tb_SaveModelPath.Text + "\\" + cb_CurModels.Text + "\\modelimg.bmp");
                ModelControlUtil.SerializeROIFile(modelParam, tb_SaveModelPath.Text + "\\" + cb_CurModels.Text + "\\param.sxp", out errMsg);
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// 设置模板保存路径
        /// </summary>
        /// <param name="savePath"></param>
        public void SetModelSavePath(string savePath)
        {
            tb_SaveModelPath.Text = savePath;
        }

        /// <summary>
        /// 设置模板保存路径按钮是否可用
        /// </summary>
        /// <param name="canEnable"></param>
        public void SetModelSavePathEnable(bool canEnable)
        {
            btn_SaveModelPath.Enabled = canEnable;
        }

        /// <summary>
        /// 加载产品模板到控件
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool LoadModels(out string errMsg)
        {
            try
            {
                if (tb_SaveModelPath.Text.Trim() == "")
                {
                    errMsg = "请先设置模板路径";
                    return false;
                }
                if (!Directory.Exists(tb_SaveModelPath.Text))
                {
                    errMsg = "模板路径不存在";
                    return false;
                }
                QueryModelNames(tb_SaveModelPath.Text);
                errMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        private void btn_NewModel_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_NewModel.Text.Trim() == "")
                {
                    MessageBox.Show("请填写产品模板名称！");
                    return;
                }
                if (tb_SaveModelPath.Text.Trim() == "")
                {
                    MessageBox.Show("请选择模板保存路径！");
                    return;
                }
                if (!Directory.Exists(tb_SaveModelPath.Text))
                {
                    Directory.CreateDirectory(tb_SaveModelPath.Text);
                }
                string proPath = tb_SaveModelPath.Text + "\\" + tb_NewModel.Text;
                if (Directory.Exists(proPath))
                {
                    MessageBox.Show("该模板名称已存在，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb_NewModel.Focus();
                    return;
                }
                Directory.CreateDirectory(tb_SaveModelPath.Text + "\\" + tb_NewModel.Text);
                QueryModelNames(tb_SaveModelPath.Text);
                tb_NewModel.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("模板创建失败！" + ex.Message);
            }
        }

        /// <summary>
        /// 加载所有产品名称
        /// </summary>
        private void QueryModelNames(string modelsPath)
        {
            if (!Directory.Exists(modelsPath))
            {
                Directory.CreateDirectory(modelsPath);
            }
            string[] pros = Directory.GetDirectories(modelsPath, "*.*", SearchOption.TopDirectoryOnly);
            tb_AllModels.Items.Clear();
            cb_CurModels.Items.Clear();
            foreach (string item in pros)
            {
                int startIndex = item.LastIndexOf('\\');
                string thisPro = item.Substring(startIndex + 1);
                tb_AllModels.Items.Add(thisPro);
                cb_CurModels.Items.Add(thisPro);
            }
        }

        private void btn_DelModel_Click(object sender, EventArgs e)
        {
            if (tb_SaveModelPath.Text.Trim() == "")
            {
                MessageBox.Show("请选择模板保存路径！");
                return;
            }
            if (tb_AllModels.SelectedIndex < 0)
            {
                MessageBox.Show("请选择要删除的模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("删除后数据将不可恢复,是否删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Directory.Delete(tb_SaveModelPath.Text + "\\" + tb_AllModels.SelectedItem, true);
                QueryModelNames(tb_SaveModelPath.Text);
                if (tb_AllModels.Items.Count <= 0)
                {
                    string orderFile = tb_SaveModelPath.Text + "\\order.ini";
                    if (File.Exists(orderFile))
                    {
                        File.Delete(orderFile);
                    }
                }
            }
        }

        private void btn_ToOrder_Click(object sender, EventArgs e)
        {
            if (tb_ModelsNoOrder.SelectedIndex < 0)
            {
                return;
            }
            tb_ModelsOrder.Items.Add(tb_ModelsNoOrder.SelectedItem);
            tb_ModelsNoOrder.Items.Remove(tb_ModelsNoOrder.SelectedItem);
        }

        private void btn_RemoveOrder_Click(object sender, EventArgs e)
        {
            if (tb_ModelsOrder.SelectedIndex < 0)
            {
                return;
            }
            tb_ModelsNoOrder.Items.Add(tb_ModelsOrder.SelectedItem);
            tb_ModelsOrder.Items.Remove(tb_ModelsOrder.SelectedItem);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                
            }
            else if(tabControl1.SelectedIndex == 2)//加载模板顺序
            {
                tb_ModelsOrder.Items.Clear();
                if (tb_SaveModelPath.Text.Trim() == "")
                {
                    return;
                }
                string orderFile = tb_SaveModelPath.Text + "\\order.ini";
                if (File.Exists(orderFile))
                {
                    string[] sections = ModelControlUtil.INIGetAllSectionNames(orderFile);
                    for (int i = 0; i < sections.Length; i++)
                    {
                        tb_ModelsOrder.Items.Add(ModelControlUtil.GetStringValue(orderFile, i.ToString(), "model", ""));
                    }
                }
                QueryModelNamesOrder(tb_SaveModelPath.Text);
            }
        }
        
        private void QueryModelNamesOrder(string modelsPath)
        {
            if (!Directory.Exists(modelsPath))
            {
                Directory.CreateDirectory(modelsPath);
            }
            string[] pros = Directory.GetDirectories(modelsPath, "*.*", SearchOption.TopDirectoryOnly);
            tb_ModelsNoOrder.Items.Clear();
            foreach (string item in pros)
            {
                int startIndex = item.LastIndexOf('\\');
                string thisPro = item.Substring(startIndex + 1);
                if (!tb_ModelsOrder.Items.Contains(thisPro))
                {
                    tb_ModelsNoOrder.Items.Add(thisPro);
                }
            }
        }

        private void btn_ResetOrder_Click(object sender, EventArgs e)
        {
            if (tb_SaveModelPath.Text.Trim() == "")
            {
                MessageBox.Show("请选择模板保存路径");
                return;
            }
            string orderFile = tb_SaveModelPath.Text + "\\order.ini";
            if (File.Exists(orderFile))
            {
                File.Delete(orderFile);
            }
            tb_ModelsOrder.Items.Clear();
            QueryModelNamesOrder(tb_SaveModelPath.Text);
        }

        private void btn_SnapShot_Click(object sender, EventArgs e)
        {
            CamSnapShot(cb_CurCamera.SelectedIndex);
        }

        private void btn_GoSaveData_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void cb_CurModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(tb_SaveModelPath.Text + "\\" + cb_CurModels.Text + "\\modelimg.bmp"))
                {
                    HObject readedImg;
                    HOperatorSet.ReadImage(out readedImg, tb_SaveModelPath.Text + "\\" + cb_CurModels.Text + "\\modelimg.bmp");
                    dispControl1.DisplayImage(readedImg, out errMsg);
                }
                if (File.Exists(tb_SaveModelPath.Text + "\\" + cb_CurModels.Text + "\\param.sxp"))
                {
                    object modelObj = null;
                    ModelControlUtil.AntiSerializeROIFile(tb_SaveModelPath.Text + "\\" + cb_CurModels.Text + "\\param.sxp", out modelObj, out errMsg);
                    ModelParam modelParam = (ModelParam)modelObj;
                    tb_AngleStart.Value = (decimal)modelParam.AngleStart.D;
                    tb_AngleExtent.Value = (decimal)modelParam.AngleExtent.D;
                    tb_MinThreshold.Value = (decimal)modelParam.MinThreshold.I;
                    tb_MinScore.Value = (decimal)modelParam.MinScore.D;
                    tb_MatchNum.Value = (decimal)modelParam.NumMatch.I;
                    tb_Greediness.Value = (decimal)modelParam.GreedIness.D;
                }
            }
            catch (Exception) { }
        }

        public bool SetCameraList(List<string> camList, out string errMsg)
        {
            try
            {
                cb_CurCamera.Items.Clear();
                
                for (int i = 0; i < camList.Count; i++)
                {
                    cb_CurCamera.Items.Add(camList[i]);
                }
                errMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        
    }
}
