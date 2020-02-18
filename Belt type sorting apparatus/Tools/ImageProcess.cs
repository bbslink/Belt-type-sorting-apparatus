using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class ImageProcess
    {
        static SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        static string errMsg;
        static int temp = 0;//定拍照次数

        public static void StartActionA(HObject grabImage)
        {
            try
            {
                //sysEvent.showRealInfo(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>收到图", CommonData.infoMess);
                object obj = new object();
                lock (obj)
                {
                    sysEvent.showRealInfo("检定拍处理完成", CommonData.infoMess);
                    //检定拍处理完成
                    if (!CommonData.signal_UpCameraDataOK)
                        return;
                    CommonData.signal_UpCameraDataOK = false;
                }
             

                CommonData.camAControl.DisplayImage(grabImage, out errMsg);

                switch (CommonData.signal_CameraNowPlace)
                {
                    case 1:
                        break;
                    case 2:

                        double k = 0.008;
                        //  double k = 0.011707435;
                        HTuple CheckRow1, CheckColumn1, CheckAngle1, CheckScore1, CheckRow2, CheckColumn2, CheckAngle2, CheckScore2;
                        bool isok = SXModelsControl.ShapeModelUtil.FindShapeModelsIdx(grabImage, CommonData.ModelIDs, 0,
                            CommonData.ModelRegions[0], CommonData.dispControlUp, 0, 360, CommonData.saveData.pre_Score, 1, 4, 0.5, out CheckRow1, out CheckColumn1, out CheckAngle1, out CheckScore1, out errMsg);
                        if (!isok || CheckRow1.Length <= 0 || CheckRow1 == null)
                        {
                            if (CommonData.upfrontorbehind == 1)
                            {
                                WriteInfo.WriteSB("fsxj", CommonData.curFrontPosition + "," );
                            }
                            else
                            {
                                WriteInfo.WriteSB("bsxj", CommonData.curBehindPosition + ",");
                            }
                            sysEvent.showRealInfo("Mark匹配失败", CommonData.warnMess);
                            HOperatorSet.WriteImage(grabImage, "bmp", 0, Application.StartupPath + "\\imgs\\" + DateTime.Now.ToString("yyyy-MM-dd HHmmssfff") + ".bmp");
                            CommonData.signal_curUpImageRusult = false;
                        }
                        else
                        {
                             bool isok2 = SXModelsControl.ShapeModelUtil.FindShapeModelsIdx(grabImage, CommonData.ModelIDs, 1,
                                 CommonData.ModelRegions[1], CommonData.dispControlUp, 0, 360, CommonData.saveData.product_Score, 1, 4, 0.5, out CheckRow2, out CheckColumn2, out CheckAngle2, out CheckScore2, out errMsg);
                             if (!isok2|| CheckRow2.Length <= 0||CheckRow2 == null )
                             {
                                 if (CommonData.upfrontorbehind == 1)
                                 {
                                     WriteInfo.WriteSB("fsxj", CommonData.curFrontPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," );
                                 }
                                 else
                                 {
                                     WriteInfo.WriteSB("bsxj", CommonData.curBehindPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," );
                                 }
                               
                                 sysEvent.showRealInfo("产品匹配失败", CommonData.warnMess);
                                 HOperatorSet.WriteImage(grabImage, "bmp", 0, Application.StartupPath + "\\imgs\\" + DateTime.Now.ToString("yyyy-MM-dd HHmmssfff") + ".bmp");
                                 CommonData.signal_curUpImageRusult = false;
                             }                        
                             else
                             {
                                 double resultrow = (Math.Abs(CheckRow1.D - CheckRow2.D)) * k;

                                 if (CommonData.saveData.commonRow - CommonData.saveData.rowdelta > resultrow)
                                 {

                                     CommonData.signal_curUpImageRusult = false;
                                     if (CommonData.upfrontorbehind == 1)
                                     {
                                         WriteInfo.WriteSB("fsxj", CommonData.curFrontPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + "," + CheckColumn2.D + "," + resultrow.ToString()+ ","+"NG"+",");
                                     }
                                     else
                                     {
                                         WriteInfo.WriteSB("bsxj", CommonData.curBehindPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + "," + CheckColumn2.D + "," + resultrow.ToString() + "," + "NG" + ",");
                                     }
                           
                                     HOperatorSet.WriteImage(grabImage, "bmp", 0, Application.StartupPath + "\\imgs\\" + DateTime.Now.ToString("yyyy-MM-dd HHmmssfff") + ".bmp");
                                 }
                                 else if (CommonData.saveData.commonRow + CommonData.saveData.rowdelta < resultrow)
                                 {
                                     CommonData.signal_curUpImageRusult = false;
                                     if (CommonData.upfrontorbehind == 1)
                                     {
                                         WriteInfo.WriteSB("fsxj", CommonData.curFrontPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + "," + CheckColumn2.D + "," + resultrow.ToString() + "," + "NG" + ",");
                                     }
                                     else
                                     {
                                         WriteInfo.WriteSB("bsxj", CommonData.curBehindPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + "," + CheckColumn2.D + "," + resultrow.ToString() + "," + "NG" + ",");
                                     }
                      
                                     HOperatorSet.WriteImage(grabImage, "bmp", 0, Application.StartupPath + "\\imgs\\" + DateTime.Now.ToString("yyyy-MM-dd HHmmssfff") + ".bmp");
                                 }
                                 else
                                 {
                                     double resultrow2 = (Math.Abs(CheckColumn1.D - CheckColumn2.D)) * k;


                                     if (CommonData.saveData.commonCol - CommonData.saveData.coldelat > resultrow2)
                                     {

                                         CommonData.signal_curUpImageRusult = false;
                                         if (CommonData.upfrontorbehind == 1)
                                         {
                                             WriteInfo.WriteSB("fsxj", CommonData.curFrontPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + "," + CheckColumn2.D + "," + resultrow.ToString() + ","  + resultrow2.ToString() + "," + "NG" + ",");
                                         }
                                         else
                                         {
                                             WriteInfo.WriteSB("bsxj", CommonData.curBehindPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + "," + CheckColumn2.D + "," + resultrow.ToString() + "," + resultrow2.ToString() + "," + "NG" + ",");
                                         }
                                      
                                         HOperatorSet.WriteImage(grabImage, "bmp", 0, Application.StartupPath + "\\imgs\\" + DateTime.Now.ToString("yyyy-MM-dd HHmmssfff") + ".bmp");
                                     }
                                     else if (CommonData.saveData.commonCol + CommonData.saveData.coldelat < resultrow2)
                                     {
                                         CommonData.signal_curUpImageRusult = false;
                                         if (CommonData.upfrontorbehind == 1)
                                         {
                                             WriteInfo.WriteSB("fsxj", CommonData.curFrontPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + "," + CheckColumn2.D + "," + resultrow.ToString() + ","  + resultrow2.ToString() + "," + "NG" + ",");
                                         }
                                         else
                                         {
                                             WriteInfo.WriteSB("bsxj", CommonData.curBehindPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + "," + CheckColumn2.D + "," + resultrow.ToString() + "," + resultrow2.ToString() + "," + "NG" + ",");
                                         }
                                  
                                         HOperatorSet.WriteImage(grabImage, "bmp", 0, Application.StartupPath + "\\imgs\\" + DateTime.Now.ToString("yyyy-MM-dd HHmmssfff") + ".bmp");
                                     }
                                     else
                                     {
                                         LogHelper.WriteInfoLog(typeof(ImageProcess), "识别原始角度>>>>>>>>>>>>" + CheckAngle2.D);
                                         if (CheckAngle2.D > 4)
                                         {
                                             CheckAngle2.D -= 2 * Math.PI;
                                         }
                                         else if (CheckAngle2.D >2)
                                         {
                                             CheckAngle2.D = CheckAngle2.D - Math.PI;
                                         }

                                         if (CheckAngle2.D > CommonData.saveData.commonAngel + CommonData.saveData.deltaAngel)
                                         {

                                             CommonData.signal_curUpImageRusult = false;
                                             if (CommonData.upfrontorbehind == 1)
                                             {
                                                 WriteInfo.WriteSB("fsxj", CommonData.curFrontPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + "," 
                                                     + CheckColumn2.D + "," + CheckAngle2.D + "," +resultrow.ToString() + "," + resultrow2.ToString() +"," + "NG" + ",");
                                             }
                                             else
                                             {
                                                 WriteInfo.WriteSB("bsxj", CommonData.curBehindPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + "," 
                                                     + CheckColumn2.D + "," + CheckAngle2.D + "," + resultrow.ToString() + "," + resultrow2.ToString() + ","  + "NG" + ",");
                                             }
                               
                                             HOperatorSet.WriteImage(grabImage, "bmp", 0, Application.StartupPath + "\\imgs\\" + DateTime.Now.ToString("yyyy-MM-dd HHmmssfff") + ".bmp");
                                         }
                                         else if (CheckAngle2.D < CommonData.saveData.commonAngel - CommonData.saveData.deltaAngel)
                                         {
                                             CommonData.signal_curUpImageRusult = false;
                                             if (CommonData.upfrontorbehind == 1)
                                             {
                                                 WriteInfo.WriteSB("fsxj", CommonData.curFrontPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + ","
                                                     + CheckColumn2.D + "," + CheckAngle2.D + "," + resultrow.ToString() + "," + resultrow2.ToString() + "," + "NG" + ",");
                                             }
                                             else
                                             {
                                                 WriteInfo.WriteSB("bsxj", CommonData.curBehindPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + ","
                                                     + CheckColumn2.D + "," + CheckAngle2.D + "," + resultrow.ToString() + "," + resultrow2.ToString() + "," + "NG" + ",");
                                             }
                            
                                             HOperatorSet.WriteImage(grabImage, "bmp", 0, Application.StartupPath + "\\imgs\\" + DateTime.Now.ToString("yyyy-MM-dd HHmmssfff") + ".bmp");
                                         }
                                         else
                                         {
                                             CommonData.signal_curUpImageRusult = true;
                                             if (CommonData.upfrontorbehind == 1)
                                             {
                                                 WriteInfo.WriteSB("fsxj", CommonData.curFrontPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + ","
                                                     + CheckColumn2.D + "," + CheckAngle2.D + "," + resultrow.ToString() + "," + resultrow2.ToString() + "," + "OK" + ",");
                                             }
                                             else
                                             {
                                                 WriteInfo.WriteSB("bsxj", CommonData.curBehindPosition + "," + CheckRow1.D + "," + CheckColumn1.D + "," + CheckRow2.D + ","
                                                     + CheckColumn2.D + "," + CheckAngle2.D + "," + resultrow.ToString() + "," + resultrow2.ToString() + "," + "OK" + ",");
                                             }
                                             
                                         }                                        
                                     }
                                     
                                 }
                             }
                        }
                        break;
                    default:
                        break;

                }
                //HOperatorSet.WriteImage(grabImage, "bmp", 0, Application.StartupPath +"\\imgs\\"+DateTime.Now.ToString("yyyy-MM-dd HHmmssfff")+ ".bmp");
                //sysEvent.showRealInfo(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>处理完", CommonData.infoMess);
                CommonData.signal_UpCameraOK = true;
               
             
            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo("错误0xVS004,相片1处理异常\r" + ex.Message, CommonData.warnMess);
                StopAction.QuickErrStop();
            }

        }



        public static void StartActionB(HObject grabImage)
        {
            try
            {

            }
            catch(Exception ex)
            {
                sysEvent.showRealInfo("错误0xVS004,相片2处理异常\r" + ex.Message, CommonData.warnMess);
                StopAction.QuickErrStop();
            }
        }

        public static void StartActionC(HObject grabImage)
        {
            try
            {

            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo("错误0xVS004,相片3处理异常\r" + ex.Message, CommonData.warnMess);
                StopAction.QuickErrStop();
            }
        }

        public static void StartActionD(HObject grabImage)
        {
            try
            {

            }
            catch (Exception ex)
            {
                sysEvent.showRealInfo("错误0xVS004,相片4处理异常\r" + ex.Message, CommonData.warnMess);
                StopAction.QuickErrStop();
            }
        }

    }
}
