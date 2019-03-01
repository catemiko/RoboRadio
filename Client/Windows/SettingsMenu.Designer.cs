namespace RoboRadio
{
    partial class OptionsMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsMenu));
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SaveStationOnExit = new System.Windows.Forms.CheckBox();
            this.SaveShazamOnExit = new System.Windows.Forms.CheckBox();
            this.VisColorDialog = new System.Windows.Forms.ColorDialog();
            this.ColorSelectButton = new System.Windows.Forms.Button();
            this.EnableVisGradient = new System.Windows.Forms.CheckBox();
            this.RandomVisColorButton = new System.Windows.Forms.Button();
            this.MinimizeTray = new System.Windows.Forms.CheckBox();
            this.TrayStart = new System.Windows.Forms.CheckBox();
            this.StartInfo = new System.Windows.Forms.CheckBox();
            this.RichPresenceSwitch = new System.Windows.Forms.CheckBox();
            this.FilterSwitch = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(264, 403);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(120, 35);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save Settings";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(138, 403);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 35);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(12, 403);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(120, 35);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // SaveStationOnExit
            // 
            this.SaveStationOnExit.AutoSize = true;
            this.SaveStationOnExit.Location = new System.Drawing.Point(12, 12);
            this.SaveStationOnExit.Name = "SaveStationOnExit";
            this.SaveStationOnExit.Size = new System.Drawing.Size(166, 17);
            this.SaveStationOnExit.TabIndex = 4;
            this.SaveStationOnExit.Text = "Save Station On Program Exit";
            this.SaveStationOnExit.UseVisualStyleBackColor = true;
            this.SaveStationOnExit.CheckedChanged += new System.EventHandler(this.SaveStationOnExit_CheckedChanged);
            // 
            // SaveShazamOnExit
            // 
            this.SaveShazamOnExit.AutoSize = true;
            this.SaveShazamOnExit.Location = new System.Drawing.Point(12, 35);
            this.SaveShazamOnExit.Name = "SaveShazamOnExit";
            this.SaveShazamOnExit.Size = new System.Drawing.Size(199, 17);
            this.SaveShazamOnExit.TabIndex = 5;
            this.SaveShazamOnExit.Text = "Save Shazam State On Program Exit";
            this.SaveShazamOnExit.UseVisualStyleBackColor = true;
            this.SaveShazamOnExit.CheckedChanged += new System.EventHandler(this.SaveShazamOnExit_CheckedChanged);
            // 
            // ColorSelectButton
            // 
            this.ColorSelectButton.Location = new System.Drawing.Point(264, 374);
            this.ColorSelectButton.Name = "ColorSelectButton";
            this.ColorSelectButton.Size = new System.Drawing.Size(120, 23);
            this.ColorSelectButton.TabIndex = 6;
            this.ColorSelectButton.Text = "Visualization Color";
            this.ColorSelectButton.UseVisualStyleBackColor = true;
            this.ColorSelectButton.Click += new System.EventHandler(this.ColorSelectButton_Click);
            // 
            // EnableVisGradient
            // 
            this.EnableVisGradient.AutoSize = true;
            this.EnableVisGradient.Location = new System.Drawing.Point(12, 58);
            this.EnableVisGradient.Name = "EnableVisGradient";
            this.EnableVisGradient.Size = new System.Drawing.Size(163, 17);
            this.EnableVisGradient.TabIndex = 8;
            this.EnableVisGradient.Text = "Enable Visualization Gradient";
            this.EnableVisGradient.UseVisualStyleBackColor = true;
            this.EnableVisGradient.CheckedChanged += new System.EventHandler(this.EnableVisGradient_CheckedChanged);
            // 
            // RandomVisColorButton
            // 
            this.RandomVisColorButton.Location = new System.Drawing.Point(264, 345);
            this.RandomVisColorButton.Name = "RandomVisColorButton";
            this.RandomVisColorButton.Size = new System.Drawing.Size(120, 23);
            this.RandomVisColorButton.TabIndex = 9;
            this.RandomVisColorButton.Text = "WTF Mode";
            this.RandomVisColorButton.UseVisualStyleBackColor = true;
            this.RandomVisColorButton.Click += new System.EventHandler(this.RandomVisColorButton_Click);
            // 
            // MinimizeTray
            // 
            this.MinimizeTray.AutoSize = true;
            this.MinimizeTray.Location = new System.Drawing.Point(12, 81);
            this.MinimizeTray.Name = "MinimizeTray";
            this.MinimizeTray.Size = new System.Drawing.Size(102, 17);
            this.MinimizeTray.TabIndex = 10;
            this.MinimizeTray.Text = "Minimize In Tray";
            this.MinimizeTray.UseVisualStyleBackColor = true;
            this.MinimizeTray.CheckedChanged += new System.EventHandler(this.MinimizeTray_CheckedChanged);
            // 
            // TrayStart
            // 
            this.TrayStart.AutoSize = true;
            this.TrayStart.Location = new System.Drawing.Point(12, 104);
            this.TrayStart.Name = "TrayStart";
            this.TrayStart.Size = new System.Drawing.Size(84, 17);
            this.TrayStart.TabIndex = 11;
            this.TrayStart.Text = "Start In Tray";
            this.TrayStart.UseVisualStyleBackColor = true;
            this.TrayStart.CheckedChanged += new System.EventHandler(this.TrayStart_CheckedChanged);
            // 
            // StartInfo
            // 
            this.StartInfo.AutoSize = true;
            this.StartInfo.Location = new System.Drawing.Point(12, 127);
            this.StartInfo.Name = "StartInfo";
            this.StartInfo.Size = new System.Drawing.Size(116, 17);
            this.StartInfo.TabIndex = 12;
            this.StartInfo.Text = "Show Info On Start";
            this.StartInfo.UseVisualStyleBackColor = true;
            this.StartInfo.CheckedChanged += new System.EventHandler(this.StartInfo_CheckedChanged);
            // 
            // RichPresenceSwitch
            // 
            this.RichPresenceSwitch.AutoSize = true;
            this.RichPresenceSwitch.Location = new System.Drawing.Point(12, 150);
            this.RichPresenceSwitch.Name = "RichPresenceSwitch";
            this.RichPresenceSwitch.Size = new System.Drawing.Size(135, 17);
            this.RichPresenceSwitch.TabIndex = 13;
            this.RichPresenceSwitch.Text = "Rich Presence Discord";
            this.RichPresenceSwitch.UseVisualStyleBackColor = true;
            this.RichPresenceSwitch.CheckedChanged += new System.EventHandler(this.RichPresenceSwitch_CheckedChanged);
            // 
            // FilterSwitch
            // 
            this.FilterSwitch.AutoSize = true;
            this.FilterSwitch.Location = new System.Drawing.Point(12, 173);
            this.FilterSwitch.Name = "FilterSwitch";
            this.FilterSwitch.Size = new System.Drawing.Size(98, 17);
            this.FilterSwitch.TabIndex = 14;
            this.FilterSwitch.Text = "Enable Filtering";
            this.FilterSwitch.UseVisualStyleBackColor = true;
            this.FilterSwitch.CheckedChanged += new System.EventHandler(this.FilterSwitch_CheckedChanged);
            // 
            // OptionsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(396, 450);
            this.Controls.Add(this.FilterSwitch);
            this.Controls.Add(this.RichPresenceSwitch);
            this.Controls.Add(this.StartInfo);
            this.Controls.Add(this.TrayStart);
            this.Controls.Add(this.MinimizeTray);
            this.Controls.Add(this.RandomVisColorButton);
            this.Controls.Add(this.EnableVisGradient);
            this.Controls.Add(this.ColorSelectButton);
            this.Controls.Add(this.SaveShazamOnExit);
            this.Controls.Add(this.SaveStationOnExit);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(412, 488);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(412, 488);
            this.Name = "OptionsMenu";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsMenu_FormClosing);
            this.Load += new System.EventHandler(this.OptionsMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        public System.Windows.Forms.CheckBox SaveStationOnExit;
        public System.Windows.Forms.CheckBox SaveShazamOnExit;
        private System.Windows.Forms.ColorDialog VisColorDialog;
        private System.Windows.Forms.Button ColorSelectButton;
        private System.Windows.Forms.CheckBox EnableVisGradient;
        private System.Windows.Forms.Button RandomVisColorButton;
        private System.Windows.Forms.CheckBox MinimizeTray;
        private System.Windows.Forms.CheckBox TrayStart;
        private System.Windows.Forms.CheckBox StartInfo;
        private System.Windows.Forms.CheckBox RichPresenceSwitch;
        private System.Windows.Forms.CheckBox FilterSwitch;
    }
}