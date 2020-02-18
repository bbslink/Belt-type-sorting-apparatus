namespace Belt_type_sorting_apparatus
{
    partial class VisionSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisionSetting));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.modelsControl1 = new SXModelsControl.ModelsControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tisCamControl1 = new SXTisCam.TisCamControl();
            this.dispControl2 = new SXDispControl.DispControl();
            this.optLigCon2 = new SXOptLig.OptLigCon();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1040, 654);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.modelsControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1032, 627);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "模板设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // modelsControl1
            // 
            this.modelsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelsControl1.Font = new System.Drawing.Font("宋体", 10F);
            this.modelsControl1.Location = new System.Drawing.Point(0, 0);
            this.modelsControl1.Name = "modelsControl1";
            this.modelsControl1.Size = new System.Drawing.Size(1032, 627);
            this.modelsControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tisCamControl1);
            this.tabPage3.Controls.Add(this.dispControl2);
            this.tabPage3.Controls.Add(this.optLigCon2);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1032, 627);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "相机光源";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tisCamControl1
            // 
            this.tisCamControl1.CurSelCam = null;
            this.tisCamControl1.Font = new System.Drawing.Font("宋体", 10F);
            this.tisCamControl1.Location = new System.Drawing.Point(528, 13);
            this.tisCamControl1.Name = "tisCamControl1";
            this.tisCamControl1.Size = new System.Drawing.Size(481, 224);
            this.tisCamControl1.TabIndex = 3;
            // 
            // dispControl2
            // 
            this.dispControl2.BackColor = System.Drawing.Color.Black;
            this.dispControl2.Location = new System.Drawing.Point(2, 2);
            this.dispControl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dispControl2.Name = "dispControl2";
            this.dispControl2.Size = new System.Drawing.Size(517, 466);
            this.dispControl2.TabIndex = 2;
            // 
            // optLigCon2
            // 
            this.optLigCon2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.optLigCon2.Font = new System.Drawing.Font("宋体", 10F);
            this.optLigCon2.Location = new System.Drawing.Point(528, 287);
            this.optLigCon2.Name = "optLigCon2";
            this.optLigCon2.Size = new System.Drawing.Size(496, 181);
            this.optLigCon2.TabIndex = 1;
            // 
            // VisionSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 654);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VisionSetting";
            this.Text = "WorkDataSetting(生产品目数据设定）";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VisionSetting_FormClosed);
            this.Load += new System.EventHandler(this.VisionSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private SXDispControl.DispControl dispControl2;
        private SXOptLig.OptLigCon optLigCon2;
        private SXModelsControl.ModelsControl modelsControl1;
        private SXTisCam.TisCamControl tisCamControl1;
    }
}