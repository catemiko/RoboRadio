namespace RoboRadio
{
    partial class RadioStationAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadioStationAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.Link = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Link";
            // 
            // Link
            // 
            this.Link.Location = new System.Drawing.Point(12, 69);
            this.Link.Name = "Link";
            this.Link.Size = new System.Drawing.Size(260, 20);
            this.Link.TabIndex = 1;
            this.Link.TextChanged += new System.EventHandler(this.Link_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(12, 30);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(260, 20);
            this.Description.TabIndex = 3;
            this.Description.TextChanged += new System.EventHandler(this.Description_TextChanged);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 105);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(260, 28);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RadioStationAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 145);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Link);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RadioStationAdd_FormClosing);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 183);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 183);
            this.Name = "RadioStationAdd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Station Add";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Link;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.Button AddButton;
    }
}