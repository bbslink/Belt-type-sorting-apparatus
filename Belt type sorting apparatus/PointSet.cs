
using Belt_type_sorting_apparatus;
using Belt_type_sorting_apparatus.CommonClass;
using HalconDotNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    public partial class PointSet : Form
    {

       
        SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        IniFiles iniControl = IniFiles.GetiniControl();
        PointControl CurModelClass = null;
        int dgv_selectRowIndex = 0;//datagridview中选中的点的行号
        int CurInPlaceNo = -1;//当前正在第几个点位
        int curX = 0;
        int curY = 0;
        string errMsg = "";//记录错误信息


        private void PointSet_Shown(object sender, EventArgs e)
        {
            timer_io.Start();

        }

        public PointSet()
        {
            InitializeComponent();    
        }

        private void PointSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer_io.Stop();                   
        }



        #region 重要按钮


        private void btn_SubmitPro_Click(object sender, EventArgs e)
        {

            if (cb_SelectProModel.SelectedIndex < 0)
            {
                MessageBox.Show("请选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("是否以当前位置为基准生成模板的【" + cb_SelectProModel.Text + "】检测坐标？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (CheckCurKeyExist(cb_SelectProModel.Text))
            {
                if (MessageBox.Show("模板【" + cb_SelectProModel.Text + "】的工作点位已存在,是否覆盖？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    //return;
                }
                else
                {
                    //删除表格中数据
                    for (int i = 0; i < dgv_ProPoints.Rows.Count; i++)
                    {
                        if (dgv_ProPoints.Rows[i].Cells[5].Value.ToString() == cb_SelectProModel.Text)
                        {
                            dgv_ProPoints.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                    //删除点位中数据
                    GetCurModelClass(cb_SelectProModel.Text);
                    if (CurModelClass.ModelPoints == null)
                    {
                        CurModelClass.ModelPoints = new ArrayList();
                    }
                    CurModelClass.ModelPoints.Clear();
                }
            }

            int curX2 = Convert.ToInt32(textBox2.Text);
            int curY2 = Convert.ToInt32(textBox19.Text);
            int curR;
            if (cb_SelectProModel.Text.Equals("SuckFront"))
            {
               curR = Convert.ToInt32(tb_CurYPlace.Text);
            }
            else
            {
                curR = Convert.ToInt32(textBox3.Text);
            }
            int curQJ= Convert.ToInt32(textBox1.Text);


            int rowNum = Convert.ToInt32(tb_ProRowNum.Text);
            int columnNum = Convert.ToInt32(tb_ProColumnNum.Text);
            double perRowDis=0, perColumnDis=0;
            if (rowNum != 1)
            {
                perRowDis = (curX2 - curX) / (rowNum - 1); 
            }
            if (columnNum != 1)
            {
                perColumnDis = (curY2 - curY) / (columnNum - 1);
            }
            int thisX, thisY;
            for (int i = 0; i < columnNum; i++)
            {
                thisY = (int)(curY + perColumnDis*i);
                for (int j = 0; j < rowNum; j++)
                {
                    thisX = (int)(curX + perRowDis*j);

                    string[] curData = new string[] { (i * rowNum + j).ToString(), thisX.ToString(), thisY.ToString(), curR.ToString(), curQJ.ToString(), cb_SelectProModel.Text };
                    dgv_ProPoints.Rows.Add(curData);
                }

            }


        
        }

        /// <summary>
        /// 基准点坐标生成
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            curX = Convert.ToInt32(textBox2.Text);
            curY = Convert.ToInt32(textBox19.Text);
        }
     
        private void btn_ClearPro_Click(object sender, EventArgs e)
        {
            if (cb_SelectProModel.Text == "")
            {
                MessageBox.Show("请先选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("是否清空当前设置点位？清空后将不可恢复！", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            dgv_ProPoints.Rows.Clear();
            GetCurModelClass(cb_SelectProModel.Text);
            if (CurModelClass.ModelPoints == null)
            {
                CurModelClass.ModelPoints = new ArrayList();
            }
            CurModelClass.ModelPoints.Clear();
        }

        /// <summary>
        /// 保存点位
        /// </summary>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (cb_SelectProModel.Text == "")
            {
                MessageBox.Show("请选择要配置的模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool checkResult = true;
            if (dgv_ProPoints.Rows.Count <= 0)
            {
                MessageBox.Show("请至少填写一行数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < dgv_ProPoints.Rows.Count; i++)
            {
                foreach (DataGridViewCell columnItem in dgv_ProPoints.Rows[i].Cells)
                {
                    if (columnItem.Value == null || columnItem.Value.ToString().Trim() == "")
                    {
                        checkResult = false;
                        break;
                    }
                }
            }
            if (!checkResult)
            {
                MessageBox.Show("请将数据填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("是否保存数据？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            GetCurModelClass(cb_SelectProModel.Text);
            if (CurModelClass.ModelPoints == null)
            {
                CurModelClass.ModelPoints = new ArrayList();
            }
            if (CurModelClass.ModelPoints != null && CurModelClass.ModelPoints.Count > 0)
            {
                CurModelClass.ModelPoints.Clear();
            }
            for (int idx = 0; idx < dgv_ProPoints.Rows.Count; idx++)
            {
                if (dgv_ProPoints.Rows[idx].Cells[5].Value.ToString() == cb_SelectProModel.Text)
                {
                    string curPointStr = dgv_ProPoints.Rows[idx].Cells[1].Value.ToString() + " " + dgv_ProPoints.Rows[idx].Cells[2].Value.ToString()
                        + " " + dgv_ProPoints.Rows[idx].Cells[3].Value.ToString() + " " + dgv_ProPoints.Rows[idx].Cells[4].Value.ToString();
                    CurModelClass.ModelPoints.Add(curPointStr);
                }
            }

            LoadProPoints(cb_SelectProModel.Text);
        }
     
        private bool CheckCurKeyExist(string curKey)
        {
            bool checkResult = false;
            if (dgv_ProPoints.Rows.Count <= 0)
            {
                return checkResult;
            }
            foreach (DataGridViewRow item in dgv_ProPoints.Rows)
            {
                if (item.Cells[5].Value != null)
                {
                    if (item.Cells[5].Value.ToString() == curKey)
                    {
                        checkResult = true;
                        break;
                    }
                }
            }
            return checkResult;
        }

   

        /// <summary>
        /// 获取到产品模板文件类
        /// </summary>
        /// <param name="curKey"></param>
        private void GetCurModelClass(string curKey)
        {
            try
            {
                CommonData.saveData.PointModels.TryGetValue(curKey, out CurModelClass);
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(this.GetType(), ex);
            }
        }

        private void cb_SelectProModel_MouseDown(object sender, MouseEventArgs e)
        {
            cb_SelectProModel.Items.Clear();
            if (CommonData.saveData.PointModels == null || CommonData.saveData.PointModels.Count <= 0)
            {
                return;
            }
            foreach (string thisModel in CommonData.saveData.PointModels.Keys)
            {
                cb_SelectProModel.Items.Add(thisModel);
            }
        }

        /// <summary>
        /// 加载运动点位
        /// </summary>
        private void LoadProPoints(string curModel)
        {
            GetCurModelClass(curModel);
            if (CurModelClass.ModelPoints == null || CurModelClass.ModelPoints.Count <= 0)
            {
                dgv_ProPoints.Rows.Clear();
                return;
            }
            dgv_ProPoints.Rows.Clear();
            string[] curRow = new string[6];
            for (int idx = 0; idx < CurModelClass.ModelPoints.Count; idx++)
            {
                curRow[0] = idx.ToString();
                string[] curArrayItem = CurModelClass.ModelPoints[idx].ToString().Split(' ');
                curRow[1] = curArrayItem[0];
                curRow[2] = curArrayItem[1];
                curRow[3] = curArrayItem[2];
                curRow[4] = curArrayItem[3];
                curRow[5] = curModel;
                dgv_ProPoints.Rows.Add(curRow);
                if (idx % 2 != 0)
                {
                    dgv_ProPoints.Rows[idx].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void timer_io_Tick(object sender, EventArgs e)
        {
         //   textBox2.Text = LTDMC.dmc_get_position(CommonData.cardID, CommonData.axisProduct_01).ToString();
         //   textBox19.Text = LTDMC.dmc_get_position(CommonData.cardID, CommonData.axisProduct_02).ToString();
         ////   textBox1.Text = LTDMC.dmc_get_position(CommonData.cardID, CommonData.axisCarryFrontAndBack).ToString();
         //   tb_CurXPlace.Text = LTDMC.dmc_get_position(CommonData.cardID, CommonData.axisEmptyTray).ToString();
         //   tb_CurYPlace.Text = LTDMC.dmc_get_position(CommonData.cardID, CommonData.axisDepth_X).ToString();
         //   textBox4.Text = LTDMC.dmc_get_position(CommonData.cardID, CommonData.axisProductTray).ToString();
         //   textBox3.Text = LTDMC.dmc_get_position(CommonData.cardID, CommonData.axisCamera_Y).ToString();
        }

        private void cb_SelectProModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_SelectProModel.SelectedIndex < 0)
            {
                return;
            }
            LoadProPoints(cb_SelectProModel.Text);
        }

     










        #endregion

        #region 表格菜单
        private void tsm_GoPoint_Click(object sender, EventArgs e)
        {
            try
            {

                tb_InspectResult.Text = "";
                tb_InspectResult.Text += "执行运动中...\r\n";
                CurInPlaceNo = Convert.ToInt32(dgv_ProPoints.Rows[dgv_selectRowIndex].Cells["PointName"].Value.ToString());
                int GoalXPlace = Convert.ToInt32(dgv_ProPoints.Rows[dgv_selectRowIndex].Cells["XPlace"].Value.ToString());
                int GoalYPlace = Convert.ToInt32(dgv_ProPoints.Rows[dgv_selectRowIndex].Cells["YPlace"].Value.ToString());
                int GoalJPPlace = Convert.ToInt32(dgv_ProPoints.Rows[dgv_selectRowIndex].Cells["JPPlace"].Value.ToString());
                int GoalR1Place = Convert.ToInt32(dgv_ProPoints.Rows[dgv_selectRowIndex].Cells["R1Place"].Value.ToString());
               
                //if (!CheckSignal.WaitSomeTime(() => CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisEmptyTray, CommonData.axisProductTray },
                //                  new int[] { CommonData.saveData.FrontDownDis[0], CommonData.saveData.BehinDownDis[0] }, new ushort[] { 1, 1 }), CommonData.saveData.delay_CommonTime))
                //{
                //    throw new Exception();
                //}
                //if (!CheckSignal.WaitSomeTime(() => CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisProduct_01, CommonData.axisCarryEmptyTray, CommonData.axisDepth_X, CommonData.axisProduct_02, CommonData.axisCamera_Y },
                // new int[] { GoalXPlace, GoalYPlace, GoalR1Place, GoalJPPlace, GoalR1Place }, new ushort[] { 1, 1, 1, 1,1 }), CommonData.saveData.delay_CommonTime))
                //{
                //    MessageBox.Show("运动失败，请重试!");
                //}
                tb_InspectResult.Text += "运动到位\r\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show("运动失败！");
            }
        }

        private void tsm_DeletePoint_Click(object sender, EventArgs e)
        {
            if (dgv_selectRowIndex < 0)
            {
                return;
            }
            if (MessageBox.Show("是否删除该坐标，删除后不可恢复！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }
            dgv_ProPoints.Rows.RemoveAt(dgv_selectRowIndex);
        }



        private void dgv_ProPoints_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dgv_selectRowIndex = e.RowIndex;
                    ProPointsMenu.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }


        private void tsm_SaveAllPoint_Click(object sender, EventArgs e)
        {
            if (cb_SelectProModel.Text == "")
            {
                MessageBox.Show("请选择要配置的模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool checkResult = true;
            if (dgv_ProPoints.Rows.Count <= 0)
            {
                MessageBox.Show("请至少填写一行数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < dgv_ProPoints.Rows.Count; i++)
            {
                foreach (DataGridViewCell columnItem in dgv_ProPoints.Rows[i].Cells)
                {
                    if (columnItem.Value == null || columnItem.Value.ToString().Trim() == "")
                    {
                        checkResult = false;
                        break;
                    }
                }
            }
            if (!checkResult)
            {
                MessageBox.Show("请将数据填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("是否保存数据？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            GetCurModelClass(cb_SelectProModel.Text);
            if (CurModelClass.ModelPoints == null)
            {
                CurModelClass.ModelPoints = new ArrayList();
            }
            if (CurModelClass.ModelPoints != null && CurModelClass.ModelPoints.Count > 0)
            {
                CurModelClass.ModelPoints.Clear();
            }
            for (int idx = 0; idx < dgv_ProPoints.Rows.Count; idx++)
            {
                if (dgv_ProPoints.Rows[idx].Cells[5].Value.ToString() == cb_SelectProModel.Text)
                {
                    string curPointStr = dgv_ProPoints.Rows[idx].Cells[1].Value.ToString() + " " + dgv_ProPoints.Rows[idx].Cells[2].Value.ToString()
                       + " " + dgv_ProPoints.Rows[idx].Cells[3].Value.ToString() + " " + dgv_ProPoints.Rows[idx].Cells[4].Value.ToString();
                    CurModelClass.ModelPoints.Add(curPointStr);
                }
            }

            LoadProPoints(cb_SelectProModel.Text);
        }



        #endregion




        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
           

        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
           

        }

        private void button34_Click(object sender, EventArgs e)
        {
            ParaSetVision pa = new ParaSetVision();
            pa.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cb_SelectProModel.SelectedIndex < 0)
            {
                MessageBox.Show("请选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string[] curData = new string[] { "0", textBox2.Text, textBox19.Text, tb_CurYPlace.Text, textBox1.Text, cb_SelectProModel.Text };
            dgv_ProPoints.Rows.Add(curData);
        }

      
        private void btn_ExcutePoint_Click(object sender, EventArgs e)
        {

        }
    }
}
