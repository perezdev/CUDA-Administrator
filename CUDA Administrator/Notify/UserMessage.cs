using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CUDA_Administrator.Controls;

namespace CUDA_Administrator.Notify
{
    public static class UserMessage
    {
        public enum MessageType
        {
            Success,
            Warning,
            Error
        }

        public static void ShowMessage(Form frm, MessageType type, string message)
        {
            MessageControl msgCtrl = null;

            if (type == MessageType.Success)
            {
                msgCtrl = new MessageControl(frm, MessageControl.MessageType.Success, message);
            }
            else if (type == MessageType.Warning)
            {
                msgCtrl = new MessageControl(frm, MessageControl.MessageType.Warn, message);
            }
            else if (type == MessageType.Error)
            {
                msgCtrl = new MessageControl(frm, MessageControl.MessageType.Error, message);
            }

            frm.Controls.Add(msgCtrl);
        }
    }
}
