using Belt_type_sorting_apparatus.CommonClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    public partial class Authorization : Form
    {
        SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        public Authorization()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select right from author where name=" + "'" + textBox1.Text + "' and passw=" + "'" + textBox2.Text + "'";
                
                SQLiteCommand command = new SQLiteCommand(sql, CommonData.Conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["right"].Equals("操作员"))
                    {
                        CommonData.authorization = 1;
                        CommonData.userRight = "操作员";
                        MessageBox.Show("您当前是操作员！");
                    }
                    else if (reader["right"].Equals("管理员"))
                    {
                        CommonData.authorization = 2;
                        CommonData.userRight = "管理员";
                        MessageBox.Show("您当前是管理员！");
                    }
                    else if (reader["right"].Equals("开发员"))
                    {
                        CommonData.authorization = 3;
                        CommonData.userRight = "开发员";
                        MessageBox.Show("您当前是开发员！");
                    }
                    else
                    {
                        MessageBox.Show("您账号存在异常，请联系管理员！");
                        CommonData.authorization = 1;
                        this.DialogResult = DialogResult.No;
                        this.Close();
                        return;
                    }
                }
                if (reader.StepCount == 0)
                {
                    CommonData.authorization = 1;
                    MessageBox.Show("您密码输入有误或者账号不存在！");
                    this.DialogResult = DialogResult.No;
                    this.Close();
                    return;
                }
                CommonData.userName = textBox1.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                CommonData.authorization = 1;
                MessageBox.Show("查询数据失败\r" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CommonData.authorization == 1)
            {
                MessageBox.Show("您权限不够！");
            }
            else
            {
                Registe rg = new Registe();
                rg.ShowDialog();
            }
        }

        private void Authorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            //sysEvent.setButtonEnable(false, false, true, false, false, false, false, false, false, false, false);
            StopAction.ErrStop();
        }


        #region
        private void btn_CreateTable_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "create table if not exists " + textBox4.Text + " (name varchar(20), passw char(50),right char(50))";
                SQLiteCommand command = new SQLiteCommand(sql, CommonData.Conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("创建数据表" + textBox4.Text + "失败：" + ex.Message);
            }
        }

        private void btn_FindData_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from " + textBox4.Text + " order by score desc";
                SQLiteCommand command = new SQLiteCommand(sql, CommonData.Conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    richTextBox1.Text = "Name: " + reader["name"] + "\tScore: " + reader["score"] + "\r\n" + richTextBox1.Text;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("查询数据失败：\r" + ex.Message);
            }
        }

        private void btn_CreateData_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into " + textBox4.Text + " (name, score) values ('" + textBox5.Text + "', " + Convert.ToInt32(textBox6.Text) + ")";
                SQLiteCommand command = new SQLiteCommand(sql, CommonData.Conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("插入数据：" + textBox5.Text + ":" + textBox6.Text + "失败：" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FindTable();
        }

        private void FindTable()
        {
            try
            {
                comboBox1.Items.Clear();
                string sql = "select name from sqlite_master where type='table' order by name";
                SQLiteCommand command = new SQLiteCommand(sql, CommonData.Conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["name"]);
                    //richTextBox1.Text = "表名: " + reader["name"]+"\r\n" + richTextBox1.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询表失败\r" + ex.Message);
                //throw new Exception("创建数据表" + textBox4.Text + "失败：" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("请选择要删除的表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox1.SelectedItem.Equals("author"))
            {
                MessageBox.Show("当前权限表不可删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("删除后数据不可恢复,是否删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                //Directory.Delete(CommonData.proDir + cb_Product.SelectedItem.ToString(), true);
                string sql = "drop table if exists "+ comboBox1.SelectedItem.ToString();
                SQLiteCommand command = new SQLiteCommand(sql, CommonData.Conn);
                command.ExecuteNonQuery();
            }
            FindTable();
            comboBox1.Text = "";
        }
        #endregion

    }
}
