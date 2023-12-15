using De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp042.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp042.Services.MessageBus;
using De.HsFlensburg.ClientApp042.Services.SerializationService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.IO;
using System.Collections;
using System.Threading;
using System.Security.Cryptography;

namespace De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ModelFileHandler modelFileHandler;
        private string pathForSerialization;
        public ICommand FeedCommand { get; }

        public ICommand FeedStrawberryCommand { get; }
        public ICommand FeedBrocolliCommand { get; }
        public ICommand FeedCheeseCommand { get; }
        public ICommand FeedLollipopCommand { get; }

        public ICommand MedicinCommand { get; }
        public ICommand StartGameCommand { get; }
        public ICommand LowerCommand { get; }
        public ICommand HigherCommand { get; }

        public ICommand ResetCommand { get; }


        public TamagotchiViewModel MyTamagotchi { get; set; }
        public GameViewModel MyGame { get; set; }
       

        public MainWindowViewModel()
        {  
            modelFileHandler = new ModelFileHandler();
            //pathForSerialization = Environment.GetFolderPath(
            //Environment.SpecialFolder.MyDocuments) +
            //"\\ClientCollectionSerialization\\MyTamagotchi.cc";

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(workingDirectory, "..\\..\\..\\", "Logic.UI", "ViewModels", "Data", "MyTamagotchi.cc"));
            Console.WriteLine(projectDirectory);
            Console.WriteLine(Environment.GetFolderPath(
            Environment.SpecialFolder.MyDocuments) +
            "\\ClientCollectionSerialization\\MyTamagotchi.cc");

            pathForSerialization = projectDirectory;


            MyTamagotchi = new TamagotchiViewModel
            {
                Model = modelFileHandler.ReadModelFromFile(pathForSerialization)
            };

            MyGame = new GameViewModel();


            MedicinCommand = new RelayCommand(GiveMedicin);

            FeedStrawberryCommand = new RelayCommand(FeedStrawberry);
            FeedBrocolliCommand = new RelayCommand(FeedBrocolli);
            FeedCheeseCommand = new RelayCommand(FeedCheese);
            FeedLollipopCommand = new RelayCommand(FeedLollipop);

            StartGameCommand = new RelayCommand(StartGame);
            LowerCommand = new RelayCommand(LowerGuess);
            HigherCommand = new RelayCommand(HigherGuess);

            ResetCommand = new RelayCommand(ResetTamagotchi);

            CalculateData();
            UpdateTamagotchi();
            //MyTamagotchi.LoginTime = DateTime.Now;
        }

        private void UpdateTamagotchi()
        {
            CheckHealth();
            CheckData();
            SetImage();

            modelFileHandler.WriteModelToFile(
                pathForSerialization,
                MyTamagotchi.Model);

            Console.WriteLine("------ Update Tamagotchi ------");
            Console.WriteLine("Name: " + MyTamagotchi.Name);
            Console.WriteLine("Age: " + MyTamagotchi.Age);
            Console.WriteLine("LoginTime: " + MyTamagotchi.LoginTime);
            Console.WriteLine("Hunger: "+MyTamagotchi.Hunger);
            Console.WriteLine("Health: " + MyTamagotchi.Health);
            Console.WriteLine("Happiness: " + MyTamagotchi.Happiness);
            Console.WriteLine("InfoText: " + MyTamagotchi.InfoText);
            Console.WriteLine("Birthday: " + MyTamagotchi.Birthday);
        }

        
        private void FeedStrawberry()
        {
            if (MyTamagotchi.Hunger < 100)
            {
                MyTamagotchi.Hunger += 15;
                MyTamagotchi.Happiness += 5;
                MyTamagotchi.Health += 5;
                UpdateTamagotchi();
            }
        }

        private void FeedBrocolli()
        {
            if (MyTamagotchi.Hunger < 100)
            {
                MyTamagotchi.Hunger += 20;
                MyTamagotchi.Happiness += 5;
                MyTamagotchi.Health += 5;
                UpdateTamagotchi();
            }
        }

        private void FeedCheese()
        {
            if (MyTamagotchi.Hunger < 100)
            {
                MyTamagotchi.Hunger += 20;
                MyTamagotchi.Happiness += 5;
                MyTamagotchi.Health += 2;
                UpdateTamagotchi();
            }
        }

        private void FeedLollipop()
        {
            if (MyTamagotchi.Hunger < 100)
            {
                MyTamagotchi.Hunger += 10;
                MyTamagotchi.Happiness += 20;
                MyTamagotchi.Health -= 5;
                UpdateTamagotchi();
            }
        }
        private void GiveMedicin()
        {
            if (MyTamagotchi.Health < 50)
            {
                MyTamagotchi.Health = 100;
                MyTamagotchi.Happiness += 20;
                UpdateTamagotchi();
            }
        }

        private void SetImage()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(workingDirectory, "..\\..\\..\\", "Logic.UI", "ViewModels", "Images"));
            string imagePath = "tamagotchi_"+MyTamagotchi.Hunger+".png";
            string fullPath = Path.Combine(projectDirectory, imagePath);
            Console.WriteLine(fullPath);

            MyTamagotchi.TamagotchiImage = System.Drawing.Image.FromFile(fullPath);
        }

        private void ResetTamagotchi()
        {
            MyTamagotchi.Health = 0;
            MyTamagotchi.Hunger = 0;
            MyTamagotchi.Happiness = 0;
            UpdateTamagotchi();
        }


        private void CalculateData()
        {
            TimeSpan loginDifference = DateTime.Now.Subtract(MyTamagotchi.LoginTime);
            TimeSpan ageDifference = DateTime.Now.Subtract(MyTamagotchi.Birthday);
            int sinceLogin = (int)(loginDifference.TotalMinutes);

            //calculate age
            MyTamagotchi.Age = (int)(ageDifference.TotalDays);

            //calculate Health
            MyTamagotchi.Health -= (sinceLogin / 5);

            //calculate Hunger
            MyTamagotchi.Hunger -= (sinceLogin / 5);

            //calculate Happiness
            MyTamagotchi.Happiness -= (sinceLogin / 5);
        }

        private void CheckData()
        {
            MyTamagotchi.Health = MyTamagotchi.Health < 0 ? 0 : (MyTamagotchi.Health > 100 ? 100 : MyTamagotchi.Health);
            MyTamagotchi.Hunger = MyTamagotchi.Hunger < 0 ? 0 : (MyTamagotchi.Hunger > 100 ? 100 : MyTamagotchi.Hunger);
            MyTamagotchi.Hunger = 10 * (int)Math.Floor(MyTamagotchi.Hunger / 10.0);
            MyTamagotchi.Happiness = MyTamagotchi.Happiness < 0 ? 0 : (MyTamagotchi.Happiness > 100 ? 100 : MyTamagotchi.Happiness);
        }

        private void CheckHealth()
        {
            if (MyTamagotchi.Health < 20)
            {
                MyTamagotchi.InfoText = "Your Tamagotchi is sick!";
            }
            else
            {
                MyTamagotchi.InfoText = "Your Tamagotchi is healthy.";
            }
        }




        private void StartGame()
        {
            if (!MyGame.GameStarted)
            {
                MyGame.GameStarted = true;
                MyGame.Attempts = 5;
                MyGame.Points = 0;
                GenerateNumbers();
            }
        }

        private void LowerGuess()
        {
            if (MyGame.Attempts > 0 && MyGame.GameStarted == true)
            {
                if (MyGame.GenNumber > MyGame.NextNumber)
                {
                    MyGame.Points++;
                    MyTamagotchi.Happiness += 5;
                }
                MyGame.Attempts--;
                GenerateNumbers();
            } else
            {
                MyGame.GameStarted = false;
            }
        }

        private void HigherGuess()
        {
            if (MyGame.Attempts > 0 && MyGame.GameStarted == true)
            {
                if (MyGame.GenNumber < MyGame.NextNumber)
                {
                    MyGame.Points++;
                    MyTamagotchi.Happiness += 5;
                }
                MyGame.Attempts--;
                GenerateNumbers();
            } else
            {
                MyGame.GameStarted = false;
            }
        }


        public void GenerateNumbers()
        {
            Random rnd = new Random();
            MyGame.GenNumber = rnd.Next(1, 10);
            MyGame.NextNumber = rnd.Next(1, 10);
        
            while (MyGame.GenNumber == MyGame.NextNumber)
            {
                MyGame.NextNumber = rnd.Next(1, 10);
            }
            Console.WriteLine(MyGame.GenNumber);
            Console.WriteLine(MyGame.NextNumber);
            Console.WriteLine(MyGame.Attempts);
            Console.WriteLine(MyGame.Points);
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(
                    this,
                    new PropertyChangedEventArgs(propertyName));
        }
    }
}
