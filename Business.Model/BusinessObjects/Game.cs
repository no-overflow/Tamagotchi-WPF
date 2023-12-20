using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
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

        private Tamagotchi MyTamagotchi;

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


        public void StartGame()
        {
            if (!GameStarted)
            {
                GameStarted = true;
                Attempts = 5;
                Points = 0;
                GenerateNumbers();
            }
        }

        public void LowerGuess()
        {
            if (Attempts > 0 && GameStarted == true)
            {
                if (GenNumber > NextNumber)
                {
                    Points++;
                    MyTamagotchi.Happiness += 5;
                }
                Attempts--;
                GenerateNumbers();
            }
            else
            {
                GameStarted = false;
            }
        }

        public void HigherGuess()
        {
            if (Attempts > 0 && GameStarted == true)
            {
                if (GenNumber < NextNumber)
                {
                    Points++;
                    MyTamagotchi.Happiness += 5;
                }
                Attempts--;
                GenerateNumbers();
            }
            else
            {
                GameStarted = false;
            }
        }


        private void GenerateNumbers()
        {
            Random rnd = new Random();
            GenNumber = rnd.Next(1, 10);
            NextNumber = rnd.Next(1, 10);

            while (GenNumber == NextNumber)
            {
                NextNumber = rnd.Next(1, 10);
            }
            Console.WriteLine(GenNumber);
            Console.WriteLine(NextNumber);
            Console.WriteLine(Attempts);
            Console.WriteLine(Points);
        }
    }
}
