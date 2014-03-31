using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CUDA_Administrator.Data.Devices;
using System.Drawing.Drawing2D;
using CUDA_Administrator.Calls.Setting;
using CUDA_Administrator.Data.Setting;

namespace CUDA_Administrator.Controls
{
    public partial class NvidiaDisplayControl : UserControl
    {
        VideoCard nvidiaCard;
        int TemperatureRun = 0;
        bool IsCoolingDown = false;

        public NvidiaDisplayControl()
        {
            InitializeComponent();

            this.BackColor = Color.Transparent;
        }

        public void RefreshCard(VideoCard card)
        {
            string strError = string.Empty;
            SettingCall settingsCall = new SettingCall();
            Settings settings = settingsCall.GetSettings(ref strError); ;

            nvidiaCard = card;

            int temp = Convert.ToInt32(card.TemperatureSensors[0].Value);
            Color clr = Color.White;
            if (temp < 70)
                clr = Color.Green;
            else if (temp >= 70 && temp < 90)
                clr = Color.Orange;
            else if (temp >= 90)
                clr = Color.Red;

            lblNumber.Text = card.Number.ToString();
            lblName.Text = card.Name;
            lblTemp.Text = card.TemperatureSensors[0].Value.ToString() + "°C";
            lblClockSpeed.Text = Convert.ToInt32(card.ClockSensors[0].Value).ToString() + " MHz";

            lblTemp.ForeColor = clr;

            if (!cbxFanSpeed.DroppedDown) //We don't want to add the fan % if this is dropped down because then the user will have a hard time selecting a new value
                cbxFanSpeed.Text = card.FanSensors[0].Value.ToString() + "%";

            if (settings.Options.IsTempProtectionActivated)
            {
                if (TemperatureRun > 0)
                    TemperatureRun++;

                if (card.TemperatureSensors[0].Value >= settings.Options.TemperatureMax && !IsCoolingDown)
                {
                    SendNotificationToTray("Temperature Protection", "Temperature threshold reached. The Fan will run at 100% for 3 minutes and then run at 50%.");
                    nvidiaCard.FanSensors[0].Control.SetSoftware(100);
                    IsCoolingDown = true;
                }
                else if (!settings.Options.IsTempProtectionActivated || card.TemperatureSensors[0].Value < settings.Options.TemperatureMax && TemperatureRun >= 180)  //180 = 3 minutes. Let the fan run for 3 minutes
                {
                    IsCoolingDown = false;
                    TemperatureRun = 0;
                    nvidiaCard.FanSensors[0].Control.SetSoftware(50);
                }
            }
        }

        public bool IsAdded(int num)
        {
            bool isadded = false;

            if (Convert.ToInt32(lblNumber.Text) == num)
                isadded = true;

            return isadded;
        }

        private void NvidiaDisplayControl_Paint(object sender, PaintEventArgs e)
        {
            using (HatchBrush h1 = new HatchBrush(HatchStyle.ForwardDiagonal, UI.BackgroundColors.BackgroundDotsLight, UI.BackgroundColors.BackgroundColor))
            {
                e.Graphics.FillRectangle(h1, e.ClipRectangle);
            }
        }

        private void cbxFanSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFanSpeed.Text == "Auto")
                nvidiaCard.FanSensors[0].Control.SetAuto();
            else if (cbxFanSpeed.Text == "Default")
                nvidiaCard.FanSensors[0].Control.SetDefault();
            else
                nvidiaCard.FanSensors[0].Control.SetSoftware(Convert.ToInt32(cbxFanSpeed.Text.Replace("%", "")));
        }
        private void SendNotificationToTray(string title, string message)
        {
            SettingCall settingsCall = new SettingCall();
            notifyTray.BalloonTipTitle = title;
            notifyTray.BalloonTipText = message;
            notifyTray.Icon = settingsCall.GetApplicationIcon(); ;
            notifyTray.ShowBalloonTip(5000);
        }
    }
}
