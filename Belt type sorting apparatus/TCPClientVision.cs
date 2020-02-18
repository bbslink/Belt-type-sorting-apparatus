using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    public partial class TCPClientVision : Form
    {
       TCPClient ss;
        string errmsg;
        public TCPClientVision()
        {
            InitializeComponent();
        }

        private void TCPClientVision_Load(object sender, EventArgs e)
        {
            try
            {
                ss = new TCPClient();
                Ping ping = new Ping();
                PingReply pingreply = ping.Send(textBox1.Text);
               for(int i =0 ;i<=30;i++)
               {
                    pingreply = ping.Send(textBox1.Text);
                    if (pingreply.Status == IPStatus.Success)
                    {
                        if (ss.AsynConnect(textBox1.Text, 64000, out errmsg) == false)
                            MessageBox.Show(errmsg);
                        ss.PostMessEvent += new TCPClient.PostMessEventHandler(showinfo);
                        return;
                    }
                    Thread.Sleep(1);
                }
               throw new Exception("超时啊，连不上探高哦！");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ss.ClientSend(textBox3.Text+"\r\n",out errmsg);
        }

        public void showinfo(Socket socket, object abs)
        {
            richTextBox1.Invoke(new Action(() =>
            {
                richTextBox1.AppendText("【接收数据】" + abs.ToString() + "\r\n");
            }));
        }

        private void TCPClientVision_FormClosing(object sender, FormClosingEventArgs e)
        {
            ss.PostMessEvent -= new TCPClient.PostMessEventHandler(showinfo);
            //ss.AsynDisConnect(out errmsg);
        }

    }
}
