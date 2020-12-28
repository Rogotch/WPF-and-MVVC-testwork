using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBaseWPF.Models
{
    public class Shop : INotifyPropertyChanged
    {
        private string _city;
        private string _name;
        private string[] _workers;

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string[] Workers
        {
            get { return _workers; }
            set
            {
                _workers = value;
                OnPropertyChanged("Workers");
            }
        }

        public Shop(string city, string name, params string[] workers)
        {
            City = city;
            Name = name;
            Workers = workers;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}