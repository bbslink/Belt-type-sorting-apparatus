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
    public partial class IOVision : Form
    {
        public IOVision()
        {
            InitializeComponent();
        }

        private void ReadAllInport()
        {

            try
            {

                for (ushort axis = 0; axis < CommonData.axisNum; axis++)
                {

                    bool org = CardControl.CheckAxisHome(axis);//ORG
                    bool elf = CardControl.CheckAxisELMin(axis);//EL-
                    bool elz = CardControl.CheckAxisELPlus(axis);//EL+
                    bool alm = CardControl.CheckAxisALM(axis);//ALM
                  
                    if (org)
                        ((Label)(this.tableLayoutPanel_input.Controls.Find("in_" + (axis * 4 + 0), false)[0])).BackColor = Color.Red;
                    else
                        ((Label)(this.tableLayoutPanel_input.Controls.Find("in_" + (axis * 4 + 0), false)[0])).BackColor = SystemColors.ControlDark;
                    //EL-
                    if (elf)
                        ((Label)(this.tableLayoutPanel_input.Controls.Find("in_" + (axis * 4 + 1), false)[0])).BackColor = Color.Red;
                    else
                        ((Label)(this.tableLayoutPanel_input.Controls.Find("in_" + (axis * 4 + 1), false)[0])).BackColor = SystemColors.ControlDark;
                    //EL+
                    if (elz)
                        ((Label)(this.tableLayoutPanel_input.Controls.Find("in_" + (axis * 4 + 2), false)[0])).BackColor = Color.Red;
                    else
                        ((Label)(this.tableLayoutPanel_input.Controls.Find("in_" + (axis * 4 + 2), false)[0])).BackColor = SystemColors.ControlDark;
                    //ALM
                    if (axis <= 7)   //屏蔽步进没有报警
                    {
                        if (alm)
                            ((Label)(this.tableLayoutPanel_input.Controls.Find("in_" + (axis * 4 + 3), false)[0])).BackColor = Color.Red;
                        else
                            ((Label)(this.tableLayoutPanel_input.Controls.Find("in_" + (axis * 4 + 3), false)[0])).BackColor = SystemColors.ControlDark;
                    }
                }


                for (ushort ioNo = 0; ioNo < 16; ioNo++)
                {
                    short result = IOMonitor.ReadOneInBit(ioNo);

                    if (result <= 0)
                    {
                        ((Label)(this.tableLayoutPanel1.Controls.Find("In" + ioNo, false)[0])).BackColor = Color.Red;
                    }
                    else
                    {
                        ((Label)(this.tableLayoutPanel1.Controls.Find("In" + ioNo, false)[0])).BackColor = SystemColors.ControlDark;
                    }
                }

                for (ushort ioNo = 0; ioNo < 16; ioNo++)
                {
                    short result = IOMonitor.ReadOneOutBit(ioNo);

                    if (result <= 0)
                    {
                        ((Label)(this.tableLayoutPanel3.Controls.Find("Out" + ioNo, true)[0])).BackColor = Color.Red;
                    }
                    else
                    {
                        ((Label)(this.tableLayoutPanel3.Controls.Find("Out" + ioNo, true)[0])).BackColor = SystemColors.ControlDark;
                    }
                }

                for (ushort ioNo = 0; ioNo < 16; ioNo++)
                {
                    short result = IOMonitor.ReadOneInBit((ushort)(ioNo+100));

                    if (result <= 0)
                    {
                        ((Label)(this.tableLayoutPanel2.Controls.Find("P1In" + ioNo, true)[0])).BackColor = Color.Red;
                    }
                    else
                    {
                        ((Label)(this.tableLayoutPanel2.Controls.Find("P1In" + ioNo, true)[0])).BackColor = SystemColors.ControlDark;
                    }
                }

                for (ushort ioNo = 0; ioNo < 16; ioNo++)
                {
                    short result = IOMonitor.ReadOneOutBit((ushort)(ioNo + 100));

                    if (result <= 0)
                    {
                        ((Label)(this.tableLayoutPanel6.Controls.Find("P1Out" + ioNo, true)[0])).BackColor = Color.Red;
                    }
                    else
                    {
                        ((Label)(this.tableLayoutPanel6.Controls.Find("P1Out" + ioNo, true)[0])).BackColor = SystemColors.ControlDark;
                    }
                }

                for (ushort ioNo = 0; ioNo < 16; ioNo++)
                {
                    short result = IOMonitor.ReadOneInBit((ushort)(ioNo + 200));

                    if (result <= 0)
                    {
                        ((Label)(this.tableLayoutPanel4.Controls.Find("P2In" + ioNo, true)[0])).BackColor = Color.Red;
                    }
                    else
                    {
                        ((Label)(this.tableLayoutPanel4.Controls.Find("P2In" + ioNo, true)[0])).BackColor = SystemColors.ControlDark;
                    }
                }

                for (ushort ioNo = 0; ioNo < 16; ioNo++)
                {
                    short result = IOMonitor.ReadOneOutBit((ushort)(ioNo + 200));

                    if (result <= 0)
                    {
                        ((Label)(this.tableLayoutPanel5.Controls.Find("P2Out" + ioNo, true)[0])).BackColor = Color.Red;
                    }
                    else
                    {
                        ((Label)(this.tableLayoutPanel5.Controls.Find("P2Out" + ioNo, true)[0])).BackColor = SystemColors.ControlDark;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("IO状态检测失败\r" + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ReadAllInport();
        }

        private void ALLINPUT_Shown(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void ALLINPUT_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
    }
}
