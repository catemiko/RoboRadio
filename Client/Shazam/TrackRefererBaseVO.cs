using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Shazam
{
    public abstract class TrackRefererBaseVO : ModelBase, IXmlSerializable
    {
        public const string TrackIdPropertyName = "TrackId";

        public const string TrackPropertyName = "Track";

        private int _TrackId;

        private TrackVO _Track;

        public int TrackId
        {
            get
            {
                return this._TrackId;
            }
            set
            {
                int trackId = this._TrackId;
                this._TrackId = value;
                base.NotifyPropertyChanged("TrackId");
                if (this._TrackId != trackId)
                {
                    this._Track = null;
                }
            }
        }

        public virtual TrackVO Track
        {
            get
            {
                if (this._Track == null)
                {
                    if (this.TrackId == 0)
                    {
                        return null;
                    }
                    this._Track = AppState.Instance.GetTrackById(this.TrackId);
                }
                return this._Track;
            }
            set
            {
                this._Track = value;
                base.NotifyPropertyChanged("Track");
            }
        }

        protected void ReadXml(XmlReader reader, XElement xRoot)
        {
            if (xRoot.Attribute("TrackId") != null)
            {
                this.TrackId = Convert.ToInt32(xRoot.Attribute("TrackId").Value);
            }
        }

        public abstract XmlSchema GetSchema();

        public virtual void ReadXml(XmlReader reader)
        {
            XElement root = XDocument.Load(reader).Root;
            this.ReadXml(reader, root);
        }

        public virtual void WriteXml(XmlWriter writer)
        {
            if (this.TrackId != 0)
            {
                writer.WriteAttributeString("TrackId", this.TrackId.ToString());
            }
        }
    }
}
