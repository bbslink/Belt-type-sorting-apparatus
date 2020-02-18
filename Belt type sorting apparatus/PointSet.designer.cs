namespace Belt_type_sorting_apparatus
{
    partial class PointSet
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointSet));
            this.button1 = new System.Windows.Forms.Button();
            this.tb_InspectResult = new System.Windows.Forms.RichTextBox();
            this.cb_SelectProModel = new System.Windows.Forms.ComboBox();
            this.dgv_ProPoints = new System.Windows.Forms.DataGridView();
            this.PointName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JPPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R1Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.模板 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProPointsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsm_GoPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsm_SaveAllPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_ExportData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsm_DeletePoint = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_ExcutePoint = new System.Windows.Forms.Button();
            this.btn_ClearPro = new System.Windows.Forms.Button();
            this.btn_SubmitPro = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.tb_ProRowNum = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tb_ProColumnNum = new System.Windows.Forms.TextBox();
            this.timer_io = new System.Windows.Forms.Timer(this.components);
            this.btn_YZ = new System.Windows.Forms.Button();
            this.btn_YF = new System.Windows.Forms.Button();
            this.btn_QLZ = new System.Windows.Forms.Button();
            this.btn_QLF = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.btn_RZ = new System.Windows.Forms.Button();
            this.btn_RF = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_CurXPlace = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tb_CurYPlace = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.button34 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProPoints)).BeginInit();
            this.ProPointsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(666, 319);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 46);
            this.button1.TabIndex = 155;
            this.button1.Text = "示教左下";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_InspectResult
            // 
            this.tb_InspectResult.Location = new System.Drawing.Point(2, 434);
            this.tb_InspectResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_InspectResult.Name = "tb_InspectResult";
            this.tb_InspectResult.Size = new System.Drawing.Size(472, 137);
            this.tb_InspectResult.TabIndex = 154;
            this.tb_InspectResult.Text = "";
            // 
            // cb_SelectProModel
            // 
            this.cb_SelectProModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_SelectProModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SelectProModel.Font = new System.Drawing.Font("宋体", 12F);
            this.cb_SelectProModel.FormattingEnabled = true;
            this.cb_SelectProModel.Location = new System.Drawing.Point(750, 429);
            this.cb_SelectProModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_SelectProModel.Name = "cb_SelectProModel";
            this.cb_SelectProModel.Size = new System.Drawing.Size(144, 24);
            this.cb_SelectProModel.TabIndex = 133;
            this.cb_SelectProModel.SelectedIndexChanged += new System.EventHandler(this.cb_SelectProModel_SelectedIndexChanged);
            this.cb_SelectProModel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cb_SelectProModel_MouseDown);
            // 
            // dgv_ProPoints
            // 
            this.dgv_ProPoints.AllowUserToAddRows = false;
            this.dgv_ProPoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ProPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ProPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PointName,
            this.XPlace,
            this.JPPlace,
            this.R1Place,
            this.YPlace,
            this.模板});
            this.dgv_ProPoints.ContextMenuStrip = this.ProPointsMenu;
            this.dgv_ProPoints.Location = new System.Drawing.Point(2, 2);
            this.dgv_ProPoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_ProPoints.Name = "dgv_ProPoints";
            this.dgv_ProPoints.RowTemplate.Height = 27;
            this.dgv_ProPoints.Size = new System.Drawing.Size(472, 420);
            this.dgv_ProPoints.TabIndex = 127;
            this.dgv_ProPoints.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ProPoints_CellMouseDown);
            // 
            // PointName
            // 
            this.PointName.HeaderText = "序号";
            this.PointName.Name = "PointName";
            this.PointName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // XPlace
            // 
            this.XPlace.HeaderText = "X坐标";
            this.XPlace.Name = "XPlace";
            this.XPlace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // JPPlace
            // 
            this.JPPlace.HeaderText = "JP坐标";
            this.JPPlace.Name = "JPPlace";
            // 
            // R1Place
            // 
            this.R1Place.HeaderText = "R1坐标";
            this.R1Place.Name = "R1Place";
            // 
            // YPlace
            // 
            this.YPlace.HeaderText = "Y坐标";
            this.YPlace.Name = "YPlace";
            this.YPlace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 模板
            // 
            this.模板.HeaderText = "模板";
            this.模板.Name = "模板";
            // 
            // ProPointsMenu
            // 
            this.ProPointsMenu.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.ProPointsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ProPointsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_GoPoint,
            this.toolStripSeparator1,
            this.tsm_SaveAllPoint,
            this.tsm_ExportData,
            this.toolStripSeparator2,
            this.tsm_DeletePoint});
            this.ProPointsMenu.Name = "ProPointsMenu";
            this.ProPointsMenu.Size = new System.Drawing.Size(139, 112);
            // 
            // tsm_GoPoint
            // 
            this.tsm_GoPoint.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.tsm_GoPoint.Name = "tsm_GoPoint";
            this.tsm_GoPoint.Size = new System.Drawing.Size(138, 24);
            this.tsm_GoPoint.Text = "执行运动";
            this.tsm_GoPoint.Click += new System.EventHandler(this.tsm_GoPoint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // tsm_SaveAllPoint
            // 
            this.tsm_SaveAllPoint.Name = "tsm_SaveAllPoint";
            this.tsm_SaveAllPoint.Size = new System.Drawing.Size(138, 24);
            this.tsm_SaveAllPoint.Text = "全部保存";
            this.tsm_SaveAllPoint.Click += new System.EventHandler(this.tsm_SaveAllPoint_Click);
            // 
            // tsm_ExportData
            // 
            this.tsm_ExportData.Name = "tsm_ExportData";
            this.tsm_ExportData.Size = new System.Drawing.Size(138, 24);
            this.tsm_ExportData.Text = "导出数据";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(135, 6);
            // 
            // tsm_DeletePoint
            // 
            this.tsm_DeletePoint.Name = "tsm_DeletePoint";
            this.tsm_DeletePoint.Size = new System.Drawing.Size(138, 24);
            this.tsm_DeletePoint.Text = "删除点位";
            this.tsm_DeletePoint.Click += new System.EventHandler(this.tsm_DeletePoint_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_save.Location = new System.Drawing.Point(791, 521);
            this.btn_save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(103, 39);
            this.btn_save.TabIndex = 149;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_ExcutePoint
            // 
            this.btn_ExcutePoint.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ExcutePoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ExcutePoint.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_ExcutePoint.Location = new System.Drawing.Point(666, 521);
            this.btn_ExcutePoint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ExcutePoint.Name = "btn_ExcutePoint";
            this.btn_ExcutePoint.Size = new System.Drawing.Size(100, 39);
            this.btn_ExcutePoint.TabIndex = 148;
            this.btn_ExcutePoint.Text = "执行运动";
            this.btn_ExcutePoint.UseVisualStyleBackColor = false;
            this.btn_ExcutePoint.Click += new System.EventHandler(this.btn_ExcutePoint_Click);
            // 
            // btn_ClearPro
            // 
            this.btn_ClearPro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ClearPro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ClearPro.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_ClearPro.Location = new System.Drawing.Point(791, 466);
            this.btn_ClearPro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ClearPro.Name = "btn_ClearPro";
            this.btn_ClearPro.Size = new System.Drawing.Size(103, 41);
            this.btn_ClearPro.TabIndex = 147;
            this.btn_ClearPro.Text = "全部清除";
            this.btn_ClearPro.UseVisualStyleBackColor = false;
            this.btn_ClearPro.Click += new System.EventHandler(this.btn_ClearPro_Click);
            // 
            // btn_SubmitPro
            // 
            this.btn_SubmitPro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_SubmitPro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SubmitPro.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_SubmitPro.Location = new System.Drawing.Point(667, 466);
            this.btn_SubmitPro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_SubmitPro.Name = "btn_SubmitPro";
            this.btn_SubmitPro.Size = new System.Drawing.Size(99, 41);
            this.btn_SubmitPro.TabIndex = 146;
            this.btn_SubmitPro.Text = "提交生成";
            this.btn_SubmitPro.UseVisualStyleBackColor = false;
            this.btn_SubmitPro.Click += new System.EventHandler(this.btn_SubmitPro_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(665, 434);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 139;
            this.label5.Text = "当前模板：";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(665, 209);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(65, 12);
            this.label33.TabIndex = 145;
            this.label33.Text = "检测行数：";
            // 
            // tb_ProRowNum
            // 
            this.tb_ProRowNum.Location = new System.Drawing.Point(750, 206);
            this.tb_ProRowNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_ProRowNum.Name = "tb_ProRowNum";
            this.tb_ProRowNum.Size = new System.Drawing.Size(144, 21);
            this.tb_ProRowNum.TabIndex = 132;
            this.tb_ProRowNum.Text = "3";
            this.tb_ProRowNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(665, 246);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 12);
            this.label30.TabIndex = 144;
            this.label30.Text = "检测列数：";
            // 
            // tb_ProColumnNum
            // 
            this.tb_ProColumnNum.Location = new System.Drawing.Point(750, 242);
            this.tb_ProColumnNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_ProColumnNum.Name = "tb_ProColumnNum";
            this.tb_ProColumnNum.Size = new System.Drawing.Size(144, 21);
            this.tb_ProColumnNum.TabIndex = 134;
            this.tb_ProColumnNum.Text = "4";
            this.tb_ProColumnNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer_io
            // 
            this.timer_io.Tick += new System.EventHandler(this.timer_io_Tick);
            // 
            // btn_YZ
            // 
            this.btn_YZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_YZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_YZ.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_YZ.Image = ((System.Drawing.Image)(resources.GetObject("btn_YZ.Image")));
            this.btn_YZ.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_YZ.Location = new System.Drawing.Point(547, 121);
            this.btn_YZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_YZ.Name = "btn_YZ";
            this.btn_YZ.Size = new System.Drawing.Size(60, 60);
            this.btn_YZ.TabIndex = 173;
            this.btn_YZ.Text = "+X";
            this.btn_YZ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_YZ.UseVisualStyleBackColor = false;
            this.btn_YZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btn_YZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btn_YF
            // 
            this.btn_YF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_YF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_YF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_YF.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_YF.Image = ((System.Drawing.Image)(resources.GetObject("btn_YF.Image")));
            this.btn_YF.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_YF.Location = new System.Drawing.Point(547, 2);
            this.btn_YF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_YF.Name = "btn_YF";
            this.btn_YF.Size = new System.Drawing.Size(60, 60);
            this.btn_YF.TabIndex = 170;
            this.btn_YF.Text = "-X";
            this.btn_YF.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_YF.UseVisualStyleBackColor = false;
            this.btn_YF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btn_YF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btn_QLZ
            // 
            this.btn_QLZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_QLZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_QLZ.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btn_QLZ.Image = ((System.Drawing.Image)(resources.GetObject("btn_QLZ.Image")));
            this.btn_QLZ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_QLZ.Location = new System.Drawing.Point(480, 66);
            this.btn_QLZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_QLZ.Name = "btn_QLZ";
            this.btn_QLZ.Size = new System.Drawing.Size(72, 51);
            this.btn_QLZ.TabIndex = 204;
            this.btn_QLZ.Text = "+JP";
            this.btn_QLZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_QLZ.UseVisualStyleBackColor = false;
            this.btn_QLZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btn_QLZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btn_QLF
            // 
            this.btn_QLF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_QLF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_QLF.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btn_QLF.Image = ((System.Drawing.Image)(resources.GetObject("btn_QLF.Image")));
            this.btn_QLF.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_QLF.Location = new System.Drawing.Point(600, 66);
            this.btn_QLF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_QLF.Name = "btn_QLF";
            this.btn_QLF.Size = new System.Drawing.Size(66, 51);
            this.btn_QLF.TabIndex = 203;
            this.btn_QLF.Text = "JP-";
            this.btn_QLF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_QLF.UseVisualStyleBackColor = false;
            this.btn_QLF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btn_QLF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button15.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button15.Image = ((System.Drawing.Image)(resources.GetObject("button15.Image")));
            this.button15.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button15.Location = new System.Drawing.Point(791, 88);
            this.button15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(61, 55);
            this.button15.TabIndex = 209;
            this.button15.Text = "+Z1";
            this.button15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button15.UseVisualStyleBackColor = false;
            this.button15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.button15.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button16.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button16.Image = ((System.Drawing.Image)(resources.GetObject("button16.Image")));
            this.button16.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button16.Location = new System.Drawing.Point(791, 29);
            this.button16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(61, 55);
            this.button16.TabIndex = 208;
            this.button16.Text = "-Z1";
            this.button16.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button16.UseVisualStyleBackColor = false;
            this.button16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.button16.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btn_RZ
            // 
            this.btn_RZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_RZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_RZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RZ.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_RZ.Image = ((System.Drawing.Image)(resources.GetObject("btn_RZ.Image")));
            this.btn_RZ.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_RZ.Location = new System.Drawing.Point(704, 29);
            this.btn_RZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_RZ.Name = "btn_RZ";
            this.btn_RZ.Size = new System.Drawing.Size(61, 55);
            this.btn_RZ.TabIndex = 205;
            this.btn_RZ.Text = "-R1";
            this.btn_RZ.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_RZ.UseVisualStyleBackColor = false;
            this.btn_RZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btn_RZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btn_RF
            // 
            this.btn_RF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_RF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RF.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_RF.Image = ((System.Drawing.Image)(resources.GetObject("btn_RF.Image")));
            this.btn_RF.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_RF.Location = new System.Drawing.Point(704, 88);
            this.btn_RF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_RF.Name = "btn_RF";
            this.btn_RF.Size = new System.Drawing.Size(61, 55);
            this.btn_RF.TabIndex = 206;
            this.btn_RF.Text = "+R1";
            this.btn_RF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_RF.UseVisualStyleBackColor = false;
            this.btn_RF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.btn_RF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(490, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 21);
            this.label2.TabIndex = 222;
            this.label2.Text = "X：";
            // 
            // tb_CurXPlace
            // 
            this.tb_CurXPlace.Location = new System.Drawing.Point(548, 296);
            this.tb_CurXPlace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_CurXPlace.Name = "tb_CurXPlace";
            this.tb_CurXPlace.ReadOnly = true;
            this.tb_CurXPlace.Size = new System.Drawing.Size(111, 21);
            this.tb_CurXPlace.TabIndex = 215;
            this.tb_CurXPlace.Text = "0";
            this.tb_CurXPlace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label24.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label24.Location = new System.Drawing.Point(489, 298);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 21);
            this.label24.TabIndex = 218;
            this.label24.Text = "Z1：";
            // 
            // tb_CurYPlace
            // 
            this.tb_CurYPlace.Location = new System.Drawing.Point(547, 273);
            this.tb_CurYPlace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_CurYPlace.Name = "tb_CurYPlace";
            this.tb_CurYPlace.ReadOnly = true;
            this.tb_CurYPlace.Size = new System.Drawing.Size(111, 21);
            this.tb_CurYPlace.TabIndex = 216;
            this.tb_CurYPlace.Text = "0";
            this.tb_CurYPlace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label22.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label22.Location = new System.Drawing.Point(488, 272);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 21);
            this.label22.TabIndex = 217;
            this.label22.Text = "R1：";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(546, 200);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(111, 21);
            this.textBox2.TabIndex = 219;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(548, 248);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(110, 21);
            this.textBox1.TabIndex = 220;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(488, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 21);
            this.label1.TabIndex = 221;
            this.label1.Text = " Y：";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(546, 223);
            this.textBox19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(111, 21);
            this.textBox19.TabIndex = 231;
            this.textBox19.Text = "0";
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label20.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label20.Location = new System.Drawing.Point(488, 225);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 21);
            this.label20.TabIndex = 232;
            this.label20.Text = "JP：";
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button34.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button34.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button34.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button34.Location = new System.Drawing.Point(492, 505);
            this.button34.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(106, 55);
            this.button34.TabIndex = 233;
            this.button34.Text = "参数设定";
            this.button34.UseVisualStyleBackColor = false;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(795, 319);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 46);
            this.button3.TabIndex = 234;
            this.button3.Text = "示教单个点";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(489, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 21);
            this.label3.TabIndex = 243;
            this.label3.Text = "R2：";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(548, 321);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(111, 21);
            this.textBox4.TabIndex = 241;
            this.textBox4.Text = "0";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(548, 344);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(111, 21);
            this.textBox3.TabIndex = 242;
            this.textBox3.Text = "0";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label4.Location = new System.Drawing.Point(489, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 21);
            this.label4.TabIndex = 244;
            this.label4.Text = "Z2：";
            // 
            // PointSet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(915, 578);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button34);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_CurXPlace);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.tb_CurYPlace);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.btn_RZ);
            this.Controls.Add(this.btn_RF);
            this.Controls.Add(this.btn_QLZ);
            this.Controls.Add(this.btn_QLF);
            this.Controls.Add(this.btn_YZ);
            this.Controls.Add(this.btn_YF);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_InspectResult);
            this.Controls.Add(this.cb_SelectProModel);
            this.Controls.Add(this.dgv_ProPoints);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_ExcutePoint);
            this.Controls.Add(this.btn_ClearPro);
            this.Controls.Add(this.btn_SubmitPro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.tb_ProRowNum);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.tb_ProColumnNum);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PointSet";
            this.Text = "PointSet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PointSet_FormClosing);
            this.Shown += new System.EventHandler(this.PointSet_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProPoints)).EndInit();
            this.ProPointsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox tb_InspectResult;
        private System.Windows.Forms.ComboBox cb_SelectProModel;
        private System.Windows.Forms.DataGridView dgv_ProPoints;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_ExcutePoint;
        private System.Windows.Forms.Button btn_ClearPro;
        private System.Windows.Forms.Button btn_SubmitPro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tb_ProRowNum;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tb_ProColumnNum;
        private System.Windows.Forms.Timer timer_io;
        private System.Windows.Forms.ContextMenuStrip ProPointsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsm_GoPoint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsm_SaveAllPoint;
        private System.Windows.Forms.ToolStripMenuItem tsm_ExportData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsm_DeletePoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn PointName;
        private System.Windows.Forms.DataGridViewTextBoxColumn XPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn JPPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn R1Place;
        private System.Windows.Forms.DataGridViewTextBoxColumn YPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模板;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_YZ;
        private System.Windows.Forms.Button btn_YF;
        private System.Windows.Forms.Button btn_QLZ;
        private System.Windows.Forms.Button btn_QLF;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button btn_RZ;
        private System.Windows.Forms.Button btn_RF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_CurXPlace;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tb_CurYPlace;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
    }
}