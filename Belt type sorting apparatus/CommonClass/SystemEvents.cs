using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belt_type_sorting_apparatus.CommonClass
{
    /// <summary>
    /// 系统中的一系列委托事件
    /// </summary>
    public class SystemEvents
    {
        private static SystemEvents sysEvent;
        /// <summary>
        /// 获取委托事件实例
        /// </summary>
        /// <returns></returns>
        public static SystemEvents GetSysEventInstance()
        {
            if (sysEvent == null)
            {
                sysEvent = new SystemEvents();
            }
            return sysEvent;
        }






        /// <summary>
        /// 刷新当前模板所有检测标识 委托
        /// </summary>
        public delegate void refreshModelFlagsEventHandler();
        public refreshModelFlagsEventHandler refreshModelFlagsEvent;
        /// <summary>
        /// 刷新当前模板所有检测标识 委托
        /// </summary>
        public void refreshModelFlags()
        {
            if (refreshModelFlagsEvent != null)
            {
                refreshModelFlagsEvent();
            }
        }

        /// <summary>
        /// 刷新检测标识 委托
        /// </summary>
        public delegate void refreshTestFlagEventHandler(int whichCount, bool result);
        public refreshTestFlagEventHandler refreshTestFlagEvent;
        public void refreshTestFlag(int whichCount, bool result)
        {
            if (refreshTestFlagEvent != null)
            {
                refreshTestFlagEvent(whichCount, result);
            }
        }

        /// <summary>
        /// 自动运行状态控件使能委托
        /// </summary>
        public delegate void refreshBtnStateEventHandler(int curState);
        public refreshBtnStateEventHandler refreshBtnStateEvent;
        /// <summary>
        /// 自动运行状态控件使能委托
        /// </summary>
        public void refreshBtnState(int curState)
        {
            if (refreshBtnStateEvent != null)
            {
                refreshBtnStateEvent(curState);
            }
        }

        /// <summary>
        /// 告知轴回到原点委托
        /// </summary>
        public delegate void axisHomeOkEventHandler(int axisNo);
        public axisHomeOkEventHandler axisHomeOkEvent;
        /// <summary>
        /// 告知轴回到原点委托
        /// </summary>
        public void axisHomeOk(int axisNo)
        {
            if (axisHomeOkEvent != null)
            {
                axisHomeOkEvent(axisNo);
            }
        }

        /// <summary>
        /// 主窗体显示信息委托
        /// </summary>
        public delegate void showRealInfoEventHandler(string mess, int level);
        public showRealInfoEventHandler showRealInfoEvent;
        /// <summary>
        /// 主窗体显示信息委托
        /// </summary>
        public void showRealInfo(string mess, int level)
        {
            if (showRealInfoEvent != null)
            {
                showRealInfoEvent(mess, level);
            }
        }


        /// <summary>
        /// 主窗体显示检测结果图像委托
        /// </summary>
        public delegate void showRealFrameEventHandler(HImage RealFrame);
        public showRealFrameEventHandler showRealFrameEvent;
        /// <summary>
        /// 主窗体显示检测结果图像委托
        /// </summary>
        public void showRealFrame(HImage RealFrame)
        {
            if (showRealFrameEvent != null)
            {
                showRealFrameEvent(RealFrame);
            }
        }


        /// <summary>
        /// 主窗体显示设备当前状态委托
        /// </summary>
        public delegate void refreshCurStateEventHandler(string mess, Color backColor);
        public refreshCurStateEventHandler refreshCurStateEvent;
        /// <summary>
        /// 主窗体显示设备当前状态委托
        /// </summary>
        public void refreshCurState(string mess, Color backColor)
        {
            if (refreshCurStateEvent != null)
            {
                refreshCurStateEvent(mess, backColor);
            }
        }



        /// <summary>
        /// 设置按钮使能
        /// </summary>
        public delegate void setButtonEnableEventHandler(bool BHome, bool BStart, bool BStop, bool BContinue,
         bool BPause, bool BCardSet, bool BVsiSet, bool BProSet, bool BParaSet, bool BAuthorSet, bool BFixSet);
        public setButtonEnableEventHandler setButtonEnableEvent;
        /// <summary>
        /// 设置按钮使能
        /// </summary>
        public void setButtonEnable(bool BHome, bool BStart, bool BStop, bool BContinue,
         bool BPause, bool BCardSet, bool BVsiSet, bool BProSet, bool BParaSet, bool BAuthorSet, bool BFixSet)
        {
            if (setButtonEnableEvent != null)
            {
                setButtonEnableEvent(BHome, BStart, BStop, BContinue,BPause,  BCardSet,  BVsiSet,  BProSet,  BParaSet,  BAuthorSet, BFixSet);
            }
        }


        /// <summary>
        /// 主窗体进度条更新委托
        /// </summary>
        public delegate void refreshProgressEventHandler(int percent);
        public refreshProgressEventHandler refreshProgressEvent;
        /// <summary>
        /// 主窗体进度条更新委托
        /// </summary>
        public void refreshProgress(int percent)
        {
            if (refreshProgressEvent != null)
            {
                refreshProgressEvent(percent);
            }
        }

        /// <summary>
        /// 显示自动巡检结果轮廓委托
        /// </summary>
        public delegate void refreshInspectResultEventHandler(bool result, string curPos, HTuple xdis, HTuple ydis, HTuple rdis, HObject MarkContours, HObject ProContours);
        public refreshInspectResultEventHandler RefreshInspectResultEvent;
        /// <summary>
        /// 显示自动巡检结果轮廓委托
        /// </summary>
        public void RefreshInspectResult(bool result, string curPos, HTuple xdis, HTuple ydis, HTuple rdis, HObject MarkContours, HObject ProContours)
        {
            if (RefreshInspectResultEvent != null)
            {
                RefreshInspectResultEvent(result, curPos, xdis, ydis, rdis, MarkContours, ProContours);
            }
        }


        /// <summary>
        /// 显示自动运行时检测结果委托
        /// </summary>
        public delegate void refreshRunCheckResultEventHandler(bool result, string curPos, HTuple xdis, HTuple ydis, HTuple rdis, HObject MarkContours, HObject ProContours);
        public refreshRunCheckResultEventHandler refreshRunCheckResultEvent;
        /// <summary>
        /// 显示自动运行时检测结果委托
        /// </summary>
        public void refreshRunCheckResult(bool result, string curPos, HTuple xdis, HTuple ydis, HTuple rdis, HObject MarkContours, HObject ProContours)
        {
            if (refreshRunCheckResultEvent != null)
            {
                refreshRunCheckResultEvent(result, curPos, xdis, ydis, rdis, MarkContours, ProContours);
            }
        }



        /// <summary>
        /// 自动巡检告知巡检完毕委托
        /// </summary>
        public delegate void tellInspectOutEventHandler();
        public tellInspectOutEventHandler tellInspectOutEvent;
        /// <summary>
        /// 自动巡检告知巡检完毕委托
        /// </summary>
        public void TellInspectOut()
        {
            if (tellInspectOutEvent != null)
            {
                tellInspectOutEvent();
            }
        }

        /// <summary>
        /// 自动巡检告知巡检完毕委托
        /// </summary>
        public delegate void RefreshHomeTextEventHandler(string message);
        public RefreshHomeTextEventHandler refreshHomeTextEvent;
        /// <summary>
        /// 自动巡检告知巡检完毕委托
        /// </summary>
        public void RefreshHomeText(string message)
        {
            if (refreshHomeTextEvent != null)
            {
                refreshHomeTextEvent(message);
            }
        }


        /// <summary>
        /// 自动巡检告知巡检完毕委托
        /// </summary>
        public delegate string ReadHomeTextEventHandler();
        public ReadHomeTextEventHandler readHomeTextEvent;
        /// <summary>
        /// 自动巡检告知巡检完毕委托
        /// </summary>
        public string ReadHomeText()
        {
            if (readHomeTextEvent != null)
                return readHomeTextEvent();
            else
                return "";
        }


        public delegate void ButtonHomeEventHandler(object sender, EventArgs e);
        public ButtonHomeEventHandler buttonHomeEvent;

        public void ButtonHome()
        {
            if (buttonHomeEvent != null)
            {
                showRealInfo("按下回原点按钮", CommonData.infoMess);
                buttonHomeEvent(new object(), new EventArgs());
            }
        }

        public delegate void ButtonStartEventHandler(object sender, EventArgs e);
        public ButtonStartEventHandler buttonStartEvent;

        public void ButtonStart()
        {
            if (buttonStartEvent != null)
            {
                showRealInfo("按下开始按钮", CommonData.infoMess);
                buttonStartEvent(new object(), new EventArgs());
            }
        }

        public delegate void ButtonStopEventHandler(object sender, EventArgs e);
        public ButtonStopEventHandler buttonStopEvent;

        public void ButtonStop()
        {
            if (buttonStopEvent != null)
            {
                showRealInfo("按下停止按钮", CommonData.infoMess);
                buttonStopEvent(new object(), new EventArgs());
            }
        }

        public delegate void ButtonPauseEventHandler(object sender, EventArgs e);
        public ButtonPauseEventHandler buttonPauseEvent;

        public void ButtonPause()
        {
            if (buttonPauseEvent != null)
            {
                showRealInfo("按下暂停按钮", CommonData.infoMess);
                buttonPauseEvent(new object(), new EventArgs());
            }
        }

        public delegate void ButtonContiuneEventHandler(object sender, EventArgs e);
        public ButtonContiuneEventHandler buttonContiuneEvent;

        public void ButtonContiune()
        {
            if (buttonContiuneEvent != null)
            {
                showRealInfo("按下继续按钮", CommonData.infoMess);
                buttonContiuneEvent(new object(), new EventArgs());
            }
        }


    }
}
