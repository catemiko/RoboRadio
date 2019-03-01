using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace RoboRadio
{
   public static class FiltersList
    {
        public static List<Filter> filtersListXML = new List<Filter>();

        public static void FiltersLoad()
        {

            if (!Directory.Exists("Filters"))
                Directory.CreateDirectory("Filters");

            if (!File.Exists("Filters/Filters.xml"))
                File.AppendAllText("Filters/Filters.xml", Properties.Resources.Filters);

            XmlDocument filters = new XmlDocument();

            try
            {
                filters.Load("Filters/Filters.xml");
            }

            catch (FileNotFoundException)
            {
                MessageBox.Show("'Filters.xml' file missing!");
                File.Create("Filters/Filters.xml");
                return;
            }

            catch (XmlException)
            {
                MessageBox.Show("'Filters.xml' empty!");
                File.AppendAllText("Filters/Filters.xml", Properties.Resources.Filters);
                return;
            }

            XmlElement xRoot = filters.DocumentElement;

            foreach (XmlNode xNode in xRoot)
            {
                Filter filter = new Filter();

                XmlNode IsTwoFieldsBool = xNode.Attributes.GetNamedItem("IsTwoFields");
                if (IsTwoFieldsBool != null)
                    filter.isTwoFields = Convert.ToBoolean(IsTwoFieldsBool.InnerText);

                foreach (XmlNode ChildNode in xNode.ChildNodes)
                {

                    if (ChildNode.Name == "prefix")
                    {
                        filter.title = ChildNode.InnerText;
                    }

                    if (ChildNode.Name == "suffix")
                    {
                        filter.artist = ChildNode.InnerText;
                    }
                }

                filtersListXML.Add(filter);
            }
        }

        public static void FiltersReload()
        {

        }
    }
}
