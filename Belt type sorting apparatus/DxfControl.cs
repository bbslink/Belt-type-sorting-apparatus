using SXDxf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus
{
    public partial class DxfControl : Form
    {
        List<double> ho_RowList;
        List<double> ho_ColList;

        List<double> ho_RowDist;
        List<double> ho_ColDist;
        List<double> ho_StrightDist;


        string errMsg;
        int[] dxfState;
        int[] hv_order;

        int hv_moveX;
        int hv_moveY;
        double hv_scaleX;
        double hv_scaleY;

       

        public DxfControl()
        {
            InitializeComponent();
        }

       

        private void DxfControl_Load(object sender, EventArgs e)
        {
            numControl1.SetModelSavePathEnable(false);
            numControl1.SetFileDirPath(CommonData.CurProDxf, out errMsg);
           // ReadDxf.ReadOrderFile(CommonData.CurProDxf, out hv_order, out hv_moveX, out hv_moveY, out hv_scaleX, out hv_scaleY, out errMsg);
           // ReadDxf.ReadOneDxf(CommonData.CurProDxf+ "\\" + "model_dxf.dxf", CommonData.CurProDxf, out ho_RowDist, out ho_ColDist, out errMsg);
            ReadDxf.CalcPosDist(ho_RowList, ho_ColList, 0, out ho_RowDist, out ho_ColDist, out ho_StrightDist, out errMsg);       
        }

        private void DxfControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReadDxf.ReadDxfCoordinate(CommonData.CurProDxf, out CommonData.saveData.ho_RowList, out CommonData.saveData.ho_ColList, out errMsg);
            ReadDxf.ReadDistOrder(CommonData.CurProDxf, out CommonData.saveData.ho_RowDist, out CommonData.saveData.ho_ColDist, out CommonData.saveData.ho_StrightDist, out errMsg);
        }
    }
}
