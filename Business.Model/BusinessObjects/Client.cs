using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects
{
    [Serializable]
    public class Client : INotifyPropertyChanged
    {
        private int id;
        public int Id {
            get {
                return id;
            }
            
            set {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string name;

        public String Name {
            get
            {
                return name;
            }
            
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(
                    this,
                    new PropertyChangedEventArgs(propertyName));
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
