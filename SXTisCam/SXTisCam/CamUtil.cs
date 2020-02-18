using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SXTisCam
{
 
    /// <summary>
    /// 相机光源参数类
    /// </summary>
    [Serializable]
    public class CameraParam
    {
        string cameraName;
        double camExposure;
        double camGain;
        double camBrightness;
        double camContrast;
        double camBlackLevel;
        TisCamera tisCamera;
        public CameraParam() { }
        public CameraParam(string cameraname,double camexposure, double camgain, double cambrightness, 
            double camcontrast, double camblackLevel, TisCamera tiscamera)
        {
            cameraName = cameraname;
            camExposure = camexposure;
            camGain = camgain;
            camBrightness = cambrightness;
            camContrast = camcontrast;
            camBlackLevel = camblackLevel;
            tisCamera = tiscamera;
        }

        public string CameraName
        {
            get { return cameraName; }
            set { cameraName = value; }
        }

        public double CamExposure
        {
            get { return camExposure; }
            set { camExposure = value; }
        }
        public double CamGain
        {
            get { return camGain; }
            set { camGain = value; }
        }
        public double CamBrightness
        {
            get { return camBrightness; }
            set { camBrightness = value; }
        }
        public double CamContrast
        {
            get { return camContrast; }
            set { camContrast = value; }
        }
        public double CamBlackLevel
        {
            get { return camBlackLevel; }
            set { camBlackLevel = value; }
        }

        public TisCamera ThisTisCamera
        {
            get { return tisCamera; }
            set { tisCamera = value; }
        }
    }

}
