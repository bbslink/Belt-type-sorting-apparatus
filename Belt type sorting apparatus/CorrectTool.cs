using Belt_type_sorting_apparatus.CommonClass;
using HalconDotNet;
using SXTisCam;
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
    public partial class CorrectTool : Form
    {
        int origin_X = 0;
        int origin_y = 0;
        string errMsg;
        ArrayList modelFlag = new ArrayList();
        TextBox temp;

        Point location;
        public CorrectTool()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            origin_X = 1000;
            origin_y = 1000;
        }



        private void textbox_MouseDown(object sender, MouseEventArgs e)
        {
            location = e.Location;
            temp = sender as TextBox;

        }

        private void textbox_MouseMove(object sender, MouseEventArgs e)
        {

            int pos_x, pos_y;

            if (e.Button == MouseButtons.Left)
            {
                pos_x = temp.Location.X + (e.X - location.X);
                pos_y = temp.Location.Y + (e.Y - location.Y);
                temp.Location = new Point(pos_x, pos_y);
            }


        }

        private void btn_SaveCurFlag_Click(object sender, EventArgs e)
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
                        if (CommonData.saveData.StandFlag == null || CommonData.saveData.StandFlag.Count <= 0)
                        {
                            CommonData.saveData.StandFlag = new Dictionary<string, FlagTextBox>();
                        }

                        CommonData.saveData.StandFlag.Add(temp.Name, curFlag);
                    }
                }
                else
                {
                    MessageBox.Show("检测未通过不保存！");
                }
            }
            catch (Exception ex)
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
            dispControl1.Controls.Clear();
        }

        private void btn_SubmitFlag_Click(object sender, EventArgs e)
        {
            TextBox curFlagBox;
            int columnNum = Convert.ToInt32(tb_ColumnNum.Text);
            int rowNum = Convert.ToInt32(tb_RowNum.Text);
            dispControl1.Controls.Clear();
            modelFlag.Clear();
            for (int i = 0; i < columnNum; i++)
            {
                for (int j = 0; j < rowNum; j++)
                {
                    curFlagBox = new TextBox();
                    curFlagBox.Size = new Size(20, 10);
                    curFlagBox.Enabled = true;
                    curFlagBox.TextAlign = HorizontalAlignment.Center;
                    curFlagBox.Left =  i * 35;
                    curFlagBox.Top =  j * 30;
                    curFlagBox.MouseDown += new System.Windows.Forms.MouseEventHandler(textbox_MouseDown);
                    curFlagBox.MouseMove += new System.Windows.Forms.MouseEventHandler(textbox_MouseMove);
                    modelFlag.Add(curFlagBox);
                    dispControl1.Controls.Add(curFlagBox);
                }
            }
        }

        private void btn_LoadCurFlag_Click(object sender, EventArgs e)
        {
            dispControl1.Controls.Clear();
            modelFlag.Clear();
            if (CommonData.saveData.StandFlag == null || CommonData.saveData.StandFlag.Count <= 0)
            {
                MessageBox.Show("当前模板尚未配置检测标识！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (FlagTextBox temp in CommonData.saveData.StandFlag.Values)
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
                dispControl1.Controls.Add(CurFlagBox);
            }
        }

       
    }
}
