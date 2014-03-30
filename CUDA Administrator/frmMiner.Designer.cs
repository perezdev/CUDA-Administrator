namespace CUDA_Administrator
{
    partial class frmMiner
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
            this.lblOldGuid = new System.Windows.Forms.Label();
            this.cbxMiner = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcMiners = new CUDA_Administrator.Controls.TablessTabControl();
            this.tbCudaMiner = new System.Windows.Forms.TabPage();
            this.btnAddEditCudaMiner = new System.Windows.Forms.Button();
            this.chkSingleMemory_CudaMiner = new System.Windows.Forms.CheckBox();
            this.txtBatchsize_CudaMiner = new System.Windows.Forms.TextBox();
            this.chkInteractive_CudaMiner = new System.Windows.Forms.CheckBox();
            this.txtPoolAddress_CudaMiner = new System.Windows.Forms.TextBox();
            this.chkDebug_CudaMiner = new System.Windows.Forms.CheckBox();
            this.txtName_CudaMiner = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtWorkerName_CudaMiner = new System.Windows.Forms.TextBox();
            this.txtLookupGap_CudaMiner = new System.Windows.Forms.MaskedTextBox();
            this.txtWorkerPassword_CudaMiner = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxCpuAssist_CudaMiner = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxTextureCache_CudaMiner = new System.Windows.Forms.ComboBox();
            this.cbxKernel_CudaMiner = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxDevice_CudaMiner = new System.Windows.Forms.ComboBox();
            this.cbxAlgorithm_CudaMiner = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCpuMiner = new System.Windows.Forms.TabPage();
            this.btnAddEditCpuMiner = new System.Windows.Forms.Button();
            this.chkNoStratum_CpuMiner = new System.Windows.Forms.CheckBox();
            this.chkLongPoll_CpuMiner = new System.Windows.Forms.CheckBox();
            this.chkDebug_CpuMiner = new System.Windows.Forms.CheckBox();
            this.txtName_CpuMiner = new System.Windows.Forms.TextBox();
            this.txtPoolAddress_CpuMiner = new System.Windows.Forms.TextBox();
            this.txtWorkerName_CpuMiner = new System.Windows.Forms.TextBox();
            this.txtWorkerPassword_CpuMiner = new System.Windows.Forms.TextBox();
            this.tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.tcMiners.SuspendLayout();
            this.tbCudaMiner.SuspendLayout();
            this.tbCpuMiner.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOldGuid
            // 
            this.lblOldGuid.AutoSize = true;
            this.lblOldGuid.BackColor = System.Drawing.Color.Transparent;
            this.lblOldGuid.ForeColor = System.Drawing.Color.White;
            this.lblOldGuid.Location = new System.Drawing.Point(72, 7);
            this.lblOldGuid.Name = "lblOldGuid";
            this.lblOldGuid.Size = new System.Drawing.Size(34, 13);
            this.lblOldGuid.TabIndex = 26;
            this.lblOldGuid.Text = "GUID";
            this.lblOldGuid.Visible = false;
            // 
            // cbxMiner
            // 
            this.cbxMiner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMiner.FormattingEnabled = true;
            this.cbxMiner.Items.AddRange(new object[] {
            "GPU",
            "CPU"});
            this.cbxMiner.Location = new System.Drawing.Point(4, 4);
            this.cbxMiner.Name = "cbxMiner";
            this.cbxMiner.Size = new System.Drawing.Size(62, 21);
            this.cbxMiner.TabIndex = 27;
            this.cbxMiner.SelectedIndexChanged += new System.EventHandler(this.cbxMiner_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cbxMiner);
            this.panel1.Controls.Add(this.lblOldGuid);
            this.panel1.Controls.Add(this.tcMiners);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 244);
            this.panel1.TabIndex = 29;
            // 
            // tcMiners
            // 
            this.tcMiners.Controls.Add(this.tbCudaMiner);
            this.tcMiners.Controls.Add(this.tbCpuMiner);
            this.tcMiners.Location = new System.Drawing.Point(-2, 24);
            this.tcMiners.Name = "tcMiners";
            this.tcMiners.SelectedIndex = 0;
            this.tcMiners.Size = new System.Drawing.Size(364, 218);
            this.tcMiners.TabIndex = 1;
            // 
            // tbCudaMiner
            // 
            this.tbCudaMiner.BackColor = System.Drawing.Color.Black;
            this.tbCudaMiner.Controls.Add(this.btnAddEditCudaMiner);
            this.tbCudaMiner.Controls.Add(this.chkSingleMemory_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.txtBatchsize_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.chkInteractive_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.txtPoolAddress_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.chkDebug_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.txtName_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.label10);
            this.tbCudaMiner.Controls.Add(this.txtWorkerName_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.txtLookupGap_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.txtWorkerPassword_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.label11);
            this.tbCudaMiner.Controls.Add(this.label2);
            this.tbCudaMiner.Controls.Add(this.label8);
            this.tbCudaMiner.Controls.Add(this.cbxCpuAssist_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.label9);
            this.tbCudaMiner.Controls.Add(this.cbxTextureCache_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.cbxKernel_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.label7);
            this.tbCudaMiner.Controls.Add(this.cbxDevice_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.cbxAlgorithm_CudaMiner);
            this.tbCudaMiner.Controls.Add(this.label6);
            this.tbCudaMiner.Location = new System.Drawing.Point(0, 0);
            this.tbCudaMiner.Name = "tbCudaMiner";
            this.tbCudaMiner.Padding = new System.Windows.Forms.Padding(3);
            this.tbCudaMiner.Size = new System.Drawing.Size(364, 218);
            this.tbCudaMiner.TabIndex = 0;
            this.tbCudaMiner.Text = "tabPage1";
            this.tbCudaMiner.Paint += new System.Windows.Forms.PaintEventHandler(this.Controls_Paint);
            // 
            // btnAddEditCudaMiner
            // 
            this.btnAddEditCudaMiner.ForeColor = System.Drawing.Color.Black;
            this.btnAddEditCudaMiner.Location = new System.Drawing.Point(293, 192);
            this.btnAddEditCudaMiner.Name = "btnAddEditCudaMiner";
            this.btnAddEditCudaMiner.Size = new System.Drawing.Size(68, 23);
            this.btnAddEditCudaMiner.TabIndex = 14;
            this.btnAddEditCudaMiner.Text = "Add Miner";
            this.btnAddEditCudaMiner.UseVisualStyleBackColor = true;
            this.btnAddEditCudaMiner.Click += new System.EventHandler(this.AddEditMiners_Click);
            // 
            // chkSingleMemory_CudaMiner
            // 
            this.chkSingleMemory_CudaMiner.AutoSize = true;
            this.chkSingleMemory_CudaMiner.BackColor = System.Drawing.Color.Transparent;
            this.chkSingleMemory_CudaMiner.ForeColor = System.Drawing.Color.White;
            this.chkSingleMemory_CudaMiner.Location = new System.Drawing.Point(185, 157);
            this.chkSingleMemory_CudaMiner.Name = "chkSingleMemory_CudaMiner";
            this.chkSingleMemory_CudaMiner.Size = new System.Drawing.Size(95, 17);
            this.chkSingleMemory_CudaMiner.TabIndex = 12;
            this.chkSingleMemory_CudaMiner.Text = "Single Memory";
            this.chkSingleMemory_CudaMiner.UseVisualStyleBackColor = false;
            // 
            // txtBatchsize_CudaMiner
            // 
            this.txtBatchsize_CudaMiner.Location = new System.Drawing.Point(262, 95);
            this.txtBatchsize_CudaMiner.Name = "txtBatchsize_CudaMiner";
            this.txtBatchsize_CudaMiner.Size = new System.Drawing.Size(94, 20);
            this.txtBatchsize_CudaMiner.TabIndex = 10;
            this.txtBatchsize_CudaMiner.Text = "1024";
            this.txtBatchsize_CudaMiner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkInteractive_CudaMiner
            // 
            this.chkInteractive_CudaMiner.AutoSize = true;
            this.chkInteractive_CudaMiner.BackColor = System.Drawing.Color.Transparent;
            this.chkInteractive_CudaMiner.ForeColor = System.Drawing.Color.White;
            this.chkInteractive_CudaMiner.Location = new System.Drawing.Point(185, 127);
            this.chkInteractive_CudaMiner.Name = "chkInteractive_CudaMiner";
            this.chkInteractive_CudaMiner.Size = new System.Drawing.Size(76, 17);
            this.chkInteractive_CudaMiner.TabIndex = 11;
            this.chkInteractive_CudaMiner.Text = "Interactive";
            this.chkInteractive_CudaMiner.UseVisualStyleBackColor = false;
            // 
            // txtPoolAddress_CudaMiner
            // 
            this.txtPoolAddress_CudaMiner.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPoolAddress_CudaMiner.Location = new System.Drawing.Point(186, 7);
            this.txtPoolAddress_CudaMiner.Name = "txtPoolAddress_CudaMiner";
            this.txtPoolAddress_CudaMiner.Size = new System.Drawing.Size(173, 20);
            this.txtPoolAddress_CudaMiner.TabIndex = 1;
            this.txtPoolAddress_CudaMiner.Text = "stratum+tcp://pool.of.choice:0000";
            this.txtPoolAddress_CudaMiner.Enter += new System.EventHandler(this.CudaMinerTextControls_Enter);
            this.txtPoolAddress_CudaMiner.Leave += new System.EventHandler(this.CudaMinerTextControls_Leave);
            // 
            // chkDebug_CudaMiner
            // 
            this.chkDebug_CudaMiner.AutoSize = true;
            this.chkDebug_CudaMiner.BackColor = System.Drawing.Color.Transparent;
            this.chkDebug_CudaMiner.ForeColor = System.Drawing.Color.White;
            this.chkDebug_CudaMiner.Location = new System.Drawing.Point(185, 187);
            this.chkDebug_CudaMiner.Name = "chkDebug_CudaMiner";
            this.chkDebug_CudaMiner.Size = new System.Drawing.Size(58, 17);
            this.chkDebug_CudaMiner.TabIndex = 13;
            this.chkDebug_CudaMiner.Text = "Debug";
            this.chkDebug_CudaMiner.UseVisualStyleBackColor = false;
            // 
            // txtName_CudaMiner
            // 
            this.txtName_CudaMiner.ForeColor = System.Drawing.Color.DarkGray;
            this.txtName_CudaMiner.Location = new System.Drawing.Point(5, 7);
            this.txtName_CudaMiner.MaxLength = 40;
            this.txtName_CudaMiner.Name = "txtName_CudaMiner";
            this.txtName_CudaMiner.Size = new System.Drawing.Size(173, 20);
            this.txtName_CudaMiner.TabIndex = 0;
            this.txtName_CudaMiner.Text = "Name";
            this.tipMain.SetToolTip(this.txtName_CudaMiner, "test");
            this.txtName_CudaMiner.Enter += new System.EventHandler(this.CudaMinerTextControls_Enter);
            this.txtName_CudaMiner.Leave += new System.EventHandler(this.CudaMinerTextControls_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(183, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Batchsize:";
            // 
            // txtWorkerName_CudaMiner
            // 
            this.txtWorkerName_CudaMiner.ForeColor = System.Drawing.Color.DarkGray;
            this.txtWorkerName_CudaMiner.Location = new System.Drawing.Point(5, 36);
            this.txtWorkerName_CudaMiner.Name = "txtWorkerName_CudaMiner";
            this.txtWorkerName_CudaMiner.Size = new System.Drawing.Size(173, 20);
            this.txtWorkerName_CudaMiner.TabIndex = 2;
            this.txtWorkerName_CudaMiner.Text = "Worker Name";
            this.txtWorkerName_CudaMiner.Enter += new System.EventHandler(this.CudaMinerTextControls_Enter);
            this.txtWorkerName_CudaMiner.Leave += new System.EventHandler(this.CudaMinerTextControls_Leave);
            // 
            // txtLookupGap_CudaMiner
            // 
            this.txtLookupGap_CudaMiner.Location = new System.Drawing.Point(262, 65);
            this.txtLookupGap_CudaMiner.Mask = "0";
            this.txtLookupGap_CudaMiner.Name = "txtLookupGap_CudaMiner";
            this.txtLookupGap_CudaMiner.Size = new System.Drawing.Size(96, 20);
            this.txtLookupGap_CudaMiner.TabIndex = 9;
            this.txtLookupGap_CudaMiner.Text = "1";
            this.txtLookupGap_CudaMiner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWorkerPassword_CudaMiner
            // 
            this.txtWorkerPassword_CudaMiner.ForeColor = System.Drawing.Color.DarkGray;
            this.txtWorkerPassword_CudaMiner.Location = new System.Drawing.Point(185, 36);
            this.txtWorkerPassword_CudaMiner.Name = "txtWorkerPassword_CudaMiner";
            this.txtWorkerPassword_CudaMiner.Size = new System.Drawing.Size(173, 20);
            this.txtWorkerPassword_CudaMiner.TabIndex = 3;
            this.txtWorkerPassword_CudaMiner.Text = "Worker Password";
            this.txtWorkerPassword_CudaMiner.Enter += new System.EventHandler(this.CudaMinerTextControls_Enter);
            this.txtWorkerPassword_CudaMiner.Leave += new System.EventHandler(this.CudaMinerTextControls_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(3, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Device:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Algorithm:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(183, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Lookup-Gap:";
            // 
            // cbxCpuAssist_CudaMiner
            // 
            this.cbxCpuAssist_CudaMiner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCpuAssist_CudaMiner.FormattingEnabled = true;
            this.cbxCpuAssist_CudaMiner.Items.AddRange(new object[] {
            "None",
            "Multi Threaded",
            "Single Threaded"});
            this.cbxCpuAssist_CudaMiner.Location = new System.Drawing.Point(66, 155);
            this.cbxCpuAssist_CudaMiner.Name = "cbxCpuAssist_CudaMiner";
            this.cbxCpuAssist_CudaMiner.Size = new System.Drawing.Size(112, 21);
            this.cbxCpuAssist_CudaMiner.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Kernel:";
            // 
            // cbxTextureCache_CudaMiner
            // 
            this.cbxTextureCache_CudaMiner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTextureCache_CudaMiner.FormattingEnabled = true;
            this.cbxTextureCache_CudaMiner.Items.AddRange(new object[] {
            "Disabled",
            "1D Cache",
            "2D Cache"});
            this.cbxTextureCache_CudaMiner.Location = new System.Drawing.Point(66, 185);
            this.cbxTextureCache_CudaMiner.Name = "cbxTextureCache_CudaMiner";
            this.cbxTextureCache_CudaMiner.Size = new System.Drawing.Size(112, 21);
            this.cbxTextureCache_CudaMiner.TabIndex = 8;
            // 
            // cbxKernel_CudaMiner
            // 
            this.cbxKernel_CudaMiner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKernel_CudaMiner.FormattingEnabled = true;
            this.cbxKernel_CudaMiner.Items.AddRange(new object[] {
            "Auto",
            "F4x4",
            "F8x16",
            "F14x8",
            "F15x16",
            "F16x8",
            "F16x14",
            "F16x16",
            "F26x12",
            "F28x4",
            "F48x2",
            "K2x10",
            "K3x9",
            "K3x24",
            "K4X32",
            "K4x32",
            "K6x32",
            "K7x32",
            "k7x32",
            "K8x24",
            "k8x32",
            "K8x32",
            "K12x32",
            "K15x32",
            "K16x32",
            "K20x8",
            "K20x32",
            "K50x6",
            "K64x16",
            "K98x2",
            "L6x3",
            "L90x1",
            "T10x24",
            "T12x20",
            "T12x32",
            "T14x24",
            "T15x16",
            "T24x20",
            "T24x24",
            "T29x4",
            "T30x16",
            "X6x1",
            "Y7x32",
            "Y8x32",
            "Y12x16",
            "Z12x24"});
            this.cbxKernel_CudaMiner.Location = new System.Drawing.Point(66, 125);
            this.cbxKernel_CudaMiner.Name = "cbxKernel_CudaMiner";
            this.cbxKernel_CudaMiner.Size = new System.Drawing.Size(112, 21);
            this.cbxKernel_CudaMiner.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Txt Cache:";
            // 
            // cbxDevice_CudaMiner
            // 
            this.cbxDevice_CudaMiner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDevice_CudaMiner.DropDownWidth = 150;
            this.cbxDevice_CudaMiner.FormattingEnabled = true;
            this.cbxDevice_CudaMiner.Location = new System.Drawing.Point(66, 65);
            this.cbxDevice_CudaMiner.Name = "cbxDevice_CudaMiner";
            this.cbxDevice_CudaMiner.Size = new System.Drawing.Size(112, 21);
            this.cbxDevice_CudaMiner.TabIndex = 4;
            // 
            // cbxAlgorithm_CudaMiner
            // 
            this.cbxAlgorithm_CudaMiner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlgorithm_CudaMiner.FormattingEnabled = true;
            this.cbxAlgorithm_CudaMiner.Items.AddRange(new object[] {
            "scrypt",
            "scrypt:N",
            "scrypt-jane:Nfactor",
            "keccak"});
            this.cbxAlgorithm_CudaMiner.Location = new System.Drawing.Point(66, 95);
            this.cbxAlgorithm_CudaMiner.Name = "cbxAlgorithm_CudaMiner";
            this.cbxAlgorithm_CudaMiner.Size = new System.Drawing.Size(112, 21);
            this.cbxAlgorithm_CudaMiner.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "CPU Assist: ";
            // 
            // tbCpuMiner
            // 
            this.tbCpuMiner.BackColor = System.Drawing.Color.Black;
            this.tbCpuMiner.Controls.Add(this.btnAddEditCpuMiner);
            this.tbCpuMiner.Controls.Add(this.chkNoStratum_CpuMiner);
            this.tbCpuMiner.Controls.Add(this.chkLongPoll_CpuMiner);
            this.tbCpuMiner.Controls.Add(this.chkDebug_CpuMiner);
            this.tbCpuMiner.Controls.Add(this.txtName_CpuMiner);
            this.tbCpuMiner.Controls.Add(this.txtPoolAddress_CpuMiner);
            this.tbCpuMiner.Controls.Add(this.txtWorkerName_CpuMiner);
            this.tbCpuMiner.Controls.Add(this.txtWorkerPassword_CpuMiner);
            this.tbCpuMiner.Location = new System.Drawing.Point(0, 0);
            this.tbCpuMiner.Name = "tbCpuMiner";
            this.tbCpuMiner.Padding = new System.Windows.Forms.Padding(3);
            this.tbCpuMiner.Size = new System.Drawing.Size(364, 218);
            this.tbCpuMiner.TabIndex = 1;
            this.tbCpuMiner.Text = "tabPage2";
            this.tbCpuMiner.Paint += new System.Windows.Forms.PaintEventHandler(this.Controls_Paint);
            // 
            // btnAddEditCpuMiner
            // 
            this.btnAddEditCpuMiner.ForeColor = System.Drawing.Color.Black;
            this.btnAddEditCpuMiner.Location = new System.Drawing.Point(290, 189);
            this.btnAddEditCpuMiner.Name = "btnAddEditCpuMiner";
            this.btnAddEditCpuMiner.Size = new System.Drawing.Size(68, 23);
            this.btnAddEditCpuMiner.TabIndex = 7;
            this.btnAddEditCpuMiner.Text = "Add Miner";
            this.btnAddEditCpuMiner.UseVisualStyleBackColor = true;
            this.btnAddEditCpuMiner.Click += new System.EventHandler(this.AddEditMiners_Click);
            // 
            // chkNoStratum_CpuMiner
            // 
            this.chkNoStratum_CpuMiner.AutoSize = true;
            this.chkNoStratum_CpuMiner.BackColor = System.Drawing.Color.Transparent;
            this.chkNoStratum_CpuMiner.Checked = true;
            this.chkNoStratum_CpuMiner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoStratum_CpuMiner.ForeColor = System.Drawing.Color.White;
            this.chkNoStratum_CpuMiner.Location = new System.Drawing.Point(255, 7);
            this.chkNoStratum_CpuMiner.Name = "chkNoStratum_CpuMiner";
            this.chkNoStratum_CpuMiner.Size = new System.Drawing.Size(62, 17);
            this.chkNoStratum_CpuMiner.TabIndex = 5;
            this.chkNoStratum_CpuMiner.Text = "Stratum";
            this.chkNoStratum_CpuMiner.UseVisualStyleBackColor = false;
            // 
            // chkLongPoll_CpuMiner
            // 
            this.chkLongPoll_CpuMiner.AutoSize = true;
            this.chkLongPoll_CpuMiner.BackColor = System.Drawing.Color.Transparent;
            this.chkLongPoll_CpuMiner.Checked = true;
            this.chkLongPoll_CpuMiner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLongPoll_CpuMiner.ForeColor = System.Drawing.Color.White;
            this.chkLongPoll_CpuMiner.Location = new System.Drawing.Point(182, 7);
            this.chkLongPoll_CpuMiner.Name = "chkLongPoll_CpuMiner";
            this.chkLongPoll_CpuMiner.Size = new System.Drawing.Size(67, 17);
            this.chkLongPoll_CpuMiner.TabIndex = 4;
            this.chkLongPoll_CpuMiner.Text = "LongPoll";
            this.chkLongPoll_CpuMiner.UseVisualStyleBackColor = false;
            // 
            // chkDebug_CpuMiner
            // 
            this.chkDebug_CpuMiner.AutoSize = true;
            this.chkDebug_CpuMiner.BackColor = System.Drawing.Color.Transparent;
            this.chkDebug_CpuMiner.ForeColor = System.Drawing.Color.White;
            this.chkDebug_CpuMiner.Location = new System.Drawing.Point(182, 32);
            this.chkDebug_CpuMiner.Name = "chkDebug_CpuMiner";
            this.chkDebug_CpuMiner.Size = new System.Drawing.Size(58, 17);
            this.chkDebug_CpuMiner.TabIndex = 6;
            this.chkDebug_CpuMiner.Text = "Debug";
            this.chkDebug_CpuMiner.UseVisualStyleBackColor = false;
            // 
            // txtName_CpuMiner
            // 
            this.txtName_CpuMiner.ForeColor = System.Drawing.Color.DarkGray;
            this.txtName_CpuMiner.Location = new System.Drawing.Point(7, 4);
            this.txtName_CpuMiner.MaxLength = 40;
            this.txtName_CpuMiner.Name = "txtName_CpuMiner";
            this.txtName_CpuMiner.Size = new System.Drawing.Size(169, 20);
            this.txtName_CpuMiner.TabIndex = 0;
            this.txtName_CpuMiner.Text = "Name";
            this.txtName_CpuMiner.Enter += new System.EventHandler(this.CudaMinerTextControls_Enter);
            this.txtName_CpuMiner.Leave += new System.EventHandler(this.CudaMinerTextControls_Leave);
            // 
            // txtPoolAddress_CpuMiner
            // 
            this.txtPoolAddress_CpuMiner.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPoolAddress_CpuMiner.Location = new System.Drawing.Point(7, 29);
            this.txtPoolAddress_CpuMiner.Name = "txtPoolAddress_CpuMiner";
            this.txtPoolAddress_CpuMiner.Size = new System.Drawing.Size(169, 20);
            this.txtPoolAddress_CpuMiner.TabIndex = 1;
            this.txtPoolAddress_CpuMiner.Text = "stratum+tcp://pool.of.choice:0000";
            this.txtPoolAddress_CpuMiner.Enter += new System.EventHandler(this.CudaMinerTextControls_Enter);
            this.txtPoolAddress_CpuMiner.Leave += new System.EventHandler(this.CudaMinerTextControls_Leave);
            // 
            // txtWorkerName_CpuMiner
            // 
            this.txtWorkerName_CpuMiner.ForeColor = System.Drawing.Color.DarkGray;
            this.txtWorkerName_CpuMiner.Location = new System.Drawing.Point(7, 54);
            this.txtWorkerName_CpuMiner.Name = "txtWorkerName_CpuMiner";
            this.txtWorkerName_CpuMiner.Size = new System.Drawing.Size(169, 20);
            this.txtWorkerName_CpuMiner.TabIndex = 2;
            this.txtWorkerName_CpuMiner.Text = "Worker Name";
            this.txtWorkerName_CpuMiner.Enter += new System.EventHandler(this.CudaMinerTextControls_Enter);
            this.txtWorkerName_CpuMiner.Leave += new System.EventHandler(this.CudaMinerTextControls_Leave);
            // 
            // txtWorkerPassword_CpuMiner
            // 
            this.txtWorkerPassword_CpuMiner.ForeColor = System.Drawing.Color.DarkGray;
            this.txtWorkerPassword_CpuMiner.Location = new System.Drawing.Point(7, 79);
            this.txtWorkerPassword_CpuMiner.Name = "txtWorkerPassword_CpuMiner";
            this.txtWorkerPassword_CpuMiner.Size = new System.Drawing.Size(169, 20);
            this.txtWorkerPassword_CpuMiner.TabIndex = 3;
            this.txtWorkerPassword_CpuMiner.Text = "Worker Password";
            this.txtWorkerPassword_CpuMiner.Enter += new System.EventHandler(this.CudaMinerTextControls_Enter);
            this.txtWorkerPassword_CpuMiner.Leave += new System.EventHandler(this.CudaMinerTextControls_Leave);
            // 
            // tipMain
            // 
            this.tipMain.AutoPopDelay = 32000;
            this.tipMain.InitialDelay = 500;
            this.tipMain.ReshowDelay = 100;
            this.tipMain.ShowAlways = true;
            this.tipMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tipMain.ToolTipTitle = "Info";
            this.tipMain.UseFading = false;
            // 
            // frmMiner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(363, 244);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMiner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Something Miner";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Controls_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tcMiners.ResumeLayout(false);
            this.tbCudaMiner.ResumeLayout(false);
            this.tbCudaMiner.PerformLayout();
            this.tbCpuMiner.ResumeLayout(false);
            this.tbCpuMiner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TablessTabControl tcMiners;
        private System.Windows.Forms.TabPage tbCudaMiner;
        private System.Windows.Forms.Button btnAddEditCudaMiner;
        private System.Windows.Forms.CheckBox chkSingleMemory_CudaMiner;
        private System.Windows.Forms.TextBox txtBatchsize_CudaMiner;
        private System.Windows.Forms.CheckBox chkInteractive_CudaMiner;
        private System.Windows.Forms.TextBox txtPoolAddress_CudaMiner;
        private System.Windows.Forms.CheckBox chkDebug_CudaMiner;
        private System.Windows.Forms.TextBox txtName_CudaMiner;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtWorkerName_CudaMiner;
        private System.Windows.Forms.MaskedTextBox txtLookupGap_CudaMiner;
        private System.Windows.Forms.TextBox txtWorkerPassword_CudaMiner;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxCpuAssist_CudaMiner;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxTextureCache_CudaMiner;
        private System.Windows.Forms.ComboBox cbxKernel_CudaMiner;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxDevice_CudaMiner;
        private System.Windows.Forms.ComboBox cbxAlgorithm_CudaMiner;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tbCpuMiner;
        private System.Windows.Forms.Button btnAddEditCpuMiner;
        private System.Windows.Forms.CheckBox chkNoStratum_CpuMiner;
        private System.Windows.Forms.CheckBox chkLongPoll_CpuMiner;
        private System.Windows.Forms.CheckBox chkDebug_CpuMiner;
        private System.Windows.Forms.TextBox txtName_CpuMiner;
        private System.Windows.Forms.TextBox txtPoolAddress_CpuMiner;
        private System.Windows.Forms.TextBox txtWorkerName_CpuMiner;
        private System.Windows.Forms.TextBox txtWorkerPassword_CpuMiner;
        private System.Windows.Forms.Label lblOldGuid;
        private System.Windows.Forms.ComboBox cbxMiner;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip tipMain;
    }
}