using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Belt_type_sorting_apparatus
{
    [Serializable]
    /// <summary>
    /// 创建异步TCP通信客户端
    /// </summary>
    public class TCPClient
    {

        Socket tcpClient = null;
        /// <summary>
        /// 推送收到的信息 委托
        /// </summary>
        public delegate void PostMessEventHandler(Socket socket, object grabMess);
        public PostMessEventHandler PostMessEvent;

        /// <summary>
        /// 推送收到的信息 委托
        /// </summary>
        private void PostMess(Socket socket, object grabMess)
        {
            if (PostMessEvent != null)
            {
                PostMessEvent(socket, grabMess);
            }
        }

        #region 异步连接
        /// <summary>
        /// Tcp协议异步连接服务器
        /// </summary>
        /// <param name="connectIp">服务器IP地址</param>
        /// <param name="connectPort">服务器端口号</param>
        /// <param name="errMsg">返回错误信息</param>
        /// <returns></returns>
        public bool AsynConnect(string connectIp, int connectPort, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                //主机IP
                IPEndPoint serverIp = new IPEndPoint(IPAddress.Parse(connectIp), connectPort);
                tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                tcpClient.BeginConnect(serverIp, asyncResult =>
                {
                    tcpClient.EndConnect(asyncResult);
                    ClientReceive(tcpClient);
                }, null);

                thisResult = true;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = ex.Message;
            }
            return thisResult;
        }

        /// <summary>
        /// Tcp协议异步连接服务器
        /// </summary>
        /// <param name="connectIp">服务器IP地址</param>
        /// <param name="connectPort">服务器端口号</param>
        /// <param name="errMsg">返回错误信息</param>
        /// <returns></returns>
        public bool AsynDisConnect(out string errMsg)
        {
            bool thisResult = true;
            try
            {
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }
                thisResult = true;
                errMsg = "";
            }
            catch (Exception ex)
            {
                thisResult = false;
                errMsg = ex.Message;
            }
            return thisResult;
        }
        #endregion

        #region 异步接受消息
        /// <summary>
        /// 异步连接客户端回调函数
        /// </summary>
        /// <param name="tcpClient"></param>
        private void ClientReceive(Socket tcpClient)
        {
            try
            {
                byte[] data = new byte[1024];
                tcpClient.BeginReceive(data, 0, data.Length, SocketFlags.None, asyncResult =>
                {
                    int length = tcpClient.EndReceive(asyncResult);
                    PostMess(tcpClient, Encoding.Default.GetString(data));
                    ClientReceive(tcpClient);
                }, null);
            }
            catch (Exception) {  }
        }
        #endregion

        #region 异步发送消息
        /// <summary>
        /// 客户端异步发送消息
        /// </summary>
        /// <param name="message">发送消息内容</param>
        /// <param name="errMsg">返回错误信息</param>
        /// <returns></returns>
        public bool ClientSend(string message, out string errMsg)
        {
            bool thisResult = true;
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(message);
                tcpClient.BeginSend(data, 0, data.Length, SocketFlags.None, asyncResult =>
                {
                    //完成发送消息
                    int length = tcpClient.EndSend(asyncResult);
                }, null);

                errMsg = "";
                thisResult = true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                thisResult = false;
            }
            return thisResult;
        }
        #endregion
    }
}
