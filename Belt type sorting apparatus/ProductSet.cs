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
    public partial class ProductSet : Form
    {
        IniFiles iniControl = IniFiles.GetiniControl();
        public ProductSet()
        {
            InitializeComponent();
        }

        private void btn_SwitchPro_Click(object sender, EventArgs e)
        {
            if (cb_Product.SelectedIndex < 0)
            {
                MessageBox.Show("请选择要切换的产品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cb_Product.SelectedItem.Equals(CommonData.CurProName))
            {
                MessageBox.Show("该产品正在生产！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("是否切换产品并重启系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                iniControl.IniWriteValue("CurPro", "CurPro", cb_Product.SelectedItem.ToString());
                Application.Restart();
            }
   
        }

        private void ProductSet_Shown(object sender, EventArgs e)
        {
            lab_Product.Text = CommonData.CurProName;
            QueryProNames();
            QueryModelNames();
            
        }

        /// <summary>
        /// 加载所有产品名称
        /// </summary>
        private void QueryProNames()
        {
            cb_Product.Items.Clear();
            DirectoryInfo root = new DirectoryInfo(CommonData.proDir);
            foreach (DirectoryInfo d in root.GetDirectories())
            {
                cb_Product.Items.Add(d.Name);
            }

        }

        public void QueryModelNames()
        {
            if (CommonData.saveData.PointModels == null || CommonData.saveData.PointModels.Count <= 0)
            {
                cb_Model.Items.Clear();
                return;
            }

            cb_Model.Items.Clear();
            foreach (string thisModel in CommonData.saveData.PointModels.Keys)
            {
                cb_Model.Items.Add(thisModel);
            }
        }

        private void btn_DelPro_Click(object sender, EventArgs e)
        {
            if (cb_Product.SelectedIndex < 0)
            {
                MessageBox.Show("请选择要删除的产品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cb_Product.SelectedItem.Equals(CommonData.CurProName))
            {
                MessageBox.Show("当前产品正在生产,不可删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("删除后数据不可恢复,是否删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                Directory.Delete(CommonData.proDir + cb_Product.SelectedItem.ToString(), true);
                QueryProNames();
            }
            cb_Product.Text = "";
        }

        private void btn_DelModel_Click(object sender, EventArgs e)
        {
            if (cb_Model.SelectedIndex < 0)
            {
                MessageBox.Show("请选择要删除的产品模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("数据删除后不可恢复,是否删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CommonData.saveData.PointModels.Remove(cb_Model.SelectedItem.ToString());
                QueryModelNames();
            }
            cb_Model.Text = "";
        }

        private void btn_NewModel_Click(object sender, EventArgs e)
        {
            InPut inp = new InPut(0);
            inp.ShowDialog();
            if (inp.DialogResult == DialogResult.OK)
            {
                QueryModelNames();
            }
        }

        private void btn_NewPro_Click(object sender, EventArgs e)
        {
            InPut inp = new InPut(1);
            inp.ShowDialog();
            if (inp.DialogResult == DialogResult.OK)
            {
                QueryProNames();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DxfControl s = new DxfControl();
            s.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DxfControl s = new DxfControl();
            s.Show();
        }
    }
}
