namespace RoboRadio.Windows
{
    partial class FilterAdd
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
            this.AddFilterButton = new System.Windows.Forms.Button();
            this.Prefix = new System.Windows.Forms.TextBox();
            this.PrefixLabel = new System.Windows.Forms.Label();
            this.Suffix = new System.Windows.Forms.TextBox();
            this.SuffixLabel = new System.Windows.Forms.Label();
            this.TwoFieldsCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // AddFilterButton
            // 
            this.AddFilterButton.Location = new System.Drawing.Point(14, 117);
            this.AddFilterButton.Name = "AddFilterButton";
            this.AddFilterButton.Size = new System.Drawing.Size(259, 28);
            this.AddFilterButton.TabIndex = 9;
            this.AddFilterButton.Text = "Add";
            this.AddFilterButton.UseVisualStyleBackColor = true;
            this.AddFilterButton.Click += new System.EventHandler(this.AddFilterButton_Click);
            // 
            // Prefix
            // 
            this.Prefix.Location = new System.Drawing.Point(13, 29);
            this.Prefix.Name = "Prefix";
            this.Prefix.Size = new System.Drawing.Size(260, 20);
            this.Prefix.TabIndex = 8;
            this.Prefix.TextChanged += new System.EventHandler(this.Prefix_TextChanged);
            // 
            // PrefixLabel
            // 
            this.PrefixLabel.AutoSize = true;
            this.PrefixLabel.Location = new System.Drawing.Point(126, 13);
            this.PrefixLabel.Name = "PrefixLabel";
            this.PrefixLabel.Size = new System.Drawing.Size(33, 13);
            this.PrefixLabel.TabIndex = 7;
            this.PrefixLabel.Text = "Prefix";
            // 
            // Suffix
            // 
            this.Suffix.Location = new System.Drawing.Point(13, 68);
            this.Suffix.Name = "Suffix";
            this.Suffix.Size = new System.Drawing.Size(260, 20);
            this.Suffix.TabIndex = 6;
            this.Suffix.TextChanged += new System.EventHandler(this.Suffix_TextChanged);
            // 
            // SuffixLabel
            // 
            this.SuffixLabel.AutoSize = true;
            this.SuffixLabel.Location = new System.Drawing.Point(126, 52);
            this.SuffixLabel.Name = "SuffixLabel";
            this.SuffixLabel.Size = new System.Drawing.Size(33, 13);
            this.SuffixLabel.TabIndex = 5;
            this.SuffixLabel.Text = "Suffix";
            // 
            // TwoFieldsCheck
            // 
            this.TwoFieldsCheck.AutoSize = true;
            this.TwoFieldsCheck.Location = new System.Drawing.Point(13, 94);
            this.TwoFieldsCheck.Name = "TwoFieldsCheck";
            this.TwoFieldsCheck.Size = new System.Drawing.Size(77, 17);
            this.TwoFieldsCheck.TabIndex = 10;
            this.TwoFieldsCheck.Text = "Two Fields";
            this.TwoFieldsCheck.UseVisualStyleBackColor = true;
            this.TwoFieldsCheck.CheckedChanged += new System.EventHandler(this.TwoFieldsCheck_CheckedChanged);
            // 
            // FilterAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 155);
            this.Controls.Add(this.TwoFieldsCheck);
            this.Controls.Add(this.AddFilterButton);
            this.Controls.Add(this.Prefix);
            this.Controls.Add(this.PrefixLabel);
            this.Controls.Add(this.Suffix);
            this.Controls.Add(this.SuffixLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FilterAdd_FormClosing);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 193);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 193);
            this.Name = "FilterAdd";
            this.ShowIcon = false;
            this.Text = "Filter Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddFilterButton;
        private System.Windows.Forms.TextBox Prefix;
        private System.Windows.Forms.Label PrefixLabel;
        private System.Windows.Forms.TextBox Suffix;
        private System.Windows.Forms.Label SuffixLabel;
        private System.Windows.Forms.CheckBox TwoFieldsCheck;
    }
}