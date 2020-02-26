using Belt_type_sorting_apparatus.CommonClass;
using SXHikCam;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{ 
    public partial class MainForm : Form
    {
        SystemEvents sysEvent = SystemEvents.GetSysEventInstance();
        Point CPoint = new Point();
        IniFiles iniControl = IniFiles.GetiniControl();
        ThreadControl threadControls = ThreadControl.GetThreadControl();
        int i = 0;
        string errMsg;

        #region 功能注册
        /// <summary>
        /// 注册事件
        /// </summary>
        private void MainEventInit()
        {
            sysEvent.showRealInfoEvent += new SystemEvents.showRealInfoEventHandler(RefreshRealInfo);
            sysEvent.setButtonEnableEvent += new SystemEvents.setButtonEnableEventHandler(SetButtonEnable);           
        }

        /// <summary>
        /// 开启/禁用按钮
        /// </summary>
        private void SetButtonEnable(bool BHome, bool BStart, bool BStop, bool BContinue,
         bool BPause,bool BCardSet, bool BVsiSet, bool BProSet, bool BParaSet, bool BAuthorSet, bool BFixSet)
        {
            btn_Home.Invoke(new Action(() =>
            {               
                btn_Home.Enabled = BHome;
                if (BHome)
                {
                    if(sysEvent.buttonHomeEvent==null)
                        sysEvent.buttonHomeEvent += new SystemEvents.ButtonHomeEventHandler(btn_Home_Click);
                }
                else
                    sysEvent.buttonHomeEvent -= new SystemEvents.ButtonHomeEventHandler(btn_Home_Click);
            }));

            btn_Start.Invoke(new Action(() =>
            {
                btn_Start.Enabled = BStart;
                if (BStart)
                {
                    if (sysEvent.buttonStartEvent == null)
                        sysEvent.buttonStartEvent += new SystemEvents.ButtonStartEventHandler(btn_Start_Click);
                }
                else
                    sysEvent.buttonStartEvent -= new SystemEvents.ButtonStartEventHandler(btn_Start_Click);
            }));

            btn_Stop.Invoke(new Action(() =>
            {
                btn_Stop.Enabled = BStop;
                if (BStop)
                {
                    if (sysEvent.buttonStopEvent == null)
                        sysEvent.buttonStopEvent += new SystemEvents.ButtonStopEventHandler(btn_Stop_Click);
                }
                else
                    sysEvent.buttonStopEvent -= new SystemEvents.ButtonStopEventHandler(btn_Stop_Click);
            }));

            btn_Continue.Invoke(new Action(() =>
            {
                btn_Continue.Enabled = BContinue;
                if (BContinue)
                {
                    if (sysEvent.buttonContiuneEvent == null)
                        sysEvent.buttonContiuneEvent += new SystemEvents.ButtonContiuneEventHandler(btn_Continue_Click);
                }
                else
                    sysEvent.buttonContiuneEvent -= new SystemEvents.ButtonContiuneEventHandler(btn_Continue_Click);
            }));

            btn_Pause.Invoke(new Action(() =>
            {
                btn_Pause.Enabled = BPause;
                if (BPause)
                {
                    if (sysEvent.buttonPauseEvent == null)
                        sysEvent.buttonPauseEvent += new SystemEvents.ButtonPauseEventHandler(btn_Pause_Click);
                }
                else
                    sysEvent.buttonPauseEvent -= new SystemEvents.ButtonPauseEventHandler(btn_Pause_Click);
            }));


            if (CommonData.authorization == 1)
            {

                btn_MachineSetting.Invoke(new Action(() =>
                {
                    btn_MachineSetting.Enabled = false;
                }));

                btn_VisionSetting.Invoke(new Action(() =>
                {
                    btn_VisionSetting.Enabled = false;
                }));

                btn_ProSetting.Invoke(new Action(() =>
                {
                    btn_ProSetting.Enabled = BProSet;
                }));
             
                btn_Authorization.Invoke(new Action(() =>
                {
                    btn_Authorization.Enabled = BAuthorSet;
                }));
                btn_Maintenance.Invoke(new Action(() =>
                {
                    btn_Maintenance.Enabled = false;
                }));

                btn_Param.Invoke(new Action(() =>
                {
                    btn_Param.Enabled = BParaSet;
                }));
            }
            else 
            {
                
                btn_MachineSetting.Invoke(new Action(() =>
                {
                    btn_MachineSetting.Enabled = BCardSet;
                }));

                btn_VisionSetting.Invoke(new Action(() =>
                {
                    btn_VisionSetting.Enabled = BVsiSet;
                }));

                btn_ProSetting.Invoke(new Action(() =>
                {
                    btn_ProSetting.Enabled = BProSet;
                }));
                btn_Param.Invoke(new Action(() =>
                {
                    btn_Param.Enabled = BParaSet;
                }));
                btn_Authorization.Invoke(new Action(() =>
                {
                    btn_Authorization.Enabled = BAuthorSet;
                }));
                btn_Maintenance.Invoke(new Action(() =>
                {
                    btn_Maintenance.Enabled = BFixSet;
                }));
            }

        }

        /// <summary>
        /// 实时信息输出
        /// </summary>
        private void RefreshRealInfo(string message, int messLevel)
        {
            try
            {
                switch (messLevel)
                {
                    case CommonData.infoMess:
                        LogHelper.WriteInfoLog(this.GetType(), message);
                        this.rb_Information.Invoke(new Action(() => {
                            this.rb_Information.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff ") + message + "\r\n");
                        }));
                        break;
                    case CommonData.warnMess:
                        LogHelper.WriteErrorLog(this.GetType(), message);
                        this.rb_ErrorInfo.Invoke(new Action(() => {
                            this.rb_ErrorInfo.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff 【警告】") + message + "\r\n");
                        }));
                        tabControl1.Invoke(new Action(() =>
                        {
                            tabControl1.SelectedIndex = 1;
                        }));
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(this.GetType(), ex);
            }
        }

        #endregion

        public MainForm()
        {
            InitializeComponent();
            //初始化事件
            MainEventInit();

            //初始化视觉窗口
            dispControlA.GetWindowHandle(out CommonData.dispControlUp, out errMsg);
            dispControlB.GetWindowHandle(out CommonData.dispControlDown, out errMsg);                 
            CommonData.camAControl = dispControlA;
            CommonData.camBControl = dispControlB;

            //定时器开始计时
            timera.Start();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                timera.Stop();
              
                if (CommonData.signal_SysInitOK == true)
                {
                    //关闭所有线程
                    threadControls.AbortAllThread();

                    //轴停止
                    for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
                    {
                        CardControl.StopOneAxis(axisno, 200);
                    }

                    //关闭电机使能
                    for (ushort axisno = 0; axisno < CommonData.axisNum; axisno++)
                    {
                        CardControl.AxisSet(axisno, 1);
                    }
                    IOMonitor.SetOneOutBit(CommonData.out_ComeMoveEnable, 1);
                    IOMonitor.SetOneOutBit(CommonData.out_LeaveMoveEnable, 1);

                    //关闭电机总电源
                    IOMonitor.SetOneOutBit(CommonData.out_ServoPower, 1);

                    //关闭必要IO
                    CardControl.CloseImpIO();//关闭输出IO

                    //注销委托
                    CommonData.CameraUp.PostFrameEvent -= new SXTisCam.TisCamera.PostFrameEventHandler(ImageProcess.StartActionB);
                    CommonData.CameraDown.PostFrameEvent -= new SXTisCam.TisCamera.PostFrameEventHandler(ImageProcess.StartActionB);
                   
                    //释放相机
                    if (CommonData.CameraUp != null)
                    {
                        CommonData.CameraUp.StopGrabImage(out errMsg);
                        CommonData.CameraUp.CloseCamera(out errMsg);
                    }
                    if (CommonData.CameraDown != null)
                    {
                        CommonData.CameraDown.StopGrabImage(out errMsg);
                        CommonData.CameraDown.CloseCamera(out errMsg);
                    }                 
                    
                }
            
                //关数据库
                if (CommonData.Conn!=null)
                    CommonData.Conn.Close();

                //保存模板文件
                if (!Directory.Exists(Application.StartupPath + "\\product\\" + CommonData.CurProName))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\product\\" + CommonData.CurProName);
                }
                FileHandle.SerializeFile(CommonData.saveData, CommonData.CurProFile);
            }
            catch(Exception ex)
            {
                RefreshRealInfo(ex.Message, CommonData.warnMess);
            }                   
        }  

        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                //窗体可被更改
                Control.CheckForIllegalCrossThreadCalls = false;
                //使能按钮
                SetButtonEnable(false, false, false, false, false, false, false, false, false, false, false);
                //加载产品
                CommonData.CurProName = iniControl.IniReadValue("CurPro", "CurPro");
                //显示产品
                tb_CurProduct.Text = CommonData.CurProName;               
                //开始初始化线程
                threadControls.ReInitThread(2);
                //开始急停线程
                threadControls.ReInitThread(1);

               
            }
            catch(Exception ex)
            {
                RefreshRealInfo(ex.Message, CommonData.warnMess);
            }
           
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
             try
            {
                object obj = new object();

                lock (obj)
                {

                    //检测安全门
                    if (CommonData.signal_SafeEnable)
                    {
                        if (CardControl.CheckMagnet())
                            throw new Exception("安全门打开，请关闭安全门");
                    }

                    if (ThreadControl.goHomeProcesss.IsAlive)
                        throw new Exception("系统在回原点，不要重复按！！");

                    if (CommonData.signal_IsStartNow)
                        throw new Exception("系统已经运行，请停止后再回原点！");

                    //开启回原点线程
                    threadControls.ReInitThread(3);
                }
            }
            catch(Exception ex)
            {
                RefreshRealInfo(ex.Message, CommonData.warnMess);
            }
            
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {

                
                object obj = new object();

                lock (obj)
                {
                    //检测是否回原点
                    if (CommonData.signal_HomeStateNow == false)
                        throw new Exception("系统未回原点！");

                    //检测安全门
                    if (CommonData.signal_SafeEnable)
                    {
                        if (CardControl.CheckMagnet())
                            throw new Exception("安全门打开，请关闭安全门再试");
                    }

                    if (ThreadControl.startProcess.IsAlive)
                        throw new Exception("已经开始程序，不要重复按!");

                    if (CommonData.signal_IsStartNow)
                        throw new Exception("系统已经运行，不要重复按！");

                    Thread.Sleep(10);
                 
                   
                    threadControls.ReInitThread(5);

                    
                }
              
            }
            catch(Exception ex)
            {
                RefreshRealInfo(ex.Message, CommonData.warnMess);
            }      
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                object obj = new object();

                lock (obj)
                {
                    if (MessageBox.Show("是否停止？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                    StopAction.ErrStop();
                }
               
            }
            catch(Exception ex)
            {
                RefreshRealInfo(ex.Message, CommonData.warnMess);
            }
           
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            try
            {
                object obj = new object();

                lock (obj)
                {
                    if (CommonData.signal_IsStartNow)
                    {
                        threadControls.PauseAllThreadWithoutEMIn();
                        SetButtonEnable(false, false, false, true, false, false, false, false, true, false, false);
                        RefreshRealInfo("程序已经暂停，请按启动按钮继续", CommonData.infoMess);
                    }
                    else
                        throw new Exception("程序还未运行，无法暂停！");                                                                                                        

                }
            }
            catch (Exception ex)
            {
                RefreshRealInfo(ex.Message, CommonData.warnMess);
            }
           
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            try
            {
                object obj = new object();

                lock (obj)
                {
                    if (CommonData.signal_IsStartNow)
                    {
                        threadControls.ContiuneAllThreadWithoutEMIn();
                        SetButtonEnable(false, false, true, false, true, false, false, false, true, false, false);
                        RefreshRealInfo("程序已经恢复", CommonData.infoMess);
                    }
                    else
                        throw new Exception("程序未暂停，无法继续！");
                }
            }
            catch (Exception ex)
            {
                RefreshRealInfo(ex.Message, CommonData.warnMess);
            }
        }
     

        private void btn_VisionSetting_Click(object sender, EventArgs e)
        {
            VisionSetting ws = new VisionSetting();
            ws.ShowDialog();
        }

        private void btn_Param_Click(object sender, EventArgs e)
        {
            FlagView d = new FlagView();
            d.Show();
        }

        private void btn_Authorization_Click(object sender, EventArgs e)
        {
            Authorization au = new Authorization();
            au.ShowDialog();
            if (au.DialogResult == DialogResult.OK)
            {
                label3.Text = CommonData.userName;
                label4.Text = CommonData.userRight;
            }
        }

        private void btn_MachineSetting_Click(object sender, EventArgs e)
        {
            if (CommonData.signal_HomeStateNow == false)
            {
                RefreshRealInfo("系统未回原点！请回原点重试", CommonData.warnMess);
                return;
            }
            this.Visible = false;
            MachineStateForm m = new MachineStateForm();
            m.ShowDialog();
            this.Visible = true;
        }

        private void btn_ProSetting_Click(object sender, EventArgs e)
        {
            ProductSet pro = new ProductSet();
            pro.ShowDialog();
        }



        private void btn_SafeEnable_Click(object sender, EventArgs e)
        {
            if (btn_SafeEnable.Text == "打开安全项目")
            {
                btn_SafeEnable.BackColor = Color.Green;
                CommonData.signal_SafeEnable = true;
                btn_SafeEnable.Text = "屏蔽安全项目";
            }
            else
            {
                btn_SafeEnable.BackColor = Color.Red;
                CommonData.signal_SafeEnable = false;
                btn_SafeEnable.Text = "打开安全项目";
            }
        }

        private void timera_Tick(object sender, EventArgs e)
        {
            if (CommonData.signal_SysInitOK)
            {
               
                    txtGoodProducts.Text = CommonData.data_NumberPut.ToString();

                    txtNGProducts.Text = CommonData.data_NGPut.ToString();
                    txtFinished.Text = (CommonData.data_NumberPut + CommonData.data_NGPut).ToString();
                    if (i == 0)
                    {
                        textBox22.Text = CommonData.saveData.commonRow.ToString();
                        textBox27.Text = CommonData.saveData.rowdelta.ToString();
                        textBox28.Text = CommonData.saveData.commonCol.ToString();
                        textBox29.Text = CommonData.saveData.coldelat.ToString();
                        textBox3.Text = CommonData.saveData.depthMax.ToString();
                        textBox2.Text = CommonData.saveData.depthMin.ToString();
                        textBox5.Text = CommonData.saveData.commonAngel.ToString();
                        textBox4.Text = CommonData.saveData.deltaAngel.ToString();
                        i++;
                    }
                
            }
        }

        private void rb_Information_TextChanged(object sender, EventArgs e)
        {
            if (this.rb_Information.Lines.Length > 1000)
            {
                this.rb_Information.Clear();
            }
            this.rb_Information.SelectionStart = this.rb_Information.Text.Length;
            this.rb_Information.ScrollToCaret();
        }

        private void rb_ErrorInfo_TextChanged(object sender, EventArgs e)
        {
            if (this.rb_ErrorInfo.Lines.Length > 1000)
            {
                this.rb_ErrorInfo.Clear();
            }
            this.rb_ErrorInfo.SelectionStart = this.rb_ErrorInfo.Text.Length;
            this.rb_ErrorInfo.ScrollToCaret();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            CommonData.data_NumberPut = 0;
            CommonData.data_NGPut = 0;
        }

        #region 拖动界面设置
        private void MainVision_MouseDown(object sender, MouseEventArgs e)
        {
            CPoint.X = -e.X;
            CPoint.Y = -e.Y;
        }

        private void MainVision_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = Control.MousePosition;//获取当前鼠标的屏幕坐标 
                myPosittion.Offset(CPoint.X, CPoint.Y);//重载当前鼠标的位置 
                this.DesktopLocation = myPosittion;//设置当前窗体在屏幕上的位置 
            }
        }

        #endregion

        private void pbCompanyLog_Click(object sender, EventArgs e)
        {
            AboutRuixiang ab = new AboutRuixiang();
            ab.ShowDialog();
        }

        private void btn_Maintenance_Click(object sender, EventArgs e)
        {
            IOVision io = new IOVision();
            io.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CommonData.saveData.commonRow = Convert.ToDouble(textBox22.Text);
            CommonData.saveData.rowdelta = Convert.ToDouble(textBox27.Text);
            CommonData.saveData.commonCol = Convert.ToDouble(textBox28.Text);
            CommonData.saveData.coldelat = Convert.ToDouble(textBox29.Text);
            CommonData.saveData.depthMax = Convert.ToInt32(textBox3.Text);
            CommonData.saveData.depthMin = Convert.ToInt32(textBox2.Text);
            CommonData.saveData.commonAngel = Convert.ToDouble(textBox5.Text);
            CommonData.saveData.deltaAngel = Convert.ToDouble(textBox4.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DxfControl s = new DxfControl();
            s.Show();
        }
    }
}
