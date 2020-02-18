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
    public partial class AboutRuixiang : Form
    {
        public AboutRuixiang()
        {
            InitializeComponent();
        }

        private void AboutRuixiang_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
