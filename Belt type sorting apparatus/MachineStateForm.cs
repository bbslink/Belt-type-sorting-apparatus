using Belt_type_sorting_apparatus.CommonClass;
using SXHikCam;
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
    
    public partial class MachineStateForm : Form
    {
        SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        public MachineStateForm()
        {
            InitializeComponent();
        }      

        private void MachineStateForm_Shown(object sender, EventArgs e)
        {
            for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
            {
                CardControl.SetManualProfile(axisno);
            }

            //打开刹车
            IOMonitor.SetOneOutBit(CommonData.out_UpNeedleStop, 0);
            IOMonitor.SetOneOutBit(CommonData.out_DownNeedleStop, 0);

            ShowALLParam();
        }

        private void MachineStateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
                {
                    CardControl.SetAutoProfile(axisno);
                }
                //必须加这个
                sysEvent.setButtonEnable(false, false, true, false, false, true, false, false, false, false, false);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    

        /// <summary>
        /// 加载窗口参数
        /// </summary>
        private void ShowALLParam()
        {
            //////加载IO////////////////////
            for (ushort ioNo = 3; ioNo < 14; ioNo++)
            {
                short result = IOMonitor.ReadOneOutBit(ioNo);

                if (result <= 0)
                {
                    ((Label)(this.tableLayoutPanel3.Controls.Find("Out" + ioNo, true)[0])).BackColor = Color.Green;
                }
                else
                {
                    ((Label)(this.tableLayoutPanel3.Controls.Find("Out" + ioNo, true)[0])).BackColor = SystemColors.ControlDark;
                }
            }

            for (ushort ioNo = 0; ioNo < 10; ioNo++)
            {
                short result = IOMonitor.ReadOneOutBit((ushort)(ioNo + 100));

                if (result <= 0)
                {
                    ((Label)(this.tableLayoutPanel6.Controls.Find("P1Out" + ioNo, true)[0])).BackColor = Color.Green;
                }
                else
                {
                    ((Label)(this.tableLayoutPanel6.Controls.Find("P1Out" + ioNo, true)[0])).BackColor = SystemColors.ControlDark;
                }
            }

        }

     
        private void btn_ClearALM_Click(object sender, EventArgs e)
        {
            try
            {
                //伺服报警清除
                for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
                {
                    if (axisno >= 8)
                        break;
                    CardControl.AxisALLErc(axisno);
                }

                IOMonitor.SetOneOutBit(CommonData.out_ComeAndLeaveServoReset, 0);
                IOMonitor.SetOneOutBit(CommonData.out_ServoErrorReset, 0);
                CheckSignal.CommonDelay(300);
                IOMonitor.SetOneOutBit(CommonData.out_ComeAndLeaveServoReset, 1);
                IOMonitor.SetOneOutBit(CommonData.out_ServoErrorReset, 1);

            }
            catch(Exception ex)
            {
                MessageBox.Show("清除报警失败！请重试！\r" + ex.Message);
            }
            
        }
           

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                Button thisButton = (Button)sender;
                if (thisButton.Text.Equals("-进料"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisProductCome_CarryMove, 0);
                }
                else if(thisButton.Text.Equals("+进料"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisProductCome_CarryMove, 1);
                }
                else if (thisButton.Text.Equals("-上相机"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisCameraUp, 0);
                }
                else if (thisButton.Text.Equals("+上相机"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisCameraUp, 1);
                }
                else if (thisButton.Text.Equals("-下相机"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisCameraDown, 0);
                }
                else if (thisButton.Text.Equals("+下相机"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisCameraDown, 1);
                }
                else if (thisButton.Text.Equals("-上探高"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisUpDepth_CheckMove, 0);
                }
                else if (thisButton.Text.Equals("+上探高"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisUpDepth_CheckMove, 1);
                }
                else if (thisButton.Text.Equals("-下探高"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisDownDepth_CheckMove, 0);
                }
                else if (thisButton.Text.Equals("+下探高"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisDownDepth_CheckMove, 1);
                }
                else if (thisButton.Text.Equals("-出料"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisProductOut_CarryMove, 0);
                }
                else if (thisButton.Text.Equals("+出料"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisProductOut_CarryMove, 1);
                }
                else if (thisButton.Text.Equals("+进料台升"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisProductCome_RiseAndDown, 1);
                }
                else if (thisButton.Text.Equals("-进料台降"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisProductCome_RiseAndDown, 0);
                }
                else if (thisButton.Text.Equals("+出料台升"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisProductOut_RiseAndDown, 1);
                }
                else if (thisButton.Text.Equals("-出料台降"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisProductOut_RiseAndDown, 0);
                }
                else if (thisButton.Text.Equals("-上探高升"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisUpDepth_RiseAndDown, 0);
                }
                else if (thisButton.Text.Equals("+上探高降"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisUpDepth_RiseAndDown, 1);
                }
                else if (thisButton.Text.Equals("+下探高升"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisDownDepth_RiseAndDown, 1);
                }
                else if (thisButton.Text.Equals("-下探高降"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisDownDepth_RiseAndDown, 0);
                }
                else if (thisButton.Text.Equals("-后载台"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisProductReceive_Behind, 0);
                }
                else if (thisButton.Text.Equals("后载台+"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisProductReceive_Behind, 1);
                }
                else if (thisButton.Text.Equals("-前载台"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisProductReceive_Front, 0);
                }
                else if (thisButton.Text.Equals("前载台+"))
                {
                    CardControl.VmoveOneAxiss(CommonData.axisProductReceive_Front, 1);
                }
                else
                {
                    MessageBox.Show("程序轴号写错啦！联系制造商");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
           
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Button thisButton = (Button)sender;
                if (thisButton.Text.Equals("-进料"))
                {
                    CardControl.StopOneAxis(CommonData.axisProductCome_CarryMove, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("+进料"))
                {
                    CardControl.StopOneAxis(CommonData.axisProductCome_CarryMove, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("-上相机"))
                {
                    CardControl.StopOneAxis(CommonData.axisCameraUp, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("+上相机"))
                {
                    CardControl.StopOneAxis(CommonData.axisCameraUp, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("-下相机"))
                {
                    CardControl.StopOneAxis(CommonData.axisCameraDown, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("+下相机"))
                {
                    CardControl.StopOneAxis(CommonData.axisCameraDown, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("-上探高"))
                {
                    CardControl.StopOneAxis(CommonData.axisUpDepth_CheckMove, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("+上探高"))
                {
                    CardControl.StopOneAxis(CommonData.axisUpDepth_CheckMove, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("-下探高"))
                {
                    CardControl.StopOneAxis(CommonData.axisDownDepth_CheckMove, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("+下探高"))
                {
                    CardControl.StopOneAxis(CommonData.axisDownDepth_CheckMove, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("-出料"))
                {
                    CardControl.StopOneAxis(CommonData.axisProductOut_CarryMove, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("+出料"))
                {
                    CardControl.StopOneAxis(CommonData.axisProductOut_CarryMove, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("+进料台升"))
                {
                    CardControl.StopOneAxis(CommonData.axisProductCome_RiseAndDown, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("-进料台降"))
                {
                    CardControl.StopOneAxis(CommonData.axisProductCome_RiseAndDown, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("+出料台升"))
                {
                    CardControl.StopOneAxis(CommonData.axisProductOut_RiseAndDown, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("-出料台降"))
                {
                    CardControl.StopOneAxis(CommonData.axisProductOut_RiseAndDown, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("-上探高升"))
                {
                    CardControl.StopOneAxis(CommonData.axisUpDepth_RiseAndDown, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("+上探高降"))
                {
                    CardControl.StopOneAxis(CommonData.axisUpDepth_RiseAndDown, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("+下探高升"))
                {
                    CardControl.StopOneAxis(CommonData.axisDownDepth_RiseAndDown, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("-下探高降"))
                {
                    CardControl.StopOneAxis(CommonData.axisDownDepth_RiseAndDown, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("-后载台"))
                {
                    CardControl.StopOneAxis(CommonData.axisProductReceive_Behind, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("后载台+"))
                {
                    CardControl.StopOneAxis(CommonData.axisProductReceive_Behind, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("-前载台"))
                {
                    CardControl.StopOneAxis(CommonData.axisProductReceive_Front, CommonData.saveData.delay_CommonTime);
                }
                else if (thisButton.Text.Equals("前载台+"))
                {
                    CardControl.StopOneAxis(CommonData.axisProductReceive_Front, CommonData.saveData.delay_CommonTime);
                }
                else
                {
                    MessageBox.Show("程序轴号写错啦！联系制造商");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_axishome(object sender, EventArgs e)
        {
            try
            {
                Button thisButton = (Button)sender;
                ushort axisno;
                if (thisButton.Text.Equals("进料回原"))
                {
                    axisno = CommonData.axisProductCome_CarryMove;
                }
                else if (thisButton.Text.Equals("上相机回原"))
                {
                    axisno = CommonData.axisCameraUp;
                }
                else if (thisButton.Text.Equals("下相机回原"))
                {
                    axisno = CommonData.axisCameraDown;
                }
                else if (thisButton.Text.Equals("上探高回原"))
                {
                    axisno = CommonData.axisUpDepth_CheckMove;
                }
                else if (thisButton.Text.Equals("下探高回原"))
                {
                    axisno = CommonData.axisDownDepth_CheckMove;
                }
                else if (thisButton.Text.Equals("出料回原"))
                {
                    axisno = CommonData.axisProductOut_CarryMove;
                }
                else if (thisButton.Text.Equals("进料台回原"))
                {
                    axisno = CommonData.axisProductCome_RiseAndDown;
                }
                else if (thisButton.Text.Equals("出料台回原"))
                {
                    axisno = CommonData.axisProductOut_RiseAndDown;
                }
                else if (thisButton.Text.Equals("上探高升降回原"))
                {
                    axisno = CommonData.axisUpDepth_RiseAndDown;
                }
                else if (thisButton.Text.Equals("下探高升降回原"))
                {
                    axisno = CommonData.axisDownDepth_RiseAndDown;
                }
                else if (thisButton.Text.Equals("后载台回原"))
                {
                    axisno = CommonData.axisProductReceive_Behind;
                }
                else if (thisButton.Text.Equals("前载台回原"))
                {
                    axisno = CommonData.axisProductReceive_Front;
                }
                else
                {
                    MessageBox.Show("程序轴号写错啦！联系制造商");
                    return;
                }
                CardControl.AxisGoHome(axisno);
                CheckSignal.CommonDelay(500);
                if (!CardControl.CheckOneAxisIsHome(axisno, CommonData.saveData.delay_CommonTime))
                {
                    CardControl.StopOneAxis(axisno, CommonData.saveData.delay_CommonTime);
                    MessageBox.Show("回原点失败");
                }
                MessageBox.Show("回原点成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btn_setOutIO(object sender, EventArgs e)
        {
            Label thisLabel = (Label)sender;
            int bitno = Convert.ToInt32(thisLabel.Name.Substring(thisLabel.Name.IndexOf("Out")+3));
            if (thisLabel.Name.Contains("P1"))
            {
                if (IOMonitor.ReadOneOutBit((ushort)(bitno + 100)) == 0)
                {
                    IOMonitor.SetOneOutBit((ushort)(bitno + 100), 1);
                    thisLabel.BackColor = SystemColors.ControlDark;
                }
                else
                {
                    IOMonitor.SetOneOutBit((ushort)(bitno + 100), 0);
                    thisLabel.BackColor = Color.Green;
                }
            }
            else
            {
                if (IOMonitor.ReadOneOutBit((ushort)bitno) == 0)
                {
                    IOMonitor.SetOneOutBit((ushort)bitno, 1);
                    thisLabel.BackColor = SystemColors.ControlDark;
                }
                else
                {
                    IOMonitor.SetOneOutBit((ushort)bitno, 0);
                    thisLabel.BackColor = Color.Green;
                }
            }
        }

        private void btn_KPBean_Click(object sender, EventArgs e)
        {


            try
            {
                if (button68.Text == "进料对射限制使能")
                {
                    CardControl.AxisSetDstp(CommonData.axisProductCome_RiseAndDown, 1, 1);
                    button68.Text = "进料对射限制关闭";
                }
                else
                {
                    CardControl.AxisSetDstp(CommonData.axisProductCome_RiseAndDown, 0, 1);
                    button68.Text = "进料对射限制使能";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

      

        private void btn_VisionSet_Click(object sender, EventArgs e)
        {
            VisionSetting ws = new VisionSetting();
            ws.Show();
        }

        private void btn_ParaSet_Click(object sender, EventArgs e)
        {
            ParaSetVision pa = new ParaSetVision();
            pa.ShowDialog();
        }

        private void btn_InPut_Click(object sender, EventArgs e)
        {
            IOVision al = new IOVision();
            al.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PositionAndSpeedSet poi = new PositionAndSpeedSet();
            poi.Show();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            try
            {
                if (button67.Text == "出料对射限制使能")
                {
                    CardControl.AxisSetDstp(CommonData.axisProductOut_RiseAndDown, 1, 1);
                    button67.Text = "出料对射限制关闭";
                }
                else
                {
                    CardControl.AxisSetDstp(CommonData.axisProductOut_RiseAndDown, 0, 1);
                    button67.Text = "出料对射限制使能";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button62_Click(object sender, EventArgs e)
        {
            DataSetVision da = new DataSetVision();
            da.Show();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckBox radio = (CheckBox)sender;
            int bitno = Convert.ToInt32(radio.Name.Substring(radio.Name.IndexOf("cb_") + 3, 2));
            if (radio.Name.Contains("xd"))
            {
                ((CheckBox)(AnnualMaitenance.Controls.Find("cb_" + String.Format("{0:D2}", bitno) + "_jd", false)[0])).Checked = false;
            }
            else
            {
                ((CheckBox)(AnnualMaitenance.Controls.Find("cb_" + String.Format("{0:D2}", bitno) + "_xd", false)[0])).Checked = false;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            bool isselect = false;
            for (int i = 0; i < CommonData.axisNum; i++)
            {
                if (((CheckBox)(AnnualMaitenance.Controls.Find("cb_" + i, false)[0])).Checked)
                {
                    isselect = true;
                    if (((CheckBox)(AnnualMaitenance.Controls.Find("cb_" + String.Format("{0:D2}", i) + "_jd", false)[0])).Checked)
                    {
                        CardControl.AxisPmove((ushort)i, Convert.ToInt32(posi_0.Text), 1);
                        MessageBox.Show("选择轴"+i+"运动模式为绝对运动！");
                    }
                    else if (((CheckBox)(AnnualMaitenance.Controls.Find("cb_" + String.Format("{0:D2}", i) + "_xd", false)[0])).Checked)
                    {
                        CardControl.AxisPmove((ushort)i, Convert.ToInt32(posi_0.Text), 0);
                        MessageBox.Show("选择轴" + i + "运动模式为相对运动！");
                    }
                    else
                    {
                        MessageBox.Show("请选择轴"+i+"运动模式！");
                        continue;
                    }
                    
                }
                             
            }
            if (isselect == false)
            {
                MessageBox.Show("未选择任何轴！");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool isselect = false;
            for (int i = 0; i < CommonData.axisNum; i++)
            {
                if (((CheckBox)(AnnualMaitenance.Controls.Find("cb_" + i, false)[0])).Checked)
                {
                    CardControl.StopOneAxis((ushort)i, CommonData.saveData.delay_CommonTime);
                    isselect = true;
                }
            }
            if (isselect == false)
            {
                MessageBox.Show("未选择任何轴！");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
            {
                CardControl.StopOneAxis(axisno, CommonData.saveData.delay_CommonTime);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
            try
            {
                string errmsg;
                CommonData.signal_tcptest = true;
                if (!CommonData.tcpClient.ClientSend(CommonData.tcpAsk1 + "\r\n", out errmsg))
                    throw new Exception(errmsg);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {            
            CardControl.AxisMoveAndCheck(CommonData.axisDownDepth_CheckMove, CardControl.AxisNowPosition(CommonData.axisUpDepth_CheckMove)-1844, 1, CommonData.saveData.delay_CommonTime);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CheckPointSet ch = new CheckPointSet();
            ch.Show();
        }
    }
}
