using System.Windows.Forms;
using System.Xml;
using System;

namespace RoboRadio.Windows
{
    using static RoboRadio.Program;

    public partial class FilterAdd : Form
    {
        public FilterAdd()
        {
            InitializeComponent();
            AddFilterButton.Enabled = false;
        }

        private void AddFilter()
        {
            XmlDocument filtersListXml = new XmlDocument();
            filtersListXml.Load("Filters/Filters.xml");
            XmlElement xRoot = filtersListXml.DocumentElement;
            XmlElement filter = filtersListXml.CreateElement("filter");
            XmlElement filterPrefix = filtersListXml.CreateElement("prefix");
            XmlElement filterSuffix = filtersListXml.CreateElement("suffix");
            XmlAttribute isTwoFieldsXml = filtersListXml.CreateAttribute("IsTwoFields");
            XmlText isTwoFieldsXmlBool = filtersListXml.CreateTextNode(Convert.ToString(TwoFieldsCheck.Checked));
            XmlText prefixText = filtersListXml.CreateTextNode(Prefix.Text);
            XmlText suffixText = filtersListXml.CreateTextNode(Suffix.Text);

            isTwoFieldsXml.AppendChild(isTwoFieldsXmlBool);
            filter.Attributes.Append(isTwoFieldsXml);
            filterPrefix.AppendChild(prefixText);
            filterSuffix.AppendChild(suffixText);
            filter.AppendChild(filterPrefix);
            filter.AppendChild(filterSuffix);

            

            xRoot.AppendChild(filter);
            filtersListXml.Save("Filters/Filters.xml");

            Filter newFilter = new Filter();

            newFilter.title = Prefix.Text;
            newFilter.artist = Suffix.Text;
            newFilter.isTwoFields = TwoFieldsCheck.Checked;

            FiltersList.filtersListXML.Add(newFilter);
        }

        private void Prefix_TextChanged(object sender, EventArgs e)
        {         
            Functions.FilterStringCheck(Prefix, Suffix, TwoFieldsCheck.Checked, AddFilterButton);
        }

        private void Suffix_TextChanged(object sender, EventArgs e)
        {
            Functions.FilterStringCheck(Prefix, Suffix, TwoFieldsCheck.Checked, AddFilterButton);
        }

        private void AddFilterButton_Click(object sender, EventArgs e)
        {
            Prefix.Text = Prefix.Text.Replace("'", " ");

            AddFilter();
            this.Close();
        }

        private void TwoFieldsCheck_CheckedChanged(object sender, EventArgs e)
        {
            Functions.FilterStringCheck(Prefix, Suffix, TwoFieldsCheck.Checked, AddFilterButton);

            if (TwoFieldsCheck.Checked)
            {
                PrefixLabel.Text = "Title Filter";
                SuffixLabel.Text = "Artist Filter";
            }
            else
            {
                PrefixLabel.Text = "Prefix";
                SuffixLabel.Text = "Suffix";
            }
        }

        private void FilterAdd_FormClosing(object senderm, FormClosingEventArgs e)
        {
            MainWindowVirtual.AddFilter.Enabled = true;
            MainWindowVirtual.DeleteFilter.Enabled = true;
        }
    }
}
