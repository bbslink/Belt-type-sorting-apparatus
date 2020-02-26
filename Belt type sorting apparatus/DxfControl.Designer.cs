namespace Belt_type_sorting_apparatus
{
    partial class DxfControl
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
            this.numControl1 = new SXDxf.NumControl();
            this.SuspendLayout();
            // 
            // numControl1
            // 
            this.numControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numControl1.Font = new System.Drawing.Font("宋体", 10F);
            this.numControl1.Location = new System.Drawing.Point(0, 0);
            this.numControl1.Name = "numControl1";
            this.numControl1.Size = new System.Drawing.Size(949, 566);
            this.numControl1.TabIndex = 1;
            // 
            // DxfControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 566);
            this.Controls.Add(this.numControl1);
            this.Name = "DxfControl";
            this.Text = "DxfControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DxfControl_FormClosing);
            this.Load += new System.EventHandler(this.DxfControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SXDxf.NumControl numControl1;
    }
}