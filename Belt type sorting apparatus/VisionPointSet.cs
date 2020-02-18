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
    public partial class VisionPointSet : Form
    {
        ArrayList modelFlag = new ArrayList();
        PointControl CurFlagModelClass = null;
        

        public VisionPointSet(int i)
        {
            InitializeComponent();
            GetModelClass(i);

        }

        private void GetModelClass(int index)
        {
            try
            {
                switch (index)
                {
                    case 1:
                        CommonData.saveData.PointModels.TryGetValue("前载台上相机模板", out CurFlagModelClass);
                        break;
                    case 2:
                        CommonData.saveData.PointModels.TryGetValue("后载台上相机模板", out CurFlagModelClass);
                        break;
                    case 3:
                        CommonData.saveData.PointModels.TryGetValue("前载台下相机模板", out CurFlagModelClass);
                        break;
                    case 4:
                        CommonData.saveData.PointModels.TryGetValue("后载台下相机模板", out CurFlagModelClass);
                        break;
                    case 5:
                        CommonData.saveData.PointModels.TryGetValue("前载台探高模板", out CurFlagModelClass);
                        break;
                    case 6:
                        CommonData.saveData.PointModels.TryGetValue("后载台探高模板", out CurFlagModelClass);
                        break;
                    default:
                        break;
                }
                      
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(this.GetType(), ex);
            }
        }


        private void btn_SubmitFlag_Click_1(object sender, EventArgs e)
        {
            TextBox curFlagBox;
            int columnNum = Convert.ToInt32(tb_ColumnNum.Text);
            int rowNum = Convert.ToInt32(tb_RowNum.Text);
            viewPort.Controls.Clear();
            modelFlag.Clear();
            for (int i = 0; i < columnNum; i++)
            {
                for (int j = 0; j < rowNum; j++)
                {
                    curFlagBox = new TextBox();
                    curFlagBox.Size = new Size(35, 35);
                    curFlagBox.Enabled = true;
                    curFlagBox.TextAlign = HorizontalAlignment.Center;
                    curFlagBox.Left = Convert.ToInt32(tb_firstRow.Text) + i * Convert.ToInt32(tb_ColumnDist.Text);
                    curFlagBox.Top = Convert.ToInt32(tb_firstColumn.Text) + j * Convert.ToInt32(tb_RowDist.Text);
                    modelFlag.Add(curFlagBox);
                    viewPort.Controls.Add(curFlagBox);
                }
            }
        }

        private void btn_SaveCurFlag_Click_1(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (TextBox temp in modelFlag)
                {
                    temp.Name = temp.Text;
                    i += Convert.ToInt32(temp.Text);
                }

                int test = ((modelFlag.Count + 1) * modelFlag.Count / 2);

                if (i == test)
                {
                    MessageBox.Show("检测通过并保存！");
                    foreach (TextBox temp in modelFlag)
                    {
                        temp.Name = temp.Text;
                        i += Convert.ToInt32(temp.Text);

                        FlagTextBox curFlag = new FlagTextBox(temp.Size, temp.TextAlign, temp.Text, temp.Name, temp.BackColor, temp.Left, temp.Top);
                        if (CurFlagModelClass.ModelFlag == null || CurFlagModelClass.ModelFlag.Count <= 0)
                        {
                            CurFlagModelClass.ModelFlag = new Dictionary<string, FlagTextBox>();                         
                        }

                        CurFlagModelClass.ModelFlag.Add(temp.Name,curFlag);
                    }
                }
                else
                {
                    MessageBox.Show("检测未通过不保存！");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("输入有误！" + ex.Message);
            }
        }

        private void btn_ClearFlags_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否清除当前页面标识？模板标识将不会被删除!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            viewPort.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewPort.Controls.Clear();
            modelFlag.Clear();
            if (CurFlagModelClass.ModelFlag == null || CurFlagModelClass.ModelFlag.Count <= 0)
            {                
                MessageBox.Show("当前模板尚未配置检测标识！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (FlagTextBox temp in CurFlagModelClass.ModelFlag.Values)
            {
                TextBox CurFlagBox = new TextBox();
                CurFlagBox.Size = temp.FlagBoxSize;
                CurFlagBox.Name = temp.FlagBoxName;
                CurFlagBox.Text = temp.FlagBoxText;
                CurFlagBox.BackColor = temp.FlagBoxBackColor;
                CurFlagBox.Left = temp.FlagBoxLeft;
                CurFlagBox.Top = temp.FlagBoxTop;
                CurFlagBox.TextAlign = temp.FlagBoxAlign;
                modelFlag.Add(CurFlagBox);
                viewPort.Controls.Add(CurFlagBox);
            }


        }

       




    }
}
