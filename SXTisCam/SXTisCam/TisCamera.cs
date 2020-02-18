using HalconDotNet;
using System;
using System.Drawing;
using TIS.Imaging;
using TIS.Imaging.VCDHelpers;

namespace SXTisCam
{
    [Serializable]
    public class TisCamera
    {
        ICImagingControl icImagingControl1 = new ICImagingControl();
        private TIS.Imaging.VCDAbsoluteValueProperty ExposureAbsoluteValue;//绝对曝光值属性
        private TIS.Imaging.VCDSwitchProperty ExposureSwith;//绝对曝光值开关属性
        private TIS.Imaging.VCDAbsoluteValueProperty GainAbsoluteValue;//绝对增益值属性
        private TIS.Imaging.VCDSwitchProperty GainSwith;//绝对增益值开关属性

        private TIS.Imaging.VCDButtonProperty Softtrigger;//触发属性
        private TIS.Imaging.VCDSwitchProperty TrigEnableSwitch;//触发使能开关

        //对比度 亮度 伽马  锐化
        public TIS.Imaging.VCDRangeProperty ContrastValue, BrightValue, GammaValue, SharpValue;

        VCDSimpleProperty vcdProp = null;

        /// <summary>
        /// 推送相机获取的HImage图像 委托
        /// </summary>
        public delegate void PostFrameEventHandler(HObject grabImage);
        public PostFrameEventHandler PostFrameEvent;

        /// <summary>
        /// 推送相机获取的HImage图像 委托
        /// </summary>
        private void PostFrame(HObject grabImage)
        {
            if (PostFrameEvent != null)
            {
                PostFrameEvent(grabImage);
            }
        }


        public bool DeviceListAcq(out Device[] allCameraInfos, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                allCameraInfos = icImagingControl1.Devices;
                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM031," + ex.Message;
                allCameraInfos = null;
            }
            return thisResult;
        }

        public TisCamera(string snNumber, out bool thisResult, out string errMsg)
        {
            try
            {
                string temp = "";
                if (icImagingControl1.Devices.Length > 0)
                {
                    foreach (Device Dev in icImagingControl1.Devices)
                    {
                        if (Dev.GetSerialNumber(out temp))
                        {
                            if (temp == snNumber)//判断是否等于指定相机序号
                            {
                                icImagingControl1.Device = Dev.Name;
                                break;
                            }
                        }
                    }
                    if (!icImagingControl1.DeviceValid)
                    {
                        thisResult = false;
                        errMsg = "没有找到设备,请确认相机是否连接好";
                    }
                    else
                    {
                        thisResult = true;
                        errMsg = "";
                    }
                }
                else
                {
                    thisResult = false;
                    errMsg = "没有找到设备,请确认相机是否连接好";
                }
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM032," + "相机[ " + snNumber + " ]初始化失败;" + ex.Message;
            }
        }

        public bool OpenCamera(out string errMsg)
        {
            bool thisResult = true;
            try
            {
                icImagingControl1.DeviceFrameRate = 36f;
                ////黑白格式为：ICY8；彩色格式为：ICRGB32
                icImagingControl1.MemoryCurrentGrabberColorformat = ICImagingControlColorformats.ICY8;
                icImagingControl1.LiveCaptureContinuous = true;//设为回调模式
                errMsg = "";
                icImagingControl1.ImageAvailable += new System.EventHandler<TIS.Imaging.ICImagingControl.ImageAvailableEventArgs>(OnImageGrabbed);
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM033," + ex.Message;
            }
            return thisResult;
        }

        public bool CloseCamera(out string errMsg)
        {
            bool thisResult = true;
            try
            {
                icImagingControl1.ImageAvailable -= new System.EventHandler<TIS.Imaging.ICImagingControl.ImageAvailableEventArgs>(OnImageGrabbed);
                thisResult = true;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM034," + ex.Message;
            }
            return thisResult;
        }

        public bool StartGrabImage(out string errMsg)
        {
            bool thisResult = true;
            try
            {
                icImagingControl1.LiveStart();
                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM035," + "相机开启连续采集出现异常;" + ex.Message;
            }
            return thisResult;
        }

        public bool StopGrabImage(out string errMsg)
        {
            bool thisResult = true;
            try
            {
                icImagingControl1.LiveStop();
                errMsg = "";
                thisResult = false;
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM036," + "相机停止连续采集出现异常;" + ex.Message;
            }
            return thisResult;
        }

