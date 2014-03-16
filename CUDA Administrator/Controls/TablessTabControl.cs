using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CUDA_Administrator.Controls
{
    public partial class TablessTabControl : TabControl
    {
        public TablessTabControl()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            // Hide tabs by trapping the TCM_ADJUSTRECT message
            if ((m.Msg == 4904))
                m.Result = ((IntPtr)(1));
            else
                base.WndProc(ref m);
        }

    }
}
