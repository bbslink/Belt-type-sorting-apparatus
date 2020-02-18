namespace Belt_type_sorting_apparatus
{
    partial class CorrectTool
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
            this.dispControl1 = new SXDispControl.DispControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dispControl1
            // 
            this.dispControl1.BackColor = System.Drawing.Color.Black;
            this.dispControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dispControl1.Location = new System.Drawing.Point(0, 0);
            this.dispControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dispControl1.Name = "dispControl1";
            this.dispControl1.Size = new System.Drawing.Size(837, 751);
            this.dispControl1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(860, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 61);
            this.button1.TabIndex = 7;
            this.button1.Text = "识别基准点示教";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(915, 260);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 92);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(971, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 61);
            this.button3.TabIndex = 9;
            this.button3.Text = "执行点位";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // CorrectTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 751);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dispControl1);
            this.Name = "CorrectTool";
            this.Text = "CorrectTool";
            this.ResumeLayout(false);

        }

        #endregion

        private SXDispControl.DispControl dispControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}