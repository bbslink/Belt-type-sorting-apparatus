using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    public partial class Registe : Form
    {
        public Registe()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择当前用户权限！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sql = "insert into author (name, passw,right) values ('" + textBox1.Text + "', '"+ textBox2.Text + "','" +comboBox1.SelectedItem.ToString()+ "')";
                SQLiteCommand command = new SQLiteCommand(sql, CommonData.Conn);
                command.ExecuteNonQuery();
                ShowData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("增加用户数据失败\r" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select * from author where name="+"'"+textBox1.Text+"'";
                SQLiteCommand command = new SQLiteCommand(sql, CommonData.Conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] curRow = new string[2];
                    curRow[0] = reader["name"].ToString();
                    curRow[1] = reader["right"].ToString();
                    dataGridView1.Rows.Add(curRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询数据失败\r" + ex.Message);
            }
        }

        private void ShowData()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select * from author";
                SQLiteCommand command = new SQLiteCommand(sql, CommonData.Conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] curRow = new string[2];
                    curRow[0] = reader["name"].ToString();
                    curRow[1] = reader["right"].ToString();
                    dataGridView1.Rows.Add(curRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询数据失败\r" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("删除后数据不可恢复,是否删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    string sql = "delete from author where name=" + "'" + textBox1.Text + "'";
                    SQLiteCommand command = new SQLiteCommand(sql, CommonData.Conn);
                    command.ExecuteNonQuery();
                    ShowData();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除数据失败\r" + ex.Message);
            }
        }

        private void Registe_Shown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(CommonData.rightSelect);
            ShowData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("删除后数据不可恢复,是否删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    string sql = "delete  from author";
                    SQLiteCommand command = new SQLiteCommand(sql, CommonData.Conn);
                    command.ExecuteNonQuery();
                    ShowData();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除数据失败\r" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
