using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SXTisCam
{
     [Serializable]
    public partial class TisCamControl : UserControl
    {
        #region 变量定义

        /// <summary>
        /// TisCamera相机实例
        /// </summary>
        TisCamera curCam = null;
        public TisCamera CurSelCam
        {
            get { return curCam; }
            set { curCam = value; }
        }
        /// <summary>
        /// 相机列表
        /// </summary>
        List<CameraParam> CurCamList;

        /// <summary>
        /// 触发相机拍照委托
        /// </summary>
        public delegate void CamSnapShotEventHandler(int camIdx);
        public CamSnapShotEventHandler CamSnapShotEvent;
        private void CamSnapShot(int camIdx)
        {
            if (CamSnapShotEvent != null)
            {
                CamSnapShotEvent(camIdx);
            }
        }

        /// <summary>
        /// 保存相机参数委托
        /// </summary>
        public delegate void SaveCamParamEventHandler(List<CameraParam> camList);
        public SaveCamParamEventHandler SaveCamParamEvent;
        private void SaveCamParam(List<CameraParam> camList)
        {
            if (SaveCamParamEvent != null)
            {
                SaveCamParamEvent(camList);
            }
        }

        //错误信息
        string errMsg = "";
        bool thisOk = false;

        #endregion

        public TisCamControl()
        {
            InitializeComponent();
            thisOk = true;
        }
        
        private void btn_ReadCamParam_Click(object sender, EventArgs e)
        {
            LoadCamParam();
        }

        private void cb_CurCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurCamList.Count <= 0)
                {
                    MessageBox.Show("当前相机列表为空！");
                }
                curCam = CurCamList[cb_CurCamera.SelectedIndex].ThisTisCamera;
                SetCamParamBtnEnable();
                SetCamParamRange();
                btn_TextBlack.Value = (decimal)CurCamList[cb_CurCamera.SelectedIndex].CamBlackLevel;
                btn_TextBright.Value = (decimal)CurCamList[cb_CurCamera.SelectedIndex].CamBrightness;
                btn_TextContarst.Value = (decimal)CurCamList[cb_CurCamera.SelectedIndex].CamContrast;
                btn_TextExpos.Value = (decimal)CurCamList[cb_CurCamera.SelectedIndex].CamExposure / 10000;
                btn_TextGain.Value = (decimal)CurCamList[cb_CurCamera.SelectedIndex].CamGain / 100;
                //LoadCamParam();
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常！" + ex.Message);
            }
        }

        private void SetCamParamBtnEnable()
        {
            btn_TextExpos.Enabled = true;
            btn_TextGain.Enabled = true;
            btn_TextBright.Enabled = true;
            btn_TextBlack.Enabled = false;
            btn_TextContarst.Enabled = true;
            btn_BarExpos.Enabled = true;
            btn_BarGain.Enabled = true;
            btn_BarBright.Enabled = true;
            btn_BarBlack.Enabled = false;
            btn_BarContarst.Enabled = true;
        }

        private void SetCamParamRange()
        {
            #region TisRange
            btn_BarExpos.Minimum = 1; ;//曝光
            btn_BarExpos.Maximum = 300000;
            btn_TextExpos.Minimum = (decimal)0.0001;
            btn_TextExpos.Maximum = 30M;
            //btn_BarExpos.Value = 300;
            //btn_TextExpos.Value = 0.03M;
            btn_BarGain.Minimum = 0;//增益
            btn_BarGain.Maximum = 583;
            btn_TextGain.Minimum = 0;
            btn_TextGain.Maximum = (decimal)5.83;
            //btn_BarGain.Value = 0;
           // btn_TextGain.Value = 0;
            btn_BarBright.Minimum = 0;//亮度
            btn_BarBright.Maximum = 4095;
            btn_TextBright.Minimum = 0;
            btn_TextBright.Maximum = 4095;
            //btn_BarBright.Value = 40;
           // btn_TextBright.Value = 40;
            btn_BarContarst.Minimum = -10;//对比度
            btn_BarContarst.Maximum = 30;
            btn_TextContarst.Minimum = -10;
            btn_TextContarst.Maximum = 30;
            //btn_BarContarst.Value = 0;
           // btn_TextContarst.Value = 0;
            //btn_BarBlack.Minimum = 0;//黑电平
            //btn_BarBlack.Maximum = 255;
            //btn_TextBlack.Minimum = 0;
            //btn_TextBlack.Maximum = 255;
            //btn_BarBlack.Value = 0;
            //btn_TextBlack.Value = 0;
            #endregion
        }

        private void LoadCamParam()
        {
            if (curCam == null)
            {
                MessageBox.Show("TisCamera相机对象为空,请设置相机实例");
                return;
            }
            double exposureTime, camGain;
            float blackLevel, brightNess, contrast;
            if (!curCam.GetExposureTime(out exposureTime, out errMsg))
            {
                MessageBox.Show("曝光时间获取失败:" + errMsg);
            }
            if (!curCam.GetGain(out camGain, out errMsg))
            {
                MessageBox.Show("相机增益获取失败:" + errMsg);
            }
            //if (!curCam.GetBlackLevel(out blackLevel, out errMsg))
            //{
            //    MessageBox.Show("黑电平获取失败:" + errMsg);
            //}
            if (!curCam.GetBrightness(out brightNess, out errMsg))
            {
                MessageBox.Show("亮度获取失败:" + errMsg);
            }
            if (!curCam.GetContrast(out contrast, out errMsg))
            {
                MessageBox.Show("对比度获取失败:" + errMsg);
            }
            btn_TextExpos.Value = (decimal)exposureTime;
            btn_TextGain.Value = (decimal)camGain;
            btn_TextBright.Value = 0;
            btn_TextContarst.Value = 0;
            //btn_TextBlack.Value = (decimal)blackLevel;
            //btn_BarExpos.Value = (int)exposureTime;
            //btn_BarGain.Value = (int)camGain;
            //btn_BarBright.Value = 0;
            //btn_BarContarst.Value = 0;
            //btn_BarBlack.Value = (int)blackLevel;
        }

        private void btn_Snapshot_Click(object sender, EventArgs e)
        {
            try
            {
                if (curCam == null)
                {
                    MessageBox.Show("TisCamera相机对象为空,请设置相机实例");
                    return;
                }
                CamSnapShot(cb_CurCamera.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常！" + ex.Message);
            }
        }

        private void btn_RealImg_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_CurCamera.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择相机！");
                    return;
                }
                if (tb_GrabTime.Value < 1)
                {
                    MessageBox.Show("请输入触发间隔时间！");
                    return;
                }
                timer_realimg.Interval = (int)tb_GrabTime.Value;
                if (btn_RealImg.BackColor == SystemColors.Control)
                {
                    timer_realimg.Start();
                    btn_RealImg.BackColor = SystemColors.ActiveCaption;
                    cb_CurCamera.Enabled = false;
                }
                else
                {
                    timer_realimg.Stop();
                    btn_RealImg.BackColor = SystemColors.Control;
                    cb_CurCamera.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常！" + ex.Message);
            }
        }

        private void timer_realimg_Tick(object sender, EventArgs e)
        {
            CamSnapShot(cb_CurCamera.SelectedIndex);
        }

        private void btn_CameraText_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!thisOk)
                {
                    return;
                }
                NumericUpDown curBtn = (NumericUpDown)sender;
                int btnIdx = Convert.ToInt16(curBtn.Tag);
                switch (btnIdx)
                {
                    case 1:
                        btn_BarExpos.Value = (int)(curBtn.Value*10000);
                        break;
                    case 2:
                        btn_BarGain.Value = (int)curBtn.Value * 100;
                        break;
                    case 3:
                        btn_BarBright.Value = (int)curBtn.Value;
                        break;
                    case 4:
                        btn_BarContarst.Value = (int)curBtn.Value;
                        break;
                    case 5:
                        btn_BarBlack.Value = (int)curBtn.Value;
                        break;
                }
                TisCamSetParam((double)btn_TextExpos.Value, (double)btn_TextGain.Value, (int)btn_TextBright.Value,
                        (int)btn_TextContarst.Value, (uint)btn_TextBlack.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常！" + ex.Message);
            }
        }




        private void btn_CamBar_Scroll(object sender, EventArgs e)
        {
            try
            {
                TrackBar curBtn = (TrackBar)sender;
                int btnIdx = Convert.ToInt16(curBtn.Tag);
                switch (btnIdx)
                {
                    case 1:
                        btn_TextExpos.Value = (decimal)((double)curBtn.Value / 10000);
                        break;
                    case 2:
                        btn_TextGain.Value = (decimal)curBtn.Value / 100;
                        break;
                    case 3:
                        btn_TextBright.Value = (int)curBtn.Value;
                        break;
                    case 4:
                        btn_TextContarst.Value = (int)curBtn.Value;
                        break;
                    case 5:
                        btn_TextBlack.Value = (int)curBtn.Value;
                        break;
                }
                TisCamSetParam((double)btn_TextExpos.Value, (double)btn_TextGain.Value, (int)btn_TextBright.Value,
                            (int)btn_TextContarst.Value, (uint)btn_TextBlack.Value);

            }
            catch (Exception ex)
            {
                MessageBox.Show("异常！" + ex.Message);
            }
        }

        private void TisCamSetParam(double exposure, double gain, int brightness, int conrast, uint blacklevel)
        {
            bool result = curCam.SetExposureTime(exposure, out errMsg);
            if (!result)
            {
                MessageBox.Show("曝光时间设置失败：" + errMsg);
            }
            result = curCam.SetGain(gain, out errMsg);
            if (!result)
            {
                MessageBox.Show("相机增益设置失败：" + errMsg);
            }
            result = curCam.SetBrightness(brightness, out errMsg);
            if (!result)
            {
                MessageBox.Show("相机亮度设置失败：" + errMsg);
            }
            result = curCam.SetContrast(conrast, out errMsg);
            if (!result)
            {
                MessageBox.Show("对比度设置失败：" + errMsg);
            }
            CurCamList[cb_CurCamera.SelectedIndex].CamBlackLevel = (double)btn_TextBlack.Value;
            CurCamList[cb_CurCamera.SelectedIndex].CamBrightness = (double)btn_TextBright.Value;
            CurCamList[cb_CurCamera.SelectedIndex].CamContrast = (double)btn_TextContarst.Value;
            CurCamList[cb_CurCamera.SelectedIndex].CamExposure = (double)btn_TextExpos.Value*10000;
            CurCamList[cb_CurCamera.SelectedIndex].CamGain = (double)btn_TextGain.Value*100;
            //result = curCam.SetBlackLevel(blacklevel, out errMsg);
            //if (!result)
            //{
            //    MessageBox.Show("黑电平设置失败：" + errMsg);
            //}
        }

        public bool SetCameraList(List<CameraParam> camList, out string errMsg)
        {
            try
            {
                cb_CurCamera.Items.Clear();
                CurCamList = camList;
               
                for (int i = 0; i < camList.Count; i++)
                {
                    cb_CurCamera.Items.Add(camList[i].CameraName);
                }
                errMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        private void btn_SaveCamParam_Click(object sender, EventArgs e)
        {
            SaveCamParam(CurCamList);
        }

    }
}
