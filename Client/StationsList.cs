using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace RoboRadio
{
    public static class StationsList

    {
        public static List<Station> stationsListXML = new List<Station>();

        public static void StationsLoad()
        {
      
            if (!Directory.Exists("Stations"))
                  Directory.CreateDirectory("Stations");

            if(!File.Exists("Stations/Stations.xml"))
            File.AppendAllText("Stations/Stations.xml", Properties.Resources.Stations);

        XmlDocument stations = new XmlDocument();

            try
            {
                stations.Load("Stations/Stations.xml");
            }

            catch (FileNotFoundException)
            {
                MessageBox.Show("'Stations.xml' file missing!");
                File.Create("Stations/Stations.xml");
                return;
            }

            catch (XmlException)
            {
                MessageBox.Show("'Stations.xml' empty!");
                File.AppendAllText("Stations/Stations.xml", Properties.Resources.Stations);
                return;
            }

            XmlElement xRoot = stations.DocumentElement;

            foreach (XmlNode xNode in xRoot)
            {
                Station station = new Station();

                XmlNode stationName = xNode.Attributes.GetNamedItem("name");
                if (stationName != null)
                station.name = stationName.InnerText;



                foreach (XmlNode ChildNode in xNode.ChildNodes)
                {
                    if (ChildNode.Name == "link")
                    {
                        station.link = ChildNode.InnerText;
                    }
                }

                stationsListXML.Add(station);
            }
        }
    }
}

   

