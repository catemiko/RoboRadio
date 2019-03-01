namespace RoboRadio
{
    partial class RadioStationDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadioStationDelete));
            this.StationsList = new System.Windows.Forms.ListBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StationsList
            // 
            this.StationsList.FormattingEnabled = true;
            this.StationsList.Location = new System.Drawing.Point(12, 12);
            this.StationsList.Name = "StationsList";
            this.StationsList.Size = new System.Drawing.Size(189, 186);
            this.StationsList.TabIndex = 0;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(12, 209);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(189, 41);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // RadioStationDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(213, 262);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.StationsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RadioStationDelete_FormClosing);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(229, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(229, 300);
            this.Name = "RadioStationDelete";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Station Delete";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RadioStationDelete_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button DeleteButton;
        public System.Windows.Forms.ListBox StationsList;
    }
}