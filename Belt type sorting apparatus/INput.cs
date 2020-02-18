using Belt_type_sorting_apparatus;
using Belt_type_sorting_apparatus.CommonClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    public partial class InPut : Form
    {
        IniFiles iniControl = IniFiles.GetiniControl();
        uint select;
        public InPut(uint x)
        {
            select = x;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(select==1)
            {
                if (tb_New.Text.Trim() == "")
                {
                    MessageBox.Show("请输入新产品名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string proPath = CommonData.proDir + tb_New.Text.Trim();
                if (Directory.Exists(proPath))
                {
                    MessageBox.Show("该产品名称已存在，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb_New.Focus();
                    return;
                }
                Directory.CreateDirectory(CommonData.proDir + tb_New.Text.Trim() + "\\");
                iniControl.IniWriteValue("CurPro", "CurPro", tb_New.Text);
            }
            else
            {
                if (tb_New.Text.Trim() == "")
                {
                    MessageBox.Show("请输入新模板名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (CommonData.saveData.PointModels.ContainsKey(tb_New.Text.Trim()))
                {
                    MessageBox.Show("该模板名称已存在，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CommonData.saveData.PointModels.Add(tb_New.Text.Trim(), new PointControl());
            }

            this.DialogResult = DialogResult.OK;
            MessageBox.Show("添加成功");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
