namespace RoboRadio.Windows
{
    partial class InfoWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoWindow));
            this.AvatarBox = new System.Windows.Forms.PictureBox();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.DonateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AvatarBox
            // 
            this.AvatarBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AvatarBox.Location = new System.Drawing.Point(12, 78);
            this.AvatarBox.Name = "AvatarBox";
            this.AvatarBox.Size = new System.Drawing.Size(128, 128);
            this.AvatarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AvatarBox.TabIndex = 0;
            this.AvatarBox.TabStop = false;
            this.AvatarBox.Click += new System.EventHandler(this.AvatarBox_Click);
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(28, 9);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(96, 13);
            this.AuthorLabel.TabIndex = 1;
            this.AuthorLabel.Text = "Made By xRoBoTx";
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Location = new System.Drawing.Point(38, 32);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(29, 13);
            this.YearLabel.TabIndex = 2;
            this.YearLabel.Text = "Year";
            // 
            // DonateButton
            // 
            this.DonateButton.Location = new System.Drawing.Point(12, 48);
            this.DonateButton.Name = "DonateButton";
            this.DonateButton.Size = new System.Drawing.Size(128, 24);
            this.DonateButton.TabIndex = 3;
            this.DonateButton.Text = "Donate";
            this.DonateButton.UseVisualStyleBackColor = true;
            this.DonateButton.Click += new System.EventHandler(this.DonateButton_Click);
            // 
            // InfoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 218);
            this.Controls.Add(this.DonateButton);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.AvatarBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Program Info";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoWindow_FormClosing);
            this.Load += new System.EventHandler(this.InfoWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AvatarBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AvatarBox;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.Button DonateButton;
    }
}