        public bool GetExposureTime(out double ExposureTime, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                ExposureSwith = (TIS.Imaging.VCDSwitchProperty)icImagingControl1.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Exposure + ":" + VCDIDs.VCDElement_Auto + ":" + VCDIDs.VCDInterface_Switch);
                ExposureSwith.Switch = false;//关闭自动曝光
                //绝对曝光对象初始化
                ExposureAbsoluteValue = (TIS.Imaging.VCDAbsoluteValueProperty)icImagingControl1.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Exposure + ":" + VCDIDs.VCDElement_Value + ":" + VCDIDs.VCDInterface_AbsoluteValue);
                ExposureTime = ExposureAbsoluteValue.Value;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                ExposureTime = 0f;
                errMsg = "错误0xAM037," + "相机曝光时间获取失败;" + ex.Message;
            }
            return thisResult;
        }

        public bool SetExposureTime(double value, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                ExposureSwith = (TIS.Imaging.VCDSwitchProperty)icImagingControl1.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Exposure + ":" + VCDIDs.VCDElement_Auto + ":" + VCDIDs.VCDInterface_Switch);
                ExposureSwith.Switch = false;//关闭自动曝光
                //绝对曝光对象初始化
                ExposureAbsoluteValue = (TIS.Imaging.VCDAbsoluteValueProperty)icImagingControl1.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Exposure + ":" + VCDIDs.VCDElement_Value + ":" + VCDIDs.VCDInterface_AbsoluteValue);
                ExposureAbsoluteValue.Value = value;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM038," + "相机曝光时间设置失败;" + ex.Message;
            }
            return thisResult;
        }

        public bool GetGain(out double GainRaw, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                GainSwith = (TIS.Imaging.VCDSwitchProperty)icImagingControl1.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Gain + ":" + VCDIDs.VCDElement_Auto + ":" + VCDIDs.VCDInterface_Switch);
                //绝对增益对象初始化
                GainAbsoluteValue = (TIS.Imaging.VCDAbsoluteValueProperty)icImagingControl1.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Gain + ":" + VCDIDs.VCDElement_Value + ":" + VCDIDs.VCDInterface_AbsoluteValue);
                GainRaw = GainAbsoluteValue.Value;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                GainRaw = 0f;
                errMsg = "错误0xAM039," + "相机增益获取失败;" + ex.Message;
            }
            return thisResult;
        }

        public bool SetGain(double value, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                GainSwith = (TIS.Imaging.VCDSwitchProperty)icImagingControl1.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Gain + ":" + VCDIDs.VCDElement_Auto + ":" + VCDIDs.VCDInterface_Switch);
                GainSwith.Switch = false;//关闭自动增益
                //绝对增益对象初始化
                GainAbsoluteValue = (TIS.Imaging.VCDAbsoluteValueProperty)icImagingControl1.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Gain + ":" + VCDIDs.VCDElement_Value + ":" + VCDIDs.VCDInterface_AbsoluteValue);
                GainAbsoluteValue.Value = value;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM040," + "相机增益设置失败;" + ex.Message;
            }
            return thisResult;
        }

        public bool SetContinuousAcq(out string errMsg)
        {
            bool thisResult = true;
            try
            {
                TrigEnableSwitch = (TIS.Imaging.VCDSwitchProperty)icImagingControl1.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_TriggerMode + ":" +
                TIS.Imaging.VCDIDs.VCDElement_Value + ":" + TIS.Imaging.VCDIDs.VCDInterface_Switch);
                TrigEnableSwitch.Switch = false;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM041," + ex.Message;
            }
            return thisResult;
        }

        public bool SnapShot(out string errMsg)
        {
            bool thisResult = true;
            try
            {
                Softtrigger = (TIS.Imaging.VCDButtonProperty)icImagingControl1.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_TriggerMode + ":" +
                TIS.Imaging.VCDIDs.VCDElement_SoftwareTrigger + ":" + TIS.Imaging.VCDIDs.VCDInterface_Button);
                Softtrigger.Push();//软触发

                errMsg = "";
                thisResult = true;
                
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM042," + ex.Message;
            }
            return thisResult;
        }

        public bool SetSoftwareTrigger(out string errMsg)
        {
            bool thisResult = true;
            try
            {
                TrigEnableSwitch = (TIS.Imaging.VCDSwitchProperty)icImagingControl1.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_TriggerMode + ":" +
                TIS.Imaging.VCDIDs.VCDElement_Value + ":" + TIS.Imaging.VCDIDs.VCDInterface_Switch);
                TrigEnableSwitch.Switch = true;

                thisResult = true;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM043," + "设置相机软触发模式异常;" + ex.Message;
            }
            return thisResult;
        }

        public bool SetLineTrigger(out string errMsg)
        {
            bool thisResult = true;
            try
            {
                TrigEnableSwitch = (TIS.Imaging.VCDSwitchProperty)icImagingControl1.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_TriggerMode + ":" +
                TIS.Imaging.VCDIDs.VCDElement_Value + ":" + TIS.Imaging.VCDIDs.VCDInterface_Switch);
                TrigEnableSwitch.Switch = true;

                thisResult = true;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM044," + "设置相机硬触发模式异常;" + ex.Message;
            }
            return thisResult;
        }

        public bool SetBlackLevel(uint value, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                
                thisResult = true;
                errMsg = "该相机不支持此参数";
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM045," + ex.Message;
            }
            return thisResult;
        }

        public bool SetBrightness(int value, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                //获取这亮度接口
                BrightValue = (TIS.Imaging.VCDRangeProperty)icImagingControl1.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Brightness + ":" +
                    VCDIDs.VCDElement_Value + ":" + VCDIDs.VCDInterface_Range);
                if (value <= BrightValue.RangeMin)
                {
                    BrightValue.Value = BrightValue.RangeMin;
                }
                else if (value >= BrightValue.RangeMax)
                {
                    BrightValue.Value = BrightValue.RangeMax;
                }
                else
                {
                    BrightValue.Value = value;
                }
                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM046," + ex.Message;
            }
            return thisResult;
        }

        public bool SetContrast(int value, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                //获取对比度接口
                ContrastValue = (TIS.Imaging.VCDRangeProperty)icImagingControl1.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Contrast + ":" +
                    VCDIDs.VCDElement_Value + ":" + VCDIDs.VCDInterface_Range);
                if (value <= ContrastValue.RangeMin)
                {
                    ContrastValue.Value = ContrastValue.RangeMin;
                }
                else if (value >= ContrastValue.RangeMax)
                {
                    ContrastValue.Value = ContrastValue.RangeMax;
                }
                else
                {
                    ContrastValue.Value = value;
                }

                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM047," + ex.Message;
            }
            return thisResult;
        }

        public bool GetBlackLevel(out float value, out string errMsg)
        {
            bool thisResult = true;
            float curBlackLevel = 0f;
            try
            {
                curBlackLevel = 0f;
                thisResult = true;
                errMsg = "错误0xAM048," + "该相机不支持此参数";
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = ex.Message;
            }
            value = curBlackLevel;
            return thisResult;
        }

        public bool GetBrightness(out float value, out string errMsg)
        {
            bool thisResult = true;
            float curBrightness = 0f;
            try
            {
                //获取这亮度接口
                BrightValue = (TIS.Imaging.VCDRangeProperty)icImagingControl1.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Brightness + ":" +
                    VCDIDs.VCDElement_Value + ":" + VCDIDs.VCDInterface_Range);

                value = BrightValue.Value;
                thisResult = true;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM049," + ex.Message;
            }
            value = curBrightness;
            return thisResult;
        }

        public bool GetContrast(out float value, out string errMsg)
        {
            bool thisResult = true;
            float curContrast = 0f;
            try
            {
                //获取对比度接口
                ContrastValue = (TIS.Imaging.VCDRangeProperty)icImagingControl1.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Contrast + ":" +
                    VCDIDs.VCDElement_Value + ":" + VCDIDs.VCDInterface_Range);

                value = ContrastValue.Value;
                thisResult = true;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = "错误0xAM050," + ex.Message;
            }
            value = curContrast;
            return thisResult;
        }

        private void OnImageGrabbed(object sender, TIS.Imaging.ICImagingControl.ImageAvailableEventArgs e)
        {
            try
            {
                HObject hobmp;
                Bitmap bmp= icImagingControl1.ImageActiveBuffer.Bitmap;
                IntPtr curPtr = icImagingControl1.ImageActiveBuffer.GetIntPtr();
               
                HOperatorSet.GenImage1(out hobmp, "byte", icImagingControl1.ImageWidth, icImagingControl1.ImageHeight, curPtr);
                PostFrame(hobmp);
            }
            catch (Exception) { }
        }
        
        

    }
}
