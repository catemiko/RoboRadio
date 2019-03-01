using System.Windows.Forms;

namespace RoboRadio.Windows
{
    partial class SoundVisualization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundVisualization));
            this.VisPanel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.VisPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // VisPanel
            // 
            this.VisPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VisPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisPanel.Location = new System.Drawing.Point(0, 0);
            this.VisPanel.MinimumSize = new System.Drawing.Size(640, 256);
            this.VisPanel.Name = "VisPanel";
            this.VisPanel.Size = new System.Drawing.Size(640, 280);
            this.VisPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.VisPanel.TabIndex = 0;
            this.VisPanel.TabStop = false;
            // 
            // SoundVisualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(640, 280);
            this.Controls.Add(this.VisPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoundVisualization";
            this.Text = "Sound Visualization";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SoundVisualization_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.VisPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox VisPanel;
    }
}