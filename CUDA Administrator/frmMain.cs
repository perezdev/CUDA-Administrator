using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using UI;
using ThreadSafeExtensions;
using CUDA_Administrator.Notify;
using CUDA_Administrator.Calls.Setting;
using CUDA_Administrator.Data.Setting;
using CUDA_Administrator.Data.Miner;
using CUDA_Administrator.Controls;
using CUDA_Administrator.Nvidia_API.Hardware.Nvidia;
using CUDA_Administrator.Data.Devices;
using CUDA_Administrator.Calls.Devices;
using CUDA_Administrator.Miscellaneous;
using OpenHardwareMonitor.Hardware;
using System.Threading;
using CUDA_Administrator.Calls.ScheduleTasks;
using CUDA_Administrator.Calls.Miner;

namespace CUDA_Administrator
{
    public partial class frmMain : Form
    {
        SettingCall settingsCall;
        Settings settings;
        DevicesCall devices;
        Computer comp;
        MinerCall miner;

        int TemperatureRun = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        #region Form Events

        private void frmMain_Load(object sender, EventArgs e)
        {
            string strError = string.Empty;

            ScheduleTask.CreateNewTask();
            //ScheduleTask.RunTask();

            //Initialize Calls and data
            settingsCall = new SettingCall();
            settings = new Settings();
            devices = new DevicesCall();
            comp = new Computer();
            miner = new MinerCall();

            if (miner.IsMinersRunning())
                if (MessageBox.Show("CUDA Administrator detected that there are CPU or GPU miners already running. Do you want to shutdown these miners now?",
                    "Miners Running", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    miner.ShutdownMiners();

            bool isNewVersion = settingsCall.IsNewVersionAvailable(ref strError);
            if (!string.IsNullOrEmpty(strError))
            {
                UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "There was an error while trying to check for the latest version of CUDA Administrator. Error: " + strError);
                strError = string.Empty;
            }
            else
            {
                if (isNewVersion)
                    if (MessageBox.Show("A new version of CUDA Administrator is available. Would you like to go to the subreddit?", "Verion Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        Process.Start("http://www.reddit.com/r/CudaAdministrator");
            }

            this.Icon = settingsCall.GetApplicationIcon();

            comp.Open();
            comp.CPUEnabled = true;

            //Set UI data
            AddMinersToDataGridViews();

            //Setup everything required to run CUDA Admin
            settingsCall.CreateFolders(ref strError);
            if (!string.IsNullOrEmpty(strError))
            {
                MessageBox.Show(strError, "Folder Creation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(Environment.ExitCode);
            }

            if (!File.Exists(FileManager.CudaMinerPath + "cudaminer.exe") || !File.Exists(FileManager.CudaMinerPath + "pthreadVC2.dll") || !(File.Exists(FileManager.CudaMinerPath + "cudart64_55.dll") || File.Exists(FileManager.CudaMinerPath + "cudart32_55.dll")))
                UserMessage.ShowMessage(this, UserMessage.MessageType.Warning, "GPU Miner disabled. Either it or some/all of it's dependencies couldn't be located");
            if (!File.Exists(FileManager.CpuMinerPath + "minerd.exe") || !File.Exists(FileManager.CpuMinerPath + "libwinpthread-1.dll") || !(File.Exists(FileManager.CpuMinerPath + "libcurl.dll") || File.Exists(FileManager.CpuMinerPath + "libcurl-4.dll")))
                UserMessage.ShowMessage(this, UserMessage.MessageType.Warning, "CPU Miner disabled. Either it or some/all of it's dependencies couldn't be located");

            settings = settingsCall.GetSettings(ref strError);
            if (!string.IsNullOrEmpty(strError))
                UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "An error occurred while trying to get the settings data. Error: " + strError);

            string[] args = Environment.GetCommandLineArgs();
            if (args.Contains("--autorun"))
                btnMinerAutomation.PerformClick();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close CUDA Administrator? All miner processes will be shutdown.", "Close Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string strError = string.Empty;

                //Save any changes prior to closing
                SaveMinerSettings(ref strError);
                if (!string.IsNullOrEmpty(strError))
                {
                    UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "An error occurred while trying to save the settings data. Error: " + strError);
                    e.Cancel = true;
                }
                else
                {
                    //Stop all timers
                    tmrHardwareScan.Stop();

                    //Close hardware monitors gracefully
                    comp.Close();

                    //Shutdown all miners
                    miner.ShutdownMiners();

                    //Reset all fans back to their auto settings
                    foreach (VideoCard card in devices.GetVideoCards(ref strError))
                        foreach (var sensor in card.FanSensors)
                            sensor.Control.SetAuto();

                    //Kills all open threads, just in case
                    Process.GetCurrentProcess().Kill();
                }
            }
            else
            {
                e.Cancel = true;
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

        #endregion

        #region Enums

        public enum Miner
        {
            GPU,
            CPU
        }

        #endregion

        #region Public Methods

        public void AddMinersToDataGridViews(bool isRefresh = false)
        {
            string strError = string.Empty;

            settings = settingsCall.GetSettings(ref strError);

            if (!string.IsNullOrEmpty(strError))
                UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "An error occurred while trying to read the settings.dat file. Error: " + strError);
            else
            {
                if (isRefresh)
                    dgvMiners.Rows.Clear();

                if (settings.GpuMiners.Count > 0)
                {
                    foreach (var miner in settings.GpuMiners)
                        if (!DoesMinerExist(Miner.GPU, miner.MinerGUID.ToString()))
                            dgvMiners.Rows.Add(miner.MinerGUID.ToString(), "GPU",
                                miner.Name, miner.CommandLine, miner.WorkerName, miner.Active.ToString(), miner.Failover.ToString(), miner.Retries.ToString());
                }

                if (settings.CpuMiners.Count > 0)
                {
                    foreach (var miner in settings.CpuMiners)
                        if (!DoesMinerExist(Miner.CPU, miner.MinerGUID.ToString()))
                            dgvMiners.Rows.Add(miner.MinerGUID.ToString(), "CPU",
                                miner.Name, miner.CommandLine, miner.WorkerName, miner.Active.ToString(), miner.Failover.ToString(), miner.Retries.ToString());
                }
            }
        }
        public void ChangeMinerTabText(string oldName, string newName)
        {
            foreach (TabPage tb in tcMinerConsoles.TabPages)
                if (tb.Text == oldName)
                    tb.Text = newName;
        }

        #endregion

        #region Private Methods

        private bool DoesMinerExist(Miner miner, string guid)
        {
            bool exist = false;

            if (miner == Miner.GPU)
            {
                foreach (DataGridViewRow row in dgvMiners.Rows)
                    if (row.Cells[0].Value.ToString() == guid)
                        exist = true;
            }

            return exist;
        }
        private bool SaveMinerSettings(ref string strError)
        {
            bool save = false;

            settings = settingsCall.GetSettings(ref strError);

            if (!string.IsNullOrEmpty(strError))
                UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "An error occurred while trying to read the settings.dat file. Error: " + strError);
            else
            {
                try
                {
                    foreach (DataGridViewRow row in dgvMiners.Rows)
                    {
                        foreach (GpuMinerData data in settings.GpuMiners)
                        {
                            if (data.MinerGUID.ToString().ToUpper() == row.Cells[0].Value.ToString().ToUpper())
                            {
                                data.Name = row.Cells[2].Value.ToString();
                                data.Active = Convert.ToBoolean(row.Cells[5].Value.ToString());
                                data.Failover = Convert.ToBoolean(row.Cells[6].Value.ToString());
                                data.Retries = Convert.ToInt32(row.Cells[7].Value.ToString());
                            }
                        }
                        foreach (CpuMinerData data in settings.CpuMiners)
                        {
                            if (data.MinerGUID.ToString().ToUpper() == row.Cells[0].Value.ToString().ToUpper())
                            {
                                data.Name = row.Cells[2].Value.ToString();
                                data.Active = Convert.ToBoolean(row.Cells[5].Value.ToString());
                                data.Failover = Convert.ToBoolean(row.Cells[6].Value.ToString());
                                data.Retries = Convert.ToInt32(row.Cells[7].Value.ToString());
                            }
                        }
                    }

                    settingsCall.SeriliazeSettings(settings);
                    save = true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }
            }

            return save;
        }
        private void GetHardware()
        {
            string strError = string.Empty;
            settings = settingsCall.GetSettings(ref strError);

            foreach (GpuTemp gpu in devices.GetGpuTemps())
            {
                int temp = Convert.ToInt32(gpu.Temperature);
                Color clr = Color.White;
                if (temp < 70)
                    clr = Color.Green;
                else if (temp >= 70 && temp < 90)
                    clr = Color.Orange;
                else if (temp >= 90)
                    clr = Color.Red;

                if (flpHardware.Controls.Count > 0)
                {
                    foreach (Control ctrl in flpHardware.Controls)
                        if (ctrl.Name == gpu.Name + "_TEMP")
                        {
                            ctrl.Text = temp.ToString() + " °C";
                            ctrl.ForeColor = clr;
                        }
                }
                else
                {
                    Label lblGPU = new Label() { Name = gpu.Name, Text = gpu.Name, ForeColor = Color.White, AutoSize = true };
                    Label lblTemp = new Label() { Name = gpu.Name + "_TEMP", Text = temp.ToString() + " °C", ForeColor = clr, AutoSize = true };

                    flpHardware.Controls.Add(lblTemp);
                    flpHardware.Controls.Add(lblGPU);
                }
            }
            
            foreach (VideoCard card in devices.GetVideoCards(ref strError))
            {
                foreach (var sensor in card.FanSensors)
                {
                    btnFanSpeed.Text = "Fan Speed: " + sensor.Value.ToString() + "%";

                    if (settings.Options.IsTempProtectionActivated)
                    {
                        if (TemperatureRun > 0)
                            TemperatureRun++;

                        if (card.TemperatureSensors[0].Value >= settings.Options.TemperatureMax)
                        {
                            this.InvokeThreadSafeMethod(() => SendNotificationToTray("Temperature Protection", "Temperature threshold reached. The Fan will run at 100% for 3 minutes and then run at 50%."));
                            if (TemperatureRun == 0)
                                TemperatureRun++; //We only increment here once so it kicks off the initial check

                            sensor.Control.SetSoftware(100);
                        }
                        else if (!settings.Options.IsTempProtectionActivated || card.TemperatureSensors[0].Value < settings.Options.TemperatureMax && TemperatureRun >= 180)  //180 = 3 minutes. Let the fan run for 3 minutes
                        {
                            TemperatureRun = 0;
                            sensor.Control.SetSoftware(50);
                        }
                    }
                }
            }
            
            foreach (var hrdwre in comp.Hardware)
            {
                if (hrdwre.HardwareType == HardwareType.CPU)
                {
                    hrdwre.Update();
                    foreach (var sensor in hrdwre.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature && sensor.Name == "CPU Package")
                        {
                            bool shouldAdd = true;

                            float? temp = sensor.Value;
                            Color clr = Color.White;
                            if (temp < 70)
                                clr = Color.Green;
                            else if (temp >= 70 && temp < 90)
                                clr = Color.Orange;
                            else if (temp >= 90)
                                clr = Color.Red;

                            foreach (Control ctrl in flpHardware.Controls)
                            {
                                if (ctrl.Name == hrdwre.Name + "_TEMP")
                                {
                                    ctrl.Text = temp.ToString() + " °C";
                                    ctrl.ForeColor = clr;
                                    shouldAdd = false;
                                }
                            }

                            if (shouldAdd)
                            {
                                Label lblCPU_Name = new Label() { Name = hrdwre.Name, Text = hrdwre.Name, ForeColor = Color.White, AutoSize = true };
                                Label lblCPU_Temp = new Label() { Name = hrdwre.Name + "_TEMP", Text = sensor.Value.ToString() + "°C", ForeColor = clr, AutoSize = true };

                                flpHardware.Controls.Add(lblCPU_Temp);
                                flpHardware.Controls.Add(lblCPU_Name);
                            }
                        }
                    }
                }
            }
        }
        private void SendNotificationToTray(string title, string message)
        {
            notifyTray.BalloonTipTitle = title;
            notifyTray.BalloonTipText = message;
            notifyTray.Icon = settingsCall.GetApplicationIcon(); ;
            notifyTray.ShowBalloonTip(5000);
        }
        private bool IsMinerSetupValid(ref string message)
        {
            bool isvalid = true;

            foreach (DataGridViewRow row in dgvMiners.Rows)
            {
                if (Convert.ToBoolean(row.Cells[5].Value) && Convert.ToBoolean(row.Cells[6].Value))
                {
                    isvalid = false;
                    message = "One or more of the miners are setup as an active miner AND a failover. Failovers cannot be set to active.";
                }
            }

            if (isvalid)
            {
                int count = 0;
                foreach (DataGridViewRow row in dgvMiners.Rows)
                    if (Convert.ToBoolean(row.Cells[5].Value))
                        count++;

                if (count == 0)
                {
                    isvalid = false;
                    message = "You must have at least one active miner.";
                }
            }

            return isvalid;
        }

