using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belt_type_sorting_apparatus.CommonClass
{
    class FlagControl
    {
        static PointControl CurUpCameraFrontModelClass = null;
        static PointControl CurUpCameraBehindModelClass = null;
        static PointControl CurDownCameraFrontModelClass = null;
        static PointControl CurDownCameraBehindModelClass = null;
        static PointControl CurDepthFrontModelClass = null;
        static PointControl CurDepthBehindModelClass = null;

        public static void Show1()
        {
            CommonData.saveData.PointModels.TryGetValue("前载台上相机模板", out CurUpCameraFrontModelClass);
            if (CurUpCameraFrontModelClass.ModelFlag != null && CurUpCameraFrontModelClass.ModelFlag.Count > 0)
            {
                CommonData.flagController1.Invoke(new Action(() =>
                {
                    CommonData.flagController1.Controls.Clear();
                    foreach (FlagTextBox temp in CurUpCameraFrontModelClass.ModelFlag.Values)
                    {
                        TextBox CurFlagBox = new TextBox();
                        CurFlagBox.Size = temp.FlagBoxSize;
                        CurFlagBox.Name = temp.FlagBoxName;
                        CurFlagBox.Text = temp.FlagBoxText;
                        CurFlagBox.BackColor = Color.White;
                        CurFlagBox.Left = temp.FlagBoxLeft;
                        CurFlagBox.Top = temp.FlagBoxTop;
                        CurFlagBox.TextAlign = temp.FlagBoxAlign;
                        CurFlagBox.Enabled = false;
                        CommonData.flagController1.Controls.Add(CurFlagBox);
                    }

                }));

            }

        }


        public static void Show2()
        {
            CommonData.saveData.PointModels.TryGetValue("前载台下相机模板", out CurDownCameraFrontModelClass);
            if (CurDownCameraFrontModelClass.ModelFlag != null && CurDownCameraFrontModelClass.ModelFlag.Count > 0)
            {
                CommonData.flagController2.Invoke(new Action(() =>
                {
                    CommonData.flagController2.Controls.Clear();
                    foreach (FlagTextBox temp in CurDownCameraFrontModelClass.ModelFlag.Values)
                    {
                        TextBox CurFlagBox = new TextBox();
                        CurFlagBox.Size = temp.FlagBoxSize;
                        CurFlagBox.Name = temp.FlagBoxName;
                        CurFlagBox.Text = temp.FlagBoxText;
                        CurFlagBox.BackColor = Color.White;
                        CurFlagBox.Left = temp.FlagBoxLeft;
                        CurFlagBox.Top = temp.FlagBoxTop;
                        CurFlagBox.TextAlign = temp.FlagBoxAlign;
                        CurFlagBox.Enabled = false;
                        CommonData.flagController2.Controls.Add(CurFlagBox);
                    }
                }));
            }
        }

        public static void Show3()
        {
            CommonData.saveData.PointModels.TryGetValue("前载台探高模板", out CurDepthFrontModelClass);
            if (CurDepthFrontModelClass.ModelFlag != null && CurDepthFrontModelClass.ModelFlag.Count > 0)
            {
                CommonData.flagController3.Invoke(new Action(() =>
                {
                    CommonData.flagController3.Controls.Clear();
                    foreach (FlagTextBox temp in CurDepthFrontModelClass.ModelFlag.Values)
                    {
                        TextBox CurFlagBox = new TextBox();
                        CurFlagBox.Size = temp.FlagBoxSize;
                        CurFlagBox.Name = temp.FlagBoxName;
                        CurFlagBox.Text = temp.FlagBoxText;
                        CurFlagBox.BackColor = Color.White;
                        CurFlagBox.Left = temp.FlagBoxLeft;
                        CurFlagBox.Top = temp.FlagBoxTop;
                        CurFlagBox.TextAlign = temp.FlagBoxAlign;
                        CurFlagBox.Enabled = false;
                        CommonData.flagController3.Controls.Add(CurFlagBox);
                    }
                }));
            }
        }

        public static void Show4()
        {
            CommonData.saveData.PointModels.TryGetValue("后载台上相机模板", out CurUpCameraBehindModelClass);
            if (CurUpCameraBehindModelClass.ModelFlag != null && CurUpCameraBehindModelClass.ModelFlag.Count > 0)
            {
                CommonData.flagController4.Invoke(new Action(() =>
                {
                    CommonData.flagController4.Controls.Clear();
                    foreach (FlagTextBox temp in CurUpCameraBehindModelClass.ModelFlag.Values)
                    {
                        TextBox CurFlagBox = new TextBox();
                        CurFlagBox.Size = temp.FlagBoxSize;
                        CurFlagBox.Name = temp.FlagBoxName;
                        CurFlagBox.Text = temp.FlagBoxText;
                        CurFlagBox.BackColor = Color.White;
                        CurFlagBox.Left = temp.FlagBoxLeft;
                        CurFlagBox.Top = temp.FlagBoxTop;
                        CurFlagBox.TextAlign = temp.FlagBoxAlign;
                        CurFlagBox.Enabled = false;
                        CommonData.flagController4.Controls.Add(CurFlagBox);
                    }
                }));
            }
        }

        public static void Show5()
        {
            CommonData.saveData.PointModels.TryGetValue("后载台下相机模板", out CurDownCameraBehindModelClass);
            if (CurDownCameraBehindModelClass.ModelFlag != null && CurDownCameraBehindModelClass.ModelFlag.Count > 0)
            {
                CommonData.flagController5.Invoke(new Action(() =>
                {
                    CommonData.flagController5.Controls.Clear();
                    foreach (FlagTextBox temp in CurDownCameraBehindModelClass.ModelFlag.Values)
                    {
                        TextBox CurFlagBox = new TextBox();
                        CurFlagBox.Size = temp.FlagBoxSize;
                        CurFlagBox.Name = temp.FlagBoxName;
                        CurFlagBox.Text = temp.FlagBoxText;
                        CurFlagBox.BackColor = Color.White;
                        CurFlagBox.Left = temp.FlagBoxLeft;
                        CurFlagBox.Top = temp.FlagBoxTop;
                        CurFlagBox.TextAlign = temp.FlagBoxAlign;
                        CurFlagBox.Enabled = false;
                        CommonData.flagController5.Controls.Add(CurFlagBox);
                    }
                }));
            }
        }

        public static void Show6()
        {
            CommonData.saveData.PointModels.TryGetValue("后载台探高模板", out CurDepthBehindModelClass);
            if (CurDepthBehindModelClass.ModelFlag != null && CurDepthBehindModelClass.ModelFlag.Count > 0)
            {
                CommonData.flagController6.Invoke(new Action(() =>
                {
                    CommonData.flagController6.Controls.Clear();
                    foreach (FlagTextBox temp in CurDepthBehindModelClass.ModelFlag.Values)
                    {
                        TextBox CurFlagBox = new TextBox();
                        CurFlagBox.Size = temp.FlagBoxSize;
                        CurFlagBox.Name = temp.FlagBoxName;
                        CurFlagBox.Text = temp.FlagBoxText;
                        CurFlagBox.BackColor = Color.White;
                        CurFlagBox.Left = temp.FlagBoxLeft;
                        CurFlagBox.Top = temp.FlagBoxTop;
                        CurFlagBox.TextAlign = temp.FlagBoxAlign;
                        CurFlagBox.Enabled = false;
                        CommonData.flagController6.Controls.Add(CurFlagBox);
                    }
                }));
            }
        }


        public static void ReflashBehind()
        {
            CommonData.flagController4.Invoke(new Action(() =>
            {
                foreach (TextBox a in CommonData.flagController4.Controls)
                {
                    a.BackColor = Color.White;
                }

            }));

            CommonData.flagController5.Invoke(new Action(() =>
            {
                foreach (TextBox a in CommonData.flagController5.Controls)
                {
                    a.BackColor = Color.White;
                }

            }));

            CommonData.flagController6.Invoke(new Action(() =>
            {
                foreach (TextBox a in CommonData.flagController6.Controls)
                {
                    a.BackColor = Color.White;
                }

            }));

        }

        public static void ReflashFront()
        {
            CommonData.flagController1.Invoke(new Action(() =>
            {
                foreach (TextBox a in CommonData.flagController1.Controls)
                {
                    a.BackColor = Color.White;
                };

            }));

            CommonData.flagController2.Invoke(new Action(() =>
            {
                foreach (TextBox a in CommonData.flagController2.Controls)
                {
                    a.BackColor = Color.White;
                }

            }));

            CommonData.flagController3.Invoke(new Action(() =>
            {
                foreach (TextBox a in CommonData.flagController3.Controls)
                {
                    a.BackColor = Color.White;
                }

            }));


        }
    }
}
