using Belt_type_sorting_apparatus;
using Belt_type_sorting_apparatus.CommonClass;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GroupDemo.CommonClass
{
    class IO232Control
    {
        SerialPort ComDevice = new SerialPort();
        string typeCom;
        string in_state;
        public Thread needSingal;
        bool havedeal;
        bool havegive;
        object obj = new object();
        public IO232Control(string comName,string type)
        {
            typeCom = type;
            OpenSerial(comName);
            havedeal = true;
            havegive = true;

            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);//绑定事件

            if (type == "In")
            {

                needSingal = new Thread(() => PleaseSignal());
                needSingal.Start();
            }
        }

        public bool OpenSerial(string comNum)
        {
            if (ComDevice.IsOpen == false)
            {
                ComDevice.PortName = comNum;
                ComDevice.BaudRate = Convert.ToInt32("9600");
                ComDevice.Parity = (Parity)Convert.ToInt32(0);
                ComDevice.DataBits = Convert.ToInt32("8");
                ComDevice.StopBits = (StopBits)Convert.ToInt32("1");
                try
                {
                    ComDevice.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    //输出错误
                    return false;
                }

            }
            else
            {
                return true;
            }

        }

        public void PleaseSignal()
        {
            try
            {

                //CheckSignal.WaitForALLTime(() => havedeal);
                //havedeal = false;
                //SetOut("010380400002", 2);
                //CheckSignal.CommonDelay(1);

            }
            catch
            {
                return;
            }
           
        }
        public int ReadIn(ushort Innum)
        {
            try
            {
                if (in_state == null)
                {
                    CheckSignal.WaitForALLTime(() => in_state != null);
                    if (in_state.Length != 32)
                        throw new Exception();
                }

                if (in_state.Length != 32)
                    throw new Exception();
                int ss = Convert.ToInt32(in_state[Innum].ToString());
                CheckSignal.CommonDelay(1);
                return ss;
            }
            catch
            {
                //
                return -1;
            }
            
            
        }



        public void SetOut(string mes, int state)
        {

            lock (obj)
            {
                if (state == 1)
                {
                    mes = mes.Trim() + "FF00";
                }
                else if (state == 0)
                {
                    mes = mes.Trim() + "0000";
                }

                string ssr = CRC.ToModbusCRC16(mes.Trim());


                byte[] sendData = null;
                sendData = strToHexByte(mes.Trim() + ssr);

                if (ComDevice.IsOpen)
                {
                    try
                    {
                        ComDevice.Write(sendData, 0, sendData.Length);//发送数据
                        ComDevice.DiscardOutBuffer();
                        CheckSignal.CommonDelay(20);
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                }
                else
                {
                    //
                }
            }

        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void ClearSelf()
        {
            if (ComDevice.IsOpen)
            {
                ComDevice.Close();

            }

            if (needSingal != null)
                needSingal.Abort();
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (typeCom.Equals("Out"))
                {
                    havegive = true ;
                    return;
                }
                    
                //Thread.Sleep(100);
                byte[] ReDatas = new byte[ComDevice.BytesToRead];

                while (ReDatas.Length != 9)
                {
                    ReDatas = new byte[ComDevice.BytesToRead];
                }
                ComDevice.Read(ReDatas, 0, ReDatas.Length);//读取数据

                string tmp = "";
                for (int i = 3; i < 7; i++)
                {
                    tmp = tmp + Convert.ToString(ReDatas[i], 2).PadLeft(8, '0');
                }
                in_state = Turn(tmp);
                havedeal = true;
                ComDevice.DiscardInBuffer();
                //  ReDatas = null;
            }
            catch
            {
                
                return;
            }
        }


        public string Turn(string str)
        {
            string _str = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                _str += str[i];
            }
            return _str;
        }

        /// <summary>
        /// 字符串转换16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private byte[] strToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0) hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ", ""), 16);
            return returnBytes;
        }

    
    }
}
