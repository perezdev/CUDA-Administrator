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
    public partial class MessageControl : UserControl
    {
        Form form = null;

        public enum MessageType
        {
            Success,
            Warn,
            Error
        }

        public MessageControl(Form frm, MessageType type, string message)
        {
            InitializeComponent();

            form = frm;
            picHideMessage.Image = Properties.Resources.remove;

            txtMessage.Text = message;
            this.Dock = DockStyle.Top;

            if (type == MessageType.Success)
            {
                this.BackColor = Color.Green;
                txtMessage.BackColor = Color.Green;
            }
            else if (type == MessageType.Warn)
            {
                this.BackColor = Color.Yellow;
                txtMessage.BackColor = Color.Yellow;
                txtMessage.ForeColor = Color.Black;
            }
            else if (type == MessageType.Error)
            {
                this.BackColor = Color.Red;
                txtMessage.BackColor = Color.Red;
            }
        }

        private void picHideMessage_Click(object sender, EventArgs e)
        {
            if (form != null)
                form.Controls.Remove(this);
        }
    }
}
