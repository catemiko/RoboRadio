using System.Windows.Forms;
using System.Diagnostics;
using System;

namespace RoboRadio.Windows
{
    
    using static RoboRadio.Program;

    public partial class InfoWindow : Form
    {
        public InfoWindow()
        {
            InitializeComponent();
        }

        private void InfoWindow_Load(object sender, EventArgs e)
        {
            AvatarBox.Image = Properties.Resources.Avatar;
            YearLabel.Text = String.Format("© 2017 - {0}", DateTime.Today.Year);
        }

        private void InfoWindow_FormClosing(object sender, EventArgs e)
        {
            MainWindowVirtual.Info.Enabled = true;
        }

        private void DonateButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.donationalerts.ru/c/xrobotx");
        }

        private void AvatarBox_Click(object sender, EventArgs e)
        {
            Process.Start("https://steamcommunity.com/id/pustokapusto");
        }
    }
}
