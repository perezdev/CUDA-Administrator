namespace CUDA_Administrator.Controls
{
    partial class MessageControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picHideMessage = new System.Windows.Forms.PictureBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHideMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // picHideMessage
            // 
            this.picHideMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picHideMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHideMessage.Location = new System.Drawing.Point(395, 4);
            this.picHideMessage.Name = "picHideMessage";
            this.picHideMessage.Size = new System.Drawing.Size(16, 16);
            this.picHideMessage.TabIndex = 2;
            this.picHideMessage.TabStop = false;
            this.picHideMessage.Click += new System.EventHandler(this.picHideMessage_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.Location = new System.Drawing.Point(4, 6);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(385, 13);
            this.txtMessage.TabIndex = 3;
            // 
            // MessageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.picHideMessage);
            this.Name = "MessageControl";
            this.Size = new System.Drawing.Size(416, 24);
            ((System.ComponentModel.ISupportInitialize)(this.picHideMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picHideMessage;
        private System.Windows.Forms.TextBox txtMessage;
    }
}
