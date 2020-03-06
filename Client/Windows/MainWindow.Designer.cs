using System.Windows.Forms;

namespace RoboRadio
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>


        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.VolumeBox = new System.Windows.Forms.TextBox();
            this.RadioStation = new System.Windows.Forms.ComboBox();
            this.PlayButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.Artist = new System.Windows.Forms.Label();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.ArtistBox = new System.Windows.Forms.TextBox();
            this.StartShazam = new System.Windows.Forms.Button();
            this.ShazamTimer = new System.Windows.Forms.Timer(this.components);
            this.RecordTimer = new System.Windows.Forms.Timer(this.components);
            this.ShazamProgress = new System.Windows.Forms.ProgressBar();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.Stations = new System.Windows.Forms.ToolStripMenuItem();
            this.AddStation = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteStation = new System.Windows.Forms.ToolStripMenuItem();
            this.RandomStation = new System.Windows.Forms.ToolStripMenuItem();
            this.Filters = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.EnableShazam = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.EnableVisualizationButton = new System.Windows.Forms.ToolStripMenuItem();
            this.Info = new System.Windows.Forms.ToolStripMenuItem();
            this.FrameCounter = new System.Windows.Forms.Timer(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShazamTray = new System.Windows.Forms.ToolStripMenuItem();
            this.VisTray = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitTray = new System.Windows.Forms.ToolStripMenuItem();
            this.RPCUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            this.Menu.SuspendLayout();
            this.TrayMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // VolumeBar
            // 
            resources.ApplyResources(this.VolumeBar, "VolumeBar");
            this.VolumeBar.Maximum = 100;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.TabStop = false;
            this.VolumeBar.TickFrequency = 2;
            this.VolumeBar.Scroll += new System.EventHandler(this.Volume_Scroll);
            // 
            // VolumeBox
            // 
            resources.ApplyResources(this.VolumeBox, "VolumeBox");
            this.VolumeBox.Name = "VolumeBox";
            this.VolumeBox.ReadOnly = true;
            this.VolumeBox.TabStop = false;
            // 
            // RadioStation
            // 
            resources.ApplyResources(this.RadioStation, "RadioStation");
            this.RadioStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RadioStation.FormattingEnabled = true;
            this.RadioStation.Name = "RadioStation";
            this.RadioStation.TabStop = false;
            this.RadioStation.SelectedIndexChanged += new System.EventHandler(this.RadioStation_SelectedIndexChanged);
            this.RadioStation.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.RadioStation_MouseWheel);
            // 
            // PlayButton
            // 
            resources.ApplyResources(this.PlayButton, "PlayButton");
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // Title
            // 
            resources.ApplyResources(this.Title, "Title");
            this.Title.Name = "Title";
            // 
            // Artist
            // 
            resources.ApplyResources(this.Artist, "Artist");
            this.Artist.Name = "Artist";
            // 
            // TitleBox
            // 
            resources.ApplyResources(this.TitleBox, "TitleBox");
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.ReadOnly = true;
            // 
            // ArtistBox
            // 
            resources.ApplyResources(this.ArtistBox, "ArtistBox");
            this.ArtistBox.Name = "ArtistBox";
            this.ArtistBox.ReadOnly = true;
            // 
            // StartShazam
            // 
            resources.ApplyResources(this.StartShazam, "StartShazam");
            this.StartShazam.Name = "StartShazam";
            this.StartShazam.UseVisualStyleBackColor = true;
            this.StartShazam.Click += new System.EventHandler(this.StartShazam_Click);
            // 
            // ShazamTimer
            // 
            this.ShazamTimer.Interval = 10000;
            this.ShazamTimer.Tick += new System.EventHandler(this.ShazamTimer_Stop);
            // 
            // RecordTimer
            // 
            this.RecordTimer.Interval = 1000;
            this.RecordTimer.Tick += new System.EventHandler(this.RecordTimer_Tick);
            // 
            // ShazamProgress
            // 
            resources.ApplyResources(this.ShazamProgress, "ShazamProgress");
            this.ShazamProgress.Maximum = 900;
            this.ShazamProgress.Name = "ShazamProgress";
            this.ShazamProgress.Step = 100;
            this.ShazamProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.Menu, "Menu");
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Stations,
            this.Filters,
            this.Settings,
            this.Info});
            this.Menu.Name = "Menu";
            // 
            // Stations
            // 
            this.Stations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddStation,
            this.DeleteStation,
            this.RandomStation});
            this.Stations.Name = "Stations";
            resources.ApplyResources(this.Stations, "Stations");
            // 
            // AddStation
            // 
            this.AddStation.Name = "AddStation";
            resources.ApplyResources(this.AddStation, "AddStation");
            this.AddStation.Click += new System.EventHandler(this.AddStation_Click);
            // 
            // DeleteStation
            // 
            this.DeleteStation.Name = "DeleteStation";
            resources.ApplyResources(this.DeleteStation, "DeleteStation");
            this.DeleteStation.Click += new System.EventHandler(this.DeleteStationMenuItem_Click);
            // 
            // RandomStation
            // 
            this.RandomStation.Name = "RandomStation";
            resources.ApplyResources(this.RandomStation, "RandomStation");
            this.RandomStation.Click += new System.EventHandler(this.RandomStation_Click);
            // 
            // Filters
            // 
            this.Filters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFilter,
            this.DeleteFilter});
            this.Filters.Name = "Filters";
            resources.ApplyResources(this.Filters, "Filters");
            // 
            // AddFilter
            // 
            this.AddFilter.Name = "AddFilter";
            resources.ApplyResources(this.AddFilter, "AddFilter");
            this.AddFilter.Click += new System.EventHandler(this.AddFilter_Click);
            // 
            // DeleteFilter
            // 
            this.DeleteFilter.Name = "DeleteFilter";
            resources.ApplyResources(this.DeleteFilter, "DeleteFilter");
            this.DeleteFilter.Click += new System.EventHandler(this.DeleteFilter_Click);
            // 
            // Settings
            // 
            this.Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EnableShazam,
            this.OptionsButton,
            this.EnableVisualizationButton});
            this.Settings.Name = "Settings";
            resources.ApplyResources(this.Settings, "Settings");
            // 
            // EnableShazam
            // 
            this.EnableShazam.Name = "EnableShazam";
            resources.ApplyResources(this.EnableShazam, "EnableShazam");
            this.EnableShazam.Click += new System.EventHandler(this.EnableShazam_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.Name = "OptionsButton";
            resources.ApplyResources(this.OptionsButton, "OptionsButton");
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // EnableVisualizationButton
            // 
            this.EnableVisualizationButton.Name = "EnableVisualizationButton";
            resources.ApplyResources(this.EnableVisualizationButton, "EnableVisualizationButton");
            this.EnableVisualizationButton.Click += new System.EventHandler(this.EnableVisualizationButton_Click);
            // 
            // Info
            // 
            this.Info.Name = "Info";
            resources.ApplyResources(this.Info, "Info");
            this.Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // FrameCounter
            // 
            this.FrameCounter.Interval = 1000;
            this.FrameCounter.Tick += new System.EventHandler(this.FrameCounter_Tick);
            // 
            // NotifyIcon
            // 
            resources.ApplyResources(this.NotifyIcon, "NotifyIcon");
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // TrayMenu
            // 
            this.TrayMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShazamTray,
            this.VisTray,
            this.ExitTray});
            this.TrayMenu.Name = "TrayMenu";
            resources.ApplyResources(this.TrayMenu, "TrayMenu");
            // 
            // ShazamTray
            // 
            this.ShazamTray.Name = "ShazamTray";
            resources.ApplyResources(this.ShazamTray, "ShazamTray");
            this.ShazamTray.Click += new System.EventHandler(this.ShazamTray_Click);
            // 
            // VisTray
            // 
            this.VisTray.Name = "VisTray";
            resources.ApplyResources(this.VisTray, "VisTray");
            this.VisTray.Click += new System.EventHandler(this.VisTray_Click);
            // 
            // ExitTray
            // 
            this.ExitTray.Name = "ExitTray";
            resources.ApplyResources(this.ExitTray, "ExitTray");
            this.ExitTray.Click += new System.EventHandler(this.ExitTray_Click);
            // 
            // RPCUpdateTimer
            // 
            this.RPCUpdateTimer.Interval = 15000;
            this.RPCUpdateTimer.Tick += new System.EventHandler(this.RPCUpdateTimer_Tick);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 1000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.VolumeBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.VolumeBar, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.ShazamProgress, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.StartShazam, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.ArtistBox, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.Artist, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.TitleBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.RadioStation, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.PlayButton, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.Title, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Menu);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KeyPreview = true;
            this.MainMenuStrip = this.Menu;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.TrayMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Artist;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.TextBox ArtistBox;
        private System.Windows.Forms.Button StartShazam;
        private System.Windows.Forms.Timer ShazamTimer;
        private System.Windows.Forms.Timer RecordTimer;
        private System.Windows.Forms.ProgressBar ShazamProgress;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem Settings;
        private System.Windows.Forms.ToolStripMenuItem RandomStation;
        private System.Windows.Forms.ToolStripMenuItem EnableShazam;
        private System.Windows.Forms.Timer FrameCounter;
        private System.Windows.Forms.ToolStripMenuItem OptionsButton;
        public System.Windows.Forms.TrackBar VolumeBar;
        public System.Windows.Forms.TextBox VolumeBox;
        public System.Windows.Forms.ComboBox RadioStation;
        public System.Windows.Forms.ToolStripMenuItem EnableVisualizationButton;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.ToolStripMenuItem ShazamTray;
        private System.Windows.Forms.ToolStripMenuItem ExitTray;
        public System.Windows.Forms.ToolStripMenuItem VisTray;
        public System.Windows.Forms.ToolStripMenuItem Info;
        private System.Windows.Forms.Timer RPCUpdateTimer;
        private System.Windows.Forms.Timer UpdateTimer;
        public System.Windows.Forms.ToolStripMenuItem AddStation;
        public System.Windows.Forms.ToolStripMenuItem DeleteStation;
        public System.Windows.Forms.ToolStripMenuItem AddFilter;
        public System.Windows.Forms.ToolStripMenuItem DeleteFilter;
        public System.Windows.Forms.ToolStripMenuItem Stations;
        public System.Windows.Forms.ToolStripMenuItem Filters;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}