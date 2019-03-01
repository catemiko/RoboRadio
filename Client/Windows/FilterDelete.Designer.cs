namespace RoboRadio.Windows
{
    partial class FilterDelete
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
            this.DeleteFilterButton = new System.Windows.Forms.Button();
            this.FiltersListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // DeleteFilterButton
            // 
            this.DeleteFilterButton.Location = new System.Drawing.Point(12, 209);
            this.DeleteFilterButton.Name = "DeleteFilterButton";
            this.DeleteFilterButton.Size = new System.Drawing.Size(189, 41);
            this.DeleteFilterButton.TabIndex = 3;
            this.DeleteFilterButton.Text = "Delete";
            this.DeleteFilterButton.UseVisualStyleBackColor = true;
            this.DeleteFilterButton.Click += new System.EventHandler(this.DeleteFilterButton_Click);
            // 
            // FiltersListBox
            // 
            this.FiltersListBox.FormattingEnabled = true;
            this.FiltersListBox.Location = new System.Drawing.Point(12, 12);
            this.FiltersListBox.Name = "FiltersListBox";
            this.FiltersListBox.Size = new System.Drawing.Size(189, 186);
            this.FiltersListBox.TabIndex = 2;
            // 
            // FilterDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(213, 262);
            this.Controls.Add(this.DeleteFilterButton);
            this.Controls.Add(this.FiltersListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FilterDelete_FormClosing);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(229, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(229, 300);
            this.Name = "FilterDelete";
            this.ShowIcon = false;
            this.Text = "Filter Delete";
            this.Load += new System.EventHandler(this.FilterDelete_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DeleteFilterButton;
        public System.Windows.Forms.ListBox FiltersListBox;
    }
}