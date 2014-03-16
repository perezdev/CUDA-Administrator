using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CUDA_Administrator.Calls.Devices;
using CUDA_Administrator.Calls.Setting;
using CUDA_Administrator.Data.Miner;
using CUDA_Administrator.Data.Setting;
using CUDA_Administrator.Notify;
using UI;

namespace CUDA_Administrator
{
    public partial class frmMiner : Form
    {
        SettingCall settingsCall;
        Settings settings;
        DevicesCall devices;
        Type minerType;
        Guid minerGuid;

        public enum Type
        {
            Add,
            Edit
        }

        public enum Miner
        {
            CPU,
            GPU
        }

        public frmMiner(Type type, Miner miner = Miner.GPU, Guid guid = default(Guid))
        {
            InitializeComponent();
            string strError = string.Empty;

            SetTips();

            devices = new DevicesCall();
            settingsCall = new SettingCall();

            settings = settingsCall.GetSettings(ref strError);
            this.Icon = settingsCall.GetApplicationIcon();

            AddVideoCardsToComboBox();
            ResetAddMinerFields(Miner.GPU);
            ResetAddMinerFields(Miner.CPU);
            cbxMiner.SelectedIndex = 0; //Default to GPU
            minerType = type;
            minerGuid = guid;

            if (type == Type.Add)
            {
                this.Text = "Add Miner";
                btnAddEditCpuMiner.Text = "Add";
            }
            else if (type == Type.Edit)
            {
                if (guid == default(Guid))
                    MessageBox.Show("The user should never see this message.\r\n\r\nEdit was selected, but no GUID was passed.", "Err...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (Debugger.IsAttached)
                        lblOldGuid.Visible = true;

                    txtName_CudaMiner.ForeColor = Color.Black;
                    txtPoolAddress_CudaMiner.ForeColor = Color.Black;
                    txtWorkerName_CudaMiner.ForeColor = Color.Black;
                    txtWorkerPassword_CudaMiner.ForeColor = Color.Black;

                    txtName_CpuMiner.ForeColor = Color.Black;
                    txtPoolAddress_CpuMiner.ForeColor = Color.Black;
                    txtWorkerName_CpuMiner.ForeColor = Color.Black;
                    txtWorkerPassword_CpuMiner.ForeColor = Color.Black;

                    if (miner == Miner.GPU)
                    {
                        tcMiners.SelectedIndex = 0;
                        cbxMiner.SelectedIndex = 0;
                        btnAddEditCudaMiner.Text = "Edit Miner";

                        GpuMinerData selectedMiner = settings.GpuMiners.SingleOrDefault(x => x.MinerGUID == guid);
                        txtName_CudaMiner.Text = selectedMiner.Name;
                        txtPoolAddress_CudaMiner.Text = selectedMiner.PoolAddress;
                        txtWorkerName_CudaMiner.Text = selectedMiner.WorkerName;
                        txtWorkerPassword_CudaMiner.Text = selectedMiner.WorkerPassword;
                        cbxDevice_CudaMiner.SelectedIndex = selectedMiner.Device;
                        cbxAlgorithm_CudaMiner.Text = selectedMiner.Algorithm;
                        cbxCpuAssist_CudaMiner.Text = selectedMiner.CpuAssist;
                        cbxTextureCache_CudaMiner.Text = selectedMiner.TextureCache;
                        txtLookupGap_CudaMiner.Text = selectedMiner.LookupGap.ToString();
                        txtBatchsize_CudaMiner.Text = selectedMiner.Batchsize.ToString();
                        chkInteractive_CudaMiner.Checked = selectedMiner.Interactive;
                        chkSingleMemory_CudaMiner.Checked = selectedMiner.SingleMemory;
                        chkDebug_CudaMiner.Checked = selectedMiner.Debug;
                    }
                    else if (miner == Miner.CPU)
                    {
                        tcMiners.SelectedIndex = 1;
                        cbxMiner.SelectedIndex = 1;
                        btnAddEditCpuMiner.Text = "Edit Miner";

                        CpuMinerData selectedMiner = settings.CpuMiners.SingleOrDefault(x => x.MinerGUID == guid);
                        txtName_CpuMiner.Text = selectedMiner.Name;
                        txtPoolAddress_CpuMiner.Text = selectedMiner.PoolAddress;
                        txtWorkerName_CpuMiner.Text = selectedMiner.WorkerName;
                        txtWorkerPassword_CpuMiner.Text = selectedMiner.WorkerPassword;
                    }

                    cbxMiner.Enabled = false;

                    this.Text = "Edit Miner";
                    btnAddEditCpuMiner.Text = "Edit";

                    lblOldGuid.Text = guid.ToString().ToUpper();
                }
            }
        }

