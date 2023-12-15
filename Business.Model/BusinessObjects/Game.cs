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


        public Game()
        { 
            var newGame = new Game();
            GenerateNumbers();

        }

        public void GenerateNumbers()
        {
            Random rnd = new Random();
            genNumber = rnd.Next(1, 10);
            nextNumber = rnd.Next(1, 10);

            while (genNumber == nextNumber)
            {
                nextNumber = rnd.Next(1, 10);
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
