
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace Belt_type_sorting_apparatus
{
    public partial class CameraSet : Form
    {
        int select;
        string errmsg;
        public CameraSet(int select)
        {
            InitializeComponent();
            this.select = select;
            ShownParam();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (select == 1)
            {
               // CommonData.saveData.upCameraExposureTime = (float)Convert.ToDouble(label4.Text);
               // CommonData.saveData.upCameraGainRaw = (float)Convert.ToDouble(label5.Text);
               // CommonData.saveData.upCameraContrast = Convert.ToInt32(label8.Text);
               // CommonData.saveData.upCameraBlackLevel = Convert.ToUInt32(label6.Text);
               //// CommonData.saveData.upCameraBrightness = Convert.ToUInt32(label7.Text);
               // CommonData.CameraUp.SetExposureTime(CommonData.saveData.upCameraExposureTime, out errmsg);
               // CommonData.CameraUp.SetGain(CommonData.saveData.upCameraGainRaw, out errmsg);
               // CommonData.CameraUp.SetContrast(CommonData.saveData.upCameraContrast, out errmsg);
               // CommonData.CameraUp.SetBlackLevel(CommonData.saveData.upCameraBlackLevel, out errmsg);
               // CommonData.CameraUp.SetBrightness(CommonData.saveData.upCameraBrightness, out errmsg);
               // tb_Exposuretime.Text = (CommonData.saveData.upCameraExposureTime).ToString();
               // tb_CameraGain.Text = (CommonData.saveData.upCameraGainRaw).ToString();
               // tb_CameraContrast.Text = CommonData.saveData.upCameraContrast.ToString();
               // tb_BlackLevel.Text = CommonData.saveData.upCameraBlackLevel.ToString();
               // tb_Brightness.Text = CommonData.saveData.upCameraBrightness.ToString();
            }
            else
            {
                //CommonData.saveData.downCameraExposureTime = Convert.ToDouble(label4.Text);
                //CommonData.saveData.downCameraGainRaw = Convert.ToDouble(label5.Text);
                //CommonData.saveData.downCameraContrast = Convert.ToInt32(label8.Text);
                //CommonData.saveData.downCameraBlackLevel = Convert.ToUInt32(label6.Text);
                //CommonData.saveData.downCameraBrightness = Convert.ToInt32(label7.Text);
                //CommonData.CameraDown.SetExposureTime(CommonData.saveData.downCameraExposureTime, out errmsg);
                //CommonData.CameraDown.SetGain(CommonData.saveData.downCameraGainRaw, out errmsg);
                //CommonData.CameraDown.SetContrast(CommonData.saveData.downCameraContrast, out errmsg);
                //CommonData.CameraDown.SetBlackLevel(CommonData.saveData.downCameraBlackLevel, out errmsg);
                //CommonData.CameraDown.SetBrightness(CommonData.saveData.downCameraBrightness, out errmsg);
                //tb_Exposuretime.Text = (CommonData.saveData.downCameraExposureTime).ToString();
                //tb_CameraGain.Text = (CommonData.saveData.downCameraGainRaw).ToString();
                //tb_CameraContrast.Text = CommonData.saveData.downCameraContrast.ToString();
                //tb_BlackLevel.Text = CommonData.saveData.downCameraBlackLevel.ToString();
                //tb_Brightness.Text = CommonData.saveData.downCameraBrightness.ToString();
            }
          

        }

        private void ShownParam()
        {
            if (select == 1)
            {
                tb_Exposuretime.Text = (CommonData.saveData.upCameraExposureTime).ToString();
                tb_CameraGain.Text = (CommonData.saveData.upCameraGainRaw).ToString();
                tb_CameraContrast.Text = CommonData.saveData.upCameraContrast.ToString();
                tb_BlackLevel.Text = CommonData.saveData.upCameraBlackLevel.ToString();
                tb_Brightness.Text = CommonData.saveData.upCameraBrightness.ToString();
                CommonData.CameraUp.SetExposureTime(CommonData.saveData.upCameraExposureTime, out errmsg);
                CommonData.CameraUp.SetGain(CommonData.saveData.upCameraGainRaw, out errmsg);
                CommonData.CameraUp.SetContrast(CommonData.saveData.upCameraContrast, out errmsg);
                CommonData.CameraUp.SetBlackLevel(CommonData.saveData.upCameraBlackLevel, out errmsg);
                CommonData.CameraUp.SetBrightness(CommonData.saveData.upCameraBrightness, out errmsg);
            }
            else
            {
                tb_Exposuretime.Text = (CommonData.saveData.downCameraExposureTime).ToString();
                tb_CameraGain.Text = (CommonData.saveData.downCameraGainRaw).ToString();
                tb_CameraContrast.Text = CommonData.saveData.downCameraContrast.ToString();
                tb_BlackLevel.Text = CommonData.saveData.downCameraBlackLevel.ToString();
                tb_Brightness.Text = CommonData.saveData.downCameraBrightness.ToString();

                CommonData.CameraDown.SetExposureTime(CommonData.saveData.downCameraExposureTime, out errmsg);
                CommonData.CameraDown.SetGain(CommonData.saveData.downCameraGainRaw, out errmsg);
                CommonData.CameraDown.SetContrast(CommonData.saveData.downCameraContrast, out errmsg);
                CommonData.CameraDown.SetBlackLevel(CommonData.saveData.downCameraBlackLevel, out errmsg);
                CommonData.CameraDown.SetBrightness(CommonData.saveData.downCameraBrightness, out errmsg);
            }

            trackBar1.Value = Convert.ToInt32(tb_Exposuretime.Text);
            label4.Text = tb_Exposuretime.Text;
            trackBar2.Value = Convert.ToInt32(Convert.ToDouble(tb_CameraGain.Text) * 10);
            label5.Text = tb_CameraGain.Text;
            trackBar3.Value = Convert.ToInt32(tb_BlackLevel.Text);
            label6.Text = tb_BlackLevel.Text;
            trackBar4.Value = Convert.ToInt32(tb_Brightness.Text);
            label7.Text = tb_Brightness.Text;
            trackBar5.Value = Convert.ToInt32(tb_CameraContrast.Text);
            label8.Text = tb_CameraContrast.Text;
        }

     

        private void CameraSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (select == 1)
            {
                CommonData.CameraUp.SetExposureTime(CommonData.saveData.upCameraExposureTime, out errmsg);
                CommonData.CameraUp.SetGain(CommonData.saveData.upCameraGainRaw, out errmsg);
                CommonData.CameraUp.SetContrast(CommonData.saveData.upCameraContrast, out errmsg);
                CommonData.CameraUp.SetBlackLevel(CommonData.saveData.upCameraBlackLevel, out errmsg);
                CommonData.CameraUp.SetBrightness(CommonData.saveData.upCameraBrightness, out errmsg);
            }
            else
            {
                CommonData.CameraDown.SetExposureTime(CommonData.saveData.downCameraExposureTime, out errmsg);
                CommonData.CameraDown.SetGain(CommonData.saveData.downCameraGainRaw, out errmsg);
                CommonData.CameraDown.SetContrast(CommonData.saveData.downCameraContrast, out errmsg);
                CommonData.CameraDown.SetBlackLevel(CommonData.saveData.downCameraBlackLevel, out errmsg);
                CommonData.CameraDown.SetBrightness(CommonData.saveData.downCameraBrightness, out errmsg);
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar1.Value.ToString();
            if (select == 1)
                CommonData.CameraUp.SetExposureTime((float)Convert.ToDouble(label4.Text), out errmsg);
            else
                CommonData.CameraDown.SetExposureTime(Convert.ToDouble(label4.Text), out errmsg);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label5.Text = ((trackBar2.Value)/10.0).ToString();
            if (select == 1)
                CommonData.CameraUp.SetGain((float)Convert.ToDouble(label5.Text), out errmsg);
            else
                CommonData.CameraDown.SetGain(Convert.ToDouble(label5.Text), out errmsg);

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label6.Text = (trackBar3.Value).ToString();
            if (select == 1)
                CommonData.CameraUp.SetBlackLevel(Convert.ToUInt32(label6.Text), out errmsg);
            else
                CommonData.CameraDown.SetBlackLevel(Convert.ToUInt32(label6.Text), out errmsg);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label7.Text = (trackBar4.Value).ToString();
            //if (select == 1)
            //    CommonData.CameraUp.SetBrightness(Convert.ToUInt32(label7.Text), out errmsg);
            //else
            //    CommonData.CameraDown.SetBrightness(Convert.ToInt32(label7.Text), out errmsg);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            label8.Text = (trackBar5.Value).ToString();
            if (select == 1)
                CommonData.CameraUp.SetContrast(Convert.ToInt32(label8.Text), out errmsg);
            else
                CommonData.CameraDown.SetContrast(Convert.ToInt32(label8.Text), out errmsg);
        }

        private void tb_Exposuretime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                trackBar1.Value = (int)Convert.ToDouble(tb_Exposuretime.Text);
                label4.Text = trackBar1.Value.ToString();
            }
            if (select == 1)
                CommonData.CameraUp.SetExposureTime((float)Convert.ToDouble(label4.Text), out errmsg);
            else
                CommonData.CameraDown.SetExposureTime(Convert.ToDouble(label4.Text), out errmsg);
        }

        private void tb_CameraGain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                trackBar2.Value = Convert.ToInt32(Convert.ToDouble(tb_CameraGain.Text) * 10);
                label5.Text = ((trackBar2.Value) / 10.0).ToString();
            }
            if (select == 1)
                CommonData.CameraUp.SetGain((float)Convert.ToDouble(label5.Text), out errmsg);
            else
                CommonData.CameraDown.SetGain(Convert.ToDouble(label5.Text), out errmsg);
        }

        private void tb_BlackLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                trackBar3.Value = (int)Convert.ToDouble(tb_BlackLevel.Text);
                label6.Text = (trackBar3.Value).ToString();
            }
            if (select == 1)
                CommonData.CameraUp.SetBlackLevel(Convert.ToUInt32(label6.Text), out errmsg);
            else
                CommonData.CameraDown.SetBlackLevel(Convert.ToUInt32(label6.Text), out errmsg);
        }

        private void tb_Brightness_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                trackBar4.Value = (int)Convert.ToDouble(tb_Brightness.Text);
                label7.Text = (trackBar4.Value).ToString();
            }
            //if (select == 1)
            //    CommonData.CameraUp.SetBrightness(Convert.ToUInt32(label7.Text), out errmsg);
            //else
            //    CommonData.CameraDown.SetBrightness(Convert.ToInt32(label7.Text), out errmsg);
        }

        private void tb_CameraContrast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                trackBar5.Value = (int)Convert.ToDouble(tb_CameraContrast.Text);
                label8.Text = (trackBar5.Value).ToString();
            }
            if (select == 1)
                CommonData.CameraUp.SetContrast(Convert.ToInt32(label8.Text), out errmsg);
            else
                CommonData.CameraDown.SetContrast(Convert.ToInt32(label8.Text), out errmsg);

        }
    }
}