        private void Controls_Paint(object sender, PaintEventArgs e)
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

        private void AddEditMiners_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            string strError = string.Empty;
            try
            {
                settings = settingsCall.GetSettings(ref strError);

                if (btn == btnAddEditCudaMiner)
                {
                    if (cbxDevice_CudaMiner.SelectedIndex == -1) //-1 means that there were no nvidia cards found
                        MessageBox.Show("It appears as if CUDA Admin could not find any nVidia video cards. You can try updating your drivers and/or restarting your PC.", "No Video Card Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        //The only required fields are the pool address, the worker name, and the worker password
                        //A dark gray foreground means that no data has been entered because of the way the textbox logic works
                        if (txtPoolAddress_CudaMiner.ForeColor == Color.DarkGray || txtWorkerName_CudaMiner.ForeColor == Color.DarkGray || txtWorkerPassword_CudaMiner.ForeColor == Color.DarkGray)
                            UserMessage.ShowMessage(this, UserMessage.MessageType.Warning, "Please make enter valid information for the pool address, worker name, and the worker password");
                        else
                        {
                            GpuMinerData data = new GpuMinerData()
                            {
                                Name = txtName_CudaMiner.Text,
                                Retries = 3,
                                Active = false,
                                WorkerName = txtWorkerName_CudaMiner.Text,
                                WorkerPassword = txtWorkerPassword_CudaMiner.Text,
                                PoolAddress = txtPoolAddress_CudaMiner.Text,
                                Device = cbxDevice_CudaMiner.SelectedIndex,
                                Algorithm = cbxAlgorithm_CudaMiner.Text,
                                Kernel = cbxKernel_CudaMiner.Text,
                                CpuAssist = cbxCpuAssist_CudaMiner.Text,
                                TextureCache = cbxTextureCache_CudaMiner.Text,
                                LookupGap = Convert.ToInt32(txtLookupGap_CudaMiner.Text),
                                Batchsize = Convert.ToInt32(txtBatchsize_CudaMiner.Text),
                                Interactive = chkInteractive_CudaMiner.Checked,
                                SingleMemory = chkSingleMemory_CudaMiner.Checked,
                                Debug = chkDebug_CudaMiner.Checked,
                                CommandLine = GetCommandLineString(Miner.GPU)
                            };

                            if (minerType == Type.Edit)
                            {
                                //Get the index of the item to be edited
                                int index = (from GpuMinerData miner in settings.GpuMiners
                                             where miner.MinerGUID == minerGuid
                                             select settings.GpuMiners.IndexOf(miner)).First();
                                //Replace that item
                                settings.GpuMiners[index] = data;
                            }
                            else if (minerType == Type.Add)
                            {
                                settings.GpuMiners.Add(data); //Add the miner to the settings list
                            }

                            settingsCall.SeriliazeSettings(settings); //Serialize all the settings
                            Application.OpenForms.OfType<frmMain>().Single(x => x.Name == "frmMain").AddMinersToDataGridViews(true);

                            this.Close();
                        }
                    }
                }
                else if (btn == btnAddEditCpuMiner)
                {
                    if (txtPoolAddress_CpuMiner.ForeColor == Color.DarkGray || txtWorkerName_CpuMiner.ForeColor == Color.DarkGray || txtWorkerPassword_CpuMiner.ForeColor == Color.DarkGray)
                        UserMessage.ShowMessage(this, UserMessage.MessageType.Warning, "Please make enter valid information for the pool address, worker name, and the worker password");
                    else
                    {
                        CpuMinerData data = new CpuMinerData()
                        {
                            Name = txtName_CpuMiner.Text,
                            Retries = 3,
                            WorkerName = txtWorkerName_CpuMiner.Text,
                            WorkerPassword = txtWorkerPassword_CpuMiner.Text,
                            Active = false,
                            CommandLine = GetCommandLineString(Miner.CPU),
                            LongPoll = chkLongPoll_CpuMiner.Checked,
                            Stratum = chkNoStratum_CpuMiner.Checked,
                            PoolAddress = txtPoolAddress_CpuMiner.Text,
                            Debug = chkDebug_CpuMiner.Checked
                        };
                        if (minerType == Type.Edit)
                        {
                            //Get the index of the item to be edited
                            int index = (from CpuMinerData miner in settings.CpuMiners
                                         where miner.MinerGUID == minerGuid
                                         select settings.CpuMiners.IndexOf(miner)).First();
                            //Replace that item
                            settings.CpuMiners[index] = data;
                        }
                        else if (minerType == Type.Add)
                        {
                            settings.CpuMiners.Add(data); //Add the miner to the settings list
                        }

                        settingsCall.SeriliazeSettings(settings); //Serialize all the settings
                        Application.OpenForms.OfType<frmMain>().Single(x => x.Name == "frmMain").AddMinersToDataGridViews(true);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "An error occurred while trying to add that miner. Error: " + ex.Message);
            }
        }

