using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Client.Shazam
{
    [XmlRoot("AddOn")]
    public class AddOnVO : ModelBase, IXmlSerializable
    {
        public enum AddOnType
        {
            UrlType,
            ShazamUrlType,
            LaunchType
        }

        public const string ElementName = "AddOn";

        public const string CaptionPropertyName = "Caption";

        public const string UrlPropertyName = "Url";

        public const string TypePropertyName = "Type";

        public const string ProviderNamePropertyName = "ProviderName";

        public const string TypeIdPropertyName = "TypeId";

        public const string CreditTypeIdPropertyName = "CreditTypeId";

        public const string ImageUriPropertyName = "ImageUri";

        public const string ActionsPropertyName = "Actions";

        private string _Caption;

        private string _Url;

        private AddOnType _Type;

        private string _ProviderName;

        private int _TypeId;

        private int _CreditTypeId;

        private string _ImageUri;

        private List<AddOnActionVO> _Actions;

        private TrackVO _OwnerTrack;

        public string Caption
        {
            get
            {
                return this._Caption;
            }
            set
            {
                this._Caption = value;
                base.NotifyPropertyChanged("Caption");
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

        public AddOnType Type
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

        public string ProviderName
        {
            get
            {
                return this._ProviderName;
            }
            set
            {
                this._ProviderName = value;
                base.NotifyPropertyChanged("ProviderName");
            }
        }

        public int TypeId
        {
            get
            {
                return this._TypeId;
            }
            set
            {
                this._TypeId = value;
                base.NotifyPropertyChanged("TypeId");
            }
        }

        public int CreditTypeId
        {
            get
            {
                return this._CreditTypeId;
            }
            set
            {
                this._CreditTypeId = value;
                base.NotifyPropertyChanged("CreditTypeId");
            }
        }

        public string ImageUri
        {
            get
            {
                return this._ImageUri;
            }
            set
            {
                this._ImageUri = value;
                base.NotifyPropertyChanged("ImageUri");
            }
        }

        public List<AddOnActionVO> Actions
        {
            get
            {
                return this._Actions;
            }
            set
            {
                this._Actions = value;
                base.NotifyPropertyChanged("Actions");
            }
        }

        public TrackVO OwnerTrack
        {
            get
            {
                return this._OwnerTrack;
            }
        }

        public void AssociateOwnerTrack(TrackVO track)
        {
            this._OwnerTrack = track;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XElement root = XDocument.Load(reader).Root;
            this.Caption = root.Attribute("Caption").Value;
            if (root.Attribute("Url") != null)
            {
                this.Url = root.Attribute("Url").Value;
            }
            if (root.Attribute("Type") != null)
            {
                this.Type = (AddOnType)Enum.Parse(typeof(AddOnType), root.Attribute("Type").Value, true);
            }
            if (root.Attribute("ProviderName") != null)
            {
                this.ProviderName = root.Attribute("ProviderName").Value;
            }
            this.TypeId = short.Parse(root.Attribute("TypeId").Value);
            if (root.Attribute("CreditTypeId") != null)
            {
                this.CreditTypeId = short.Parse(root.Attribute("CreditTypeId").Value);
            }
            else
            {
                this.CreditTypeId = 0;
            }
            if (root.Attribute("ImageUri") != null)
            {
                this.ImageUri = root.Attribute("ImageUri").Value;
            }
            if (root.Element("Actions") != null)
            {
                this.Actions = new List<AddOnActionVO>();
                foreach (XElement item2 in root.Element("Actions").Elements("AddOnAction"))
                {
                    AddOnActionVO item = new XmlSerializer(typeof(AddOnActionVO)).Deserialize(new StringReader(item2.ToString())) as AddOnActionVO;
                    this.Actions.Add(item);
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Caption", this.Caption);
            writer.WriteAttributeString("ProviderName", this.ProviderName);
            writer.WriteAttributeString("TypeId", this.TypeId.ToString());
            if (this.CreditTypeId != 0)
            {
                writer.WriteAttributeString("CreditTypeId", this.CreditTypeId.ToString());
            }
            if (!string.IsNullOrEmpty(this.ImageUri))
            {
                writer.WriteAttributeString("ImageUri", this.ImageUri);
            }
            if (this.Actions != null)
            {
                writer.WriteStartElement("Actions");
                foreach (AddOnActionVO action in this.Actions)
                {
                    new XmlSerializer(typeof(AddOnActionVO)).Serialize(writer, action);
                }
                writer.WriteEndElement();
            }
        }
    }
}
