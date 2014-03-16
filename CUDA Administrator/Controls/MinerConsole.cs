using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CUDA_Administrator.Data.Setting;
using System.Threading;
using System.Diagnostics;
using ThreadSafeExtensions;
using CUDA_Administrator.Data.Miner;
using CUDA_Administrator.Miscellaneous;
using System.Threading.Tasks;
using System.IO;
using CUDA_Administrator.Calls.Setting;

namespace CUDA_Administrator.Controls
{
    public partial class MinerConsole : TabPage
    {
        object data;
        StreamWriter log;
        SettingCall settingsCall;
        Settings settings;

        FlowLayoutPanel flpStatus;
        Label lblAvgHashrate;
        Label lblRuntime;
        RichTextBox txtConsole;
        Label lblAccepts;
        Label lblKernel;
        Label lblGUID;
        Label lblPipe;
        Stopwatch watch;

        int PID = 0;
        int Accepts = 0;
        int Retries = 0;
        int hashrateCount = 0;
        decimal hashrateTotal = 0;

        public MinerConsole(GpuMinerData d)
        {
            InitializeComponent();

            this.data = d;
            Setup();

            Task.Factory.StartNew(() => { StartMiner(); });
        }

        public MinerConsole(CpuMinerData d)
        {
            this.data = d;
            Setup();

            Task.Factory.StartNew(() => { StartMiner(); });
        }

        private void Setup()
        {
            InitializeComponent();
            string strError = string.Empty;

            settingsCall = new SettingCall();
            settings = settingsCall.GetSettings(ref strError);

            flpStatus = new FlowLayoutPanel() { Dock = DockStyle.Top, Height = 20, BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle };
            lblPipe = new Label() { Text = "|", AutoSize = true, Margin = new Padding(0, 2, 0, 0) };
            lblAvgHashrate = new Label() { Text = "Avg. Hashrate: 0 kh/s", Margin = new Padding(0, 2, 0, 0), AutoSize = true };
            lblRuntime = new Label() { Text = "Run Time: 00:00:00", Margin = new Padding(0, 2, 0, 0), AutoSize = true };
            txtConsole = new RichTextBox() { Dock = DockStyle.Fill, ReadOnly = true, BackColor = SystemColors.Control, ForeColor = SystemColors.WindowText, Multiline = true, Height = this.Height, BorderStyle = BorderStyle.FixedSingle };
            lblAccepts = new Label() { Text = "Accepts: 0/min", Margin = new Padding(0, 2, 0, 0), AutoSize = true };
            lblKernel = new Label() { Text = "Kernel: N/A", Margin = new Padding(0, 2, 0, 0), AutoSize = true };
            lblGUID = new Label() { Text = "GUID: ", Margin = new Padding(0, 2, 0, 0), AutoSize = true, ForeColor = Color.Gray };

            flpStatus.Controls.Add(lblAvgHashrate);
            flpStatus.Controls.Add(lblPipe); //Separator
            flpStatus.Controls.Add(lblRuntime);
            flpStatus.Controls.Add(lblPipe); //Separator
            flpStatus.Controls.Add(lblAccepts);
            flpStatus.Controls.Add(lblPipe); //Separator
            flpStatus.Controls.Add(lblKernel);
            flpStatus.Controls.Add(lblPipe); //Separator
            flpStatus.Controls.Add(lblGUID);

            this.Controls.Add(flpStatus);
            this.Controls.Add(txtConsole);

            watch = new Stopwatch();
            watch.Start();
        }