        #region Private Methods

        private void ResetAddMinerFields(Miner miner)
        {
            if (miner == Miner.GPU)
            {
                txtName_CudaMiner.Text = "Name";
                txtPoolAddress_CudaMiner.Text = "stratum+tcp://pool.of.choice:0000";
                txtWorkerName_CudaMiner.Text = "Worker Name";
                txtWorkerPassword_CudaMiner.Text = "Worker Password";

                txtName_CudaMiner.ForeColor = Color.DarkGray;
                txtPoolAddress_CudaMiner.ForeColor = Color.DarkGray;
                txtWorkerName_CudaMiner.ForeColor = Color.DarkGray;
                txtWorkerPassword_CudaMiner.ForeColor = Color.DarkGray;

                cbxAlgorithm_CudaMiner.SelectedIndex = 0;
                cbxKernel_CudaMiner.SelectedIndex = 0;
                cbxCpuAssist_CudaMiner.SelectedIndex = 0;
                cbxTextureCache_CudaMiner.SelectedIndex = 0;
                cbxDevice_CudaMiner.SelectedIndex = 0;

                txtLookupGap_CudaMiner.Text = "1";
                txtBatchsize_CudaMiner.Text = "1024";

                chkDebug_CudaMiner.Checked = false;
                chkInteractive_CudaMiner.Checked = false;
                chkSingleMemory_CudaMiner.Checked = false;
            }
            else if (miner == Miner.CPU)
            {
                txtName_CpuMiner.Text = "Name";
                txtPoolAddress_CpuMiner.Text = "stratum+tcp://pool.of.choice:0000";
                txtWorkerName_CpuMiner.Text = "Worker Name";
                txtWorkerPassword_CpuMiner.Text = "Worker Password";

                txtName_CpuMiner.ForeColor = Color.DarkGray;
                txtPoolAddress_CpuMiner.ForeColor = Color.DarkGray;
                txtWorkerName_CpuMiner.ForeColor = Color.DarkGray;
                txtWorkerPassword_CpuMiner.ForeColor = Color.DarkGray;

                chkDebug_CpuMiner.Checked = false;
            }
        }
        private string GetCommandLineString(Miner miner)
        {
            string commandLine = string.Empty;

            if (miner == Miner.GPU)
            {
                string CpuAssist = string.Empty;
                if (cbxCpuAssist_CudaMiner.SelectedIndex == 0) //None - offload everything to GPU
                    CpuAssist = "2";
                else if (cbxCpuAssist_CudaMiner.SelectedIndex == 1) //Multi-thread
                    CpuAssist = "1";
                else if (cbxCpuAssist_CudaMiner.SelectedIndex == 2) //Single-thread
                    CpuAssist = "0";

                commandLine =
                    "-o " + txtPoolAddress_CudaMiner.Text + //Pool address
                    " -O " + txtWorkerName_CudaMiner.Text + ":" + txtWorkerPassword_CudaMiner.Text + //Username/Password
                    " -d " + cbxDevice_CudaMiner.SelectedIndex.ToString() + //Device (Video card)
                    " -a " + cbxAlgorithm_CudaMiner.Text + //Algorithm
                    " -l " + cbxKernel_CudaMiner.Text + //Kernel
                    " -H " + CpuAssist + //Hash parallel (CPU Assist)
                    " -C " + cbxTextureCache_CudaMiner.SelectedIndex.ToString() + //Texture cache
                    " -L " + txtLookupGap_CudaMiner.Text + //Lookup Gap
                    " -b " + txtBatchsize_CudaMiner.Text + //Batchsize
                    " -i " + (chkInteractive_CudaMiner.Checked ? "1" : "0") + //Interactive
                    " -m " + (chkSingleMemory_CudaMiner.Checked ? "1" : "0") + //Single Memory
                    (chkDebug_CudaMiner.Checked ? " -D" : ""); //Debug flag
            }
            else if (miner == Miner.CPU)
            {
                commandLine =
                    "-o " + txtPoolAddress_CpuMiner.Text +
                    " -u " + txtWorkerName_CpuMiner.Text +
                    " -p " + txtWorkerPassword_CpuMiner.Text +
                    (chkDebug_CpuMiner.Checked ? " -D" : "") +
                    (!chkLongPoll_CpuMiner.Checked ? " --no-longpoll" : "") +
                    (!chkNoStratum_CpuMiner.Checked ? " --no-stratum" : "");
            }

            return commandLine;
        }
        private void AddVideoCardsToComboBox()
        {
            string strError = string.Empty;
            foreach (var card in devices.GetVideoCards(ref strError))
            {
                if (!string.IsNullOrEmpty(strError))
                    UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "An error occurred while trying to query the video card list");
                else
                    cbxDevice_CudaMiner.Items.Add(card.GPU.Name);
            }
        }
        private void SetTips() //Setting the tool tips during design time was causing UI corruption. Happened like 5 times. So I'm just going with this for now. And by "for now", I mean forever
        {
            tipMain.SetToolTip(txtName_CudaMiner,
                "The name you\'d like to give to this miner. It doesn\'t have to be unique,\r\nbut it\'" +
                "s better if it\'s different from your other miners so there\'s no\r\nconfusion.\r\n\r\n" +
                "Command Line: N/A");
            tipMain.SetToolTip(txtPoolAddress_CudaMiner,"The address of the pool you want to mine.\r\n\r\nCommand Line: -o");
            tipMain.SetToolTip(txtWorkerName_CudaMiner,
                "The name of the worker you\'ve setup on your chosen pool\'s site.\r\n\r\n" +
                "Example: username.workerName\r\n\r\nCommand Line: -O");
            tipMain.SetToolTip(txtWorkerPassword_CudaMiner,
                "The password of the worker you\'ve setup on your chosen pool\'s site.\r\n\r\n" +
                "\r\n\r\nCommand Line: -O");
            tipMain.SetToolTip(cbxDevice_CudaMiner,
                "This is a list of the video cards that CUDA Administrator has detected. Just be sure you\r\n" +
                "don't run multiple miners on the same video card, or your PC will be become unstable and crash." +
                "\r\n\r\nCommand Line: -d");
            tipMain.SetToolTip(cbxAlgorithm_CudaMiner,
                "This is a list of the algorithms that CUDA Miner supports.\r\nThe default is SCRYPT" +
                ", but you should change it to\r\nwhichever algorithm your chosen coin uses.\r\n\r\nCom" +
                "mand Line: -a");
            tipMain.SetToolTip(cbxKernel_CudaMiner,
                "By default, CUDA Miner will auto select the best kernel\r\nfor your card. However, " +
                "it\'s worth trying out different\r\nkernels to see if any other increases your hash" +
                "rate.\r\n\r\nCommand Line: -l");
            tipMain.SetToolTip(cbxCpuAssist_CudaMiner,
                "Determines if the CPU should assist while GPU mining. You should play around with this setting\r\n " +
                "to see how it affects your mining. Enabling it can sometimes decrease your hashrate.\r\n\r\n" +
                "Command Line: -H");
            tipMain.SetToolTip(cbxTextureCache_CudaMiner,
                "List of flags to enable use of the texture cache for reading from the scrypt scra" +
                "tchpad. \r\nCached operation has proven to be slightly faster than noncached opera" +
                "tion on most GPUs.\r\n\r\nCommand Line: -C");
            tipMain.SetToolTip(txtLookupGap_CudaMiner,
                "Values > 1 enable a tradeoff between memory\r\nsavings and extra computation effort" +
                ", in order to\r\nimprove efficiency with high N-factor scrypt-jane\r\ncoins. Default" +
                "s to 1.\r\n\r\nCommand Line: -L");
            tipMain.SetToolTip(txtBatchsize_CudaMiner, "Comma separated list of max. scrypt iterations that\r\n" +
                 "are run in one kernel invocation. Default is 1024. \r\n" +
                 "Best to use powers of 2 here. Increase for better performance in\r\n" +
                 "scrypt-jane with high N-factors. Lower for more interactivity\r\n" +
                 "of your video display especially when using the interactive mode\r\n\r\n" +
                 "Command Line: -b");
            tipMain.SetToolTip(chkInteractive_CudaMiner, 
                "Use this to remove lag at the cost of some hashing performance.\r\nDo not use large " +
                "launch configs for devices that shall run in\r\ninteractive mode - it\'s best to use " +
                "autotune!\r\n\r\nCommand Line: -i");
            tipMain.SetToolTip(chkSingleMemory_CudaMiner,
                "Makes the devices allocate their scrypt scratchpad in a single,\r\n" +
                 "consecutive memory block. On Windows Vista, 7/8 this may lead\r\n" +
                 "to a smaller memory size being used. When using the texture cache\r\n" +
                 "this option is implied.\r\n\r\n" + 
                 "Command Line: -m");
            tipMain.SetToolTip(chkDebug_CudaMiner,
                "Outputs debug values to the console. This adds a lot\r\nof extra text which is " +
                "usually meaningless to most people.\r\n\r\nCommand Line: -D");
        }

