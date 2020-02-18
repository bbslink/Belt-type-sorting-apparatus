namespace Belt_type_sorting_apparatus
{
    partial class CameraSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_CameraGain = new System.Windows.Forms.TextBox();
            this.tb_Exposuretime = new System.Windows.Forms.TextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_BlackLevel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Brightness = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_CameraContrast = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_CameraGain
            // 
            this.tb_CameraGain.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_CameraGain.Location = new System.Drawing.Point(221, 141);
            this.tb_CameraGain.Margin = new System.Windows.Forms.Padding(4);
            this.tb_CameraGain.Name = "tb_CameraGain";
            this.tb_CameraGain.Size = new System.Drawing.Size(183, 26);
            this.tb_CameraGain.TabIndex = 6;
            this.tb_CameraGain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_CameraGain_KeyPress);
            // 
            // tb_Exposuretime
            // 
            this.tb_Exposuretime.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_Exposuretime.Location = new System.Drawing.Point(221, 87);
            this.tb_Exposuretime.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Exposuretime.Name = "tb_Exposuretime";
            this.tb_Exposuretime.Size = new System.Drawing.Size(184, 26);
            this.tb_Exposuretime.TabIndex = 7;
            this.tb_Exposuretime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Exposuretime_KeyPress);
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Font = new System.Drawing.Font("宋体", 12F);
            this.label85.Location = new System.Drawing.Point(44, 91);
            this.label85.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(120, 16);
            this.label85.TabIndex = 8;
            this.label85.Text = "相机曝光时间：";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Font = new System.Drawing.Font("宋体", 12F);
            this.label86.Location = new System.Drawing.Point(44, 144);
            this.label86.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(88, 16);
            this.label86.TabIndex = 9;
            this.label86.Text = "相机增益：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(623, 350);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 68);
            this.button1.TabIndex = 10;
            this.button1.Text = "保存参数";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "黑电平：";
            // 
            // tb_BlackLevel
            // 
            this.tb_BlackLevel.Location = new System.Drawing.Point(221, 185);
            this.tb_BlackLevel.Margin = new System.Windows.Forms.Padding(4);
            this.tb_BlackLevel.Name = "tb_BlackLevel";
            this.tb_BlackLevel.Size = new System.Drawing.Size(184, 26);
            this.tb_BlackLevel.TabIndex = 12;
            this.tb_BlackLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_BlackLevel_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 233);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "相机亮度：";
            // 
            // tb_Brightness
            // 
            this.tb_Brightness.Location = new System.Drawing.Point(221, 227);
            this.tb_Brightness.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Brightness.Name = "tb_Brightness";
            this.tb_Brightness.Size = new System.Drawing.Size(183, 26);
            this.tb_Brightness.TabIndex = 14;
            this.tb_Brightness.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Brightness_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 279);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "相机对比度：";
            // 
            // tb_CameraContrast
            // 
            this.tb_CameraContrast.Location = new System.Drawing.Point(221, 279);
            this.tb_CameraContrast.Margin = new System.Windows.Forms.Padding(4);
            this.tb_CameraContrast.Name = "tb_CameraContrast";
            this.tb_CameraContrast.Size = new System.Drawing.Size(184, 26);
            this.tb_CameraContrast.TabIndex = 16;
            this.tb_CameraContrast.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_CameraContrast_KeyPress);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(425, 87);
            this.trackBar1.Maximum = 20000;
            this.trackBar1.Minimum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(369, 45);
            this.trackBar1.SmallChange = 100;
            this.trackBar1.TabIndex = 17;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(425, 141);
            this.trackBar2.Maximum = 150;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(369, 45);
            this.trackBar2.SmallChange = 0;
            this.trackBar2.TabIndex = 18;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(425, 185);
            this.trackBar3.Maximum = 200;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(369, 45);
            this.trackBar3.SmallChange = 2;
            this.trackBar3.TabIndex = 19;
            this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(425, 227);
            this.trackBar4.Maximum = 100;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(369, 45);
            this.trackBar4.TabIndex = 20;
            this.trackBar4.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(425, 278);
            this.trackBar5.Maximum = 100;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(369, 45);
            this.trackBar5.TabIndex = 21;
            this.trackBar5.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar5.Scroll += new System.EventHandler(this.trackBar5_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(820, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(823, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(823, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(823, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(823, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "0";
            // 
            // CameraSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 431);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar5);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.tb_CameraContrast);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Brightness);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_BlackLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_CameraGain);
            this.Controls.Add(this.tb_Exposuretime);
            this.Controls.Add(this.label85);
            this.Controls.Add(this.label86);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CameraSet";
            this.Text = "CameraSet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CameraSet_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_CameraGain;
        private System.Windows.Forms.TextBox tb_Exposuretime;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_BlackLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Brightness;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_CameraContrast;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}