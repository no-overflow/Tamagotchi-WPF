using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects
{
    [Serializable]
    public class Colors : INotifyPropertyChanged
    {
        private string tamagotchiColor;
        public String TamagotchiColor { get { return tamagotchiColor; } set { tamagotchiColor = value; OnPropertyChanged("TamagotchiColor"); } }

        private string backgroundColor;
        public String BackgroundColor { get { return backgroundColor; } set { backgroundColor = value; OnPropertyChanged("BackgroundColor"); } }
        private string buttonColor;
        public String ButtonColor { get { return buttonColor; } set { buttonColor = value; OnPropertyChanged("ButtonColor"); } }



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