        #endregion

        #region Control Events

        #region ToolStripMenuItems

        private void ToolStripMenuItems_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi.Name == tsmiExit.Name)
                Application.Exit();
            else if (tsmi.Name == tsmiOptions.Name)
                new frmOptions().ShowDialog();
            else if (tsmi.Name == tsmiAbout.Name)
                new frmAbout().ShowDialog();
            else if (tsmi.Name == tsmiDonate.Name)
                new frmDonate().ShowDialog();
        }

        #endregion

        #region DataGridView Events

        private void MinerGrids_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Name == dgvMiners.Name)
            {
                if (dgvMiners.SelectedRows.Count > 0)
                {
                    picRemoveMiner.Enabled = true;
                    picMoveUpMiner.Enabled = true;
                    picMoveDownMiner.Enabled = true;
                    picEditMiner.Enabled = true;
                }
            }
        }

        #endregion
        
        #region Timers

        private void tmrHardwareScan_Tick(object sender, EventArgs e)
        {
            new Thread(() => this.InvokeThreadSafeMethod(() => GetHardware())).Start();
        }

        private void MinerActions_Click(object sender, EventArgs e)
        {
            string strError = string.Empty;
            dgvMiners.EndEdit();

            try
            {
                PictureBox pic = sender as PictureBox;
                settings = settingsCall.GetSettings(ref strError);

                if (!string.IsNullOrEmpty(strError))
                    UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "An error occurred while trying to get the settings data: Error: " + strError);
                else
                {
                    if (pic.Name == picMoveDownMiner.Name || pic.Name == picMoveUpMiner.Name || pic.Name == picRemoveMiner.Name || pic.Name == picEditMiner.Name)
                    {
                        if (dgvMiners.SelectedRows.Count <= 0)
                            UserMessage.ShowMessage(this, UserMessage.MessageType.Warning, "Please select a miner.");
                        else
                        {
                            if (pic.Name == picMoveDownMiner.Name)
                            {
                                var row = dgvMiners.SelectedRows[0];
                                int index = dgvMiners.SelectedRows[0].Index;
                                Miner miner = row.Cells[1].Value.ToString() == "GPU" ? Miner.GPU : Miner.CPU;
                                GpuMinerData gpuMiner = settings.GpuMiners.SingleOrDefault(x => x.MinerGUID == Guid.Parse(row.Cells[0].Value.ToString()));
                                CpuMinerData cpuMiner = settings.CpuMiners.SingleOrDefault(x => x.MinerGUID == Guid.Parse(row.Cells[0].Value.ToString()));

                                if (!SelectedRowCanMove(index, "DOWN"))
                                    return;

                                dgvMiners.Rows.Remove(row);
                                dgvMiners.Rows.Insert(index + 1, row);

                                if (miner == Miner.GPU)
                                {
                                    settings.GpuMiners.Remove(gpuMiner);
                                    settings.GpuMiners.Insert(index + 1, gpuMiner);
                                }
                                else if (miner == Miner.CPU)
                                {
                                    settings.CpuMiners.Remove(cpuMiner);
                                    settings.CpuMiners.Insert(index + 1, cpuMiner);
                                }

                                
                                
                                if (!string.IsNullOrEmpty(strError))
                                {
                                    UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "An error ocurred while trying to save the data. Error: " + strError);
                                    dgvMiners.Rows.Insert(index, row); //Reinsert the old row back at the original index because an error occurred during save

                                    if (miner == Miner.GPU)
                                        settings.GpuMiners.Insert(index, gpuMiner);
                                    else
                                        settings.CpuMiners.Insert(index, cpuMiner);
                                
                                    SetSelectedRow(index);
                                }
                                else
                                {
                                    SetSelectedRow(index + 1);
                                    settingsCall.SeriliazeSettings(settings);
                                }
                            }
                            else if (pic.Name == picMoveUpMiner.Name)
                            {
                                var row = dgvMiners.SelectedRows[0];
                                int index = dgvMiners.SelectedRows[0].Index;

                                if (!SelectedRowCanMove(index, "UP"))
                                    return;

                                dgvMiners.Rows.Remove(row);
                                dgvMiners.Rows.Insert(index - 1, row);

                                //SaveMinerSettings(ref strError);
                                if (!string.IsNullOrEmpty(strError))
                                {
                                    UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "An error ocurred while trying to save the data. Error: " + strError);
                                    dgvMiners.Rows.Insert(index, row); //Reinsert the old row back at the original index because an error occurred during save
                                    SetSelectedRow(index);
                                }
                                else
                                {
                                    SetSelectedRow(index - 1);
                                }
                            }
                            else if (pic.Name == picEditMiner.Name)
                            {
                                frmMiner miner = null;

                                if (dgvMiners.SelectedRows[0].Cells[1].Value.ToString() == "GPU")
                                    miner = new frmMiner(frmMiner.Type.Edit, frmMiner.Miner.GPU, Guid.Parse(dgvMiners.SelectedRows[0].Cells[0].Value.ToString()));
                                else if (dgvMiners.SelectedRows[0].Cells[1].Value.ToString() == "CPU")
                                    miner = new frmMiner(frmMiner.Type.Edit, frmMiner.Miner.CPU, Guid.Parse(dgvMiners.SelectedRows[0].Cells[0].Value.ToString()));

                                miner.ShowDialog();
                            }
                            else if (pic.Name == picRemoveMiner.Name)
                            {
                                if (MessageBox.Show("Are you sure you want to remove that miner?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    if (dgvMiners.SelectedRows[0].Cells[1].Value.ToString() == "GPU")
                                        settings.GpuMiners.RemoveAll(x => x.MinerGUID == Guid.Parse(dgvMiners.SelectedRows[0].Cells[0].Value.ToString()));
                                    else if (dgvMiners.SelectedRows[0].Cells[1].Value.ToString() == "CPU")
                                        settings.CpuMiners.RemoveAll(x => x.MinerGUID == Guid.Parse(dgvMiners.SelectedRows[0].Cells[0].Value.ToString()));
                                    dgvMiners.Rows.Remove(dgvMiners.SelectedRows[0]);
                                    settingsCall.SeriliazeSettings(settings);
                                }
                            }
                        }
                    }
                    else if (pic.Name == picRefreshMiners.Name)
                    {
                        AddMinersToDataGridViews(true);
                        UserMessage.ShowMessage(this, UserMessage.MessageType.Success, "Miner list successfully refreshed!");
                    }
                    else if (pic.Name == picAddMiner.Name)
                    {
                        frmMiner miner = new frmMiner(frmMiner.Type.Add, frmMiner.Miner.GPU);
                        miner.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "There was an error while trying to manipulate the miners: Error: " + ex.Message);
            }
        }

        #endregion

        private void cbxTemps_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strError = string.Empty;
            foreach (VideoCard card in devices.GetVideoCards(ref strError))
            {
                foreach (var sensor in card.FanSensors)
                {
                    if (cbxTemps.Text == "Auto")
                        sensor.Control.SetAuto();
                    else if (cbxTemps.Text == "Default")
                        sensor.Control.SetDefault();
                    else
                        sensor.Control.SetSoftware(Convert.ToInt32(cbxTemps.Text.Replace("%", "")));
                }
            }
        }
        private void MinerAutomation_Click(object sender, EventArgs e)
        {
            //When users change the values, they have to commit the edits by hitting return or F2
            //But that's not dependable. So we'll commit the edits for them, just in case they don't
            dgvMiners.EndEdit();

            string message = string.Empty;
            if (!IsMinerSetupValid(ref message))
            {
                UserMessage.ShowMessage(this, UserMessage.MessageType.Error, message);
                return;
            }

            gbxMiners.Enabled = false;
            if (btnMinerAutomation.Tag.ToString() == "STOP")
            {
                string strError = string.Empty;
                SettingCall call = new SettingCall();

                SaveMinerSettings(ref strError); //Save settings here so we can just use the Settings object and pass it to the control and not have mismatched data
                if (!string.IsNullOrEmpty(strError))
                {
                    UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "The miners couldn't start because the settings couldn't be saved. Error: " + strError);
                    return;
                }

                settings = settingsCall.GetSettings(ref strError);
                if (!string.IsNullOrEmpty(strError))
                {
                    UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "The miners couldn't start because the settings couldn't be retrieved. Error: " + strError);
                    return;
                }

                if (settings.GpuMiners.Count == 0 && settings.CpuMiners.Count == 0)
                {
                    UserMessage.ShowMessage(this, UserMessage.MessageType.Warning, "There are no miners");
                    return;
                }

                btnMinerAutomation.Tag = "START";
                btnMinerAutomation.Image = Properties.Resources.stop;
                tcMinerConsoles.TabPages.Clear();

                foreach (GpuMinerData gpu in settings.GpuMiners)
                {
                    if (gpu.Active)
                    {
                        MinerConsole console = new MinerConsole(gpu);
                        console.Text = "GPU Miner - " + gpu.Name;

                        tcMinerConsoles.TabPages.Add(console);
                    }
                }
                foreach (CpuMinerData cpu in settings.CpuMiners)
                {
                    if (cpu.Active)
                    {
                        MinerConsole console = new MinerConsole(cpu);
                        console.Text = "CPU Miner - " + cpu.Name;

                        tcMinerConsoles.TabPages.Add(console);
                    }
                }
            }
            else if (btnMinerAutomation.Tag.ToString() == "START")
            {
                if (MessageBox.Show("Are you sure you want to stop all miners?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string strError = string.Empty;

                    foreach (TabPage page in tcMinerConsoles.TabPages)
                    {
                        if (page is MinerConsole)
                        {
                            MinerConsole console = page as MinerConsole;
                            console.StopMiner("Operation stopped by user", ref strError);

                            if (!string.IsNullOrEmpty(strError))
                                UserMessage.ShowMessage(this, UserMessage.MessageType.Error, "An error occurred while trying to stop the miner for " + page.Text.Replace("GPU Miner - ", "").Replace("CPU Miner - ", "") + ". Error: " + strError);
                        }
                    }

                    btnMinerAutomation.Tag = "STOP";
                    btnMinerAutomation.Image = Properties.Resources.start;
                    gbxMiners.Enabled = true;
                }
            }
        }
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is MessageControl)
                    {
                        this.Controls.Remove(ctrl);
                        return; //Return after the first remove so we can have each one removed individually. There's probably a more subtle way of doing this, but I'm not worried about that right now
                    }
                }
            }
        }
        private void SetSelectedRow(int index)
        {
            foreach (DataGridViewRow oldRow in dgvMiners.Rows)
            {
                if (oldRow.Index != index)
                    oldRow.Selected = false;
                else
                    oldRow.Selected = true;
            }
        }
        private bool SelectedRowCanMove(int index, string direction)
        {
            bool canMove = false; 

            if (direction.ToUpper() == "UP")
            {
                if (dgvMiners.Rows[index].Cells[1].Value.ToString() == "GPU" && index != 0)
                    canMove = true;
                else if (dgvMiners.Rows[index].Cells[1].Value.ToString() == "CPU" && dgvMiners.Rows[index - 1].Cells[1].Value.ToString() != "GPU")
                    canMove = true;
            }
            else if (direction.ToUpper() == "DOWN")
            {
                if (dgvMiners.Rows[index].Cells[1].Value.ToString() == "GPU" && dgvMiners.Rows[index + 1].Cells[1].Value.ToString() != "CPU")
                    canMove = true;
                else if (dgvMiners.Rows[index].Cells[1].Value.ToString() == "CPU" && dgvMiners.Rows.Count != index + 1)
                    canMove = true;
            }

            return canMove;
        }

        #endregion

    }
}
