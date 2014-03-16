using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CUDA_Administrator.Calls.Setting;
using UI;

namespace CUDA_Administrator
{
    public partial class frmDonate : Form
    {
        SettingCall settingsCall;

        public frmDonate()
        {
            InitializeComponent();

            settingsCall = new SettingCall();
            this.Icon = settingsCall.GetApplicationIcon();
        }

        private void frmDonate_Paint(object sender, PaintEventArgs e)
        {
            using (HatchBrush h1 = new HatchBrush(HatchStyle.Percent20, BackgroundColors.BackgroundDotsLight, BackgroundColors.BackgroundColor))
            {
                e.Graphics.FillRectangle(h1, e.ClipRectangle);
            }
            using (HatchBrush h2 = new HatchBrush(HatchStyle.Percent20, BackgroundColors.BackgroundDotsDark, Color.Transparent))
            {
                e.Graphics.RenderingOrigin = new Point(0, -1);
                e.Graphics.FillRectangle(h2, e.ClipRectangle);
                e.Graphics.RenderingOrigin = Point.Empty;
            }
        }
    }
}
