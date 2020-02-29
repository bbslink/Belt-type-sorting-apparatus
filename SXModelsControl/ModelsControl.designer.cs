namespace SXModelsControl
{
    partial class ModelsControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tb_SaveModelPath = new System.Windows.Forms.TextBox();
            this.btn_SaveModelPath = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_DelModel = new System.Windows.Forms.Button();
            this.btn_NewModel = new System.Windows.Forms.Button();
            this.tb_AllModels = new System.Windows.Forms.ListBox();
            this.tb_NewModel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cb_CurCamera = new System.Windows.Forms.ComboBox();
            this.btn_GoSaveData = new System.Windows.Forms.Button();
            this.btn_SnapShot = new System.Windows.Forms.Button();
            this.tb_RealInfo = new System.Windows.Forms.RichTextBox();
            this.cb_CurModels = new System.Windows.Forms.ComboBox();
            this.tb_NumLevel = new System.Windows.Forms.NumericUpDown();
            this.tb_MatchNum = new System.Windows.Forms.NumericUpDown();
            this.tb_Greediness = new System.Windows.Forms.NumericUpDown();
            this.tb_MinScore = new System.Windows.Forms.NumericUpDown();
            this.tb_MinThreshold = new System.Windows.Forms.NumericUpDown();
            this.tb_AngleExtent = new System.Windows.Forms.NumericUpDown();
            this.tb_AngleStart = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SaveROIs = new System.Windows.Forms.Button();
            this.btn_TestModelActive = new System.Windows.Forms.Button();
            this.btn_TestModelLoad = new System.Windows.Forms.Button();
            this.btn_CreateModel = new System.Windows.Forms.Button();
            this.btn_MaskModel = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_ToOrder = new System.Windows.Forms.Button();
            this.btn_RemoveOrder = new System.Windows.Forms.Button();
            this.tb_ModelsOrder = new System.Windows.Forms.ListBox();
            this.btn_ResetOrder = new System.Windows.Forms.Button();
            this.btn_SaveData = new System.Windows.Forms.Button();
            this.tb_ModelsNoOrder = new System.Windows.Forms.ListBox();
            this.dispControl1 = new SXDispControl.DispControl();
            this.btn_SaveROI = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_NumLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MatchNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Greediness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MinScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MinThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AngleExtent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AngleStart)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(482, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 562);
            this.panel1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(330, 562);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.tb_SaveModelPath);
            this.tabPage2.Controls.Add(this.btn_SaveModelPath);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btn_DelModel);
            this.tabPage2.Controls.Add(this.btn_NewModel);
            this.tabPage2.Controls.Add(this.tb_AllModels);
            this.tabPage2.Controls.Add(this.tb_NewModel);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(322, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "创建模板";
            // 
            // tb_SaveModelPath
            // 
            this.tb_SaveModelPath.Location = new System.Drawing.Point(115, 17);
            this.tb_SaveModelPath.Name = "tb_SaveModelPath";
            this.tb_SaveModelPath.ReadOnly = true;
            this.tb_SaveModelPath.Size = new System.Drawing.Size(132, 23);
            this.tb_SaveModelPath.TabIndex = 33;
            // 
            // btn_SaveModelPath
            // 
            this.btn_SaveModelPath.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SaveModelPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveModelPath.Location = new System.Drawing.Point(253, 17);
            this.btn_SaveModelPath.Name = "btn_SaveModelPath";
            this.btn_SaveModelPath.Size = new System.Drawing.Size(54, 27);
            this.btn_SaveModelPath.TabIndex = 32;
            this.btn_SaveModelPath.Text = "浏览";
            this.btn_SaveModelPath.UseVisualStyleBackColor = false;
            this.btn_SaveModelPath.Click += new System.EventHandler(this.btn_SaveModelPath_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 31;
            this.label4.Text = "模板路径：";
            // 
            // btn_DelModel
            // 
            this.btn_DelModel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_DelModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DelModel.Location = new System.Drawing.Point(17, 352);
            this.btn_DelModel.Name = "btn_DelModel";
            this.btn_DelModel.Size = new System.Drawing.Size(290, 45);
            this.btn_DelModel.TabIndex = 11;
            this.btn_DelModel.Text = "删除模板";
            this.btn_DelModel.UseVisualStyleBackColor = false;
            this.btn_DelModel.Click += new System.EventHandler(this.btn_DelModel_Click);
            // 
            // btn_NewModel
            // 
            this.btn_NewModel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_NewModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_NewModel.Location = new System.Drawing.Point(17, 301);
            this.btn_NewModel.Name = "btn_NewModel";
            this.btn_NewModel.Size = new System.Drawing.Size(290, 45);
            this.btn_NewModel.TabIndex = 11;
            this.btn_NewModel.Text = "新建模板";
            this.btn_NewModel.UseVisualStyleBackColor = false;
            this.btn_NewModel.Click += new System.EventHandler(this.btn_NewModel_Click);
            // 
            // tb_AllModels
            // 
            this.tb_AllModels.FormattingEnabled = true;
            this.tb_AllModels.Location = new System.Drawing.Point(17, 155);
            this.tb_AllModels.Name = "tb_AllModels";
            this.tb_AllModels.Size = new System.Drawing.Size(290, 134);
            this.tb_AllModels.TabIndex = 2;
            // 
            // tb_NewModel
            // 
            this.tb_NewModel.Location = new System.Drawing.Point(17, 85);
            this.tb_NewModel.Name = "tb_NewModel";
            this.tb_NewModel.Size = new System.Drawing.Size(290, 23);
            this.tb_NewModel.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "所有模板：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "新模板名称：";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.btn_SaveROI);
            this.tabPage1.Controls.Add(this.cb_CurCamera);
            this.tabPage1.Controls.Add(this.btn_GoSaveData);
            this.tabPage1.Controls.Add(this.btn_SnapShot);
            this.tabPage1.Controls.Add(this.tb_RealInfo);
            this.tabPage1.Controls.Add(this.cb_CurModels);
            this.tabPage1.Controls.Add(this.tb_NumLevel);
            this.tabPage1.Controls.Add(this.tb_MatchNum);
            this.tabPage1.Controls.Add(this.tb_Greediness);
            this.tabPage1.Controls.Add(this.tb_MinScore);
            this.tabPage1.Controls.Add(this.tb_MinThreshold);
            this.tabPage1.Controls.Add(this.tb_AngleExtent);
            this.tabPage1.Controls.Add(this.tb_AngleStart);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btn_SaveROIs);
            this.tabPage1.Controls.Add(this.btn_TestModelActive);
            this.tabPage1.Controls.Add(this.btn_TestModelLoad);
            this.tabPage1.Controls.Add(this.btn_CreateModel);
            this.tabPage1.Controls.Add(this.btn_MaskModel);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(322, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "模板参数";
            // 
            // cb_CurCamera
            // 
            this.cb_CurCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CurCamera.FormattingEnabled = true;
            this.cb_CurCamera.Location = new System.Drawing.Point(146, 243);
            this.cb_CurCamera.Name = "cb_CurCamera";
            this.cb_CurCamera.Size = new System.Drawing.Size(166, 21);
            this.cb_CurCamera.TabIndex = 37;
            // 
            // btn_GoSaveData
            // 
            this.btn_GoSaveData.BackColor = System.Drawing.SystemColors.Control;
            this.btn_GoSaveData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_GoSaveData.Location = new System.Drawing.Point(169, 383);
            this.btn_GoSaveData.Name = "btn_GoSaveData";
            this.btn_GoSaveData.Size = new System.Drawing.Size(145, 45);
            this.btn_GoSaveData.TabIndex = 36;
            this.btn_GoSaveData.Text = "保存数据";
            this.btn_GoSaveData.UseVisualStyleBackColor = false;
            this.btn_GoSaveData.Click += new System.EventHandler(this.btn_GoSaveData_Click);
            // 
            // btn_SnapShot
            // 
            this.btn_SnapShot.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SnapShot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SnapShot.Location = new System.Drawing.Point(16, 383);
            this.btn_SnapShot.Name = "btn_SnapShot";
            this.btn_SnapShot.Size = new System.Drawing.Size(145, 45);
            this.btn_SnapShot.TabIndex = 36;
            this.btn_SnapShot.Text = "触发拍照";
            this.btn_SnapShot.UseVisualStyleBackColor = false;
            this.btn_SnapShot.Click += new System.EventHandler(this.btn_SnapShot_Click);
            // 
            // tb_RealInfo
            // 
            this.tb_RealInfo.Location = new System.Drawing.Point(16, 432);
            this.tb_RealInfo.Name = "tb_RealInfo";
            this.tb_RealInfo.Size = new System.Drawing.Size(296, 93);
            this.tb_RealInfo.TabIndex = 35;
            this.tb_RealInfo.Text = "";
            // 
            // cb_CurModels
            // 
            this.cb_CurModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CurModels.FormattingEnabled = true;
            this.cb_CurModels.Location = new System.Drawing.Point(146, 4);
            this.cb_CurModels.Name = "cb_CurModels";
            this.cb_CurModels.Size = new System.Drawing.Size(166, 21);
            this.cb_CurModels.TabIndex = 34;
            this.cb_CurModels.SelectedIndexChanged += new System.EventHandler(this.cb_CurModels_SelectedIndexChanged);
            // 
            // tb_NumLevel
            // 
            this.tb_NumLevel.Location = new System.Drawing.Point(146, 182);
            this.tb_NumLevel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tb_NumLevel.Name = "tb_NumLevel";
            this.tb_NumLevel.Size = new System.Drawing.Size(166, 23);
            this.tb_NumLevel.TabIndex = 25;
            this.tb_NumLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_MatchNum
            // 
            this.tb_MatchNum.Location = new System.Drawing.Point(146, 212);
            this.tb_MatchNum.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.tb_MatchNum.Name = "tb_MatchNum";
            this.tb_MatchNum.Size = new System.Drawing.Size(166, 23);
            this.tb_MatchNum.TabIndex = 25;
            this.tb_MatchNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_MatchNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tb_Greediness
            // 
            this.tb_Greediness.DecimalPlaces = 2;
            this.tb_Greediness.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.tb_Greediness.Location = new System.Drawing.Point(146, 152);
            this.tb_Greediness.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tb_Greediness.Name = "tb_Greediness";
            this.tb_Greediness.Size = new System.Drawing.Size(166, 23);
            this.tb_Greediness.TabIndex = 24;
            this.tb_Greediness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Greediness.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // tb_MinScore
            // 
            this.tb_MinScore.DecimalPlaces = 2;
            this.tb_MinScore.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.tb_MinScore.Location = new System.Drawing.Point(146, 122);
            this.tb_MinScore.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tb_MinScore.Name = "tb_MinScore";
            this.tb_MinScore.Size = new System.Drawing.Size(166, 23);
            this.tb_MinScore.TabIndex = 24;
            this.tb_MinScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_MinScore.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // tb_MinThreshold
            // 
            this.tb_MinThreshold.Location = new System.Drawing.Point(146, 92);
            this.tb_MinThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.tb_MinThreshold.Name = "tb_MinThreshold";
            this.tb_MinThreshold.Size = new System.Drawing.Size(166, 23);
            this.tb_MinThreshold.TabIndex = 23;
            this.tb_MinThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_MinThreshold.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tb_AngleExtent
            // 
            this.tb_AngleExtent.Location = new System.Drawing.Point(146, 62);
            this.tb_AngleExtent.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.tb_AngleExtent.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.tb_AngleExtent.Name = "tb_AngleExtent";
            this.tb_AngleExtent.Size = new System.Drawing.Size(166, 23);
            this.tb_AngleExtent.TabIndex = 21;
            this.tb_AngleExtent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_AngleExtent.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            // 
            // tb_AngleStart
            // 
            this.tb_AngleStart.Location = new System.Drawing.Point(146, 32);
            this.tb_AngleStart.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.tb_AngleStart.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.tb_AngleStart.Name = "tb_AngleStart";
            this.tb_AngleStart.Size = new System.Drawing.Size(166, 23);
            this.tb_AngleStart.TabIndex = 22;
            this.tb_AngleStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 18;
            this.label6.Text = "金字塔：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "贪婪度：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 18;
            this.label7.Text = "相机列表：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 18;
            this.label9.Text = "匹配数量：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "相似度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "最小色差：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "角度范围：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 12;
            this.label10.Text = "当前模板：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "起始角度：";
            // 
            // btn_SaveROIs
            // 
            this.btn_SaveROIs.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SaveROIs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveROIs.Location = new System.Drawing.Point(16, 282);
            this.btn_SaveROIs.Name = "btn_SaveROIs";
            this.btn_SaveROIs.Size = new System.Drawing.Size(83, 45);
            this.btn_SaveROIs.TabIndex = 10;
            this.btn_SaveROIs.Text = "保存ROI";
            this.btn_SaveROIs.UseVisualStyleBackColor = false;
            this.btn_SaveROIs.Click += new System.EventHandler(this.btn_SaveROIs_Click);
            // 
            // btn_TestModelActive
            // 
            this.btn_TestModelActive.BackColor = System.Drawing.SystemColors.Control;
            this.btn_TestModelActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TestModelActive.Location = new System.Drawing.Point(244, 333);
            this.btn_TestModelActive.Name = "btn_TestModelActive";
            this.btn_TestModelActive.Size = new System.Drawing.Size(70, 45);
            this.btn_TestModelActive.TabIndex = 9;
            this.btn_TestModelActive.Text = "激活测";
            this.btn_TestModelActive.UseVisualStyleBackColor = false;
            this.btn_TestModelActive.Click += new System.EventHandler(this.btn_TestModelActive_Click);
            // 
            // btn_TestModelLoad
            // 
            this.btn_TestModelLoad.BackColor = System.Drawing.SystemColors.Control;
            this.btn_TestModelLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TestModelLoad.Location = new System.Drawing.Point(169, 333);
            this.btn_TestModelLoad.Name = "btn_TestModelLoad";
            this.btn_TestModelLoad.Size = new System.Drawing.Size(70, 45);
            this.btn_TestModelLoad.TabIndex = 9;
            this.btn_TestModelLoad.Text = "加载测";
            this.btn_TestModelLoad.UseVisualStyleBackColor = false;
            this.btn_TestModelLoad.Click += new System.EventHandler(this.btn_TestModelLoad_Click);
            // 
            // btn_CreateModel
            // 
            this.btn_CreateModel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_CreateModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CreateModel.Location = new System.Drawing.Point(16, 333);
            this.btn_CreateModel.Name = "btn_CreateModel";
            this.btn_CreateModel.Size = new System.Drawing.Size(145, 45);
            this.btn_CreateModel.TabIndex = 11;
            this.btn_CreateModel.Text = "模板训练";
            this.btn_CreateModel.UseVisualStyleBackColor = false;
            this.btn_CreateModel.Click += new System.EventHandler(this.btn_CreateModel_Click);
            // 
            // btn_MaskModel
            // 
            this.btn_MaskModel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_MaskModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MaskModel.Location = new System.Drawing.Point(169, 282);
            this.btn_MaskModel.Name = "btn_MaskModel";
            this.btn_MaskModel.Size = new System.Drawing.Size(143, 45);
            this.btn_MaskModel.TabIndex = 7;
            this.btn_MaskModel.Text = "模板掩膜";
            this.btn_MaskModel.UseVisualStyleBackColor = false;
            this.btn_MaskModel.Click += new System.EventHandler(this.btn_MaskModel_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.btn_ToOrder);
            this.tabPage3.Controls.Add(this.btn_RemoveOrder);
            this.tabPage3.Controls.Add(this.tb_ModelsOrder);
            this.tabPage3.Controls.Add(this.btn_ResetOrder);
            this.tabPage3.Controls.Add(this.btn_SaveData);
            this.tabPage3.Controls.Add(this.tb_ModelsNoOrder);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(322, 535);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "模板顺序";
            // 
            // btn_ToOrder
            // 
            this.btn_ToOrder.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ToOrder.Location = new System.Drawing.Point(100, 159);
            this.btn_ToOrder.Name = "btn_ToOrder";
            this.btn_ToOrder.Size = new System.Drawing.Size(49, 36);
            this.btn_ToOrder.TabIndex = 11;
            this.btn_ToOrder.Text = "∨";
            this.btn_ToOrder.UseVisualStyleBackColor = true;
            this.btn_ToOrder.Click += new System.EventHandler(this.btn_ToOrder_Click);
            // 
            // btn_RemoveOrder
            // 
            this.btn_RemoveOrder.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.btn_RemoveOrder.Location = new System.Drawing.Point(165, 159);
            this.btn_RemoveOrder.Name = "btn_RemoveOrder";
            this.btn_RemoveOrder.Size = new System.Drawing.Size(49, 36);
            this.btn_RemoveOrder.TabIndex = 11;
            this.btn_RemoveOrder.Text = "∧";
            this.btn_RemoveOrder.UseVisualStyleBackColor = true;
            this.btn_RemoveOrder.Click += new System.EventHandler(this.btn_RemoveOrder_Click);
            // 
            // tb_ModelsOrder
            // 
            this.tb_ModelsOrder.FormattingEnabled = true;
            this.tb_ModelsOrder.Location = new System.Drawing.Point(4, 208);
            this.tb_ModelsOrder.Name = "tb_ModelsOrder";
            this.tb_ModelsOrder.Size = new System.Drawing.Size(313, 134);
            this.tb_ModelsOrder.TabIndex = 10;
            // 
            // btn_ResetOrder
            // 
            this.btn_ResetOrder.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ResetOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ResetOrder.Location = new System.Drawing.Point(6, 361);
            this.btn_ResetOrder.Name = "btn_ResetOrder";
            this.btn_ResetOrder.Size = new System.Drawing.Size(152, 45);
            this.btn_ResetOrder.TabIndex = 9;
            this.btn_ResetOrder.Text = "重置顺序";
            this.btn_ResetOrder.UseVisualStyleBackColor = false;
            this.btn_ResetOrder.Click += new System.EventHandler(this.btn_ResetOrder_Click);
            // 
            // btn_SaveData
            // 
            this.btn_SaveData.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SaveData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveData.Location = new System.Drawing.Point(165, 361);
            this.btn_SaveData.Name = "btn_SaveData";
            this.btn_SaveData.Size = new System.Drawing.Size(152, 45);
            this.btn_SaveData.TabIndex = 9;
            this.btn_SaveData.Text = "保存数据";
            this.btn_SaveData.UseVisualStyleBackColor = false;
            this.btn_SaveData.Click += new System.EventHandler(this.btn_SaveData_Click);
            // 
            // tb_ModelsNoOrder
            // 
            this.tb_ModelsNoOrder.FormattingEnabled = true;
            this.tb_ModelsNoOrder.Location = new System.Drawing.Point(4, 6);
            this.tb_ModelsNoOrder.Name = "tb_ModelsNoOrder";
            this.tb_ModelsNoOrder.Size = new System.Drawing.Size(313, 134);
            this.tb_ModelsNoOrder.TabIndex = 0;
            // 
            // dispControl1
            // 
            this.dispControl1.BackColor = System.Drawing.Color.Black;
            this.dispControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dispControl1.Location = new System.Drawing.Point(0, 0);
            this.dispControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dispControl1.Name = "dispControl1";
            this.dispControl1.Size = new System.Drawing.Size(482, 562);
            this.dispControl1.TabIndex = 5;
            // 
            // btn_SaveROI
            // 
            this.btn_SaveROI.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SaveROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveROI.Location = new System.Drawing.Point(105, 282);
            this.btn_SaveROI.Name = "btn_SaveROI";
            this.btn_SaveROI.Size = new System.Drawing.Size(56, 45);
            this.btn_SaveROI.TabIndex = 38;
            this.btn_SaveROI.Text = "保存ROI";
            this.btn_SaveROI.UseVisualStyleBackColor = false;
            this.btn_SaveROI.Click += new System.EventHandler(this.btn_SaveROI_Click);
            // 
            // ModelsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dispControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.Name = "ModelsControl";
            this.Size = new System.Drawing.Size(812, 562);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_NumLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MatchNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Greediness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MinScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MinThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AngleExtent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AngleStart)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown tb_MatchNum;
        private System.Windows.Forms.NumericUpDown tb_MinScore;
        private System.Windows.Forms.NumericUpDown tb_MinThreshold;
        private System.Windows.Forms.NumericUpDown tb_AngleExtent;
        private System.Windows.Forms.NumericUpDown tb_AngleStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_TestModelLoad;
        private System.Windows.Forms.Button btn_CreateModel;
        private System.Windows.Forms.Button btn_MaskModel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cb_CurModels;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_NewModel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox tb_AllModels;
        private System.Windows.Forms.Button btn_NewModel;
        private System.Windows.Forms.Button btn_DelModel;
        private System.Windows.Forms.TextBox tb_SaveModelPath;
        private System.Windows.Forms.Button btn_SaveModelPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox tb_ModelsNoOrder;
        private System.Windows.Forms.Button btn_SaveData;
        private System.Windows.Forms.ListBox tb_ModelsOrder;
        private System.Windows.Forms.Button btn_RemoveOrder;
        private System.Windows.Forms.Button btn_ToOrder;
        private System.Windows.Forms.Button btn_ResetOrder;
        private System.Windows.Forms.NumericUpDown tb_Greediness;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox tb_RealInfo;
        private System.Windows.Forms.Button btn_SnapShot;
        private System.Windows.Forms.Button btn_GoSaveData;
        private System.Windows.Forms.Button btn_TestModelActive;
        private System.Windows.Forms.NumericUpDown tb_NumLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_CurCamera;
        private SXDispControl.DispControl dispControl1;
        private System.Windows.Forms.Button btn_SaveROIs;
        private System.Windows.Forms.Button btn_SaveROI;
    }
}
