using Belt_type_sorting_apparatus.CommonClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    class TCPServer
    {
        private TcpListener listener;
        Thread serverListern;
        bool isCloseListernClient = false;//启动或关闭服务端监听
       
        public  Dictionary<string, TcpClient> streams = new Dictionary<string, TcpClient>();
        SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        string errMsg;
        public bool OpenServer(string ip, int port)
        {
            try
            {
                IPAddress aip = IPAddress.Parse(ip);

                listener = new TcpListener(aip, port);
                try
                {
                    listener.Start();
                }
                catch
                {
                    Console.WriteLine("IP地址设置监听异常，检查IP地址");
                    isCloseListernClient = true;
                    return false;
                }
               
                isCloseListernClient = false;
                Console.WriteLine("监听已打开！正在监听......");
                serverListern = new Thread(() =>
                {
                    while (true)
                    {
                        try
                        {
                            TcpClient client = listener.AcceptTcpClient();
                            Thread remoteClient = new Thread(() =>
                            {
                                RemoteClient(client);
                            });
                            remoteClient.IsBackground = true;
                            remoteClient.Start();
                            Thread.Sleep(1);

                        }
                        catch
                        {
                            Console.WriteLine("已关闭监听");
                            CloseServer();
                        }
                    }
                });
                serverListern.IsBackground = true;
                serverListern.Start();
                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("设置监听异常！");
                return false;
            }

        }


        public void CloseServer()
        {
            if(listener!=null)
                listener.Stop();
            if(serverListern!=null)
                serverListern.Abort();

            streams.Clear();
            isCloseListernClient = true;
            Console.WriteLine("启动关闭监听，关闭接收信息！");

        }
        private void RemoteClient(TcpClient client)
        {
            RequestHandler handler = new RequestHandler();
            string clientip = client.Client.RemoteEndPoint.ToString().Split(':')[0];
            Console.WriteLine("\nClient Connected！{0} <-- {1}",
            client.Client.LocalEndPoint, client.Client.RemoteEndPoint);
            sysEvent.showRealInfo("\nClient Connected！" + client.Client.LocalEndPoint + " <-- {1}" + client.Client.RemoteEndPoint, CommonData.infoMess);
            NetworkStream stream= client.GetStream();//获取网络流  
            streams.Remove(clientip);
            streams.Add(clientip, client);
    
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int bytesRead = 0;

          
            try
            {
                while (true)
                {
                    
                    bytesRead=stream.Read(buffer, 0, buffer.Length);//读取网络流中的数据  

                    if (bytesRead == 0)
                    {
                        MessageProcess(client, "-1");
                        throw new Exception("检测到客户端关闭");
                    }
                  
                    if (isCloseListernClient == true)
                    {
                        stream.Close();//关闭流  
                        client.Close();
                        throw new Exception("监听关闭");
                    }

                    string receiveString = Encoding.Default.GetString(buffer).Trim('\0');//转换成字符串  
                    Array.Clear(buffer, 0, buffer.Length);
                    string[] msgArray = handler.GetActualString(receiveString);   // 获取实际的字符串


                // 遍历获得到的字符串
                foreach (string m in msgArray)
                {
                    //sysEvent.showRealInfo(clientip + "Received:" + m, CommonData.infoMess);
                    //MessageProcess(client, m);              
                    Console.WriteLine("Received: {0}", m);
                }              
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("接收失败！"+ex.Message);
            }


        }  

        public void SendMessage(string mes, NetworkStream stream)
        {
            byte[] temp = Encoding.UTF8.GetBytes(mes);
            stream.Write(temp, 0, temp.Length);
            stream.Flush();
           // Console.WriteLine("Sent: {0}", mes);
            sysEvent.showRealInfo("Sent: "+mes+"！/n", CommonData.infoMess);
        }



        public void MessageProcess(TcpClient client, string mes)
        {
            try
            {
                string clientip = client.Client.RemoteEndPoint.ToString().Split(':')[0];
                string clienthost = client.Client.RemoteEndPoint.ToString().Split(':')[1];
           
              
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(typeof(TCPServer), ex);
            }
        }

        class RequestHandler
        {
            private string temp = string.Empty;

            public string[] GetActualString(string input)
            {
                return GetActualString(input, null);
            }

            private string[] GetActualString(string input, List<string> outputList)
            {
                if (outputList == null)
                    outputList = new List<string>();

                if (!String.IsNullOrEmpty(temp))
                     input = temp + input;

                string output = "";
                string pattern = @"(?<=^\[Length=)(\d+)(?=\])";
                int length;

                if (Regex.IsMatch(input, pattern))
                {

                    Match m = Regex.Match(input, pattern);

                    // 获取消息字符串实际应有的长度
                    length = Convert.ToInt32(m.Groups[0].Value) + 1;

                    // 获取需要进行截取的位置
                    int startIndex = input.IndexOf(']') + 1;

                    // 获取从此位置开始后所有字符的长度
                    output = input.Substring(startIndex);

                    if (output.Length == length)
                    {
                        // 如果output的长度与消息字符串的应有长度相等
                        // 说明刚好是完整的一条信息
                        outputList.Add(output);
                        temp = "";
                    }
                    else if (output.Length < length)
                    {
                        // 如果之后的长度小于应有的长度，
                        // 说明没有发完整，则应将整条信息，包括元数据，全部缓存
                        // 与下一条数据合并起来再进行处理
                        temp = input;
                        // 此时程序应该退出，因为需要等待下一条数据到来才能继续处理

                    }
                    else if (output.Length > length)
                    {
                        // 如果之后的长度大于应有的长度，
                        // 说明消息发完整了，但是有多余的数据
                        // 多余的数据可能是截断消息，也可能是多条完整消息

                        // 截取字符串
                        output = output.Substring(0, length);
                        outputList.Add(output);
                        temp = "";

                        // 缩短input的长度
                        input = input.Substring(startIndex + length);

                        // 递归调用
                        GetActualString(input, outputList);
                    }
                }
                else
                {    // 说明“[”，“]”就不完整
                    temp = input;
                }

                return outputList.ToArray();
            }
        }




    }
}
