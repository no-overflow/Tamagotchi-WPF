using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects
{
    [Serializable]
    public class Game : INotifyPropertyChanged
    {
        private int genNumber;
        public int GenNumber { get { return genNumber; } set { genNumber = value; OnPropertyChanged("GenNumber"); } }

        private int nextNumber;
        public int NextNumber { get { return nextNumber; } set { nextNumber = value; OnPropertyChanged("NextNumber"); } }

        private int attempts;
        public int Attempts { get { return attempts; } set { attempts = value; OnPropertyChanged("Attempts"); } }

        private bool gameStarted;
        public Boolean GameStarted { get { return gameStarted; } set { gameStarted = value; OnPropertyChanged("GameStarted"); } }

        private int points;
        public int Points { get { return points; } set { points = value; OnPropertyChanged("Points"); } }


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
