using System.Xml.Serialization;
using SharedCoreLib.Models.VO;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Xml;
using System;



namespace Client.Shazam
{
    [XmlRoot("TagVO")]
    public class TagVO : TrackRefererBaseVO
    {
        public const string ElementName = "TagVO";

        public const string IdPropertyName = "Id";

        public const string DatePropertyName = "Date";

        private string _Id;

        private DateTime _Date;

        public string Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
                base.NotifyPropertyChanged("Id");
            }
        }

        public DateTime Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                this._Date = value;
                base.NotifyPropertyChanged("Date");
            }
        }

        public TagVO()
        {
            this._Date = DateTime.Now.ToUniversalTime();
        }

        public override XmlSchema GetSchema()
        {
            return null;
        }

        public override void ReadXml(XmlReader reader)
        {
            XElement root = XDocument.Load(reader).Root;
            this.Id = root.Attribute("Id").Value;
            this.Date = DateTime.Parse(root.Attribute("Date").Value).ToUniversalTime();
            base.ReadXml(reader, root);
        }

        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Id", this.Id);
            writer.WriteAttributeString("Date", this.Date.ToString("o"));
            base.WriteXml(writer);
        }
    }
}
