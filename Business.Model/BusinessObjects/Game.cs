using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects
{
    public class Game
    {
        private int genNumber;
        public int GenNumber { get { return genNumber; } set { genNumber = value; } }

        private int nextNumber;
        public int NextNumber { get { return nextNumber; } set { nextNumber = value; } }



        
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
        public bool IsGenNumberLower()
        {
            return (genNumber < nextNumber);
        }
    }
}
