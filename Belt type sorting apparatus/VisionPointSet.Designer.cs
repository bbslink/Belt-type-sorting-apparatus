namespace Belt_type_sorting_apparatus
{
    partial class VisionPointSet
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
            this.btn_SaveCurFlag = new System.Windows.Forms.Button();
            this.btn_SubmitFlag = new System.Windows.Forms.Button();
            this.btn_ClearFlags = new System.Windows.Forms.Button();
            this.tb_firstColumn = new System.Windows.Forms.TextBox();
            this.tb_firstRow = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.tb_RowDist = new System.Windows.Forms.TextBox();
            this.tb_ColumnDist = new System.Windows.Forms.TextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.tb_ColumnNum = new System.Windows.Forms.TextBox();
            this.tb_RowNum = new System.Windows.Forms.TextBox();
            this.viewPort = new HalconDotNet.HWindowControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_SaveCurFlag
            // 
            this.btn_SaveCurFlag.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_SaveCurFlag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveCurFlag.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_SaveCurFlag.Location = new System.Drawing.Point(381, 275);
            this.btn_SaveCurFlag.Name = "btn_SaveCurFlag";
            this.btn_SaveCurFlag.Size = new System.Drawing.Size(100, 50);
            this.btn_SaveCurFlag.TabIndex = 63;
            this.btn_SaveCurFlag.Text = "保存当前";
            this.btn_SaveCurFlag.UseVisualStyleBackColor = false;
            this.btn_SaveCurFlag.Click += new System.EventHandler(this.btn_SaveCurFlag_Click_1);
            // 
            // btn_SubmitFlag
            // 
            this.btn_SubmitFlag.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_SubmitFlag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SubmitFlag.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_SubmitFlag.Location = new System.Drawing.Point(381, 219);
            this.btn_SubmitFlag.Name = "btn_SubmitFlag";
            this.btn_SubmitFlag.Size = new System.Drawing.Size(100, 50);
            this.btn_SubmitFlag.TabIndex = 62;
            this.btn_SubmitFlag.Text = "提交生成";
            this.btn_SubmitFlag.UseVisualStyleBackColor = false;
            this.btn_SubmitFlag.Click += new System.EventHandler(this.btn_SubmitFlag_Click_1);
            // 
            // btn_ClearFlags
            // 
            this.btn_ClearFlags.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ClearFlags.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ClearFlags.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_ClearFlags.Location = new System.Drawing.Point(487, 219);
            this.btn_ClearFlags.Name = "btn_ClearFlags";
            this.btn_ClearFlags.Size = new System.Drawing.Size(100, 50);
            this.btn_ClearFlags.TabIndex = 65;
            this.btn_ClearFlags.Text = "清除界面";
            this.btn_ClearFlags.UseVisualStyleBackColor = false;
            this.btn_ClearFlags.Click += new System.EventHandler(this.btn_ClearFlags_Click);
            // 
            // tb_firstColumn
            // 
            this.tb_firstColumn.Location = new System.Drawing.Point(471, 51);
            this.tb_firstColumn.Name = "tb_firstColumn";
            this.tb_firstColumn.Size = new System.Drawing.Size(100, 21);
            this.tb_firstColumn.TabIndex = 70;
            this.tb_firstColumn.Text = "0";
            this.tb_firstColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_firstRow
            // 
            this.tb_firstRow.Location = new System.Drawing.Point(471, 15);
            this.tb_firstRow.Name = "tb_firstRow";
            this.tb_firstRow.Size = new System.Drawing.Size(100, 21);
            this.tb_firstRow.TabIndex = 69;
            this.tb_firstRow.Text = "0";
            this.tb_firstRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(386, 53);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 12);
            this.label25.TabIndex = 68;
            this.label25.Text = "首点 Y:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(386, 18);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 12);
            this.label26.TabIndex = 67;
            this.label26.Text = "首点 X:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 12F);
            this.label31.Location = new System.Drawing.Point(386, 121);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 16);
            this.label31.TabIndex = 50;
            this.label31.Text = "列距:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 12F);
            this.label35.Location = new System.Drawing.Point(386, 86);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(48, 16);
            this.label35.TabIndex = 51;
            this.label35.Text = "行距:";
            // 
            // tb_RowDist
            // 
            this.tb_RowDist.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_RowDist.Location = new System.Drawing.Point(471, 83);
            this.tb_RowDist.Name = "tb_RowDist";
            this.tb_RowDist.Size = new System.Drawing.Size(100, 26);
            this.tb_RowDist.TabIndex = 48;
            this.tb_RowDist.Text = "30";
            this.tb_RowDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_ColumnDist
            // 
            this.tb_ColumnDist.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_ColumnDist.Location = new System.Drawing.Point(471, 118);
            this.tb_ColumnDist.Name = "tb_ColumnDist";
            this.tb_ColumnDist.Size = new System.Drawing.Size(100, 26);
            this.tb_ColumnDist.TabIndex = 49;
            this.tb_ColumnDist.Text = "35";
            this.tb_ColumnDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Font = new System.Drawing.Font("宋体", 12F);
            this.label99.Location = new System.Drawing.Point(392, 191);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(48, 16);
            this.label99.TabIndex = 53;
            this.label99.Text = "列数:";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Font = new System.Drawing.Font("宋体", 12F);
            this.label100.Location = new System.Drawing.Point(392, 155);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(48, 16);
            this.label100.TabIndex = 55;
            this.label100.Text = "行数:";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Font = new System.Drawing.Font("宋体", 12F);
            this.label101.Location = new System.Drawing.Point(563, 191);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(24, 16);
            this.label101.TabIndex = 60;
            this.label101.Text = "列";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Font = new System.Drawing.Font("宋体", 12F);
            this.label102.Location = new System.Drawing.Point(563, 155);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(24, 16);
            this.label102.TabIndex = 61;
            this.label102.Text = "行";
            // 
            // tb_ColumnNum
            // 
            this.tb_ColumnNum.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_ColumnNum.Location = new System.Drawing.Point(457, 186);
            this.tb_ColumnNum.Name = "tb_ColumnNum";
            this.tb_ColumnNum.Size = new System.Drawing.Size(100, 26);
            this.tb_ColumnNum.TabIndex = 47;
            this.tb_ColumnNum.Text = "6";
            this.tb_ColumnNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_RowNum
            // 
            this.tb_RowNum.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_RowNum.Location = new System.Drawing.Point(457, 150);
            this.tb_RowNum.Name = "tb_RowNum";
            this.tb_RowNum.Size = new System.Drawing.Size(100, 26);
            this.tb_RowNum.TabIndex = 46;
            this.tb_RowNum.Text = "4";
            this.tb_RowNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // viewPort
            // 
            this.viewPort.BackColor = System.Drawing.Color.Black;
            this.viewPort.BorderColor = System.Drawing.Color.Black;
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Left;
            this.viewPort.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.viewPort.Location = new System.Drawing.Point(0, 0);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(361, 331);
            this.viewPort.TabIndex = 74;
            this.viewPort.WindowSize = new System.Drawing.Size(361, 331);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.Location = new System.Drawing.Point(487, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 50);
            this.button1.TabIndex = 75;
            this.button1.Text = "加载模板";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VisionPointSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 331);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.btn_ClearFlags);
            this.Controls.Add(this.tb_RowNum);
            this.Controls.Add(this.tb_ColumnNum);
            this.Controls.Add(this.label102);
            this.Controls.Add(this.btn_SaveCurFlag);
            this.Controls.Add(this.label101);
            this.Controls.Add(this.btn_SubmitFlag);
            this.Controls.Add(this.label100);
            this.Controls.Add(this.label99);
            this.Controls.Add(this.tb_firstColumn);
            this.Controls.Add(this.tb_ColumnDist);
            this.Controls.Add(this.tb_firstRow);
            this.Controls.Add(this.tb_RowDist);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label31);
            this.Name = "VisionPointSet";
            this.Text = "VisionPointSet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SaveCurFlag;
        private System.Windows.Forms.Button btn_SubmitFlag;
        private System.Windows.Forms.Button btn_ClearFlags;
        private System.Windows.Forms.TextBox tb_firstColumn;
        private System.Windows.Forms.TextBox tb_firstRow;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox tb_RowDist;
        private System.Windows.Forms.TextBox tb_ColumnDist;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.TextBox tb_ColumnNum;
        private System.Windows.Forms.TextBox tb_RowNum;
        private HalconDotNet.HWindowControl viewPort;
        private System.Windows.Forms.Button button1;
    }
}