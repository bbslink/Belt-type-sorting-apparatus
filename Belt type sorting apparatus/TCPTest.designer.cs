namespace GroupDemo
{
    partial class TCPTest
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_ServerSendMsg = new System.Windows.Forms.Button();
            this.tb_ServerSend = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rb_ServerReceiveMsg = new System.Windows.Forms.RichTextBox();
            this.btn_StartServer = new System.Windows.Forms.Button();
            this.tb_ServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ServerIP = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ServerSendMsg
            // 
            this.btn_ServerSendMsg.Location = new System.Drawing.Point(607, 354);
            this.btn_ServerSendMsg.Name = "btn_ServerSendMsg";
            this.btn_ServerSendMsg.Size = new System.Drawing.Size(75, 23);
            this.btn_ServerSendMsg.TabIndex = 17;
            this.btn_ServerSendMsg.Text = "发送";
            this.btn_ServerSendMsg.UseVisualStyleBackColor = true;
            this.btn_ServerSendMsg.Click += new System.EventHandler(this.btn_ServerSendMsg_Click);
            // 
            // tb_ServerSend
            // 
            this.tb_ServerSend.Location = new System.Drawing.Point(80, 330);
            this.tb_ServerSend.Name = "tb_ServerSend";
            this.tb_ServerSend.Size = new System.Drawing.Size(488, 21);
            this.tb_ServerSend.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "反馈内容";
            // 
            // rb_ServerReceiveMsg
            // 
            this.rb_ServerReceiveMsg.Location = new System.Drawing.Point(80, 121);
            this.rb_ServerReceiveMsg.Name = "rb_ServerReceiveMsg";
            this.rb_ServerReceiveMsg.Size = new System.Drawing.Size(602, 173);
            this.rb_ServerReceiveMsg.TabIndex = 14;
            this.rb_ServerReceiveMsg.Text = "";
            // 
            // btn_StartServer
            // 
            this.btn_StartServer.Location = new System.Drawing.Point(607, 53);
            this.btn_StartServer.Name = "btn_StartServer";
            this.btn_StartServer.Size = new System.Drawing.Size(75, 23);
            this.btn_StartServer.TabIndex = 13;
            this.btn_StartServer.Text = "启动服务端";
            this.btn_StartServer.UseVisualStyleBackColor = true;
            this.btn_StartServer.Click += new System.EventHandler(this.btn_StartServer_Click);
            // 
            // tb_ServerPort
            // 
            this.tb_ServerPort.Location = new System.Drawing.Point(386, 55);
            this.tb_ServerPort.Name = "tb_ServerPort";
            this.tb_ServerPort.Size = new System.Drawing.Size(100, 21);
            this.tb_ServerPort.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "端口：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "IP地址：";
            // 
            // tb_ServerIP
            // 
            this.tb_ServerIP.Location = new System.Drawing.Point(150, 55);
            this.tb_ServerIP.Name = "tb_ServerIP";
            this.tb_ServerIP.Size = new System.Drawing.Size(100, 21);
            this.tb_ServerIP.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(447, 357);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "选择客户端：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(209, 354);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "发送次数：";
            // 
            // TCPTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 419);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_ServerSendMsg);
            this.Controls.Add(this.tb_ServerSend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rb_ServerReceiveMsg);
            this.Controls.Add(this.btn_StartServer);
            this.Controls.Add(this.tb_ServerPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ServerIP);
            this.Name = "TCPTest";
            this.Text = "服务端测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.TCPTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ServerSendMsg;
        private System.Windows.Forms.TextBox tb_ServerSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rb_ServerReceiveMsg;
        private System.Windows.Forms.Button btn_StartServer;
        private System.Windows.Forms.TextBox tb_ServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ServerIP;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
    }
}

