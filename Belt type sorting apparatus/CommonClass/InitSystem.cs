using Belt_type_sorting_apparatus.CommonClass;
using HalconDotNet;
using SXHikCam;
using SXOptCam;
using SXTisCam;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    class InitSystem
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
    
        static string errMsg;//视觉处理反馈错误信息
        static ThreadControl threadControls = ThreadControl.GetThreadControl();
        public static void StartInit()
        {
            try
            {
                //初始化当前生产产品参数保存路径
                if (!Directory.Exists("D:\\points"))
                    Directory.CreateDirectory("D:\\points");
                if (!Directory.Exists(CommonData.proDir))
                    Directory.CreateDirectory(CommonData.proDir);
                CommonData.CurProPath = CommonData.proDir + CommonData.CurProName;
                if (!Directory.Exists(CommonData.CurProPath))
                    Directory.CreateDirectory(CommonData.CurProPath);

                CommonData.CurProFile = CommonData.CurProPath + "\\" + CommonData.CurProName + ".nb";

                //实例化运行参数实例
                object file = FileHandle.AntiSerializeFile(CommonData.CurProFile);
                if (file != null)
                    CommonData.saveData = (SaveData)file;
                else
                {
                    CommonData.saveData = new SaveData();
                    sysEvent.showRealInfo("系统运动配置文件丢失，恢复至默认参数", CommonData.infoMess);
                }

                //初始所有模板
                if (!CommonData.saveData.PointModels.ContainsKey("前载台上相机模板"))
                {
                    sysEvent.showRealInfo("产品第一次辅助建立前载台上相机模板", CommonData.infoMess);
                    CommonData.saveData.PointModels.Add("前载台上相机模板", new PointControl());
                }
                if (!CommonData.saveData.PointModels.ContainsKey("后载台上相机模板"))
                {
                    sysEvent.showRealInfo("产品第一次辅助建立后载台上相机模板", CommonData.infoMess);
                    CommonData.saveData.PointModels.Add("后载台上相机模板", new PointControl());
                }
                if (!CommonData.saveData.PointModels.ContainsKey("前载台下相机模板"))
                {
                    sysEvent.showRealInfo("产品第一次辅助建立前载台下相机模板", CommonData.infoMess);
                    CommonData.saveData.PointModels.Add("前载台下相机模板", new PointControl());
                }
                if (!CommonData.saveData.PointModels.ContainsKey("后载台下相机模板"))
                {
                    sysEvent.showRealInfo("产品第一次辅助建立后载台下相机模板", CommonData.infoMess);
                    CommonData.saveData.PointModels.Add("后载台下相机模板", new PointControl());
                }
                if (!CommonData.saveData.PointModels.ContainsKey("前载台探高模板"))
                {
                    sysEvent.showRealInfo("产品第一次辅助建立前载台探高模板", CommonData.infoMess);
                    CommonData.saveData.PointModels.Add("前载台探高模板", new PointControl());
                }
                if (!CommonData.saveData.PointModels.ContainsKey("后载台探高模板"))
                {
                    sysEvent.showRealInfo("产品第一次辅助建立后载台探高模板", CommonData.infoMess);
                    CommonData.saveData.PointModels.Add("后载台探高模板", new PointControl());
                }


                //加载数据库
                if (!File.Exists(CommonData.FilePath))
                {
                    SQLiteConnection.CreateFile(CommonData.FilePath);
                }
                try
                {
                    CommonData.Conn = new SQLiteConnection("Data Source=" + CommonData.FilePath + ";Version=3;");
                    CommonData.Conn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("打开数据库：" + CommonData.FilePath + "的连接失败：" + ex.Message);
                }


                //初始化运动卡
                sysEvent.showRealInfo("初始化运动卡...", CommonData.infoMess);
                CardControl.DMCardInit();
                sysEvent.showRealInfo("运动控制卡初始化成功", CommonData.infoMess);
               
                //初始化相机
                sysEvent.showRealInfo("相机初始化...", CommonData.infoMess);



                bool thisResult1, thisResult2;//视觉处理结果
                CommonData.CameraUp = new TisCamera("43914662", out thisResult1, out errMsg);
                CommonData.CameraDown = new TisCamera("43914658", out thisResult2, out errMsg);

                CommonData.upParam = new SXTisCam.CameraParam("上相机", CommonData.saveData.upCameraExposureTime, CommonData.saveData.upCameraGainRaw, 
                    CommonData.saveData.upCameraBrightness, CommonData.saveData.upCameraContrast, CommonData.saveData.upCameraBlackLevel, CommonData.CameraUp);
                CommonData.downParam = new SXTisCam.CameraParam("下相机", CommonData.saveData.downCameraExposureTime, CommonData.saveData.downCameraGainRaw,
                    CommonData.saveData.downCameraBrightness, CommonData.saveData.downCameraContrast, CommonData.saveData.downCameraBlackLevel, CommonData.CameraDown);
                CommonData.cameraList.Add(CommonData.upParam);
                CommonData.cameraList.Add(CommonData.downParam);

                if (thisResult1 && thisResult2)
                {
                    bool upok = CommonData.CameraUp.OpenCamera(out errMsg);
                    bool downok = CommonData.CameraDown.OpenCamera(out errMsg);
                    if (upok && downok)
                    {
                        sysEvent.showRealInfo("相机初始化成功", CommonData.infoMess);
                       // CommonData.CameraUp.SetLineTrigger(out errMsg);
                        CommonData.CameraUp.SetSoftwareTrigger(out errMsg);
                        CommonData.CameraUp.StartGrabImage(out errMsg);
                       CommonData.CameraDown.SetSoftwareTrigger(out errMsg);
                     //  CommonData.CameraDown.SetLineTrigger(out errMsg);
                        CommonData.CameraDown.StartGrabImage(out errMsg);
                        
                        //设置曝光
                        CommonData.CameraUp.SetExposureTime(CommonData.saveData.upCameraExposureTime/10000, out errMsg);
                        CommonData.CameraUp.SetGain(CommonData.saveData.upCameraGainRaw/100, out errMsg);
                        CommonData.CameraUp.SetContrast(CommonData.saveData.upCameraContrast, out errMsg);
                        CommonData.CameraUp.SetBlackLevel(CommonData.saveData.upCameraBlackLevel, out errMsg);
                        CommonData.CameraUp.SetBrightness(CommonData.saveData.upCameraBrightness, out errMsg);

                        CommonData.CameraDown.SetExposureTime(CommonData.saveData.downCameraExposureTime/10000, out errMsg);
                        CommonData.CameraDown.SetGain(CommonData.saveData.downCameraGainRaw/100, out errMsg);
                        CommonData.CameraDown.SetContrast(CommonData.saveData.downCameraContrast, out errMsg);
                        CommonData.CameraDown.SetBlackLevel(CommonData.saveData.downCameraBlackLevel, out errMsg);
                        CommonData.CameraDown.SetBrightness(CommonData.saveData.upCameraBrightness, out errMsg);
                    }
                    else
                    {
                        throw new Exception("错误0xVS001,相机打开失败,请关闭程序后检查再重启！");
                    }

                }
                else
                {
                    throw new Exception("错误0xVS001,相机初始化失败,请关闭程序后检查再重启！");
                }

                ////初始化模板
                if (!Directory.Exists(CommonData.CurProPath + "\\models\\"))
                    Directory.CreateDirectory(CommonData.CurProPath + "\\models\\");
                 SXModelsControl.ShapeModelUtil.ReadVisionModels(CommonData.CurProPath + "\\models\\", out CommonData.ModelIDs, out CommonData.ModelRegions, out CommonData.modelParams, out errMsg);
               
                //初始化光源
                sysEvent.showRealInfo("光源初始化...", CommonData.infoMess);
                 
                //开启按钮检测线程
                sysEvent.showRealInfo("开启按钮检测线程", CommonData.infoMess);
                threadControls.ReInitThread(4);
                sysEvent.showRealInfo("等待TCP线程", CommonData.infoMess);
                //初始化TCP
                CommonData.tcpClient=new TCPClient();
                Ping ping = new Ping();
                PingReply pingreply = ping.Send(CommonData.saveData.severTcp);

                for (int i = 0; i < 30; i++)
                {                  
                    if (pingreply.Status == IPStatus.Success)
                    {
                        if (CommonData.tcpClient.AsynConnect(CommonData.saveData.severTcp, CommonData.saveData.severPort, out errMsg) == false)
                            throw new Exception("Tcp连接失败！！"+errMsg);
                        CommonData.tcpClient.PostMessEvent += new TCPClient.PostMessEventHandler(CommonAction.GetDataFromDepth);
                        break;
                    }
                    if(i==29)
                        throw new Exception("Tcp连接超时！！");
                    pingreply = ping.Send(CommonData.saveData.severTcp);
                    CheckSignal.CommonDelay(1);
                }

                

                sysEvent.showRealInfo("系统初始化成功，请回原点！", CommonData.infoMess);
                CommonData.signal_SysInitOK = true;             
                sysEvent.setButtonEnable(true, false, false, false, false, true,true, true, true, true, true);


            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo("错误0xCA016,系统初始化失败\r"+ex.Message, CommonData.warnMess);
                sysEvent.setButtonEnable(false, false, false, false, false, false,false, false, false, false, false);
               //sysEvent.setButtonEnable(false, false, false, false, false, true, true, true, true, true, true);
                CommonData.signal_SysInitOK = false;
            }
        }




    }
}
