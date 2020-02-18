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
    public partial class PositionAndSpeedSet : Form
    {
        public PositionAndSpeedSet()
        {
            InitializeComponent();
        }


        public void ReadPosition()
        {
            for (ushort ioNo = 0; ioNo < CommonData.axisNum; ioNo++)
            {
                ((TextBox)(this.Controls.Find("posi_" + ioNo, true)[0])).Text = CardControl.AxisNowPosition(ioNo).ToString();
            }
        }

        public void ReadSpeed()
        {
            for (ushort ioNo = 0; ioNo < CommonData.axisNum; ioNo++)
            {
                ((TextBox)(this.Controls.Find("speed_" + ioNo, true)[0])).Text = CardControl.GetCurSpeed(ioNo).ToString();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            ReadPosition();
        }

        private void PositionAndSpeedSet_Shown(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void PositionAndSpeedSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ReadSpeed();
        }
    }
}
