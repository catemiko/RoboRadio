using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Client.Shazam
{
    [XmlRoot("AddOnAction")]
    public class AddOnActionVO : ModelBase, IXmlSerializable
    {
        public enum ActionType
        {
            LaunchUri,
            WebView
        }

        public const string ElementName = "AddOnAction";

        public const string UrlPropertyName = "Url";

        public const string TypePropertyName = "Type";

        public const string LaunchUriTaskPropertyName = "LaunchUriTask";

        public const string WebViewTaskPropertyName = "WebViewTask";

        private ActionType _Type;

        private string _Url;

        public ActionType Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                this._Type = value;
                base.NotifyPropertyChanged("Type");
            }
        }

        public string Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                this._Url = value;
                base.NotifyPropertyChanged("Url");
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XElement root = XDocument.Load(reader).Root;
            this.Url = root.Attribute("Url").Value;
            this.Type = (ActionType)Enum.Parse(typeof(ActionType), root.Attribute("Type").Value, true);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Url", this.Url);
            writer.WriteAttributeString("Type", this.Type.ToString());
        }
    }
}
