namespace CUDA_Administrator
{
    partial class frmOptions
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkRunOnStartup = new System.Windows.Forms.CheckBox();
            this.tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.chkContinuousMinerLogging = new System.Windows.Forms.CheckBox();
            this.bxTempProtection = new System.Windows.Forms.GroupBox();
            this.pnlTempProtectionSettings = new System.Windows.Forms.Panel();
            this.intShutdownMiners = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.intActivateProtection = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkEnableTempProtection = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bxTempProtection.SuspendLayout();
            this.pnlTempProtectionSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intShutdownMiners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intActivateProtection)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(282, 243);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // chkRunOnStartup
            // 
            this.chkRunOnStartup.AutoSize = true;
            this.chkRunOnStartup.BackColor = System.Drawing.Color.Transparent;
            this.chkRunOnStartup.ForeColor = System.Drawing.Color.White;
            this.chkRunOnStartup.Location = new System.Drawing.Point(14, 19);
            this.chkRunOnStartup.Name = "chkRunOnStartup";
            this.chkRunOnStartup.Size = new System.Drawing.Size(98, 17);
            this.chkRunOnStartup.TabIndex = 0;
            this.chkRunOnStartup.Text = "Run on Startup";
            this.tipMain.SetToolTip(this.chkRunOnStartup, "If enabled, CUDA Administrator will open when your PC\r\nstarts and will automatica" +
        "lly start the apps if the\r\nminers are already setup.");
            this.chkRunOnStartup.UseVisualStyleBackColor = false;
            this.chkRunOnStartup.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // tipMain
            // 
            this.tipMain.AutoPopDelay = 32000;
            this.tipMain.InitialDelay = 500;
            this.tipMain.ReshowDelay = 100;
            this.tipMain.ShowAlways = true;
            this.tipMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tipMain.ToolTipTitle = "Info";
            // 
            // chkContinuousMinerLogging
            // 
            this.chkContinuousMinerLogging.AutoSize = true;
            this.chkContinuousMinerLogging.BackColor = System.Drawing.Color.Transparent;
            this.chkContinuousMinerLogging.ForeColor = System.Drawing.Color.White;
            this.chkContinuousMinerLogging.Location = new System.Drawing.Point(14, 19);
            this.chkContinuousMinerLogging.Name = "chkContinuousMinerLogging";
            this.chkContinuousMinerLogging.Size = new System.Drawing.Size(149, 17);
            this.chkContinuousMinerLogging.TabIndex = 0;
            this.chkContinuousMinerLogging.Text = "Continuous Miner Logging";
            this.tipMain.SetToolTip(this.chkContinuousMinerLogging, "This allows each miner instance to continously log its output\r\nto a file.");
            this.chkContinuousMinerLogging.UseVisualStyleBackColor = false;
            this.chkContinuousMinerLogging.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // bxTempProtection
            // 
            this.bxTempProtection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bxTempProtection.BackColor = System.Drawing.Color.Transparent;
            this.bxTempProtection.Controls.Add(this.pnlTempProtectionSettings);
            this.bxTempProtection.Controls.Add(this.chkEnableTempProtection);
            this.bxTempProtection.ForeColor = System.Drawing.Color.White;
            this.bxTempProtection.Location = new System.Drawing.Point(15, 124);
            this.bxTempProtection.Name = "bxTempProtection";
            this.bxTempProtection.Size = new System.Drawing.Size(342, 104);
            this.bxTempProtection.TabIndex = 6;
            this.bxTempProtection.TabStop = false;
            this.bxTempProtection.Text = "Temperature Protection";
            // 
            // pnlTempProtectionSettings
            // 
            this.pnlTempProtectionSettings.Controls.Add(this.intShutdownMiners);
            this.pnlTempProtectionSettings.Controls.Add(this.label2);
            this.pnlTempProtectionSettings.Controls.Add(this.intActivateProtection);
            this.pnlTempProtectionSettings.Controls.Add(this.label1);
            this.pnlTempProtectionSettings.Controls.Add(this.label5);
            this.pnlTempProtectionSettings.Controls.Add(this.label4);
            this.pnlTempProtectionSettings.Location = new System.Drawing.Point(33, 43);
            this.pnlTempProtectionSettings.Name = "pnlTempProtectionSettings";
            this.pnlTempProtectionSettings.Size = new System.Drawing.Size(303, 51);
            this.pnlTempProtectionSettings.TabIndex = 9;
            // 
            // intShutdownMiners
            // 
            this.intShutdownMiners.Location = new System.Drawing.Point(118, 26);
            this.intShutdownMiners.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.intShutdownMiners.Name = "intShutdownMiners";
            this.intShutdownMiners.Size = new System.Drawing.Size(43, 20);
            this.intShutdownMiners.TabIndex = 4;
            this.intShutdownMiners.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.intShutdownMiners.ValueChanged += new System.EventHandler(this.Temps_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Shutdown miners at";
            // 
            // intActivateProtection
            // 
            this.intActivateProtection.Location = new System.Drawing.Point(118, 3);
            this.intActivateProtection.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.intActivateProtection.Name = "intActivateProtection";
            this.intActivateProtection.Size = new System.Drawing.Size(43, 20);
            this.intActivateProtection.TabIndex = 3;
            this.intActivateProtection.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.intActivateProtection.ValueChanged += new System.EventHandler(this.Temps_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "°C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Activate protection at";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "°C";
            // 
            // chkEnableTempProtection
            // 
            this.chkEnableTempProtection.AutoSize = true;
            this.chkEnableTempProtection.BackColor = System.Drawing.Color.Transparent;
            this.chkEnableTempProtection.ForeColor = System.Drawing.Color.White;
            this.chkEnableTempProtection.Location = new System.Drawing.Point(14, 20);
            this.chkEnableTempProtection.Name = "chkEnableTempProtection";
            this.chkEnableTempProtection.Size = new System.Drawing.Size(110, 17);
            this.chkEnableTempProtection.TabIndex = 1;
            this.chkEnableTempProtection.Text = "Enable Protection";
            this.chkEnableTempProtection.UseVisualStyleBackColor = false;
            this.chkEnableTempProtection.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkRunOnStartup);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 45);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Options";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.chkContinuousMinerLogging);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(15, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 45);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Miner Options";
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(369, 278);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bxTempProtection);
            this.Controls.Add(this.btnOK);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmOptions_Paint);
            this.bxTempProtection.ResumeLayout(false);
            this.bxTempProtection.PerformLayout();
            this.pnlTempProtectionSettings.ResumeLayout(false);
            this.pnlTempProtectionSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intShutdownMiners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intActivateProtection)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkRunOnStartup;
        private System.Windows.Forms.ToolTip tipMain;
        private System.Windows.Forms.GroupBox bxTempProtection;
        private System.Windows.Forms.Panel pnlTempProtectionSettings;
        private System.Windows.Forms.NumericUpDown intShutdownMiners;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown intActivateProtection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkEnableTempProtection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkContinuousMinerLogging;
    }
}