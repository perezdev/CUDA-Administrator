using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CUDA_Administrator.Calls.OptionsCall;
using CUDA_Administrator.Calls.Setting;
using CUDA_Administrator.Data.Setting;
using UI;

namespace CUDA_Administrator
{
    public partial class frmOptions : Form
    {
        SettingCall settingsCall;
        Settings settings;
        OptionsCall optionsCall;

        public frmOptions()
        {
            InitializeComponent();
        }     

        #region Form Events

        private void frmOptions_Load(object sender, EventArgs e)
        {
            string strError = string.Empty;
            
            settingsCall = new SettingCall();
            optionsCall = new OptionsCall();
            settings = settingsCall.GetSettings(ref strError);

            this.Icon = settingsCall.GetApplicationIcon();

            if (!string.IsNullOrEmpty(strError))
                MessageBox.Show("An error occurred while trying to get the settings file data.\r\n\r\n" + strError);

            chkRunOnStartup.Checked = settings.Options.IsRunningOnStartup;
            intActivateProtection.Value = settings.Options.TemperatureMax;
            intShutdownMiners.Value = settings.Options.TemperatureShutdown;

            chkEnableTempProtection.Checked = settings.Options.IsTempProtectionActivated;
            pnlTempProtectionSettings.Enabled = chkEnableTempProtection.Checked;

            chkContinuousMinerLogging.Checked = settings.Options.IsContinuousMinerLogging;
        }

        private void frmOptions_Paint(object sender, PaintEventArgs e)
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

        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == chkRunOnStartup)
            {
                settings.Options.IsRunningOnStartup = chkRunOnStartup.Checked;

                string strError = string.Empty;
                if (chkRunOnStartup.Checked)
                    optionsCall.SetStartupKey(ref strError);
                else
                    optionsCall.RemoveStartupKey(ref strError);

                if (!string.IsNullOrEmpty(strError))
                    MessageBox.Show("An error occurred while trying to set or remove the startup settings\r\n\r\n" + strError, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sender == chkEnableTempProtection)
            {
                pnlTempProtectionSettings.Enabled = chkEnableTempProtection.Checked;
                settings.Options.IsTempProtectionActivated = chkEnableTempProtection.Checked;
            }
            else if (sender == chkContinuousMinerLogging)
            {
                settings.Options.IsContinuousMinerLogging = chkContinuousMinerLogging.Checked;
            }

            settingsCall.SeriliazeSettings(settings);
        }

        private void Temps_ValueChanged(object sender, EventArgs e)
        {
            if (sender == intActivateProtection)
                settings.Options.TemperatureMax = Convert.ToInt32(intActivateProtection.Value);
            else if (sender == intShutdownMiners)
                settings.Options.TemperatureShutdown = Convert.ToInt32(intShutdownMiners.Value);

            settingsCall.SeriliazeSettings(settings);
        }

    }
}
