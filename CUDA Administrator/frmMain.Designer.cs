namespace CUDA_Administrator
{
    partial class frmMain
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
            UI.Renderers.Vs2010TabControlRenderer vs2010TabControlRenderer1 = new UI.Renderers.Vs2010TabControlRenderer();
            UI.ColorTables.Vs2010DefaultTabControlColorTable vs2010DefaultTabControlColorTable1 = new UI.ColorTables.Vs2010DefaultTabControlColorTable();
            UI.Renderers.Vs2010MenuStripRenderer vs2010MenuStripRenderer1 = new UI.Renderers.Vs2010MenuStripRenderer();
            UI.ColorTables.Vs2010DefaultMenuStripColorTable vs2010DefaultMenuStripColorTable1 = new UI.ColorTables.Vs2010DefaultMenuStripColorTable();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            UI.Renderers.Vs2010ToolStripRenderer vs2010ToolStripRenderer1 = new UI.Renderers.Vs2010ToolStripRenderer();
            UI.ColorTables.Vs2010DefaultToolStripColorTable vs2010DefaultToolStripColorTable1 = new UI.ColorTables.Vs2010DefaultToolStripColorTable();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tcMinerConsoles = new UI.Controls.Vs2010TabControl();
            this.tbDummyConsole = new System.Windows.Forms.TabPage();
            this.msMain = new UI.Controls.Vs2010MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDonate = new System.Windows.Forms.ToolStripMenuItem();
            this.flpHardware = new System.Windows.Forms.FlowLayoutPanel();
            this.gbxMiners = new System.Windows.Forms.GroupBox();
            this.picEditMiner = new System.Windows.Forms.PictureBox();
            this.picAddMiner = new System.Windows.Forms.PictureBox();
            this.dgvMiners = new System.Windows.Forms.DataGridView();
            this.colGUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommandLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFailover = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRetryLimit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.picRefreshMiners = new System.Windows.Forms.PictureBox();
            this.picRemoveMiner = new System.Windows.Forms.PictureBox();
            this.picMoveUpMiner = new System.Windows.Forms.PictureBox();
            this.picMoveDownMiner = new System.Windows.Forms.PictureBox();
            this.tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsMain = new UI.Controls.Vs2010ToolStrip();
            this.btnMinerAutomation = new System.Windows.Forms.ToolStripButton();
            this.btnFanSpeed = new System.Windows.Forms.ToolStripSplitButton();
            this.cbxTemps = new System.Windows.Forms.ToolStripComboBox();
            this.tmrHardwareScan = new System.Windows.Forms.Timer(this.components);
            this.notifyTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.tcMinerConsoles.SuspendLayout();
            this.msMain.SuspendLayout();
            this.gbxMiners.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEditMiner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddMiner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshMiners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemoveMiner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoveUpMiner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoveDownMiner)).BeginInit();
            this.panel1.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMinerConsoles
            // 
            this.tcMinerConsoles.Active = true;
            this.tcMinerConsoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMinerConsoles.Controls.Add(this.tbDummyConsole);
            this.tcMinerConsoles.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tcMinerConsoles.HotTrack = true;
            this.tcMinerConsoles.ItemSize = new System.Drawing.Size(0, 26);
            this.tcMinerConsoles.Location = new System.Drawing.Point(2, 278);
            this.tcMinerConsoles.Name = "tcMinerConsoles";
            vs2010TabControlRenderer1.ColorTable = vs2010DefaultTabControlColorTable1;
            this.tcMinerConsoles.Renderer = vs2010TabControlRenderer1;
            this.tcMinerConsoles.SelectedIndex = 0;
            this.tcMinerConsoles.Size = new System.Drawing.Size(931, 236);
            this.tcMinerConsoles.TabIndex = 0;
            this.tcMinerConsoles.TabTextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // tbDummyConsole
            // 
            this.tbDummyConsole.Location = new System.Drawing.Point(4, 30);
            this.tbDummyConsole.Name = "tbDummyConsole";
            this.tbDummyConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tbDummyConsole.Size = new System.Drawing.Size(923, 202);
            this.tbDummyConsole.TabIndex = 1;
            this.tbDummyConsole.Text = "Console";
            this.tbDummyConsole.UseVisualStyleBackColor = true;
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.tsmiDonate});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            vs2010MenuStripRenderer1.ColorTable = vs2010DefaultMenuStripColorTable1;
            vs2010MenuStripRenderer1.RoundedEdges = true;
            this.msMain.Renderer = vs2010MenuStripRenderer1;
            this.msMain.Size = new System.Drawing.Size(936, 24);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "vs2010MenuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fileToolStripMenuItem.Image = global::CUDA_Administrator.Properties.Resources.file;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // tsmiExit
            // 
            this.tsmiExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(92, 22);
            this.tsmiExit.Text = "E&xit";
            this.tsmiExit.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOptions});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolsToolStripMenuItem.Image = global::CUDA_Administrator.Properties.Resources.tools;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // tsmiOptions
            // 
            this.tsmiOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tsmiOptions.Name = "tsmiOptions";
            this.tsmiOptions.Size = new System.Drawing.Size(116, 22);
            this.tsmiOptions.Text = "&Options";
            this.tsmiOptions.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.helpToolStripMenuItem.Image = global::CUDA_Administrator.Properties.Resources.help;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(116, 22);
            this.tsmiAbout.Text = "&About...";
            this.tsmiAbout.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // tsmiDonate
            // 
            this.tsmiDonate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmiDonate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tsmiDonate.Image = global::CUDA_Administrator.Properties.Resources.donate;
            this.tsmiDonate.Name = "tsmiDonate";
            this.tsmiDonate.Size = new System.Drawing.Size(28, 20);
            this.tsmiDonate.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // flpHardware
            // 
            this.flpHardware.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flpHardware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(21)))), ((int)(((byte)(20)))));
            this.flpHardware.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpHardware.Location = new System.Drawing.Point(468, 520);
            this.flpHardware.Name = "flpHardware";
            this.flpHardware.Size = new System.Drawing.Size(461, 18);
            this.flpHardware.TabIndex = 6;
            // 
            // gbxMiners
            // 
            this.gbxMiners.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxMiners.BackColor = System.Drawing.Color.Transparent;
            this.gbxMiners.Controls.Add(this.picEditMiner);
            this.gbxMiners.Controls.Add(this.picAddMiner);
            this.gbxMiners.Controls.Add(this.dgvMiners);
            this.gbxMiners.Controls.Add(this.picRefreshMiners);
            this.gbxMiners.Controls.Add(this.picRemoveMiner);
            this.gbxMiners.Controls.Add(this.picMoveUpMiner);
            this.gbxMiners.Controls.Add(this.picMoveDownMiner);
            this.gbxMiners.ForeColor = System.Drawing.Color.White;
            this.gbxMiners.Location = new System.Drawing.Point(6, 27);
            this.gbxMiners.Name = "gbxMiners";
            this.gbxMiners.Size = new System.Drawing.Size(927, 245);
            this.gbxMiners.TabIndex = 9;
            this.gbxMiners.TabStop = false;
            this.gbxMiners.Text = "Miners";
            // 
            // picEditMiner
            // 
            this.picEditMiner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picEditMiner.BackColor = System.Drawing.Color.Transparent;
            this.picEditMiner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEditMiner.Enabled = false;
            this.picEditMiner.Image = global::CUDA_Administrator.Properties.Resources.edit;
            this.picEditMiner.Location = new System.Drawing.Point(880, 223);
            this.picEditMiner.Name = "picEditMiner";
            this.picEditMiner.Size = new System.Drawing.Size(16, 16);
            this.picEditMiner.TabIndex = 1;
            this.picEditMiner.TabStop = false;
            this.tipMain.SetToolTip(this.picEditMiner, "Edit selected miner");
            this.picEditMiner.Click += new System.EventHandler(this.MinerActions_Click);
            // 
            // picAddMiner
            // 
            this.picAddMiner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picAddMiner.BackColor = System.Drawing.Color.Transparent;
            this.picAddMiner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddMiner.Image = global::CUDA_Administrator.Properties.Resources.add;
            this.picAddMiner.Location = new System.Drawing.Point(858, 223);
            this.picAddMiner.Name = "picAddMiner";
            this.picAddMiner.Size = new System.Drawing.Size(16, 16);
            this.picAddMiner.TabIndex = 1;
            this.picAddMiner.TabStop = false;
            this.tipMain.SetToolTip(this.picAddMiner, "Add miner");
            this.picAddMiner.Click += new System.EventHandler(this.MinerActions_Click);
            // 
            // dgvMiners
            // 
            this.dgvMiners.AllowUserToAddRows = false;
            this.dgvMiners.AllowUserToDeleteRows = false;
            this.dgvMiners.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMiners.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMiners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMiners.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMiners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMiners.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGUID,
            this.Column1,
            this.colName,
            this.colCommandLine,
            this.colWorkerName,
            this.colActive,
            this.colFailover,
            this.colRetryLimit});
            this.dgvMiners.Location = new System.Drawing.Point(9, 19);
            this.dgvMiners.Name = "dgvMiners";
            this.dgvMiners.RowHeadersVisible = false;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMiners.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMiners.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMiners.Size = new System.Drawing.Size(909, 198);
            this.dgvMiners.TabIndex = 0;
            this.tipMain.SetToolTip(this.dgvMiners, "The miners higher on the list will be used first.\r\nAdditional miners will work as" +
        " failovers if your\r\nprimary miner fails after your specified amount\r\nof tries.");
            this.dgvMiners.SelectionChanged += new System.EventHandler(this.MinerGrids_SelectionChanged);
            // 
            // colGUID
            // 
            this.colGUID.HeaderText = "GUID";
            this.colGUID.Name = "colGUID";
            this.colGUID.ReadOnly = true;
            this.colGUID.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Miner";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colCommandLine
            // 
            this.colCommandLine.HeaderText = "Command Line";
            this.colCommandLine.Name = "colCommandLine";
            this.colCommandLine.ReadOnly = true;
            this.colCommandLine.Width = 515;
            // 
            // colWorkerName
            // 
            this.colWorkerName.HeaderText = "Worker";
            this.colWorkerName.Name = "colWorkerName";
            this.colWorkerName.ReadOnly = true;
            this.colWorkerName.Width = 75;
            // 
            // colActive
            // 
            this.colActive.HeaderText = "Active";
            this.colActive.Name = "colActive";
            this.colActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colActive.Width = 50;
            // 
            // colFailover
            // 
            this.colFailover.HeaderText = "Failover";
            this.colFailover.Name = "colFailover";
            this.colFailover.Width = 50;
            // 
            // colRetryLimit
            // 
            this.colRetryLimit.HeaderText = "Retry Limit";
            this.colRetryLimit.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.colRetryLimit.Name = "colRetryLimit";
            this.colRetryLimit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRetryLimit.Width = 65;
            // 
            // picRefreshMiners
            // 
            this.picRefreshMiners.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picRefreshMiners.BackColor = System.Drawing.Color.Transparent;
            this.picRefreshMiners.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRefreshMiners.Image = global::CUDA_Administrator.Properties.Resources.refresh;
            this.picRefreshMiners.Location = new System.Drawing.Point(9, 223);
            this.picRefreshMiners.Name = "picRefreshMiners";
            this.picRefreshMiners.Size = new System.Drawing.Size(16, 16);
            this.picRefreshMiners.TabIndex = 1;
            this.picRefreshMiners.TabStop = false;
            this.tipMain.SetToolTip(this.picRefreshMiners, "Refresh miners");
            this.picRefreshMiners.Click += new System.EventHandler(this.MinerActions_Click);
            // 
            // picRemoveMiner
            // 
            this.picRemoveMiner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picRemoveMiner.BackColor = System.Drawing.Color.Transparent;
            this.picRemoveMiner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRemoveMiner.Enabled = false;
            this.picRemoveMiner.Image = global::CUDA_Administrator.Properties.Resources.remove;
            this.picRemoveMiner.Location = new System.Drawing.Point(902, 223);
            this.picRemoveMiner.Name = "picRemoveMiner";
            this.picRemoveMiner.Size = new System.Drawing.Size(16, 16);
            this.picRemoveMiner.TabIndex = 1;
            this.picRemoveMiner.TabStop = false;
            this.tipMain.SetToolTip(this.picRemoveMiner, "Remove selected miner from the list");
            this.picRemoveMiner.Click += new System.EventHandler(this.MinerActions_Click);
            // 
            // picMoveUpMiner
            // 
            this.picMoveUpMiner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picMoveUpMiner.BackColor = System.Drawing.Color.Transparent;
            this.picMoveUpMiner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMoveUpMiner.Enabled = false;
            this.picMoveUpMiner.Image = global::CUDA_Administrator.Properties.Resources.moveup;
            this.picMoveUpMiner.Location = new System.Drawing.Point(31, 223);
            this.picMoveUpMiner.Name = "picMoveUpMiner";
            this.picMoveUpMiner.Size = new System.Drawing.Size(16, 16);
            this.picMoveUpMiner.TabIndex = 1;
            this.picMoveUpMiner.TabStop = false;
            this.tipMain.SetToolTip(this.picMoveUpMiner, "Move a selected miner up on the list");
            this.picMoveUpMiner.Click += new System.EventHandler(this.MinerActions_Click);
            // 
            // picMoveDownMiner
            // 
            this.picMoveDownMiner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picMoveDownMiner.BackColor = System.Drawing.Color.Transparent;
            this.picMoveDownMiner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMoveDownMiner.Enabled = false;
            this.picMoveDownMiner.Image = global::CUDA_Administrator.Properties.Resources.movedown;
            this.picMoveDownMiner.Location = new System.Drawing.Point(53, 223);
            this.picMoveDownMiner.Name = "picMoveDownMiner";
            this.picMoveDownMiner.Size = new System.Drawing.Size(16, 16);
            this.picMoveDownMiner.TabIndex = 1;
            this.picMoveDownMiner.TabStop = false;
            this.tipMain.SetToolTip(this.picMoveDownMiner, "Move a selected miner down on the list");
            this.picMoveDownMiner.Click += new System.EventHandler(this.MinerActions_Click);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.flpHardware);
            this.panel1.Controls.Add(this.tsMain);
            this.panel1.Controls.Add(this.msMain);
            this.panel1.Controls.Add(this.tcMinerConsoles);
            this.panel1.Controls.Add(this.gbxMiners);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 540);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Controls_Paint);
            // 
            // tsMain
            // 
            this.tsMain.AutoParentBackColor = false;
            this.tsMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(170)))), ((int)(((byte)(193)))));
            this.tsMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsMain.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMinerAutomation,
            this.btnFanSpeed});
            this.tsMain.Location = new System.Drawing.Point(0, 515);
            this.tsMain.Name = "tsMain";
            vs2010ToolStripRenderer1.ColorTable = vs2010DefaultToolStripColorTable1;
            vs2010ToolStripRenderer1.RoundedEdges = true;
            this.tsMain.Renderer = vs2010ToolStripRenderer1;
            this.tsMain.Size = new System.Drawing.Size(936, 25);
            this.tsMain.TabIndex = 11;
            this.tsMain.Text = "vs2010ToolStrip1";
            // 
            // btnMinerAutomation
            // 
            this.btnMinerAutomation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMinerAutomation.Image = global::CUDA_Administrator.Properties.Resources.start;
            this.btnMinerAutomation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMinerAutomation.Name = "btnMinerAutomation";
            this.btnMinerAutomation.Size = new System.Drawing.Size(23, 22);
            this.btnMinerAutomation.Tag = "STOP";
            this.btnMinerAutomation.Text = "Miner Automation";
            this.btnMinerAutomation.Click += new System.EventHandler(this.MinerAutomation_Click);
            // 
            // btnFanSpeed
            // 
            this.btnFanSpeed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFanSpeed.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbxTemps});
            this.btnFanSpeed.Image = ((System.Drawing.Image)(resources.GetObject("btnFanSpeed.Image")));
            this.btnFanSpeed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFanSpeed.Name = "btnFanSpeed";
            this.btnFanSpeed.Size = new System.Drawing.Size(77, 22);
            this.btnFanSpeed.Text = "Fan Speed";
            // 
            // cbxTemps
            // 
            this.cbxTemps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTemps.Items.AddRange(new object[] {
            "Auto",
            "Default",
            "100%",
            "95%",
            "90%",
            "85%",
            "80",
            "75%",
            "70%",
            "65%",
            "60%",
            "55%",
            "50%",
            "45%",
            "40%",
            "35%",
            "30%",
            "25%",
            "20%",
            "15%",
            "10%",
            "5%"});
            this.cbxTemps.Name = "cbxTemps";
            this.cbxTemps.Size = new System.Drawing.Size(121, 23);
            this.cbxTemps.SelectedIndexChanged += new System.EventHandler(this.cbxTemps_SelectedIndexChanged);
            // 
            // tmrHardwareScan
            // 
            this.tmrHardwareScan.Enabled = true;
            this.tmrHardwareScan.Interval = 1000;
            this.tmrHardwareScan.Tick += new System.EventHandler(this.tmrHardwareScan_Tick);
            // 
            // notifyTray
            // 
            this.notifyTray.Text = "CUDA Administrator";
            this.notifyTray.Visible = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(936, 540);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.msMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CUDA Administrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Controls_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.tcMinerConsoles.ResumeLayout(false);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbxMiners.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEditMiner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddMiner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshMiners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemoveMiner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoveUpMiner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoveDownMiner)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.Vs2010TabControl tcMinerConsoles;
        private UI.Controls.Vs2010MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOptions;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.FlowLayoutPanel flpHardware;
        private System.Windows.Forms.GroupBox gbxMiners;
        private System.Windows.Forms.ToolTip tipMain;
        private System.Windows.Forms.PictureBox picRemoveMiner;
        private System.Windows.Forms.PictureBox picMoveDownMiner;
        private System.Windows.Forms.PictureBox picMoveUpMiner;
        private System.Windows.Forms.TabPage tbDummyConsole;
        private System.Windows.Forms.DataGridView dgvMiners;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer tmrHardwareScan;
        private UI.Controls.Vs2010ToolStrip tsMain;
        private System.Windows.Forms.ToolStripSplitButton btnFanSpeed;
        private System.Windows.Forms.ToolStripButton btnMinerAutomation;
        private System.Windows.Forms.ToolStripComboBox cbxTemps;
        private System.Windows.Forms.NotifyIcon notifyTray;
        private System.Windows.Forms.PictureBox picRefreshMiners;
        private System.Windows.Forms.ToolStripMenuItem tsmiDonate;
        private System.Windows.Forms.PictureBox picEditMiner;
        private System.Windows.Forms.PictureBox picAddMiner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommandLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkerName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActive;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFailover;
        private System.Windows.Forms.DataGridViewComboBoxColumn colRetryLimit;
    }
}

