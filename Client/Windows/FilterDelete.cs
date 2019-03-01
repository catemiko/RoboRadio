using System.Windows.Forms;
using System.Xml;
using System;

namespace RoboRadio.Windows
{
    using static RoboRadio.Program;

    public partial class FilterDelete : Form
    {
        public FilterDelete()
        {
            InitializeComponent();
        }

        private void DeleteFilter()
        {
            XmlDocument filtersListXml = new XmlDocument();
            filtersListXml.Load("Filters/Filters.xml");
            int filterId = FiltersListBox.SelectedIndex;

            XmlNode xNode = filtersListXml.SelectSingleNode(String.Format("//filter[prefix = '{0}']", FiltersList.filtersListXML[filterId].title));
            xNode.ParentNode.RemoveChild(xNode);          
            filtersListXml.Save("Filters/Filters.xml");

            FiltersList.filtersListXML.RemoveAt(filterId);
            FiltersListBox.Items.RemoveAt(filterId);
        }

        private void FilterDelete_Load(object sender, EventArgs e)
        {
            FiltersListBox.Items.Clear();

            for (int i = 0; i < FiltersList.filtersListXML.Count ; i++)
            {
                FiltersListBox.Items.Add(String.Format(@"""{0}"", ""{1}""", FiltersList.filtersListXML[i].title, FiltersList.filtersListXML[i].artist));
            }
        }

        private void DeleteFilterButton_Click(object sender, EventArgs e)
        {
                DeleteFilter();
                this.Close();      
        }

        private void FilterDelete_FormClosing(object senderm, FormClosingEventArgs e)
        {
            MainWindowVirtual.AddFilter.Enabled = true;
            MainWindowVirtual.DeleteFilter.Enabled = true;
        }
    }
}