        public void StopMiner(string StopReason, ref string strError)
        {
            try
            {
                if (PID != 0)
                {
                    Process miner = Process.GetProcessById(PID);
                    if (!miner.CloseMainWindow())
                        miner.Kill();

                    tmrTotalRunTime.Stop();
                    tmrTotalRunTime.Enabled = false;
                    watch.Stop();
                    txtConsole.InvokeThreadSafeMethod(() => txtConsole.AppendText(Environment.NewLine + StopReason, Color.Red));
                    txtConsole.InvokeThreadSafeMethod(() => txtConsole.ScrollToCaret());
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
        }
        
        private void StartFailoverMiner()
        {
            if (data is GpuMinerData)
            {
                txtConsole.InvokeThreadSafeMethod(() => txtConsole.AppendText(Environment.NewLine + "Setting current miner to inactive..."));
                settings.GpuMiners.SingleOrDefault(x => x.MinerGUID == ((GpuMinerData)data).MinerGUID).Failover = false; //Set failover to false so if it was already set, it won't get chosen again

                List<GpuMinerData> FailOverMiners = settings.GpuMiners.Where(x => x.Failover == true).ToList();
                if (FailOverMiners.Count <= 0)
                    txtConsole.InvokeThreadSafeMethod(() => txtConsole.AppendText(Environment.NewLine + "There are no more failovers. Mining has stopped.", Color.Red));
                else
                {
                    frmMain main = Application.OpenForms.OfType<frmMain>().Single(x => x.Name == "frmMain");
                    main.InvokeThreadSafeMethod(() => main.ChangeMinerTabText("GPU Miner - " + ((GpuMinerData)data).Name, "GPU Miner - " + ((GpuMinerData)FailOverMiners[0]).Name));

                    data = FailOverMiners[0]; //Always get the first active miner because we always set the failed miner to inactive
                    StartMiner(); //This method uses the class scoped miner object. So setting it the line before is all we need
                }
            }
            else if (data is CpuMinerData)
            {
                txtConsole.InvokeThreadSafeMethod(() => txtConsole.AppendText(Environment.NewLine + "Setting current miner to inactive..."));
                settings.CpuMiners.SingleOrDefault(x => x.MinerGUID == ((CpuMinerData)data).MinerGUID).Failover = false; //Set failover to false so if it was already set, it won't get chosen again

                List<CpuMinerData> FailOverMiners = settings.CpuMiners.Where(x => x.Failover == true).ToList();
                if (FailOverMiners.Count <= 0)
                    txtConsole.InvokeThreadSafeMethod(() => txtConsole.AppendText(Environment.NewLine + "There are no more failovers. Mining has stopped.", Color.Red));
                else
                {
                    frmMain main = Application.OpenForms.OfType<frmMain>().Single(x => x.Name == "frmMain");
                    main.InvokeThreadSafeMethod(() => main.ChangeMinerTabText("CPU Miner - " + ((CpuMinerData)data).Name, "CPU Miner - " + ((CpuMinerData)FailOverMiners[0]).Name));

                    data = FailOverMiners[0]; //Always get the first failover miner because we always set the failed miner to false
                    StartMiner(); //This method uses the class scoped miner object. So setting it the line before is all we need
                }
            }
        }
        private void StartMiner()
        {
            string FileName = "";
            string CommandLine = "";

            tmrTotalRunTime.Enabled = true;
            tmrTotalRunTime.Start();
            watch = new Stopwatch();
            watch.Start();

            if (data is GpuMinerData)
            {
                GpuMinerData minerData = data as GpuMinerData;
                FileName = FileManager.CudaMinerPath + "cudaminer.exe";
                CommandLine = minerData.CommandLine;
            }
            else if (data is CpuMinerData)
            {
                CpuMinerData minerData = data as CpuMinerData;
                FileName = FileManager.CpuMinerPath + "minerd.exe";
                CommandLine = minerData.CommandLine;
            }

            using (Process p = new Process())
            {
                p.StartInfo = new ProcessStartInfo()
                {
                    FileName = FileName,
                    Arguments = CommandLine,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                p.EnableRaisingEvents = true;
                p.ErrorDataReceived += proc_DataReceived;
                p.OutputDataReceived += proc_DataReceived;
                p.Start();

                p.BeginErrorReadLine();
                p.BeginOutputReadLine();

                PID = p.Id; //Set PID so we can kill this specific process later
                p.WaitForExit();
            };
        }
        private void proc_DataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                string strError = string.Empty;

                string guid = data is GpuMinerData ? ((GpuMinerData)data).MinerGUID.ToString() : ((CpuMinerData)data).MinerGUID.ToString().ToUpper();
                lblGUID.SetThreadSafeProperty(() => lblGUID.Text, "GUID: " + guid.ToUpper());

                if (e.Data != null || e.Data != string.Empty)
                {
                    if (e.Data.ToLower().Contains("yay")) //Count yays for avg/accepts
                    {
                        Accepts++;
                        txtConsole.InvokeThreadSafeMethod(() => txtConsole.AppendText(Environment.NewLine + e.Data, Color.Green)); //Display text
                    }
                    else if ((e.Data.ToLower().Contains("failed") || e.Data.ToLower().Contains("interrupted")) && !e.Data.ToLower().Contains("http")) //Get retries when CudaMiner fails
                    {
                        Retries++;
                        txtConsole.InvokeThreadSafeMethod(() => txtConsole.AppendText(Environment.NewLine + e.Data, Color.Red)); //Display text
                    }
                    else
                        txtConsole.InvokeThreadSafeMethod(() => txtConsole.AppendText(Environment.NewLine + e.Data)); //Display text

                    txtConsole.InvokeThreadSafeMethod(() => txtConsole.ScrollToCaret());

                    if (e.Data.ToLower().Contains("gpu #0") || (e.Data.ToLower().EndsWith("khash/s") && !e.Data.ToLower().Contains("gpu #0"))) //The first check is for GPU, the second is for CPU
                    {
                        if (e.Data.Split(',').Count() == 2)
                        {
                            hashrateCount++;

                            string suffix = e.Data.Split(',')[1].ToLower().Contains("khash") ? " kh/s" : " mh/s";
                            hashrateTotal += Convert.ToDecimal(e.Data.Split(',')[1].Replace("khash/s", string.Empty).Replace("mhash/s", string.Empty).Trim());

                            lblAvgHashrate.SetThreadSafeProperty(() => lblAvgHashrate.Text, "Avg Hashrate: " + Math.Round((Convert.ToDouble(hashrateTotal) / hashrateCount), 0).ToString() + suffix);
                        }
                    }
                    if (e.Data.ToLower().Contains("launch configuration"))
                        lblKernel.SetThreadSafeProperty(() => lblKernel.Text, e.Data.Split(' ').Count() == 9 ? "Kernel: " + e.Data.Split(' ')[8] : "Kernel: " + e.Data.Split(' ')[7]);

                    if (data is GpuMinerData)
                    {
                        if (Retries >= (data as GpuMinerData).Retries)
                        {
                            StopMiner("Miner stopped. Retries exceeded", ref strError);
                            StartFailoverMiner();
                            return;
                        }
                    }
                    else if (data is CpuMinerData)
                    {
                        if (Retries >= (data as CpuMinerData).Retries)
                        {
                            StopMiner("Miner stopped. Retries exceeded", ref strError);
                            StartFailoverMiner();
                            return;
                        }
                    }
                    
                    try
                    {
                        if (settings.Options.IsContinuousMinerLogging)
                        {
                            using (log = new StreamWriter(FileManager.MinerLogsPath + lblGUID.GetThreadSafeProperty(() => lblGUID.Text).Replace("GUID:", "").Trim().ToUpper()))
                            {
                                log.WriteLine
                                    (
                                    lblAvgHashrate.GetThreadSafeProperty(() => lblAvgHashrate.Text) + " | " +
                                    lblRuntime.GetThreadSafeProperty(() => lblRuntime.Text) + " | " +
                                    lblAccepts.GetThreadSafeProperty(() => lblAccepts.Text) + " | " +
                                    lblKernel.GetThreadSafeProperty(() => lblKernel.Text) + " | " +
                                    lblGUID.GetThreadSafeProperty(() => lblGUID.Text)
                                    );
                                log.WriteLine(txtConsole.GetThreadSafeProperty(() => txtConsole.Text));
                                log.Close();
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        //TODO: Log error
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Log
            }    
        }

        private void tmrTotalRunTime_Tick(object sender, EventArgs e)
        {
            if (tmrTotalRunTime.Enabled)
            {
                Task.Factory.StartNew(() =>
                {
                    TimeSpan ts = watch.Elapsed;
                    lblRuntime.SetThreadSafeProperty(() => lblRuntime.Text, "Run Time: " + string.Format("{0:D2}:{1:D2}:{2:D2}", ts.Hours, ts.Minutes, ts.Seconds));
                    lblAccepts.SetThreadSafeProperty(() => lblAccepts.Text, "Accepts: " + Math.Round((Accepts / ts.TotalMinutes), 2).ToString() + "/min");
                });
            }
        }
    }
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
