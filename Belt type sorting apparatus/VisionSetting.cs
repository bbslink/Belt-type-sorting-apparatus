using Belt_type_sorting_apparatus.CommonClass;
using HalconDotNet;
using SXHikCam;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    public partial class VisionSetting : Form
    {

        System.Windows.Forms.Timer timerup_acq = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerdown_acq = new System.Windows.Forms.Timer();
        string errMsg;
        public static HTuple displayHandle;
        int temp1 = 0, temp2 = 0;
        public VisionSetting()
        {
            InitializeComponent();
        }

        private void VisionSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            CommonData.CameraUp.PostFrameEvent -= new SXTisCam.TisCamera.PostFrameEventHandler(ongrab);
            CommonData.CameraDown.PostFrameEvent -= new SXTisCam.TisCamera.PostFrameEventHandler(ongrab);
            modelsControl1.CamSnapShotEvent -= new SXModelsControl.ModelsControl.CamSnapShotEventHandler(SelectCameraSnap);
            tisCamControl1.CamSnapShotEvent -= new SXTisCam.TisCamControl.CamSnapShotEventHandler(SelectCameraSnap);
            tisCamControl1.SaveCamParamEvent -= new SXTisCam.TisCamControl.SaveCamParamEventHandler(saveParam);
            SXModelsControl.ShapeModelUtil.ReadVisionModels(CommonData.CurProPath + "\\models\\", out CommonData.ModelIDs, out CommonData.ModelRegions, out CommonData.modelParams, out errMsg);
        }

        private void VisionSetting_Load(object sender, EventArgs e)
        {
            CommonData.CameraUp.PostFrameEvent += new SXTisCam.TisCamera.PostFrameEventHandler(ongrab);
            CommonData.CameraDown.PostFrameEvent += new SXTisCam.TisCamera.PostFrameEventHandler(ongrab);
            modelsControl1.SetCameraList(new List<string>() { "上相机", "下相机" }, out errMsg);
            modelsControl1.CamSnapShotEvent += new SXModelsControl.ModelsControl.CamSnapShotEventHandler(SelectCameraSnap);
            tisCamControl1.CamSnapShotEvent += new SXTisCam.TisCamControl.CamSnapShotEventHandler(SelectCameraSnap);
            tisCamControl1.SetCameraList(CommonData.cameraList, out errMsg);
            tisCamControl1.SaveCamParamEvent += new SXTisCam.TisCamControl.SaveCamParamEventHandler(saveParam);
            modelsControl1.SetModelSavePath(CommonData.CurProPath + "\\models\\");
            modelsControl1.SetModelSavePathEnable(false);
            modelsControl1.LoadModels(out errMsg);
            modelsControl1.SetCameraPoseParam(Application.StartupPath + "\\inner.cal", Application.StartupPath + "\\outer.dat", out errMsg);

            dispControl2.GetWindowHandle(out displayHandle, out errMsg);
            //CommonData.camAControl = dispControlA;
            //CommonData.camBControl = dispControlB;
            //displayHandle
        }

 
        private void SelectCameraSnap(int a)
        {
            switch (a)
            {
                case 0:
                    acqupTimerTick();
                    break;
                case 1:
                    acqdownTimerTick();
                    break;
                default:
                    break;
            }
        }

        private void acqupTimerTick()
        {
           //IOMonitor.SetOneBitReverse(CommonData.out_UpLight, 0.01);
           CommonData.CameraUp.SnapShot(out errMsg);
           Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"+temp1++);
        }
        private void acqdownTimerTick()
        {
            //IOMonitor.SetOneBitReverse(CommonData.out_DownLight, 0.01);
            CommonData.CameraDown.SnapShot(out errMsg);
        }


        private void ShapTimerTick()
        {
            //触发拍照为相机2
            //IOMonitor.SetOneBitReverse(CommonData.out_Photo, 0.01);
            //CommonData.upCamera.SnapShot(out errMsg);
           // IOMonitor.SetOneBitReverse(CommonData.out_FlatSurfaceLight, 0.01);
        }

        public void ongrab(HObject ss)
        {
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<" + temp2++);
            if (tabControl1.SelectedIndex == 0)
            {
                modelsControl1.DispImage(ss, out errMsg);
            }
            else
            {
                dispControl2.DisplayImage(ss, out errMsg);
            }
           
            
        }

        public void saveParam(List<SXTisCam.CameraParam> s)
        {
            CommonData.saveData.upCameraExposureTime = s[0].CamExposure;
            CommonData.saveData.upCameraGainRaw = s[0].CamGain;
            CommonData.saveData.upCameraContrast = (int)s[0].CamContrast;
            CommonData.saveData.upCameraBlackLevel =(uint) s[0].CamBlackLevel;
            CommonData.saveData.upCameraBrightness = (int)s[0].CamBrightness;

            CommonData.saveData.downCameraExposureTime = s[1].CamExposure;
            CommonData.saveData.downCameraGainRaw = s[1].CamGain;
            CommonData.saveData.downCameraContrast = (int)s[1].CamContrast;
            CommonData.saveData.downCameraBlackLevel = (uint)s[1].CamBlackLevel;
            CommonData.saveData.downCameraBrightness = (int)s[1].CamBrightness;        
        }




    }
}

