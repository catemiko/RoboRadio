using System.Windows.Forms;
using System.Xml;
using System;

namespace RoboRadio
{
    using static RoboRadio.Program;

    public partial class RadioStationAdd : Form
    {
        
        public RadioStationAdd()
        {
            InitializeComponent();
            AddButton.Enabled = false;
        }

        private void AddStation()
        {
            XmlDocument StationsList = new XmlDocument();
            StationsList.Load("Stations/Stations.xml");
            XmlElement xRoot = StationsList.DocumentElement;
            XmlElement Station = StationsList.CreateElement("station");
            XmlAttribute Name = StationsList.CreateAttribute("name");
            XmlElement StLink = StationsList.CreateElement("link");
            XmlText StationName = StationsList.CreateTextNode(Description.Text);
            XmlText StationLink = StationsList.CreateTextNode(Link.Text);

            Name.AppendChild(StationName);
            StLink.AppendChild(StationLink);
            Station.Attributes.Append(Name);
            Station.AppendChild(StLink);
            xRoot.AppendChild(Station);
            StationsList.Save("Stations/Stations.xml");
            MainWindowVirtual.RadioStation.Items.Add(Description.Text);

            RoboRadio.StationsList.StationsLoad();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddStation();
            this.Close();
        }

        private void Link_TextChanged(object sender, EventArgs e)
        {
            Functions.StationStringCheck(Description, Link, AddButton);
        }

        private void Description_TextChanged(object sender, EventArgs e)
        {
            Functions.StationStringCheck(Description, Link, AddButton);
        }

        private void RadioStationAdd_FormClosing(object senderm, FormClosingEventArgs e)
        {
            MainWindowVirtual.AddStation.Enabled = true;
            MainWindowVirtual.DeleteStation.Enabled = true;
        }
    }
}
