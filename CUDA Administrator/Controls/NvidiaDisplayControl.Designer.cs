namespace CUDA_Administrator.Controls
{
    partial class NvidiaDisplayControl
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
            this.cbxFanSpeed = new System.Windows.Forms.ComboBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblClockSpeed = new System.Windows.Forms.Label();
            this.notifyTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // cbxFanSpeed
            // 
            this.cbxFanSpeed.BackColor = System.Drawing.SystemColors.Control;
            this.cbxFanSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFanSpeed.FormattingEnabled = true;
            this.cbxFanSpeed.Items.AddRange(new object[] {
            "Default",
            "Auto",
            "0%",
            "1%",
            "2%",
            "3%",
            "4%",
            "5%",
            "6%",
            "7%",
            "8%",
            "9%",
            "10%",
            "11%",
            "12%",
            "13%",
            "14%",
            "15%",
            "16%",
            "17%",
            "18%",
            "19%",
            "20%",
            "21%",
            "22%",
            "23%",
            "24%",
            "25%",
            "26%",
            "27%",
            "28%",
            "29%",
            "30%",
            "31%",
            "32%",
            "33%",
            "34%",
            "35%",
            "36%",
            "37%",
            "38%",
            "39%",
            "40%",
            "41%",
            "42%",
            "43%",
            "44%",
            "45%",
            "46%",
            "47%",
            "48%",
            "49%",
            "50%",
            "51%",
            "52%",
            "53%",
            "54%",
            "55%",
            "56%",
            "57%",
            "58%",
            "59%",
            "60%",
            "61%",
            "62%",
            "63%",
            "64%",
            "65%",
            "66%",
            "67%",
            "68%",
            "69%",
            "70%",
            "71%",
            "72%",
            "73%",
            "74%",
            "75%",
            "76%",
            "77%",
            "78%",
            "79%",
            "80%",
            "81%",
            "82%",
            "83%",
            "84%",
            "85%",
            "86%",
            "87%",
            "88%",
            "89%",
            "90%",
            "91%",
            "92%",
            "93%",
            "94%",
            "95%",
            "96%",
            "97%",
            "98%",
            "99%",
            "100%"});
            this.cbxFanSpeed.Location = new System.Drawing.Point(280, 1);
            this.cbxFanSpeed.Name = "cbxFanSpeed";
            this.cbxFanSpeed.Size = new System.Drawing.Size(50, 21);
            this.cbxFanSpeed.TabIndex = 13;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblNumber.ForeColor = System.Drawing.Color.White;
            this.lblNumber.Location = new System.Drawing.Point(10, 5);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(13, 13);
            this.lblNumber.TabIndex = 12;
            this.lblNumber.Text = "1";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(35, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(133, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "NVIDIA GeForce GTX 780";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.BackColor = System.Drawing.Color.Transparent;
            this.lblTemp.ForeColor = System.Drawing.Color.White;
            this.lblTemp.Location = new System.Drawing.Point(208, 5);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(36, 13);
            this.lblTemp.TabIndex = 10;
            this.lblTemp.Text = "100°C";
            // 
            // lblClockSpeed
            // 
            this.lblClockSpeed.AutoSize = true;
            this.lblClockSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblClockSpeed.ForeColor = System.Drawing.Color.White;
            this.lblClockSpeed.Location = new System.Drawing.Point(364, 5);
            this.lblClockSpeed.Name = "lblClockSpeed";
            this.lblClockSpeed.Size = new System.Drawing.Size(29, 13);
            this.lblClockSpeed.TabIndex = 11;
            this.lblClockSpeed.Text = "MHz";
            // 
            // notifyTray
            // 
            this.notifyTray.Text = "CUDA Administrator";
            this.notifyTray.Visible = true;
            // 
            // NvidiaDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cbxFanSpeed);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.lblClockSpeed);
            this.Name = "NvidiaDisplayControl";
            this.Size = new System.Drawing.Size(400, 25);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NvidiaDisplayControl_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxFanSpeed;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblClockSpeed;
        private System.Windows.Forms.NotifyIcon notifyTray;
    }
}
