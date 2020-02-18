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
    public partial class FlagView : Form
    {
       
        public FlagView()
        {
            InitializeComponent();
        }

   

      

        private void FlagView_Shown(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            timer5.Start();
            timer6.Start();
      
        }

 
        private void FlagView_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            timer5.Stop();
            timer6.Stop();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            viewPort1.Controls.Clear();
            CommonData.flagController1.Invoke(new Action(() =>
            {
                foreach (TextBox temp in CommonData.flagController1.Controls)
                {
                    TextBox temp1 = new TextBox();
                    temp1.Size = temp.Size;
                    temp1.Text = temp.Text;
                    temp1.BackColor = temp.BackColor;
                    temp1.Left = temp.Left;
                    temp1.Top = temp.Top;
                    temp1.TextAlign = temp.TextAlign;
                    temp1.Enabled = false;
                    viewPort1.Controls.Add(temp1);
                }
            }));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            viewPort2.Controls.Clear();
            CommonData.flagController2.Invoke(new Action(() =>
            {
                foreach (TextBox temp in CommonData.flagController2.Controls)
                {
                    TextBox temp1 = new TextBox();
                    temp1.Size = temp.Size;
                    temp1.Text = temp.Text;
                    temp1.BackColor = temp.BackColor;
                    temp1.Left = temp.Left;
                    temp1.Top = temp.Top;
                    temp1.TextAlign = temp.TextAlign;
                    temp1.Enabled = false;
                    viewPort2.Controls.Add(temp1);
                }
            }));
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            viewPort3.Controls.Clear();
            CommonData.flagController3.Invoke(new Action(() =>
            {
                foreach (TextBox temp in CommonData.flagController3.Controls)
                {
                    TextBox temp1 = new TextBox();
                    temp1.Size = temp.Size;
                    temp1.Text = temp.Text;
                    temp1.BackColor = temp.BackColor;
                    temp1.Left = temp.Left;
                    temp1.Top = temp.Top;
                    temp1.TextAlign = temp.TextAlign;
                    temp1.Enabled = false;
                    viewPort3.Controls.Add(temp1);
                }
            }));
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            viewPort4.Controls.Clear();
            CommonData.flagController4.Invoke(new Action(() =>
            {
                foreach (TextBox temp in CommonData.flagController4.Controls)
                {
                    TextBox temp1 = new TextBox();
                    temp1.Size = temp.Size;
                    temp1.Text = temp.Text;
                    temp1.BackColor = temp.BackColor;
                    temp1.Left = temp.Left;
                    temp1.Top = temp.Top;
                    temp1.TextAlign = temp.TextAlign;
                    temp1.Enabled = false;
                    viewPort4.Controls.Add(temp1);
                }
            }));
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            viewPort5.Controls.Clear();
            CommonData.flagController5.Invoke(new Action(() =>
            {
                foreach (TextBox temp in CommonData.flagController5.Controls)
                {
                    TextBox temp1 = new TextBox();
                    temp1.Size = temp.Size;
                    temp1.Text = temp.Text;
                    temp1.BackColor = temp.BackColor;
                    temp1.Left = temp.Left;
                    temp1.Top = temp.Top;
                    temp1.TextAlign = temp.TextAlign;
                    temp1.Enabled = false;
                    viewPort5.Controls.Add(temp1);
                }
            }));
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            viewPort6.Controls.Clear();
            CommonData.flagController6.Invoke(new Action(() =>
            {
                foreach (TextBox temp in CommonData.flagController6.Controls)
                {
                    TextBox temp1 = new TextBox();
                    temp1.Size = temp.Size;
                    temp1.Text = temp.Text;
                    temp1.BackColor = temp.BackColor;
                    temp1.Left = temp.Left;
                    temp1.Top = temp.Top;
                    temp1.TextAlign = temp.TextAlign;
                    temp1.Enabled = false;
                    viewPort6.Controls.Add(temp1);
                }
            }));
        }


    }
}
