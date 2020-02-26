using Belt_type_sorting_apparatus.CommonClass;
using System;
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
    public partial class DataSetVision : Form
    {
        public DataSetVision()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CardControl.AxisMoveAndCheck(CommonData.axisProductCome_CarryMove, CommonData.saveData.CarryProductDis[1], 1, CommonData.saveData.delay_CommonTime);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否重新示教【取料位置】？\r" + "当前值为" + CommonData.saveData.CarryProductDis[1], "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                CommonData.saveData.CarryProductDis[1] = CardControl.AxisNowPosition(CommonData.axisProductCome_CarryMove);
                MessageBox.Show("修改成功！\r" + "当前值为" + CommonData.saveData.CarryProductDis[1], "请重启程序保存！");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CardControl.AxisMoveAndCheck(CommonData.axisProductCome_CarryMove, CommonData.saveData.CarryProductDis[2], 1, CommonData.saveData.delay_CommonTime);
        }



        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否重新示教【前放置位】？\r" + "当前值为" + CommonData.saveData.CarryProductDis[2], "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                CommonData.saveData.CarryProductDis[2] = CardControl.AxisNowPosition(CommonData.axisProductCome_CarryMove);
                MessageBox.Show("修改成功！\r" + "当前值为" + CommonData.saveData.CarryProductDis[2], "请重启程序保存！");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CardControl.AxisMoveAndCheck(CommonData.axisProductCome_CarryMove, CommonData.saveData.CarryProductDis[3], 1, CommonData.saveData.delay_CommonTime);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否重新示教【后放置位】？\r" + "当前值为" + CommonData.saveData.CarryProductDis[3], "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                CommonData.saveData.CarryProductDis[3] = CardControl.AxisNowPosition(CommonData.axisProductCome_CarryMove);
                MessageBox.Show("修改成功！\r" + "当前值为" + CommonData.saveData.CarryProductDis[3], "请重启程序保存！");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            CardControl.AxisMoveAndCheck(CommonData.axisProductOut_CarryMove, CommonData.saveData.ThrowProductDis[1], 1, CommonData.saveData.delay_CommonTime);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否重新示教【放料位置】？\r" + "当前值为" + CommonData.saveData.ThrowProductDis[1], "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                CommonData.saveData.ThrowProductDis[1] = CardControl.AxisNowPosition(CommonData.axisProductOut_CarryMove);
                MessageBox.Show("修改成功！\r" + "当前值为" + CommonData.saveData.ThrowProductDis[1], "请重启程序保存！");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            CardControl.AxisMoveAndCheck(CommonData.axisProductOut_CarryMove, CommonData.saveData.ThrowProductDis[2], 1, CommonData.saveData.delay_CommonTime);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否重新示教【前取走位】？\r" + "当前值为" + CommonData.saveData.ThrowProductDis[2], "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                CommonData.saveData.ThrowProductDis[2] = CardControl.AxisNowPosition(CommonData.axisProductOut_CarryMove);
                MessageBox.Show("修改成功！\r" + "当前值为" + CommonData.saveData.ThrowProductDis[2], "请重启程序保存！");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CardControl.AxisMoveAndCheck(CommonData.axisProductOut_CarryMove, CommonData.saveData.ThrowProductDis[3], 1, CommonData.saveData.delay_CommonTime);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否重新示教【后取走位】？\r" + "当前值为" + CommonData.saveData.ThrowProductDis[3], "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                CommonData.saveData.ThrowProductDis[3] = CardControl.AxisNowPosition(CommonData.axisProductOut_CarryMove);
                MessageBox.Show("修改成功！\r" + "当前值为" + CommonData.saveData.ThrowProductDis[3], "请重启程序保存！");
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            CardControl.AxisMoveAndCheck(CommonData.axisProductReceive_Front, CommonData.saveData.FrontReceiveDis[1], 1, CommonData.saveData.delay_CommonTime);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否重新示教【前接料位】？\r" + "当前值为" + CommonData.saveData.FrontReceiveDis[1], "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                CommonData.saveData.FrontReceiveDis[1] = CardControl.AxisNowPosition(CommonData.axisProductReceive_Front);
                MessageBox.Show("修改成功！\r" + "当前值为" + CommonData.saveData.FrontReceiveDis[1], "请重启程序保存！");
            }
        }



        private void button53_Click(object sender, EventArgs e)
        {
            CardControl.AxisMoveAndCheck(CommonData.axisProductReceive_Front, CommonData.saveData.FrontReceiveDis[4], 1, CommonData.saveData.delay_CommonTime);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否重新示教【前出料位】？\r" + "当前值为" + CommonData.saveData.FrontReceiveDis[4], "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                CommonData.saveData.FrontReceiveDis[4] = CardControl.AxisNowPosition(CommonData.axisProductReceive_Front);
                MessageBox.Show("修改成功！\r" + "当前值为" + CommonData.saveData.FrontReceiveDis[4], "请重启程序保存！");
            }
        }

        private void button61_Click(object sender, EventArgs e)
        {
            CardControl.AxisMoveAndCheck(CommonData.axisProductReceive_Behind, CommonData.saveData.BehindReceiveDis[1], 1, CommonData.saveData.delay_CommonTime);
        }

        private void button60_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否重新示教【后接料位】？\r" + "当前值为" + CommonData.saveData.BehindReceiveDis[1], "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                CommonData.saveData.BehindReceiveDis[1] = CardControl.AxisNowPosition(CommonData.axisProductReceive_Behind);
                MessageBox.Show("修改成功！\r" + "当前值为" + CommonData.saveData.BehindReceiveDis[1], "请重启程序保存！");
            }
        }

        

        private void button55_Click(object sender, EventArgs e)
        {
            CardControl.AxisMoveAndCheck(CommonData.axisProductReceive_Behind, CommonData.saveData.BehindReceiveDis[4], 1, CommonData.saveData.delay_CommonTime);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否重新示教【后出料位】？\r" + "当前值为" + CommonData.saveData.BehindReceiveDis[4], "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                CommonData.saveData.BehindReceiveDis[4] = CardControl.AxisNowPosition(CommonData.axisProductReceive_Behind);
                MessageBox.Show("修改成功！\r" + "当前值为" + CommonData.saveData.BehindReceiveDis[4], "请重启程序保存！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisUpDepth_RiseAndDown, CommonData.axisDownDepth_RiseAndDown }, 
                new int[] { CommonData.saveData.UpDepthDis[1], CommonData.saveData.DownDepthDis[1] }, new ushort[] { 1, 1 });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CardControl.AxissMoveAndCheck(new ushort[] { CommonData.axisUpDepth_RiseAndDown, CommonData.axisDownDepth_RiseAndDown }, 
                new int[] { CommonData.saveData.UpDepthDis[0], CommonData.saveData.DownDepthDis[0] }, new ushort[] { 1, 1 });
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("是否重新示教【探高位】？\r" + "当前上探高值为" + CommonData.saveData.UpDepthDis[1]+
                "\r当前下探高值为" + CommonData.saveData.DownDepthDis[1], "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                CommonData.saveData.UpDepthDis[1] = CardControl.AxisNowPosition(CommonData.axisUpDepth_RiseAndDown);
                CommonData.saveData.DownDepthDis[1] = CardControl.AxisNowPosition(CommonData.axisDownDepth_RiseAndDown);
                MessageBox.Show("修改成功！\r" +"当前上探高值为" + CommonData.saveData.UpDepthDis[1] +
                "\r当前下探高值为" + CommonData.saveData.DownDepthDis[1], "请重启程序保存！");
            }
        }
    }
}
