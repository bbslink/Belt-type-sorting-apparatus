using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Belt_type_sorting_apparatus.CommonClass
{
    [Serializable]
    public class PointControl
    {
        string modelName;//模板名称
        public string ModelName
        {
            get { return modelName; }
            set { modelName = value; }
        }

        ArrayList modelPoints;//工作点位
        public ArrayList ModelPoints
        {
            get { return modelPoints; }
            set { modelPoints = value; }
        }

      

        double standMacth = 19;
        public double StandMacth
        {
            get { return standMacth; }
            set { standMacth = value; }
        }

        //检测标识
        public Dictionary<string, FlagTextBox> ModelFlag = new Dictionary<string, FlagTextBox>();
      



    }

    [Serializable]
    public class FlagTextBox
    {
        Size flagBoxSize;
        System.Windows.Forms.HorizontalAlignment flagBoxAlign;
        string flagBoxText;
        string flagBoxName;
        Color flagBoxBackColor;
        Font flagBoxFont;
        int flagBoxLeft;
        int flagBoxTop;

        public FlagTextBox(Size flagboxSize, System.Windows.Forms.HorizontalAlignment flagboxAlign, string flagboxText, string flagboxName,
             Color flagboxBackColor,  int flagboxLeft, int flagboxTop)
        {
            this.flagBoxSize = flagboxSize;
            this.flagBoxAlign = flagboxAlign;
            this.flagBoxText = flagboxText;
            this.flagBoxName = flagboxName;
            this.flagBoxBackColor = flagboxBackColor;
            this.flagBoxLeft = flagboxLeft;
            this.flagBoxTop = flagboxTop;
        }

        public Size FlagBoxSize
        {
            get { return flagBoxSize; }
            set { flagBoxSize = value; }
        }
        public System.Windows.Forms.HorizontalAlignment FlagBoxAlign
        {
            get { return flagBoxAlign; }
            set { flagBoxAlign = value; }
        }
        public string FlagBoxText
        {
            get { return flagBoxText; }
            set { flagBoxText = value; }
        }
        public string FlagBoxName
        {
            get { return flagBoxName; }
            set { flagBoxName = value; }
        }
        public Color FlagBoxBackColor
        {
            get { return flagBoxBackColor; }
            set { flagBoxBackColor = value; }
        }
        public int FlagBoxLeft
        {
            get { return flagBoxLeft; }
            set { flagBoxLeft = value; }
        }
        public int FlagBoxTop
        {
            get { return flagBoxTop; }
            set { flagBoxTop = value; }
        }

    }
}