        #endregion

        #region Events For The AddMiner controls

        private void CudaMinerTextControls_Enter(object sender, EventArgs e)
        {
            if (minerType == Type.Add)
            {
                TextBox txt = sender as TextBox;

                if (txt == txtWorkerPassword_CudaMiner || txt == txtWorkerPassword_CpuMiner)
                {
                    txt.UseSystemPasswordChar = false;
                    txt.Refresh();
                }

                if (txt.Text == string.Empty || txt.ForeColor == Color.DarkGray)
                {
                    txt.Text = string.Empty;
                    txt.ForeColor = Color.Black;
                }
            }
        }
        private void CudaMinerTextControls_Leave(object sender, EventArgs e)
        {
            if (minerType == Type.Add)
            {
                TextBox txt = sender as TextBox;
                if (txt.Text == string.Empty)
                {
                    txt.ForeColor = Color.DarkGray;
                    if (txt.Name == txtName_CudaMiner.Name || txt.Name == txtName_CpuMiner.Name)
                        txt.Text = "Name";
                    else if (txt.Name == txtPoolAddress_CudaMiner.Name || txt.Name == txtPoolAddress_CpuMiner.Name)
                        txt.Text = "stratum+tcp://pool.of.choice:0000";
                    else if (txt.Name == txtWorkerName_CudaMiner.Name || txt.Name == txtWorkerName_CpuMiner.Name)
                        txt.Text = "Worker Name";
                    else if (txt.Name == txtWorkerPassword_CudaMiner.Name || txt.Name == txtWorkerPassword_CpuMiner.Name)
                        txt.Text = "Worker Password";
                }

                if (txt.Text != string.Empty && txt.ForeColor == Color.Black && (txt == txtWorkerPassword_CudaMiner || txt == txtWorkerPassword_CpuMiner))
                    txt.UseSystemPasswordChar = true;
            }
        }

        #endregion

        private void cbxMiner_SelectedIndexChanged(object sender, EventArgs e)
        {
            tcMiners.SelectedIndex = cbxMiner.SelectedIndex;
        }
    }
}
