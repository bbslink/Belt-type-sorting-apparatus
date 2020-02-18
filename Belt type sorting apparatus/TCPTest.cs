using Belt_type_sorting_apparatus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupDemo
{
    public partial class TCPTest : Form
    {
        public Socket listenSocket;//监听socket
        public Socket connectSocket;//通信socket
        public string connectedNodeName;//连接到此服务器的终端节点
        public bool isOpenServer = false;
        TCPServer tcpserver;


        public TCPTest()
        {
           
            InitializeComponent();
            
        }

        private void btn_StartServer_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ip;

                int port;
                if (!IPAddress.TryParse(tb_ServerIP.Text, out ip))
                {
                    MessageBox.Show("请输入正确的IP地址！");
                    return;
                }
          
                if (!int.TryParse(tb_ServerPort.Text, out port))
                {
                    MessageBox.Show("请输入正确的端口号！");
                    return;
                }
                
                if (isOpenServer == false)
                {
                    if (tcpserver.OpenServer(tb_ServerIP.Text, port))
                    {
                        isOpenServer = true;
                        btn_StartServer.Text = "关闭服务端";
                    }
                    

                }
                else
                {
                    btn_StartServer.Text = "启动服务端";
                    isOpenServer = false;
                    tcpserver.CloseServer();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("打开失败，请检查输入信息是否正确！");
                btn_StartServer.Text = "启动服务端";
                isOpenServer = false;
            }
        }


        
      


       
        


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcpserver.CloseServer();
        }


        private void btn_ServerSendMsg_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("请选择模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string mess = tb_ServerSend.Text;
            string index = comboBox1.SelectedItem.ToString();
            if (tcpserver.streams[index] == null || mess == string.Empty) return;
    
           
            try
            {
                for (int i = 0; i <1000; i++)
                {

                    tcpserver.SendMessage(mess, tcpserver.streams[index].GetStream());
                    rb_ServerReceiveMsg.Invoke(new Action(() =>
                        {
                            rb_ServerReceiveMsg.AppendText("【发送数据】" + mess + "\r\n");
                        }));
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }

        private void comboBox1_MouseDown(object sender, MouseEventArgs e)
        {
            comboBox1.Items.Clear();

            if (tcpserver.streams == null || tcpserver.streams.Count <= 0)
            {
                return;
            }

            foreach (var a in tcpserver.streams)
            {
                comboBox1.Items.Add(a.Key);
                
            }

            
        }

        private void TCPTest_Load(object sender, EventArgs e)
        {
            tcpserver = new TCPServer();
        }
    }
}
