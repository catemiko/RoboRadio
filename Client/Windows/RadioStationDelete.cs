using System.Windows.Forms;
using System.Xml;
using System;

namespace RoboRadio
{
    using static RoboRadio.Program;

    public partial class RadioStationDelete : Form
    {
        
        public RadioStationDelete()
        {
            InitializeComponent();          
        }

        private void DeleteStation()
        {
            XmlDocument StationsListXml = new XmlDocument();
            StationsListXml.Load("Stations/Stations.xml");
            string StationName =  StationsList.SelectedItem.ToString();
            XmlNode xNode = StationsListXml.SelectSingleNode(string.Format("//station[@name = '{0}']", StationName));
            xNode.ParentNode.RemoveChild(xNode);
            StationsListXml.Save("Stations/Stations.xml");
            MainWindowVirtual.RadioStation.Items.Remove(StationName);
            StationsList.Items.Remove(StationName);
        }

        private void RadioStationDelete_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < MainWindowVirtual.RadioStation.Items.Count; i++)
            {
                StationsList.Items.Add(MainWindowVirtual.RadioStation.Items[i]);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteStation();
            this.Close();
        }

        private void RadioStationDelete_FormClosing(object senderm, FormClosingEventArgs e)
        {
            MainWindowVirtual.AddStation.Enabled = true;
            MainWindowVirtual.DeleteStation.Enabled = true;
        }
    }
}
