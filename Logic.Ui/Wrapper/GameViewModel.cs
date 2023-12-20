﻿using De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects;
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

        public override void NewModelAssigned()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            Model.StartGame();
        }

        public void LowerGuess()
        {
            Model.StartGame();
        }

        public void HigherGuess()
        {
            Model.StartGame();
        }
    }
}
