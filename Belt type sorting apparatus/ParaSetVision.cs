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
    public partial class ParaSetVision : Form
    {
        public ParaSetVision()
        {
            InitializeComponent();
            InitAll();
        }

        private void InitAll()
        {
           
            textBox10.Text = CommonData.saveData.delay_CommonTime.ToString();
            textBox7.Text = CommonData.saveData.delay_SuckTime.ToString();
            textBox8.Text = CommonData.saveData.delay_PuffTime.ToString();
            textBox14.Text = CommonData.saveData.delay_MannulHomeTime.ToString();
           
            textBox26.Text = CommonData.saveData.pre_Score.ToString();
            textBox24.Text = CommonData.saveData.product_Score.ToString();
            textBox23.Text = CommonData.saveData.cameraComeDelay.ToString();
            textBox25.Text = CommonData.saveData.cameraLeaveDelay.ToString();

            if (CommonData.saveData.signal_isLaShen)
            {
                button6.Text = "屏蔽拉伸";
            }
            else
            {
                button6.Text = "打开拉伸";
            }


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectModel();
        }

        public void SelectModel()
        {
            int select = comboBox1.SelectedIndex;
            switch (select)
            {
                case 0:

                    textBox1.Text = CommonData.saveData.startSpeedAutoAxis0.ToString();
                    textBox2.Text = CommonData.saveData.runSpeedAutoAxis0.ToString();
                    textBox3.Text = CommonData.saveData.stopSpeedAutoAxis0.ToString();
                    textBox4.Text = CommonData.saveData.accTimeAutoAxis0.ToString();
                    textBox5.Text = CommonData.saveData.decTimeAutoAxis0.ToString();
                    break;
                case 1:
                    textBox1.Text = CommonData.saveData.startSpeedAutoAxis1.ToString();
                    textBox2.Text = CommonData.saveData.runSpeedAutoAxis1.ToString();
                    textBox3.Text = CommonData.saveData.stopSpeedAutoAxis1.ToString();
                    textBox4.Text = CommonData.saveData.accTimeAutoAxis1.ToString();
                    textBox5.Text = CommonData.saveData.decTimeAutoAxis1.ToString();
                    break;
                case 2:
                    textBox1.Text = CommonData.saveData.startSpeedAutoAxis2.ToString();
                    textBox2.Text = CommonData.saveData.runSpeedAutoAxis2.ToString();
                    textBox3.Text = CommonData.saveData.stopSpeedAutoAxis2.ToString();
                    textBox4.Text = CommonData.saveData.accTimeAutoAxis2.ToString();
                    textBox5.Text = CommonData.saveData.decTimeAutoAxis2.ToString();
                    break;
                case 3:
                    textBox1.Text = CommonData.saveData.startSpeedAutoAxis3.ToString();
                    textBox2.Text = CommonData.saveData.runSpeedAutoAxis3.ToString();
                    textBox3.Text = CommonData.saveData.stopSpeedAutoAxis3.ToString();
                    textBox4.Text = CommonData.saveData.accTimeAutoAxis3.ToString();
                    textBox5.Text = CommonData.saveData.decTimeAutoAxis3.ToString();
                    break;
                case 4:
                    textBox1.Text = CommonData.saveData.startSpeedAutoAxis4.ToString();
                    textBox2.Text = CommonData.saveData.runSpeedAutoAxis4.ToString();
                    textBox3.Text = CommonData.saveData.stopSpeedAutoAxis4.ToString();
                    textBox4.Text = CommonData.saveData.accTimeAutoAxis4.ToString();
                    textBox5.Text = CommonData.saveData.decTimeAutoAxis4.ToString();
                    break;
                case 5:
                    textBox1.Text = CommonData.saveData.startSpeedAutoAxis5.ToString();
                    textBox2.Text = CommonData.saveData.runSpeedAutoAxis5.ToString();
                    textBox3.Text = CommonData.saveData.stopSpeedAutoAxis5.ToString();
                    textBox4.Text = CommonData.saveData.accTimeAutoAxis5.ToString();
                    textBox5.Text = CommonData.saveData.decTimeAutoAxis5.ToString();
                    break;
                case 6:
                    textBox1.Text = CommonData.saveData.startSpeedAutoAxis6.ToString();
                    textBox2.Text = CommonData.saveData.runSpeedAutoAxis6.ToString();
                    textBox3.Text = CommonData.saveData.stopSpeedAutoAxis6.ToString();
                    textBox4.Text = CommonData.saveData.accTimeAutoAxis6.ToString();
                    textBox5.Text = CommonData.saveData.decTimeAutoAxis6.ToString();
                    break;
                case 7:
                    textBox1.Text = CommonData.saveData.startSpeedAutoAxis7.ToString();
                    textBox2.Text = CommonData.saveData.runSpeedAutoAxis7.ToString();
                    textBox3.Text = CommonData.saveData.stopSpeedAutoAxis7.ToString();
                    textBox4.Text = CommonData.saveData.accTimeAutoAxis7.ToString();
                    textBox5.Text = CommonData.saveData.decTimeAutoAxis7.ToString();
                    break;
                case 8:
                    textBox1.Text = CommonData.saveData.startSpeedAutoAxis8.ToString();
                    textBox2.Text = CommonData.saveData.runSpeedAutoAxis8.ToString();
                    textBox3.Text = CommonData.saveData.stopSpeedAutoAxis8.ToString();
                    textBox4.Text = CommonData.saveData.accTimeAutoAxis8.ToString();
                    textBox5.Text = CommonData.saveData.decTimeAutoAxis8.ToString();
                    break;
                case 9:
                    textBox1.Text = CommonData.saveData.startSpeedAutoAxis9.ToString();
                    textBox2.Text = CommonData.saveData.runSpeedAutoAxis9.ToString();
                    textBox3.Text = CommonData.saveData.stopSpeedAutoAxis9.ToString();
                    textBox4.Text = CommonData.saveData.accTimeAutoAxis9.ToString();
                    textBox5.Text = CommonData.saveData.decTimeAutoAxis9.ToString();
                    break;
                case 10:
                    textBox1.Text = CommonData.saveData.startSpeedAutoAxis10.ToString();
                    textBox2.Text = CommonData.saveData.runSpeedAutoAxis10.ToString();
                    textBox3.Text = CommonData.saveData.stopSpeedAutoAxis10.ToString();
                    textBox4.Text = CommonData.saveData.accTimeAutoAxis10.ToString();
                    textBox5.Text = CommonData.saveData.decTimeAutoAxis10.ToString();
                    break;
                case 11:
                    textBox1.Text = CommonData.saveData.startSpeedAutoAxis11.ToString();
                    textBox2.Text = CommonData.saveData.runSpeedAutoAxis11.ToString();
                    textBox3.Text = CommonData.saveData.stopSpeedAutoAxis11.ToString();
                    textBox4.Text = CommonData.saveData.accTimeAutoAxis11.ToString();
                    textBox5.Text = CommonData.saveData.decTimeAutoAxis11.ToString();
                    break;
                default:
                    MessageBox.Show("您没有选择任何轴！");
                    break;
            }
        }

        private void ParaSetVision_Shown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(CommonData.allModel);
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(CommonData.allModel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CommonData.authorization != 3)
            {
                MessageBox.Show("您权限不够！请联系开发者修改！");
                return;
            }

            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("请选择轴设置参数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int select = comboBox1.SelectedIndex;
            switch (select)
            {
                case 0:

                    CommonData.saveData.startSpeedAutoAxis0 = Convert.ToDouble(textBox1.Text);
                    CommonData.saveData.runSpeedAutoAxis0 = Convert.ToDouble(textBox2.Text);
                    CommonData.saveData.stopSpeedAutoAxis0 = Convert.ToDouble(textBox3.Text);
                    CommonData.saveData.accTimeAutoAxis0 = Convert.ToDouble(textBox4.Text);
                    CommonData.saveData.decTimeAutoAxis0 = Convert.ToDouble(textBox5.Text);



                    break;
                case 1:
                    CommonData.saveData.startSpeedAutoAxis1 = Convert.ToDouble(textBox1.Text);
                    CommonData.saveData.runSpeedAutoAxis1 = Convert.ToDouble(textBox2.Text);
                    CommonData.saveData.stopSpeedAutoAxis1 = Convert.ToDouble(textBox3.Text);
                    CommonData.saveData.accTimeAutoAxis1 = Convert.ToDouble(textBox4.Text);
                    CommonData.saveData.decTimeAutoAxis1 = Convert.ToDouble(textBox5.Text);


                    break;
                case 2:

                    CommonData.saveData.startSpeedAutoAxis2 = Convert.ToDouble(textBox1.Text);
                    CommonData.saveData.runSpeedAutoAxis2 = Convert.ToDouble(textBox2.Text);
                    CommonData.saveData.stopSpeedAutoAxis2 = Convert.ToDouble(textBox3.Text);
                    CommonData.saveData.accTimeAutoAxis2 = Convert.ToDouble(textBox4.Text);
                    CommonData.saveData.decTimeAutoAxis2 = Convert.ToDouble(textBox5.Text);


                    break;
                case 3:

                    CommonData.saveData.startSpeedAutoAxis3 = Convert.ToDouble(textBox1.Text);
                    CommonData.saveData.runSpeedAutoAxis3 = Convert.ToDouble(textBox2.Text);
                    CommonData.saveData.stopSpeedAutoAxis3 = Convert.ToDouble(textBox3.Text);
                    CommonData.saveData.accTimeAutoAxis3 = Convert.ToDouble(textBox4.Text);
                    CommonData.saveData.decTimeAutoAxis3 = Convert.ToDouble(textBox5.Text);

                    break;
                case 4:

                    CommonData.saveData.startSpeedAutoAxis4 = Convert.ToDouble(textBox1.Text);
                    CommonData.saveData.runSpeedAutoAxis4 = Convert.ToDouble(textBox2.Text);
                    CommonData.saveData.stopSpeedAutoAxis4 = Convert.ToDouble(textBox3.Text);
                    CommonData.saveData.accTimeAutoAxis4 = Convert.ToDouble(textBox4.Text);
                    CommonData.saveData.decTimeAutoAxis4 = Convert.ToDouble(textBox5.Text);

                    break;
                case 5:

                    CommonData.saveData.startSpeedAutoAxis5 = Convert.ToDouble(textBox1.Text);
                    CommonData.saveData.runSpeedAutoAxis5 = Convert.ToDouble(textBox2.Text);
                    CommonData.saveData.stopSpeedAutoAxis5 = Convert.ToDouble(textBox3.Text);
                    CommonData.saveData.accTimeAutoAxis5 = Convert.ToDouble(textBox4.Text);
                    CommonData.saveData.decTimeAutoAxis5 = Convert.ToDouble(textBox5.Text);

                    break;
                case 6:

                    CommonData.saveData.startSpeedAutoAxis6 = Convert.ToDouble(textBox1.Text);
                    CommonData.saveData.runSpeedAutoAxis6 = Convert.ToDouble(textBox2.Text);
                    CommonData.saveData.stopSpeedAutoAxis6 = Convert.ToDouble(textBox3.Text);
                    CommonData.saveData.accTimeAutoAxis6 = Convert.ToDouble(textBox4.Text);
                    CommonData.saveData.decTimeAutoAxis6 = Convert.ToDouble(textBox5.Text);

                    break;
                case 7:

                    CommonData.saveData.startSpeedAutoAxis7 = Convert.ToDouble(textBox1.Text);
                    CommonData.saveData.runSpeedAutoAxis7 = Convert.ToDouble(textBox2.Text);
                    CommonData.saveData.stopSpeedAutoAxis7 = Convert.ToDouble(textBox3.Text);
                    CommonData.saveData.accTimeAutoAxis7 = Convert.ToDouble(textBox4.Text);
                    CommonData.saveData.decTimeAutoAxis7 = Convert.ToDouble(textBox5.Text);

                    break;
                case 8:

                    CommonData.saveData.startSpeedAutoAxis8 = Convert.ToDouble(textBox1.Text);
                    CommonData.saveData.runSpeedAutoAxis8 = Convert.ToDouble(textBox2.Text);
                    CommonData.saveData.stopSpeedAutoAxis8 = Convert.ToDouble(textBox3.Text);
                    CommonData.saveData.accTimeAutoAxis8 = Convert.ToDouble(textBox4.Text);
                    CommonData.saveData.decTimeAutoAxis8 = Convert.ToDouble(textBox5.Text);

                    break;
                case 9:

                    CommonData.saveData.startSpeedAutoAxis9 = Convert.ToDouble(textBox1.Text);
                    CommonData.saveData.runSpeedAutoAxis9 = Convert.ToDouble(textBox2.Text);
                    CommonData.saveData.stopSpeedAutoAxis9 = Convert.ToDouble(textBox3.Text);
                    CommonData.saveData.accTimeAutoAxis9 = Convert.ToDouble(textBox4.Text);
                    CommonData.saveData.decTimeAutoAxis9 = Convert.ToDouble(textBox5.Text);

                    break;
                case 10:

                    CommonData.saveData.startSpeedAutoAxis10 = Convert.ToDouble(textBox1.Text);
                    CommonData.saveData.runSpeedAutoAxis10 = Convert.ToDouble(textBox2.Text);
                    CommonData.saveData.stopSpeedAutoAxis10 = Convert.ToDouble(textBox3.Text);
                    CommonData.saveData.accTimeAutoAxis10 = Convert.ToDouble(textBox4.Text);
                    CommonData.saveData.decTimeAutoAxis10 = Convert.ToDouble(textBox5.Text);

                    break;
                case 11:

                    CommonData.saveData.startSpeedAutoAxis11 = Convert.ToDouble(textBox1.Text);
                    CommonData.saveData.runSpeedAutoAxis11 = Convert.ToDouble(textBox2.Text);
                    CommonData.saveData.stopSpeedAutoAxis11 = Convert.ToDouble(textBox3.Text);
                    CommonData.saveData.accTimeAutoAxis11 = Convert.ToDouble(textBox4.Text);
                    CommonData.saveData.decTimeAutoAxis11 = Convert.ToDouble(textBox5.Text);

                    break;
                default:
                    MessageBox.Show("您没有选择任何轴");
                    break;
            }

         


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CommonData.authorization != 3)
            {
                MessageBox.Show("您权限不够！请联系开发者修改！");
                return;
            }
            CommonData.saveData.delay_CommonTime = Convert.ToInt32(textBox10.Text);
            CommonData.saveData.delay_SuckTime = Convert.ToInt32(textBox7.Text);
            CommonData.saveData.delay_PuffTime = Convert.ToInt32(textBox8.Text);
            CommonData.saveData.delay_MannulHomeTime = Convert.ToInt32(textBox14.Text);
            CommonData.saveData.cameraComeDelay = Convert.ToInt32(textBox23.Text);
            CommonData.saveData.cameraLeaveDelay = Convert.ToInt32(textBox25.Text);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectModel2();
        }



        public void SelectModel2()
        {
            int select = comboBox2.SelectedIndex;
            switch (select)
            {
                case 0:

                    textBox13.Text = CommonData.saveData.startSpeedMaualAxis0.ToString();
                    textBox12.Text = CommonData.saveData.runSpeedMaualAxis0.ToString();
                    textBox9.Text = CommonData.saveData.stopSpeedMaualAxis0.ToString();
                    textBox11.Text = CommonData.saveData.accTimeMaualAxis0.ToString();
                    textBox6.Text = CommonData.saveData.decTimeMaualAxis0.ToString();
                    break;
                case 1:
                    textBox13.Text = CommonData.saveData.startSpeedMaualAxis1.ToString();
                    textBox12.Text = CommonData.saveData.runSpeedMaualAxis1.ToString();
                    textBox9.Text = CommonData.saveData.stopSpeedMaualAxis1.ToString();
                    textBox11.Text = CommonData.saveData.accTimeMaualAxis1.ToString();
                    textBox6.Text = CommonData.saveData.decTimeMaualAxis1.ToString();
                    break;
                case 2:
                    textBox13.Text = CommonData.saveData.startSpeedMaualAxis2.ToString();
                    textBox12.Text = CommonData.saveData.runSpeedMaualAxis2.ToString();
                    textBox9.Text = CommonData.saveData.stopSpeedMaualAxis2.ToString();
                    textBox11.Text = CommonData.saveData.accTimeMaualAxis2.ToString();
                    textBox6.Text = CommonData.saveData.decTimeMaualAxis2.ToString();
                    break;
                case 3:
                    textBox13.Text = CommonData.saveData.startSpeedMaualAxis3.ToString();
                    textBox12.Text = CommonData.saveData.runSpeedMaualAxis3.ToString();
                    textBox9.Text = CommonData.saveData.stopSpeedMaualAxis3.ToString();
                    textBox11.Text = CommonData.saveData.accTimeMaualAxis3.ToString();
                    textBox6.Text = CommonData.saveData.decTimeMaualAxis3.ToString();
                    break;
                case 4:
                    textBox13.Text = CommonData.saveData.startSpeedMaualAxis4.ToString();
                    textBox12.Text = CommonData.saveData.runSpeedMaualAxis4.ToString();
                    textBox9.Text = CommonData.saveData.stopSpeedMaualAxis4.ToString();
                    textBox11.Text = CommonData.saveData.accTimeMaualAxis4.ToString();
                    textBox6.Text = CommonData.saveData.decTimeMaualAxis4.ToString();
                    break;
                case 5:
                    textBox13.Text = CommonData.saveData.startSpeedMaualAxis5.ToString();
                    textBox12.Text = CommonData.saveData.runSpeedMaualAxis5.ToString();
                    textBox9.Text = CommonData.saveData.stopSpeedMaualAxis5.ToString();
                    textBox11.Text = CommonData.saveData.accTimeMaualAxis5.ToString();
                    textBox6.Text = CommonData.saveData.decTimeMaualAxis5.ToString();
                    break;
                case 6:
                    textBox13.Text = CommonData.saveData.startSpeedMaualAxis6.ToString();
                    textBox12.Text = CommonData.saveData.runSpeedMaualAxis6.ToString();
                    textBox9.Text = CommonData.saveData.stopSpeedMaualAxis6.ToString();
                    textBox11.Text = CommonData.saveData.accTimeMaualAxis6.ToString();
                    textBox6.Text = CommonData.saveData.decTimeMaualAxis6.ToString();
                    break;
                case 7:
                    textBox13.Text = CommonData.saveData.startSpeedMaualAxis7.ToString();
                    textBox12.Text = CommonData.saveData.runSpeedMaualAxis7.ToString();
                    textBox9.Text = CommonData.saveData.stopSpeedMaualAxis7.ToString();
                    textBox11.Text = CommonData.saveData.accTimeMaualAxis7.ToString();
                    textBox6.Text = CommonData.saveData.decTimeMaualAxis7.ToString();
                    break;
                case 8:
                    textBox13.Text = CommonData.saveData.startSpeedMaualAxis8.ToString();
                    textBox12.Text = CommonData.saveData.runSpeedMaualAxis8.ToString();
                    textBox9.Text = CommonData.saveData.stopSpeedMaualAxis8.ToString();
                    textBox11.Text = CommonData.saveData.accTimeMaualAxis8.ToString();
                    textBox6.Text = CommonData.saveData.decTimeMaualAxis8.ToString();
                    break;
                case 9:
                    textBox13.Text = CommonData.saveData.startSpeedMaualAxis9.ToString();
                    textBox12.Text = CommonData.saveData.runSpeedMaualAxis9.ToString();
                    textBox9.Text = CommonData.saveData.stopSpeedMaualAxis9.ToString();
                    textBox11.Text = CommonData.saveData.accTimeMaualAxis9.ToString();
                    textBox6.Text = CommonData.saveData.decTimeMaualAxis9.ToString();
                    break;
                case 10:
                    textBox13.Text = CommonData.saveData.startSpeedMaualAxis10.ToString();
                    textBox12.Text = CommonData.saveData.runSpeedMaualAxis10.ToString();
                    textBox9.Text = CommonData.saveData.stopSpeedMaualAxis10.ToString();
                    textBox11.Text = CommonData.saveData.accTimeMaualAxis10.ToString();
                    textBox6.Text = CommonData.saveData.decTimeMaualAxis10.ToString();
                    break;
                case 11:
                    textBox13.Text = CommonData.saveData.startSpeedMaualAxis11.ToString();
                    textBox12.Text = CommonData.saveData.runSpeedMaualAxis11.ToString();
                    textBox9.Text = CommonData.saveData.stopSpeedMaualAxis11.ToString();
                    textBox11.Text = CommonData.saveData.accTimeMaualAxis11.ToString();
                    textBox6.Text = CommonData.saveData.decTimeMaualAxis11.ToString();
                    break;
                default:
                    MessageBox.Show("您没有选择任何轴！");
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("请选择轴设置参数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int select = comboBox2.SelectedIndex;
            switch (select)
            {
                case 0:
                   
                    CommonData.saveData.startSpeedMaualAxis0 = Convert.ToDouble(textBox13.Text);
                    CommonData.saveData.runSpeedMaualAxis0 = Convert.ToDouble(textBox12.Text);
                    CommonData.saveData.stopSpeedMaualAxis0 = Convert.ToDouble(textBox9.Text);
                    CommonData.saveData.accTimeMaualAxis0 = Convert.ToDouble(textBox11.Text);
                    CommonData.saveData.decTimeMaualAxis0 = Convert.ToDouble(textBox6.Text);



                    break;
                case 1:
                    CommonData.saveData.startSpeedMaualAxis1 = Convert.ToDouble(textBox13.Text);
                    CommonData.saveData.runSpeedMaualAxis1 = Convert.ToDouble(textBox12.Text);
                    CommonData.saveData.stopSpeedMaualAxis1 = Convert.ToDouble(textBox9.Text);
                    CommonData.saveData.accTimeMaualAxis1 = Convert.ToDouble(textBox11.Text);
                    CommonData.saveData.decTimeMaualAxis1 = Convert.ToDouble(textBox6.Text);


                    break;
                case 2:

                    CommonData.saveData.startSpeedMaualAxis2 = Convert.ToDouble(textBox13.Text);
                    CommonData.saveData.runSpeedMaualAxis2 = Convert.ToDouble(textBox12.Text);
                    CommonData.saveData.stopSpeedMaualAxis2 = Convert.ToDouble(textBox9.Text);
                    CommonData.saveData.accTimeMaualAxis2 = Convert.ToDouble(textBox11.Text);
                    CommonData.saveData.decTimeMaualAxis2 = Convert.ToDouble(textBox6.Text);

                    break;
                case 3:

                    CommonData.saveData.startSpeedMaualAxis3 = Convert.ToDouble(textBox13.Text);
                    CommonData.saveData.runSpeedMaualAxis3 = Convert.ToDouble(textBox12.Text);
                    CommonData.saveData.stopSpeedMaualAxis3 = Convert.ToDouble(textBox9.Text);
                    CommonData.saveData.accTimeMaualAxis3 = Convert.ToDouble(textBox11.Text);
                    CommonData.saveData.decTimeMaualAxis3 = Convert.ToDouble(textBox6.Text);
                    break;
                case 4:

                    CommonData.saveData.startSpeedMaualAxis4 = Convert.ToDouble(textBox13.Text);
                    CommonData.saveData.runSpeedMaualAxis4 = Convert.ToDouble(textBox12.Text);
                    CommonData.saveData.stopSpeedMaualAxis4 = Convert.ToDouble(textBox9.Text);
                    CommonData.saveData.accTimeMaualAxis4 = Convert.ToDouble(textBox11.Text);
                    CommonData.saveData.decTimeMaualAxis4 = Convert.ToDouble(textBox6.Text);

                    break;
                case 5:

                    CommonData.saveData.startSpeedMaualAxis5 = Convert.ToDouble(textBox13.Text);
                    CommonData.saveData.runSpeedMaualAxis5 = Convert.ToDouble(textBox12.Text);
                    CommonData.saveData.stopSpeedMaualAxis5 = Convert.ToDouble(textBox9.Text);
                    CommonData.saveData.accTimeMaualAxis5 = Convert.ToDouble(textBox11.Text);
                    CommonData.saveData.decTimeMaualAxis5 = Convert.ToDouble(textBox6.Text);

                    break;
                case 6:

                    CommonData.saveData.startSpeedMaualAxis6 = Convert.ToDouble(textBox13.Text);
                    CommonData.saveData.runSpeedMaualAxis6 = Convert.ToDouble(textBox12.Text);
                    CommonData.saveData.stopSpeedMaualAxis6 = Convert.ToDouble(textBox9.Text);
                    CommonData.saveData.accTimeMaualAxis6 = Convert.ToDouble(textBox11.Text);
                    CommonData.saveData.decTimeMaualAxis6 = Convert.ToDouble(textBox6.Text);

                    break;
                case 7:

                    CommonData.saveData.startSpeedMaualAxis7 = Convert.ToDouble(textBox13.Text);
                    CommonData.saveData.runSpeedMaualAxis7 = Convert.ToDouble(textBox12.Text);
                    CommonData.saveData.stopSpeedMaualAxis7 = Convert.ToDouble(textBox9.Text);
                    CommonData.saveData.accTimeMaualAxis7 = Convert.ToDouble(textBox11.Text);
                    CommonData.saveData.decTimeMaualAxis7 = Convert.ToDouble(textBox6.Text);
                    break;
                case 8:

                    CommonData.saveData.startSpeedMaualAxis8 = Convert.ToDouble(textBox13.Text);
                    CommonData.saveData.runSpeedMaualAxis8 = Convert.ToDouble(textBox12.Text);
                    CommonData.saveData.stopSpeedMaualAxis8 = Convert.ToDouble(textBox9.Text);
                    CommonData.saveData.accTimeMaualAxis8 = Convert.ToDouble(textBox11.Text);
                    CommonData.saveData.decTimeMaualAxis8 = Convert.ToDouble(textBox6.Text);
                    break;
                case 9:

                    CommonData.saveData.startSpeedMaualAxis9 = Convert.ToDouble(textBox13.Text);
                    CommonData.saveData.runSpeedMaualAxis9 = Convert.ToDouble(textBox12.Text);
                    CommonData.saveData.stopSpeedMaualAxis9 = Convert.ToDouble(textBox9.Text);
                    CommonData.saveData.accTimeMaualAxis9 = Convert.ToDouble(textBox11.Text);
                    CommonData.saveData.decTimeMaualAxis9 = Convert.ToDouble(textBox6.Text);
                    break;
                case 10:

                    CommonData.saveData.startSpeedMaualAxis10 = Convert.ToDouble(textBox13.Text);
                    CommonData.saveData.runSpeedMaualAxis10 = Convert.ToDouble(textBox12.Text);
                    CommonData.saveData.stopSpeedMaualAxis10 = Convert.ToDouble(textBox9.Text);
                    CommonData.saveData.accTimeMaualAxis10 = Convert.ToDouble(textBox11.Text);
                    CommonData.saveData.decTimeMaualAxis10 = Convert.ToDouble(textBox6.Text);

                    break;
                case 11:

                    CommonData.saveData.startSpeedMaualAxis11 = Convert.ToDouble(textBox13.Text);
                    CommonData.saveData.runSpeedMaualAxis11 = Convert.ToDouble(textBox12.Text);
                    CommonData.saveData.stopSpeedMaualAxis11 = Convert.ToDouble(textBox9.Text);
                    CommonData.saveData.accTimeMaualAxis11 = Convert.ToDouble(textBox11.Text);
                    CommonData.saveData.decTimeMaualAxis11 = Convert.ToDouble(textBox6.Text);

                    break;
                default:
                    MessageBox.Show("您没有选择任何轴");
                    break;
            }



        }

        private void ParaSetVision_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CommonData.signal_SysInitOK)
            {
                for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
                {
                    CardControl.SetManualProfile(axisno);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CommonData.saveData.pre_Score = Convert.ToDouble(textBox26.Text);
            CommonData.saveData.product_Score = Convert.ToDouble(textBox24.Text);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "打开拉伸")
            {
                CommonData.saveData.signal_isLaShen = true;
                button6.Text = "屏蔽拉伸";
            }
            else
            {
                CommonData.saveData.signal_isLaShen = false;
                button6.Text = "打开拉伸";
            }
                
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
