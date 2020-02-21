using Belt_type_sorting_apparatus.CommonClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    public partial class CheckPointSet : Form
    {

        PointControl CurUpCameraFrontModelClass = null;
        PointControl CurUpCameraBehindModelClass = null;
        PointControl CurDownCameraFrontModelClass = null;
        PointControl CurDownCameraBehindModelClass = null;
        PointControl CurDepthFrontModelClass = null;
        PointControl CurDepthBehindModelClass = null;

        int dgv_selectRowIndex = 0;//datagridview中选中的点的行号
        int curX_1 = 0;
        int curY_1 = 0;
        int curDepthDelta_X = 0;
        int curDepthDelta_Y = 0;
        int curSelectData = -1;
        public CheckPointSet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载运动点位
        /// </summary>
        private void LoadProPoints(string curModel)
        {
            GetModelClass();
           
            if (curModel.Equals("前载台上相机模板"))
            {
                dgv_ProPoints1.Rows.Clear();

                if (CurUpCameraFrontModelClass.ModelPoints == null || CurUpCameraFrontModelClass.ModelPoints.Count <= 0)
                {
                    return;
                }
               
                string[] curRow = new string[4];
                for (int idx = 0; idx < CurUpCameraFrontModelClass.ModelPoints.Count; idx++)
                {
                    curRow[0] = idx.ToString();
                    string[] curArrayItem = CurUpCameraFrontModelClass.ModelPoints[idx].ToString().Split(' ');
                    curRow[1] = curArrayItem[0];
                    curRow[2] = curArrayItem[1];              
                    curRow[3] = curModel;
                    dgv_ProPoints1.Rows.Add(curRow);
                    if (idx % 2 != 0)
                    {
                        dgv_ProPoints1.Rows[idx].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
            else if (curModel.Equals("后载台上相机模板"))
            {

                dgv_ProPoints1.Rows.Clear();
                if (CurUpCameraBehindModelClass.ModelPoints == null || CurUpCameraBehindModelClass.ModelPoints.Count <= 0)
                {
                    return;
                }

                string[] curRow = new string[4];
                for (int idx = 0; idx < CurUpCameraBehindModelClass.ModelPoints.Count; idx++)
                {
                    curRow[0] = idx.ToString();
                    string[] curArrayItem = CurUpCameraBehindModelClass.ModelPoints[idx].ToString().Split(' ');
                    curRow[1] = curArrayItem[0];
                    curRow[2] = curArrayItem[1];
                    curRow[3] = curModel;
                    dgv_ProPoints1.Rows.Add(curRow);
                    if (idx % 2 != 0)
                    {
                        dgv_ProPoints1.Rows[idx].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
            else if (curModel.Equals("前载台下相机模板"))
            {

                dgv_ProPoints2.Rows.Clear();
                if (CurDownCameraFrontModelClass.ModelPoints == null || CurDownCameraFrontModelClass.ModelPoints.Count <= 0)
                {
                    return;
                }

                string[] curRow = new string[4];
                for (int idx = 0; idx < CurDownCameraFrontModelClass.ModelPoints.Count; idx++)
                {
                    curRow[0] = idx.ToString();
                    string[] curArrayItem = CurDownCameraFrontModelClass.ModelPoints[idx].ToString().Split(' ');
                    curRow[1] = curArrayItem[0];
                    curRow[2] = curArrayItem[1];
                    curRow[3] = curModel;
                    dgv_ProPoints2.Rows.Add(curRow);
                    if (idx % 2 != 0)
                    {
                        dgv_ProPoints2.Rows[idx].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
            else if (curModel.Equals("后载台下相机模板"))
            {

                dgv_ProPoints2.Rows.Clear();
                if (CurDownCameraBehindModelClass.ModelPoints == null || CurDownCameraBehindModelClass.ModelPoints.Count <= 0)
                {
                    return;
                }

                string[] curRow = new string[4];
                for (int idx = 0; idx < CurDownCameraBehindModelClass.ModelPoints.Count; idx++)
                {
                    curRow[0] = idx.ToString();
                    string[] curArrayItem = CurDownCameraBehindModelClass.ModelPoints[idx].ToString().Split(' ');
                    curRow[1] = curArrayItem[0];
                    curRow[2] = curArrayItem[1];
                    curRow[3] = curModel;
                    dgv_ProPoints2.Rows.Add(curRow);
                    if (idx % 2 != 0)
                    {
                        dgv_ProPoints2.Rows[idx].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
            else if (curModel.Equals("前载台探高模板"))
            {

                dgv_ProPoints3.Rows.Clear();
                if (CurDepthFrontModelClass.ModelPoints == null || CurDepthFrontModelClass.ModelPoints.Count <= 0)
                {
                    return;
                }

                string[] curRow = new string[5];
                for (int idx = 0; idx < CurDepthFrontModelClass.ModelPoints.Count; idx++)
                {
                    curRow[0] = idx.ToString();
                    string[] curArrayItem = CurDepthFrontModelClass.ModelPoints[idx].ToString().Split(' ');
                    curRow[1] = curArrayItem[0];
                    curRow[2] = curArrayItem[1];
                    curRow[3] = curArrayItem[2];
                    curRow[4] = curModel;
                    dgv_ProPoints3.Rows.Add(curRow);
                    if (idx % 2 != 0)
                    {
                        dgv_ProPoints3.Rows[idx].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
            else if (curModel.Equals("后载台探高模板"))
            {

                dgv_ProPoints3.Rows.Clear();
                if (CurDepthBehindModelClass.ModelPoints == null || CurDepthBehindModelClass.ModelPoints.Count <= 0)
                {
                    return;
                }

                string[] curRow = new string[5];
                for (int idx = 0; idx < CurDepthBehindModelClass.ModelPoints.Count; idx++)
                {
                    curRow[0] = idx.ToString();
                    string[] curArrayItem = CurDepthBehindModelClass.ModelPoints[idx].ToString().Split(' ');
                    curRow[1] = curArrayItem[0];
                    curRow[2] = curArrayItem[1];
                    curRow[3] = curArrayItem[2];
                    curRow[4] = curModel;
                    dgv_ProPoints3.Rows.Add(curRow);
                    if (idx % 2 != 0)
                    {
                        dgv_ProPoints3.Rows[idx].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
         
        }

        private void GetModelClass()
        {
            try
            {
                CommonData.saveData.PointModels.TryGetValue("前载台上相机模板", out CurUpCameraFrontModelClass);
                CommonData.saveData.PointModels.TryGetValue("后载台上相机模板", out CurUpCameraBehindModelClass);
                CommonData.saveData.PointModels.TryGetValue("前载台下相机模板", out CurDownCameraFrontModelClass);
                CommonData.saveData.PointModels.TryGetValue("后载台下相机模板", out CurDownCameraBehindModelClass);
                CommonData.saveData.PointModels.TryGetValue("前载台探高模板", out CurDepthFrontModelClass);
                CommonData.saveData.PointModels.TryGetValue("后载台探高模板", out CurDepthBehindModelClass);
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(this.GetType(), ex);
            }
        }


        private bool CheckIsCompelte(int select)
        {
            if (select == 1)
            {
                if (dgv_ProPoints1.Rows.Count <= 0)
                {
                    return false;
                }

                for (int i = 0; i < dgv_ProPoints1.Rows.Count; i++)
                {
                    foreach (DataGridViewCell columnItem in dgv_ProPoints1.Rows[i].Cells)
                    {
                        if (columnItem.Value == null || columnItem.Value.ToString().Trim() == "")
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            else if (select == 2)
            {
                if (dgv_ProPoints2.Rows.Count <= 0)
                {
                    return false;
                }

                for (int i = 0; i < dgv_ProPoints2.Rows.Count; i++)
                {
                    foreach (DataGridViewCell columnItem in dgv_ProPoints2.Rows[i].Cells)
                    {
                        if (columnItem.Value == null || columnItem.Value.ToString().Trim() == "")
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            else
            {
                if (dgv_ProPoints3.Rows.Count <= 0)
                {
                    return false;
                }

                for (int i = 0; i < dgv_ProPoints3.Rows.Count; i++)
                {
                    foreach (DataGridViewCell columnItem in dgv_ProPoints3.Rows[i].Cells)
                    {
                        if (columnItem.Value == null || columnItem.Value.ToString().Trim() == "")
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        private void SavePoint(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否保存数据？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }

                Button temp = (Button)sender;
                if (temp.Name.Equals("btn_save1"))
                {
                    if (!CheckIsCompelte(1))
                    {
                        MessageBox.Show("请将数据填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cb_SelectProModel1.SelectedIndex == 0)
                    {
                        GetModelClass();

                        if (CurUpCameraFrontModelClass.ModelPoints == null)
                        {
                            CurUpCameraFrontModelClass.ModelPoints = new ArrayList();
                        }

                        CurUpCameraFrontModelClass.ModelPoints.Clear();
                        //if (CurUpCameraFrontModelClass.ModelPoints != null && CurUpCameraFrontModelClass.ModelPoints.Count > 0)
                        //{
                        //    CurUpCameraFrontModelClass.ModelPoints.Clear();
                        //}

                        for (int idx = 0; idx < dgv_ProPoints1.Rows.Count; idx++)
                        {
                            string curPointStr = dgv_ProPoints1.Rows[idx].Cells[1].Value.ToString() + " " + dgv_ProPoints1.Rows[idx].Cells[2].Value.ToString();
                            CurUpCameraFrontModelClass.ModelPoints.Add(curPointStr);
                        }
                    }
                    else if (cb_SelectProModel1.SelectedIndex == 1)
                    {
                        GetModelClass();

                        if (CurUpCameraBehindModelClass.ModelPoints == null)
                        {
                            CurUpCameraBehindModelClass.ModelPoints = new ArrayList();
                        }

                        CurUpCameraBehindModelClass.ModelPoints.Clear();
                        //if (CurUpCameraFrontModelClass.ModelPoints != null && CurUpCameraFrontModelClass.ModelPoints.Count > 0)
                        //{
                        //    CurUpCameraFrontModelClass.ModelPoints.Clear();
                        //}

                        for (int idx = 0; idx < dgv_ProPoints1.Rows.Count; idx++)
                        {
                            string curPointStr = dgv_ProPoints1.Rows[idx].Cells[1].Value.ToString() + " " + dgv_ProPoints1.Rows[idx].Cells[2].Value.ToString();
                            CurUpCameraBehindModelClass.ModelPoints.Add(curPointStr);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择要配置的模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    LoadProPoints(cb_SelectProModel1.Text);
                }
                else if (temp.Name.Equals("btn_save2"))
                {
                    if (!CheckIsCompelte(2))
                    {
                        MessageBox.Show("请将数据填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cb_SelectProModel2.SelectedIndex == 0)
                    {
                        GetModelClass();

                        if (CurDownCameraFrontModelClass.ModelPoints == null)
                        {
                            CurDownCameraFrontModelClass.ModelPoints = new ArrayList();
                        }

                        CurDownCameraFrontModelClass.ModelPoints.Clear();
                        //if (CurUpCameraFrontModelClass.ModelPoints != null && CurUpCameraFrontModelClass.ModelPoints.Count > 0)
                        //{
                        //    CurUpCameraFrontModelClass.ModelPoints.Clear();
                        //}

                        for (int idx = 0; idx < dgv_ProPoints2.Rows.Count; idx++)
                        {
                            string curPointStr = dgv_ProPoints2.Rows[idx].Cells[1].Value.ToString() + " " + dgv_ProPoints2.Rows[idx].Cells[2].Value.ToString();
                            CurDownCameraFrontModelClass.ModelPoints.Add(curPointStr);
                        }
                    }
                    else if (cb_SelectProModel2.SelectedIndex == 1)
                    {
                        GetModelClass();

                        if (CurDownCameraBehindModelClass.ModelPoints == null)
                        {
                            CurDownCameraBehindModelClass.ModelPoints = new ArrayList();
                        }

                        CurDownCameraBehindModelClass.ModelPoints.Clear();
                        //if (CurUpCameraFrontModelClass.ModelPoints != null && CurUpCameraFrontModelClass.ModelPoints.Count > 0)
                        //{
                        //    CurUpCameraFrontModelClass.ModelPoints.Clear();
                        //}

                        for (int idx = 0; idx < dgv_ProPoints2.Rows.Count; idx++)
                        {
                            string curPointStr = dgv_ProPoints2.Rows[idx].Cells[1].Value.ToString() + " " + dgv_ProPoints2.Rows[idx].Cells[2].Value.ToString();
                            CurDownCameraBehindModelClass.ModelPoints.Add(curPointStr);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择要配置的模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    LoadProPoints(cb_SelectProModel2.Text);
                }
                else if (temp.Name.Equals("btn_save3"))
                {
                    if (!CheckIsCompelte(3))
                    {
                        MessageBox.Show("请将数据填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cb_SelectProModel3.SelectedIndex == 0)
                    {
                        GetModelClass();

                        if (CurDepthFrontModelClass.ModelPoints == null)
                        {
                            CurDepthFrontModelClass.ModelPoints = new ArrayList();
                        }

                        CurDepthFrontModelClass.ModelPoints.Clear();
                        //if (CurUpCameraFrontModelClass.ModelPoints != null && CurUpCameraFrontModelClass.ModelPoints.Count > 0)
                        //{
                        //    CurUpCameraFrontModelClass.ModelPoints.Clear();
                        //}

                        for (int idx = 0; idx < dgv_ProPoints3.Rows.Count; idx++)
                        {
                            string curPointStr = dgv_ProPoints3.Rows[idx].Cells[1].Value.ToString() + " " + dgv_ProPoints3.Rows[idx].Cells[2].Value.ToString() + " " + dgv_ProPoints3.Rows[idx].Cells[3].Value.ToString();
                            CurDepthFrontModelClass.ModelPoints.Add(curPointStr);
                        }
                    }
                    else if (cb_SelectProModel3.SelectedIndex == 1)
                    {
                        GetModelClass();

                        if (CurDepthBehindModelClass.ModelPoints == null)
                        {
                            CurDepthBehindModelClass.ModelPoints = new ArrayList();
                        }

                        CurDepthBehindModelClass.ModelPoints.Clear();
                        //if (CurUpCameraFrontModelClass.ModelPoints != null && CurUpCameraFrontModelClass.ModelPoints.Count > 0)
                        //{
                        //    CurUpCameraFrontModelClass.ModelPoints.Clear();
                        //}

                        for (int idx = 0; idx < dgv_ProPoints3.Rows.Count; idx++)
                        {
                            string curPointStr = dgv_ProPoints3.Rows[idx].Cells[1].Value.ToString() + " " + dgv_ProPoints3.Rows[idx].Cells[2].Value.ToString() + " " + dgv_ProPoints3.Rows[idx].Cells[3].Value.ToString();
                            CurDepthBehindModelClass.ModelPoints.Add(curPointStr);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择要配置的模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    LoadProPoints(cb_SelectProModel3.Text);
                }
                else
                {
                    throw new Exception("界面配置错误！");
                }
                FileHandle.SerializeFile(CommonData.saveData, CommonData.CurProFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (cb_SelectProModel3.SelectedIndex < 0)
            {
                MessageBox.Show("请选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("是否以当前位置为基准生成模板的【" + cb_SelectProModel3.Text + "】检测坐标？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (CheckIsCompelte(3))
            {
                if (MessageBox.Show("模板【" + cb_SelectProModel3.Text + "】的工作点位已存在,是否覆盖？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    //return;
                }
                else
                {
                    //删除表格中数据
                    dgv_ProPoints3.Rows.Clear();
                }
            }



            int curCount = dgv_ProPoints3.Rows.Count;//当前已有点位数量
            ArrayList curArrayList;
            if (cb_SelectProModel3.SelectedIndex == 0)
            {
                curArrayList = CurUpCameraFrontModelClass.ModelPoints;
            }
            else
            {
                curArrayList = CurUpCameraBehindModelClass.ModelPoints;
            }

            if (curArrayList == null || curArrayList.Count == 0)
            {

                MessageBox.Show("偏移检测模板数据为空，请检查！");
                return;
            }
            int i = 0;
            foreach (var curKV in curArrayList)
            {

                string[] curArray = curKV.ToString().Split(' ');

                string[] curData = new string[] { (i + curCount).ToString(), curArray[0]+ curDepthDelta_X, curArray[1]+ curDepthDelta_Y, curArray[1] + curDepthDelta_Y+1844, cb_SelectProModel3.Text };
                dgv_ProPoints3.Rows.Add(curData);
                i++;

            }



        }




        private void button1_Click(object sender, EventArgs e)
        {

            if (cb_SelectProModel1.SelectedIndex == 0)
            {
                curX_1 = CardControl.AxisNowPosition(CommonData.axisProductReceive_Front);
            }
            else if (cb_SelectProModel1.SelectedIndex == 1)
            {
                curX_1 = CardControl.AxisNowPosition(CommonData.axisProductReceive_Behind);
            }
            else
            {
                MessageBox.Show("请选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            curY_1 = CardControl.AxisNowPosition(CommonData.axisCameraUp);
        }

        private bool CheckCurKeyExist(string curKey)
        {
            bool checkResult = false;
            if (dgv_ProPoints1.Rows.Count <= 0)
            {
                return checkResult;
            }
            foreach (DataGridViewRow item in dgv_ProPoints1.Rows)
            {
                if (item.Cells[3].Value != null)
                {
                    if (item.Cells[3].Value.ToString() == curKey)
                    {
                        checkResult = true;
                        break;
                    }
                }
            }
            return checkResult;
        }

       

        //private void btn_SubmitPro_Click(object sender, EventArgs e)
        //{
        //    if (cb_SelectProModel.SelectedIndex < 0)
        //    {
        //        MessageBox.Show("请选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    if (MessageBox.Show("是否以当前位置为基准生成模板的【" + cb_SelectProModel.Text + "】检测坐标？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        //    {
        //        return;
        //    }
        //    if (CheckCurKeyExist(cb_SelectProModel.Text))
        //    {
        //        if (MessageBox.Show("模板【" + cb_SelectProModel.Text + "】的工作点位已存在,是否覆盖？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        //        {
        //            //return;
        //        }
        //        else
        //        {
        //            //删除表格中数据
        //            for (int i = 0; i < dgv_ProPoints.Rows.Count; i++)
        //            {
        //                if (dgv_ProPoints.Rows[i].Cells[5].Value.ToString() == cb_SelectProModel.Text)
        //                {
        //                    dgv_ProPoints.Rows.RemoveAt(i);
        //                    i--;
        //                }
        //            }
        //            //删除点位中数据
        //            GetCurUpCameraModelClass(cb_SelectProModel.Text);
        //            if (CurUpCameraModelClass.ModelPoints == null)
        //            {
        //                CurUpCameraModelClass.ModelPoints = new ArrayList();
        //            }
        //            CurUpCameraModelClass.ModelPoints.Clear();
        //        }
        //    }

        //    int curY2;
        //    if (cb_SelectProModel.SelectedIndex == 0)
        //    {
        //        curY2 = CardControl.AxisNowPosition(CommonData.axisProductReceive_Front);
        //    }
        //    else
        //    {
        //        curY2 = CardControl.AxisNowPosition(CommonData.axisProductReceive_Behind);
        //    }
        //    int curX2 = CardControl.AxisNowPosition(CommonData.axisCameraUp);


        //    int rowNum = Convert.ToInt32(tb_ProRowNum.Text);
        //    int columnNum = Convert.ToInt32(tb_ProColumnNum.Text);
        //    double perRowDis = 0, perColumnDis = 0;

        //    if (rowNum != 1)
        //    {
        //        perRowDis = (curX2 - curX_1) / (rowNum - 1);
        //    }
        //    if (columnNum != 1)
        //    {
        //        perColumnDis = (curY_1-curY2) / (columnNum - 1);
        //    }

        //    int thisX, thisY;
        //    for (int i = 0; i < columnNum; i++)
        //    {
        //        double s = Math.at(yPoints[j] - curY2, xPoints[i] - curX2) + CommonData.saveData.detangle;
        //        double q = Math.Sqrt(Math.Pow((yPoints[j] - curY2), 2) + Math.Pow((xPoints[i] - curX2), 2));
        //        thisY = (int)(curY_1 + perColumnDis * i);
        //        for (int j = 0; j < rowNum; j++)
        //        {
        //            thisX = (int)(curX_1 + perRowDis * j);

        //            string[] curData = new string[] { (i * rowNum + j).ToString(), thisX.ToString(), thisY.ToString(), cb_SelectProModel.Text };
        //            dgv_ProPoints.Rows.Add(curData);
        //        }

        //    }
        //}


        private void btn_SubmitPro_Click(object sender, EventArgs e)
        {

            if (cb_SelectProModel1.SelectedIndex < 0)
            {
                MessageBox.Show("请选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("是否以当前位置为基准生成模板的【" + cb_SelectProModel1.Text + "】检测坐标？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (CheckIsCompelte(1))
            {
                if (MessageBox.Show("模板【" + cb_SelectProModel1.Text + "】的工作点位已存在,是否覆盖？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    //return;
                }
                else
                {
                    //删除表格中数据
                    dgv_ProPoints1.Rows.Clear();
                }
            }


            int curX2;

            if (cb_SelectProModel1.SelectedIndex == 0)
            {
                curX2 = CardControl.AxisNowPosition(CommonData.axisProductReceive_Front);
            }
            else 
            {
                curX2 = CardControl.AxisNowPosition(CommonData.axisProductReceive_Behind);
            }

            int curY2 = CardControl.AxisNowPosition(CommonData.axisCameraUp);

            double rowDis = Convert.ToDouble(tb_ProRowDis.Text);
            double columnDis = Convert.ToDouble(tb_ProColumnDis.Text);
            int rowNum = Convert.ToInt32(tb_ProRowNum.Text);
            int columnNum = Convert.ToInt32(tb_ProColumnNum.Text);

            int curCount = dgv_ProPoints1.Rows.Count;//当前已有点位数量
            int[] xPoints = new int[columnNum];
            int[] yPoints = new int[rowNum];
            double[,] results = new double[columnNum * rowNum, 2];


            if (curX_1 == 0 && curY_1 == 0)
            {
                MessageBox.Show("没有示教点");
                return;
            }


            double detangle;
            //int xcommon = (int)(curX2 + columnDis * (columnNum - 1) * 1000);       
            int xcommon = (int)(curX2 - columnDis * (columnNum - 1) * 1000);
            int ycommon = (int)(curY2 + rowDis * (rowNum - 1) * 1000);
            double angcommon = Math.Atan2(ycommon - curY2, xcommon - curX2);
            detangle = Math.Atan2(curY_1 - curY2, curX_1 - curX2) - angcommon;

            //for (int xi = 0; xi < columnNum; xi++)
            //{
            //    xPoints[xi] = (int)(curX2 + xi * columnDis * 1000);  
            //}
            for (int xi = 0; xi < columnNum; xi++)
            {
                xPoints[xi] = (int)(curX2 - xi * columnDis * 1000);
            }
            for (int yi = 0; yi < rowNum; yi++)
            {
                yPoints[yi] = (int)(curY2 + yi * rowDis * 1000);
            }


            int curIndex = 0;//当前行序号

            for (int i = 0; i < columnNum; i++)
            {
                if (curIndex == 0) //从低到高
                {
                    for (int j = 0; j < rowNum; j++)
                    {
                        double s = Math.Atan2(yPoints[j] - curY2, xPoints[i] - curX2) + detangle;
                        double q = Math.Sqrt(Math.Pow((yPoints[j] - curY2), 2) + Math.Pow((xPoints[i] - curX2), 2));
                        int thisX = (int)(curX2 + q * Math.Cos(s));
                        int thisY = (int)(curY2 + q * Math.Sin(s));            
                        string[] curData = new string[] { (i * rowNum + j + curCount).ToString(), thisX.ToString(), thisY.ToString(), cb_SelectProModel1.Text };
                        dgv_ProPoints1.Rows.Add(curData);
                        curIndex = j;
                    }
                }
                else if (curIndex == rowNum - 1)//从高到低
                {
                    for (int j = rowNum - 1; j >= 0; j--)
                    {
                        double s = Math.Atan2(yPoints[j] - curY2, xPoints[i] - curX2) + detangle;
                        double q = Math.Sqrt(Math.Pow((yPoints[j] - curY2), 2) + Math.Pow((xPoints[i] - curX2), 2));
                        int thisX = (int)(curX2 + q * Math.Cos(s));
                        int thisY = (int)(curY2 + q * Math.Sin(s));
                        string[] curData = new string[] { (i * rowNum + (rowNum - j - 1) + curCount).ToString(), thisX.ToString(), thisY.ToString(), cb_SelectProModel1.Text };
                        dgv_ProPoints1.Rows.Add(curData);
                        curIndex = j;
                    }
                }
            }
            /////////////////////////test


        }

        private void TeachOnePoint(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            string[] curData;
            if (temp.Name.Equals("btn_Teach1"))
            {
                if (cb_SelectProModel1.SelectedIndex == 1)
                {
                    curData = new string[] { "0", CardControl.AxisNowPosition(CommonData.axisProductReceive_Behind).ToString(), CardControl.AxisNowPosition(CommonData.axisCameraUp).ToString(), cb_SelectProModel1.Text };
                }
                else if (cb_SelectProModel1.SelectedIndex == 0)
                {    
                    curData = new string[] { "0", CardControl.AxisNowPosition(CommonData.axisProductReceive_Front).ToString(), CardControl.AxisNowPosition(CommonData.axisCameraUp).ToString(), cb_SelectProModel1.Text };
                }
                else
                {
                    MessageBox.Show("请选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dgv_ProPoints1.Rows.Add(curData);
            }
            else if (temp.Name.Equals("btn_Teach2"))
            {
                if (cb_SelectProModel2.SelectedIndex == 1)
                {
                    curData = new string[] { "0", CardControl.AxisNowPosition(CommonData.axisProductReceive_Behind).ToString(), CardControl.AxisNowPosition(CommonData.axisCameraDown).ToString(), cb_SelectProModel2.Text };
                }
                else if (cb_SelectProModel2.SelectedIndex == 0)
                {
                    curData = new string[] { "0", CardControl.AxisNowPosition(CommonData.axisProductReceive_Front).ToString(), CardControl.AxisNowPosition(CommonData.axisCameraDown).ToString(), cb_SelectProModel2.Text };
                }
                else
                {
                    MessageBox.Show("请选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }   
                dgv_ProPoints2.Rows.Add(curData);
            }
            else if (temp.Name.Equals("btn_Teach3"))
            {
                if (cb_SelectProModel3.SelectedIndex == 1)
                {
                    curData = new string[] { "0", CardControl.AxisNowPosition(CommonData.axisProductReceive_Behind).ToString(), CardControl.AxisNowPosition(CommonData.axisUpDepth_CheckMove).ToString(), CardControl.AxisNowPosition(CommonData.axisDownDepth_CheckMove).ToString(), cb_SelectProModel3.Text };
                }
                else if (cb_SelectProModel3.SelectedIndex == 0)
                {
                    curData = new string[] { "0", CardControl.AxisNowPosition(CommonData.axisProductReceive_Front).ToString(), CardControl.AxisNowPosition(CommonData.axisUpDepth_CheckMove).ToString(), CardControl.AxisNowPosition(CommonData.axisDownDepth_CheckMove).ToString(), cb_SelectProModel3.Text };
                }
                else
                {
                    MessageBox.Show("请选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dgv_ProPoints3.Rows.Add(curData);
            }
          
        }

        private void GoPoint_Click(object sender, EventArgs e)
        {
            try
            {
                tb_InspectResult.Text = "";
                tb_InspectResult.Text += "执行运动中...\r\n";
             
                if (curSelectData==1)
                {

                    int Go_ZT = Convert.ToInt32(dgv_ProPoints1.Rows[dgv_selectRowIndex].Cells["zt1"].Value.ToString());
                    int Go_SXJ = Convert.ToInt32(dgv_ProPoints1.Rows[dgv_selectRowIndex].Cells["sxj"].Value.ToString());
                    string CurModel = dgv_ProPoints1.Rows[dgv_selectRowIndex].Cells["model1"].Value.ToString();
                    if (CurModel.Equals("前载台上相机模板"))
                    {
                        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraUp },
                 new int[] { Go_ZT, Go_SXJ }, new ushort[] { 1, 1 });
                    }
                    else if (CurModel.Equals("后载台上相机模板"))
                    {
                        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Behind, CommonData.axisCameraUp },
                new int[] { Go_ZT, Go_SXJ }, new ushort[] { 1, 1 });
                    }
                    else
                    {
                        throw new Exception("模板有问题啊！");
                    }
                   
                }
                else if (curSelectData == 2)
                {
                    int Go_ZT = Convert.ToInt32(dgv_ProPoints2.Rows[dgv_selectRowIndex].Cells["zt2"].Value.ToString());
                    int Go_XXJ = Convert.ToInt32(dgv_ProPoints2.Rows[dgv_selectRowIndex].Cells["xxj"].Value.ToString());
                    string CurModel = dgv_ProPoints2.Rows[dgv_selectRowIndex].Cells["model2"].Value.ToString();
                    if (CurModel.Equals("前载台下相机模板"))
                    {
                        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisCameraDown },
                 new int[] { Go_ZT, Go_XXJ }, new ushort[] { 1, 1 });
                    }
                    else if (CurModel.Equals("后载台下相机模板"))
                    {
                        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Behind, CommonData.axisCameraDown },
                new int[] { Go_ZT, Go_XXJ }, new ushort[] { 1, 1 });
                    }
                    else
                    {
                        throw new Exception("模板有问题啊！");
                    }
                }
                else if (curSelectData == 3)
                {
                    int Go_ZT = Convert.ToInt32(dgv_ProPoints3.Rows[dgv_selectRowIndex].Cells["zt3"].Value.ToString());
                    int Go_STG = Convert.ToInt32(dgv_ProPoints3.Rows[dgv_selectRowIndex].Cells["stg"].Value.ToString());
                    int Go_XTG = Convert.ToInt32(dgv_ProPoints3.Rows[dgv_selectRowIndex].Cells["xtg"].Value.ToString());
                    string CurModel = dgv_ProPoints3.Rows[dgv_selectRowIndex].Cells["model3"].Value.ToString();
                    if (CurModel.Equals("前载台探高模板"))
                    {
                        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisUpDepth_RiseAndDown, CommonData.axisDownDepth_RiseAndDown },
               new int[] { CommonData.saveData.UpDepthDis[0], CommonData.saveData.DownDepthDis[0] }, new ushort[] { 1, 1 });
                        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Front, CommonData.axisUpDepth_CheckMove, CommonData.axisDownDepth_CheckMove },
                 new int[] { Go_ZT, Go_STG, Go_XTG }, new ushort[] { 1, 1,1 });
                    }
                    else if (CurModel.Equals("后载台探高模板"))
                    {
                        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisUpDepth_RiseAndDown, CommonData.axisDownDepth_RiseAndDown },
               new int[] { CommonData.saveData.UpDepthDis[0], CommonData.saveData.DownDepthDis[0] }, new ushort[] { 1, 1 });
                        CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProductReceive_Behind, CommonData.axisUpDepth_CheckMove, CommonData.axisDownDepth_CheckMove },
                new int[] { Go_ZT, Go_STG, Go_XTG }, new ushort[] { 1, 1,1 });
                    }
                    else
                    {
                        throw new Exception("模板有问题啊！");
                    }
                }
                else
                {
                    throw new Exception("页面设置有问题啊！");
                }              
                tb_InspectResult.Text += "运动到位\r\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show("运动失败！"+ex.Message);
            }
        }

        private void CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView temp = (DataGridView)sender;
            if (temp.Name.Equals("dgv_ProPoints1"))
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (e.RowIndex >= 0)
                    {
                        dgv_selectRowIndex = e.RowIndex;
                        curSelectData = 1;
                        ProPointsMenu1.Show(MousePosition.X, MousePosition.Y);
                    }
                }
            }
            else if (temp.Name.Equals("dgv_ProPoints2"))
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (e.RowIndex >= 0)
                    {
                        dgv_selectRowIndex = e.RowIndex;
                        curSelectData = 2;
                        ProPointsMenu2.Show(MousePosition.X, MousePosition.Y);
                    }
                }
            }
            else if (temp.Name.Equals("dgv_ProPoints3"))
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (e.RowIndex >= 0)
                    {
                        dgv_selectRowIndex = e.RowIndex;
                        curSelectData = 3;
                        ProPointsMenu3.Show(MousePosition.X, MousePosition.Y);
                    }
                }
            }
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox temp = (ComboBox)sender;
            if (temp.Name.Equals("cb_SelectProModel1"))
            {
                if (cb_SelectProModel1.SelectedIndex == 0 || cb_SelectProModel1.SelectedIndex == 1)
                {
                    LoadProPoints(cb_SelectProModel1.Text);
                }
                else
                {
                    return;
                }
            }
            else if (temp.Name.Equals("cb_SelectProModel2"))
            {
                if (cb_SelectProModel2.SelectedIndex == 0 || cb_SelectProModel2.SelectedIndex == 1)
                {
                    LoadProPoints(cb_SelectProModel2.Text);
                }
                else
                {
                    return;
                }
            }
            else if (temp.Name.Equals("cb_SelectProModel3"))
            {
                if (cb_SelectProModel3.SelectedIndex == 0 || cb_SelectProModel3.SelectedIndex == 1)
                {
                    LoadProPoints(cb_SelectProModel3.Text);
                }
                else
                {
                    return;
                }
            }
        }

        private void ClearAllPoint(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否清空当前设置点位？清空后将不可恢复！", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            GetModelClass();
            Button temp = (Button)sender;
            if (temp.Name.Equals("btn_ClearPro1"))
            {
                dgv_ProPoints1.Rows.Clear();
                if (cb_SelectProModel1.SelectedIndex == 0)
                {
                    if (CurUpCameraFrontModelClass.ModelPoints == null)
                    {
                        CurUpCameraFrontModelClass.ModelPoints = new ArrayList();
                    }
                    CurUpCameraFrontModelClass.ModelPoints.Clear();
                }
                else if (cb_SelectProModel1.SelectedIndex == 1)
                {
                    if (CurUpCameraBehindModelClass.ModelPoints == null)
                    {
                        CurUpCameraBehindModelClass.ModelPoints = new ArrayList();
                    }
                    CurUpCameraBehindModelClass.ModelPoints.Clear();
                }
                else
                {
                    MessageBox.Show("请先选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
             
            }
            else if (temp.Name.Equals("btn_ClearPro2"))
            {
                dgv_ProPoints2.Rows.Clear();
                if (cb_SelectProModel2.SelectedIndex == 0)
                {
                    if (CurDownCameraFrontModelClass.ModelPoints == null)
                    {
                        CurDownCameraFrontModelClass.ModelPoints = new ArrayList();
                    }
                    CurDownCameraFrontModelClass.ModelPoints.Clear();
                }
                else if (cb_SelectProModel2.SelectedIndex == 1)
                {
                    if (CurDownCameraBehindModelClass.ModelPoints == null)
                    {
                        CurDownCameraBehindModelClass.ModelPoints = new ArrayList();
                    }
                    CurDownCameraBehindModelClass.ModelPoints.Clear();
                }
                else
                {
                    MessageBox.Show("请先选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (temp.Name.Equals("btn_ClearPro3"))
            {
                dgv_ProPoints3.Rows.Clear();
                if (cb_SelectProModel3.SelectedIndex == 0)
                {
                    if (CurDepthFrontModelClass.ModelPoints == null)
                    {
                        CurDepthFrontModelClass.ModelPoints = new ArrayList();
                    }
                    CurDepthFrontModelClass.ModelPoints.Clear();
                }
                else if (cb_SelectProModel3.SelectedIndex == 1)
                {
                    if (CurDepthBehindModelClass.ModelPoints == null)
                    {
                        CurDepthBehindModelClass.ModelPoints = new ArrayList();
                    }
                    CurDepthBehindModelClass.ModelPoints.Clear();
                }
                else
                {
                    MessageBox.Show("请先选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                throw new Exception("界面配置错误");
            }
           
         
        }

        private void DeleteOnePoint(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否删除该坐标，删除后不可恢复！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }
                if (curSelectData == 1)
                {

                    if (dgv_selectRowIndex < 0)
                    {
                        return;
                    }
                   
                    dgv_ProPoints1.Rows.RemoveAt(dgv_selectRowIndex);

                }
                else if (curSelectData == 2)
                {
                    if (dgv_selectRowIndex < 0)
                    {
                        return;
                    }

                    dgv_ProPoints2.Rows.RemoveAt(dgv_selectRowIndex);
                }
                else if (curSelectData == 3)
                {
                    if (dgv_selectRowIndex < 0)
                    {
                        return;
                    }

                    dgv_ProPoints3.Rows.RemoveAt(dgv_selectRowIndex);
                }
                else
                {
                    throw new Exception("页面设置有问题啊！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_ProPoints3.Rows.Count; i++)
            {
                if ((Convert.ToInt32(dgv_ProPoints3.Rows[i].Cells["stg"].Value.ToString()) - Convert.ToInt32(dgv_ProPoints3.Rows[i].Cells["xtg"].Value.ToString())) != 1844)
                {
                    MessageBox.Show("检测不通过");
                    return;
                }
                else
                    MessageBox.Show("检测通过!");
                
            }
        }

        private void ModelFlagSet(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            if (temp.Name.Equals("btn_FlagSet1"))
            {
                if (cb_SelectProModel1.SelectedIndex == 0)
                {
                    GetModelClass();
                    VisionPointSet sd = new VisionPointSet(1);
                    sd.ShowDialog();
                }
                else if (cb_SelectProModel1.SelectedIndex == 1)
                {
                    GetModelClass();
                    VisionPointSet sd = new VisionPointSet(2);
                    sd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("请选择要配置的模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (temp.Name.Equals("btn_FlagSet2"))
            {
                if (cb_SelectProModel2.SelectedIndex == 0)
                {
                    GetModelClass();
                    VisionPointSet sd = new VisionPointSet(3);
                    sd.ShowDialog();
                }
                else if (cb_SelectProModel2.SelectedIndex == 1)
                {
                    GetModelClass();
                    VisionPointSet sd = new VisionPointSet(4);
                    sd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("请选择要配置的模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (temp.Name.Equals("btn_FlagSet3"))
            {
                if (cb_SelectProModel3.SelectedIndex == 0)
                {
                    GetModelClass();
                    VisionPointSet sd = new VisionPointSet(5);
                    sd.ShowDialog();
                }
                else if (cb_SelectProModel3.SelectedIndex == 1)
                {
                    GetModelClass();
                    VisionPointSet sd = new VisionPointSet(6);
                    sd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("请选择要配置的模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btn_ExcutePoint_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            string[] curArray_front = CurUpCameraFrontModelClass.ModelPoints[0].ToString().Split(' ');
            string[] curArray_behind = CurUpCameraBehindModelClass.ModelPoints[0].ToString().Split(' ');
         

            if (cb_SelectProModel3.SelectedIndex == 0)
            {
                curDepthDelta_X = CardControl.AxisNowPosition(CommonData.axisProductReceive_Front)- Convert.ToInt32(curArray_front[0]);
                curDepthDelta_Y = CardControl.AxisNowPosition(CommonData.axisUpDepth_CheckMove) - Convert.ToInt32(curArray_front[1]);
            }
            else if (cb_SelectProModel3.SelectedIndex == 1)
            {
                curDepthDelta_Y = CardControl.AxisNowPosition(CommonData.axisProductReceive_Behind) - Convert.ToInt32(curArray_behind[0]);
                curDepthDelta_Y = CardControl.AxisNowPosition(CommonData.axisUpDepth_CheckMove) - Convert.ToInt32(curArray_behind[1]);
            }
            else
            {
                MessageBox.Show("请选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
          
        }
    }
}
