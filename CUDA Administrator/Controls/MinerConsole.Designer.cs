namespace CUDA_Administrator.Controls
{
    partial class MinerConsole
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
            this.components = new System.ComponentModel.Container();
            this.tmrTotalRunTime = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrTotalRunTime
            // 
            this.tmrTotalRunTime.Enabled = true;
            this.tmrTotalRunTime.Interval = 1000;
            this.tmrTotalRunTime.Tick += new System.EventHandler(this.tmrTotalRunTime_Tick);
            // 
            // MinerConsole
            // 
            this.Size = new System.Drawing.Size(497, 152);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrTotalRunTime;

    }
}
