using System.Windows.Forms;
using System.Drawing;
using System;

namespace RoboRadio
{
    
    using static RoboRadio.Program;

    using static OptionsController;


    public partial class OptionsMenu : Form
    {

        public OptionsMenu()
        {
            InitializeComponent();         
        }

        private void OptionsMenu_Load(object sender, EventArgs e)
        {
            if (MainWindowVirtual.visMode == "Default" || MainWindowVirtual.visMode == "Gradient")
                MainWindowVirtual.WTFMode = true;

            SaveStationOnExit.Checked = MainWindowVirtual.saveLastStation;
            SaveShazamOnExit.Checked = MainWindowVirtual.saveShazamState;

            if (MainWindowVirtual.visMode == "Gradient" || MainWindowVirtual.visMode == "RainbowGradient")
            EnableVisGradient.Checked = true;

            if (MainWindowVirtual.isTray)
                MinimizeTray.Checked = true;

            if (MainWindowVirtual.isTrayStart)
                TrayStart.Checked = true;

            if (MainWindowVirtual.showInfo)
                StartInfo.Checked = true;

            if (MainWindowVirtual.isRichPresence)
                RichPresenceSwitch.Checked = true;

            if (MainWindowVirtual.isFilteringEnabled)
                FilterSwitch.Checked = true;

            RandomVisColorButton.ForeColor = Color.FromArgb(MainWindowVirtual.random.Next(1, 255), MainWindowVirtual.random.Next(1, 255), MainWindowVirtual.random.Next(1, 255));
        }

        private void OptionsMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindowVirtual.Enabled = true;
            MainWindowVirtual.Activate();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            OptionsSave();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MainWindowVirtual.Enabled = true;
            MainWindowVirtual.Activate();

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            OptionsSave();
            this.Close();
            MainWindowVirtual.Enabled = true;
            MainWindowVirtual.Activate();
        }

        private void SaveStationOnExit_CheckedChanged(object sender, EventArgs e)
        {
            MainWindowVirtual.saveLastStation = SaveStationOnExit.Checked;
            if (!MainWindowVirtual.saveLastStation)
                MainWindowVirtual.lastStationNumber = -1;
        }

        private void SaveShazamOnExit_CheckedChanged(object sender, EventArgs e)
        {
            MainWindowVirtual.saveShazamState = SaveShazamOnExit.Checked;
        }

        private void ColorSelectButton_Click(object sender, EventArgs e)
        {
            DialogResult VisColorDialogResult = VisColorDialog.ShowDialog();

            if (VisColorDialogResult == DialogResult.OK)
                MainWindowVirtual.visColor = VisColorDialog.Color;
        }   

        private void EnableVisGradient_CheckedChanged(object sender, EventArgs e)
        {
            if (!MainWindowVirtual.WTFMode)
            {
                if (EnableVisGradient.Checked)
                    MainWindowVirtual.visMode = "RainbowGradient";
                else
                    MainWindowVirtual.visMode = "Rainbow";
            }
            
            else
            {
                if (EnableVisGradient.Checked)
                    MainWindowVirtual.visMode = "Gradient";
                else
                    MainWindowVirtual.visMode = "Default";
            }

        }

        private void RandomVisColorButton_Click(object sender, EventArgs e)
        {
            if (MainWindowVirtual.WTFMode)
            {
                if (EnableVisGradient.Checked)
                    MainWindowVirtual.visMode = "RainbowGradient";
                else
                    MainWindowVirtual.visMode = "Rainbow";
                MainWindowVirtual.WTFMode = false;
                return;
            }

            MainWindowVirtual.WTFMode = true;

            if (EnableVisGradient.Checked)
                MainWindowVirtual.visMode = "Gradient";
            else
                MainWindowVirtual.visMode = "Default";

        }

        private void MinimizeTray_CheckedChanged(object sender, EventArgs e)
        {
            MainWindowVirtual.isTray = MinimizeTray.Checked;
        }

        private void TrayStart_CheckedChanged(object sender, EventArgs e)
        {
            MainWindowVirtual.isTrayStart = TrayStart.Checked;
        }

        private void StartInfo_CheckedChanged(object sender, EventArgs e)
        {
            MainWindowVirtual.showInfo = StartInfo.Checked;
        }

        private void RichPresenceSwitch_CheckedChanged(object sender, EventArgs e)
        {
            MainWindowVirtual.isRichPresence = RichPresenceSwitch.Checked;
        }

        private void FilterSwitch_CheckedChanged(object sender, EventArgs e)
        {
            MainWindowVirtual.isFilteringEnabled = FilterSwitch.Checked;
        }
    }
}
 