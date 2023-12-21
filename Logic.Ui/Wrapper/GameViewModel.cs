using De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp042.Logic.Ui.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp042.Logic.Ui.Wrapper
{
    public class GameViewModel : ViewModelBase<Game>
    {
        public int GenNumber { get { return Model.GenNumber; } set { Model.GenNumber = value; OnPropertyChanged("GenNumber"); } }

        public int NextNumber { get { return Model.NextNumber; } set { Model.NextNumber = value; OnPropertyChanged("NextNumber"); } }

        public int Attempts { get { return Model.Attempts; } set { Model.Attempts = value; OnPropertyChanged("Attempts"); } }
        public Boolean GameStarted { get { return Model.GameStarted; } set { Model.GameStarted = value; OnPropertyChanged("GameStarted"); } }
        public int Points { get { return Model.Points; } set { Model.Points = value; OnPropertyChanged("Points"); } }
        private TamagotchiViewModel MyTamagotchi;

        public override void NewModelAssigned()
        {
            throw new NotImplementedException();
        }

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
