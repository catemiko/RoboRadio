using System.ComponentModel;


namespace Client.Shazam
{
    public abstract class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate
        {
        };

        public ModelBase()
        {
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
