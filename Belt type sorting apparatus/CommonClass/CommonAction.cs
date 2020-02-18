using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class CommonAction
    {
        /// <summary>
        /// 判断当前该用哪个相机工作  1：上相机  2：下相机  -1 都忙
        /// </summary>
        /// <returns></returns>
        public static int SelectCamera()
        {
            object obj = new object();
            lock(obj)
            {
                CheckSignal.WaitForALLTime(() => CommonData.signal_CameraUpFree|| CommonData.signal_CameraDownFree);

                //判断先用哪个相机工作
                if (CommonData.signal_CameraUpFree)
                {
                    CommonData.signal_CameraUpFree = false;
                    return 1;
                }
                else
                {
                    CommonData.signal_CameraDownFree = false;
                    return 2;
                }
            }
           
        }

        public static void WaitDepth()
        {
            object obj = new object();
            lock (obj)
            {
                CheckSignal.WaitForALLTime(() => CommonData.signal_DepthFree);
                CommonData.signal_DepthFree = false;
            }

        }

        public static void GetDataFromDepth(Socket socket, object abs)
        {
            if (CommonData.signal_tcptest)
            {
                CommonData.signal_tcptest = false;
                MessageBox.Show(abs.ToString());
            }
            else
            {
                object obj = new object();
                lock (obj)
                {                 
                    //检定拍处理完成
                    if (!CommonData.signal_DepthDataOK)
                        return;
                    CommonData.signal_DepthDataOK = false;
                }

                string getMsg = abs.ToString();
                string[] curArray = getMsg.Split(',');

                int ss1 = Convert.ToInt32(curArray[4].Remove(10));
                int ss2 = Convert.ToInt32(curArray[2]);
                if ((ss1 + ss2) > CommonData.saveData.depthMax)  //NG
                {
                    if (CommonData.depthfrontorbehind == 1)
                    {
                        string ss = curArray[4].Remove(10);
                        WriteInfo.WriteSB("ftg", CommonData.curFrontPosition + "," + curArray[1] + "," + curArray[2] + "," + curArray[3] + "," + curArray[4].Remove(10) + "," + "NG" + ",");
                    }
                    else
                    {
                        string ss = curArray[4].Remove(10);
                        WriteInfo.WriteSB("btg", CommonData.curBehindPosition + "," + curArray[1] + "," + curArray[2] + "," + curArray[3] + "," + curArray[4].Remove(10) + "," + "NG" + ",");
                    }
                    CommonData.signal_DepthDataResult = false;
                }
                else if ((ss1 + ss2) < CommonData.saveData.depthMin)
                {
                    if (CommonData.depthfrontorbehind == 1)
                    {
                        string ss = curArray[4].Remove(10);
                        WriteInfo.WriteSB("ftg", CommonData.curFrontPosition + "," + curArray[1] + "," + curArray[2] + "," + curArray[3] + "," + curArray[4].Remove(10) + "," + "NG" + ",");
                    }
                    else
                    {
                        string ss = curArray[4].Remove(10);
                        WriteInfo.WriteSB("btg", CommonData.curBehindPosition + "," + curArray[1] + "," + curArray[2] + "," + curArray[3] + "," + curArray[4].Remove(10) + "," + "NG" + ",");
                    }
                    CommonData.signal_DepthDataResult = false;
                }
                else
                {
                    if (CommonData.depthfrontorbehind == 1)
                    {

                        WriteInfo.WriteSB("ftg", CommonData.curFrontPosition + "," + curArray[1] + "," + curArray[2] + "," + curArray[3] + "," + curArray[4].Remove(10) + "," + "OK" + ",");
                    }
                    else
                    {
                        string ss = curArray[4].Remove(10);
                        WriteInfo.WriteSB("btg", CommonData.curBehindPosition + "," + curArray[1] + "," + curArray[2] + "," + curArray[3] + "," + curArray[4].Remove(10) + "," + "OK" + ",");
                    }
                    CommonData.signal_DepthDataResult = true;
                }


                CommonData.signal_DepthOK = true;
                
            }

        }



        public static void askDepthData()
        {
            try
            {
                string errmsg;
                if (!CommonData.tcpClient.ClientSend(CommonData.tcpAsk1 + "\r\n", out errmsg))
                    throw new Exception("Tcp服务异常，发送探高命令失败！"+errmsg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


        //public static int askuseDown()
        //{
        //    while (true)
        //    {
        //        if (CommonData.signal_CameraDownFree)
        //        {
        //            CommonData.signal_CameraDownFree = false;
        //            break;
        //        }
                 
        //    }
        //}
        public static void jisuan(double x_a,double y_a,double x_b,double y_b,double x_c,double y_c,double x_d,double y_d)
        {
            double k1 = 0, k2 = 0;
            double centre_x, centre_y;
            int state = 0;
            if (x_a != x_b)
            {
                k1 = (y_b - y_a) / (x_b - x_a);
                state |= 1;
            }

            if (x_c != x_d)
            {
                k2 = (y_d - y_c) / (x_d - x_c);
                state |= 2;
            }
            switch (state)
            {
                case 3:
                    if (k1 == k2)
                    {
                        return;
                    }
                    else
                    {
                        centre_x = (k1 * x_a - k2 * x_c - y_a - y_c) / (k1 - k2);
                        centre_y = k1 * centre_x - k1 * x_a + y_a;
                        double afa = Math.Atan((k2 - k1) / (1 + k1 * k2));


                    }
                    break;
            }


        }


    }
}
