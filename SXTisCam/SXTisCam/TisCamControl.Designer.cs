namespace SXTisCam
{
    partial class TisCamControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_TextContarst = new System.Windows.Forms.NumericUpDown();
            this.btn_TextBlack = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_ReadCamParam = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_BarBlack = new System.Windows.Forms.TrackBar();
            this.btn_TextExpos = new System.Windows.Forms.NumericUpDown();
            this.btn_BarContarst = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_BarExpos = new System.Windows.Forms.TrackBar();
            this.btn_BarBright = new System.Windows.Forms.TrackBar();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_TextBright = new System.Windows.Forms.NumericUpDown();
            this.cb_CurCamera = new System.Windows.Forms.ComboBox();
            this.btn_BarGain = new System.Windows.Forms.TrackBar();
            this.btn_TextGain = new System.Windows.Forms.NumericUpDown();
            this.btn_Snapshot = new System.Windows.Forms.Button();
            this.btn_RealImg = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_GrabTime = new System.Windows.Forms.NumericUpDown();
            this.timer_realimg = new System.Windows.Forms.Timer(this.components);
            this.btn_SaveCamParam = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TextContarst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TextBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_BarBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TextExpos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_BarContarst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_BarExpos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_BarBright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TextBright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_BarGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TextGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_GrabTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_TextContarst
            // 
            this.btn_TextContarst.Enabled = false;
            this.btn_TextContarst.Location = new System.Drawing.Point(80, 162);
            this.btn_TextContarst.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.btn_TextContarst.Name = "btn_TextContarst";
            this.btn_TextContarst.Size = new System.Drawing.Size(73, 23);
            this.btn_TextContarst.TabIndex = 51;
            this.btn_TextContarst.Tag = "4";
            this.btn_TextContarst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_TextContarst.ValueChanged += new System.EventHandler(this.btn_CameraText_ValueChanged);
            // 
            // btn_TextBlack
            // 
            this.btn_TextBlack.Enabled = false;
            this.btn_TextBlack.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btn_TextBlack.Location = new System.Drawing.Point(80, 192);
            this.btn_TextBlack.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.btn_TextBlack.Name = "btn_TextBlack";
            this.btn_TextBlack.Size = new System.Drawing.Size(73, 23);
            this.btn_TextBlack.TabIndex = 52;
            this.btn_TextBlack.Tag = "5";
            this.btn_TextBlack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_TextBlack.ValueChanged += new System.EventHandler(this.btn_CameraText_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 14);
            this.label15.TabIndex = 49;
            this.label15.Text = "相机列表:";
            // 
            // btn_ReadCamParam
            // 
            this.btn_ReadCamParam.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ReadCamParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ReadCamParam.Location = new System.Drawing.Point(8, 40);
            this.btn_ReadCamParam.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ReadCamParam.Name = "btn_ReadCamParam";
            this.btn_ReadCamParam.Size = new System.Drawing.Size(85, 29);
            this.btn_ReadCamParam.TabIndex = 37;
            this.btn_ReadCamParam.Tag = "false";
            this.btn_ReadCamParam.Text = "读取参数";
            this.btn_ReadCamParam.UseVisualStyleBackColor = false;
            this.btn_ReadCamParam.Click += new System.EventHandler(this.btn_ReadCamParam_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 193);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 14);
            this.label12.TabIndex = 47;
            this.label12.Text = "黑电平:";
            // 
            // btn_BarBlack
            // 
            this.btn_BarBlack.AutoSize = false;
            this.btn_BarBlack.Enabled = false;
            this.btn_BarBlack.Location = new System.Drawing.Point(159, 193);
            this.btn_BarBlack.Maximum = 255;
            this.btn_BarBlack.Name = "btn_BarBlack";
            this.btn_BarBlack.Size = new System.Drawing.Size(322, 23);
            this.btn_BarBlack.TabIndex = 41;
            this.btn_BarBlack.Tag = "5";
            this.btn_BarBlack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.btn_BarBlack.Scroll += new System.EventHandler(this.btn_CamBar_Scroll);
            // 
            // btn_TextExpos
            // 
            this.btn_TextExpos.DecimalPlaces = 4;
            this.btn_TextExpos.Enabled = false;
            this.btn_TextExpos.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.btn_TextExpos.Location = new System.Drawing.Point(63, 74);
            this.btn_TextExpos.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.btn_TextExpos.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.btn_TextExpos.Name = "btn_TextExpos";
            this.btn_TextExpos.Size = new System.Drawing.Size(90, 23);
            this.btn_TextExpos.TabIndex = 54;
            this.btn_TextExpos.Tag = "1";
            this.btn_TextExpos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_TextExpos.Value = new decimal(new int[] {
            3,
            0,
            0,
            131072});
            this.btn_TextExpos.ValueChanged += new System.EventHandler(this.btn_CameraText_ValueChanged);
            // 
            // btn_BarContarst
            // 
            this.btn_BarContarst.AutoSize = false;
            this.btn_BarContarst.Enabled = false;
            this.btn_BarContarst.Location = new System.Drawing.Point(159, 167);
            this.btn_BarContarst.Maximum = 255;
            this.btn_BarContarst.Name = "btn_BarContarst";
            this.btn_BarContarst.Size = new System.Drawing.Size(322, 23);
            this.btn_BarContarst.TabIndex = 40;
            this.btn_BarContarst.Tag = "4";
            this.btn_BarContarst.TickStyle = System.Windows.Forms.TickStyle.None;
            this.btn_BarContarst.Scroll += new System.EventHandler(this.btn_CamBar_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 14);
            this.label11.TabIndex = 46;
            this.label11.Text = "亮度:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 14);
            this.label10.TabIndex = 45;
            this.label10.Text = "对比度:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 48;
            this.label13.Text = "增益:";
            // 
            // btn_BarExpos
            // 
            this.btn_BarExpos.AutoSize = false;
            this.btn_BarExpos.Enabled = false;
            this.btn_BarExpos.Location = new System.Drawing.Point(159, 78);
            this.btn_BarExpos.Maximum = 255;
            this.btn_BarExpos.Name = "btn_BarExpos";
            this.btn_BarExpos.Size = new System.Drawing.Size(322, 23);
            this.btn_BarExpos.TabIndex = 43;
            this.btn_BarExpos.Tag = "1";
            this.btn_BarExpos.TickStyle = System.Windows.Forms.TickStyle.None;
            this.btn_BarExpos.Scroll += new System.EventHandler(this.btn_CamBar_Scroll);
            // 
            // btn_BarBright
            // 
            this.btn_BarBright.AutoSize = false;
            this.btn_BarBright.Enabled = false;
            this.btn_BarBright.Location = new System.Drawing.Point(159, 138);
            this.btn_BarBright.Maximum = 255;
            this.btn_BarBright.Name = "btn_BarBright";
            this.btn_BarBright.Size = new System.Drawing.Size(322, 23);
            this.btn_BarBright.TabIndex = 44;
            this.btn_BarBright.Tag = "3";
            this.btn_BarBright.TickStyle = System.Windows.Forms.TickStyle.None;
            this.btn_BarBright.Scroll += new System.EventHandler(this.btn_CamBar_Scroll);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 14);
            this.label14.TabIndex = 50;
            this.label14.Text = "曝光:";
            // 
            // btn_TextBright
            // 
            this.btn_TextBright.Enabled = false;
            this.btn_TextBright.Location = new System.Drawing.Point(63, 133);
            this.btn_TextBright.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.btn_TextBright.Name = "btn_TextBright";
            this.btn_TextBright.Size = new System.Drawing.Size(90, 23);
            this.btn_TextBright.TabIndex = 53;
            this.btn_TextBright.Tag = "3";
            this.btn_TextBright.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_TextBright.ValueChanged += new System.EventHandler(this.btn_CameraText_ValueChanged);
            // 
            // cb_CurCamera
            // 
            this.cb_CurCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CurCamera.FormattingEnabled = true;
            this.cb_CurCamera.Location = new System.Drawing.Point(97, 8);
            this.cb_CurCamera.Name = "cb_CurCamera";
            this.cb_CurCamera.Size = new System.Drawing.Size(376, 21);
            this.cb_CurCamera.TabIndex = 36;
            this.cb_CurCamera.SelectedIndexChanged += new System.EventHandler(this.cb_CurCamera_SelectedIndexChanged);
            // 
            // btn_BarGain
            // 
            this.btn_BarGain.AutoSize = false;
            this.btn_BarGain.Enabled = false;
            this.btn_BarGain.Location = new System.Drawing.Point(159, 108);
            this.btn_BarGain.Maximum = 255;
            this.btn_BarGain.Name = "btn_BarGain";
            this.btn_BarGain.Size = new System.Drawing.Size(322, 23);
            this.btn_BarGain.TabIndex = 42;
            this.btn_BarGain.Tag = "2";
            this.btn_BarGain.TickStyle = System.Windows.Forms.TickStyle.None;
            this.btn_BarGain.Scroll += new System.EventHandler(this.btn_CamBar_Scroll);
            // 
            // btn_TextGain
            // 
            this.btn_TextGain.DecimalPlaces = 2;
            this.btn_TextGain.Enabled = false;
            this.btn_TextGain.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.btn_TextGain.Location = new System.Drawing.Point(63, 104);
            this.btn_TextGain.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.btn_TextGain.Name = "btn_TextGain";
            this.btn_TextGain.Size = new System.Drawing.Size(90, 23);
            this.btn_TextGain.TabIndex = 55;
            this.btn_TextGain.Tag = "2";
            this.btn_TextGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_TextGain.ValueChanged += new System.EventHandler(this.btn_CameraText_ValueChanged);
            // 
            // btn_Snapshot
            // 
            this.btn_Snapshot.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Snapshot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Snapshot.Location = new System.Drawing.Point(185, 41);
            this.btn_Snapshot.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Snapshot.Name = "btn_Snapshot";
            this.btn_Snapshot.Size = new System.Drawing.Size(85, 29);
            this.btn_Snapshot.TabIndex = 37;
            this.btn_Snapshot.Tag = "false";
            this.btn_Snapshot.Text = "触发拍照";
            this.btn_Snapshot.UseVisualStyleBackColor = false;
            this.btn_Snapshot.Click += new System.EventHandler(this.btn_Snapshot_Click);
            // 
            // btn_RealImg
            // 
            this.btn_RealImg.BackColor = System.Drawing.SystemColors.Control;
            this.btn_RealImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RealImg.Location = new System.Drawing.Point(275, 41);
            this.btn_RealImg.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RealImg.Name = "btn_RealImg";
            this.btn_RealImg.Size = new System.Drawing.Size(85, 29);
            this.btn_RealImg.TabIndex = 37;
            this.btn_RealImg.Tag = "false";
            this.btn_RealImg.Text = "实时图像";
            this.btn_RealImg.UseVisualStyleBackColor = false;
            this.btn_RealImg.Click += new System.EventHandler(this.btn_RealImg_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 50;
            this.label1.Text = "频率:";
            // 
            // tb_GrabTime
            // 
            this.tb_GrabTime.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tb_GrabTime.Location = new System.Drawing.Point(410, 42);
            this.tb_GrabTime.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tb_GrabTime.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tb_GrabTime.Name = "tb_GrabTime";
            this.tb_GrabTime.Size = new System.Drawing.Size(65, 23);
            this.tb_GrabTime.TabIndex = 52;
            this.tb_GrabTime.Tag = "5";
            this.tb_GrabTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_GrabTime.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // timer_realimg
            // 
            this.timer_realimg.Tick += new System.EventHandler(this.timer_realimg_Tick);
            // 
            // btn_SaveCamParam
            // 
            this.btn_SaveCamParam.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SaveCamParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveCamParam.Location = new System.Drawing.Point(96, 40);
            this.btn_SaveCamParam.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SaveCamParam.Name = "btn_SaveCamParam";
            this.btn_SaveCamParam.Size = new System.Drawing.Size(85, 29);
            this.btn_SaveCamParam.TabIndex = 37;
            this.btn_SaveCamParam.Tag = "false";
            this.btn_SaveCamParam.Text = "保存参数";
            this.btn_SaveCamParam.UseVisualStyleBackColor = false;
            this.btn_SaveCamParam.Click += new System.EventHandler(this.btn_SaveCamParam_Click);
            // 
            // TisCamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb_GrabTime);
            this.Controls.Add(this.btn_TextContarst);
            this.Controls.Add(this.btn_TextBlack);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btn_RealImg);
            this.Controls.Add(this.btn_Snapshot);
            this.Controls.Add(this.btn_SaveCamParam);
            this.Controls.Add(this.btn_ReadCamParam);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_BarBlack);
            this.Controls.Add(this.btn_TextExpos);
            this.Controls.Add(this.btn_BarContarst);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btn_BarExpos);
            this.Controls.Add(this.btn_BarBright);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btn_TextBright);
            this.Controls.Add(this.cb_CurCamera);
            this.Controls.Add(this.btn_BarGain);
            this.Controls.Add(this.btn_TextGain);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.Name = "TisCamControl";
            this.Size = new System.Drawing.Size(481, 224);
            ((System.ComponentModel.ISupportInitialize)(this.btn_TextContarst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TextBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_BarBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TextExpos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_BarContarst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_BarExpos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_BarBright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TextBright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_BarGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TextGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_GrabTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown btn_TextContarst;
        private System.Windows.Forms.NumericUpDown btn_TextBlack;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_ReadCamParam;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar btn_BarBlack;
        private System.Windows.Forms.NumericUpDown btn_TextExpos;
        private System.Windows.Forms.TrackBar btn_BarContarst;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar btn_BarExpos;
        private System.Windows.Forms.TrackBar btn_BarBright;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown btn_TextBright;
        private System.Windows.Forms.ComboBox cb_CurCamera;
        private System.Windows.Forms.TrackBar btn_BarGain;
        private System.Windows.Forms.NumericUpDown btn_TextGain;
        private System.Windows.Forms.Button btn_Snapshot;
        private System.Windows.Forms.Button btn_RealImg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown tb_GrabTime;
        private System.Windows.Forms.Timer timer_realimg;
        private System.Windows.Forms.Button btn_SaveCamParam;
    }
}
