using De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp042.Logic.Ui.MessageBusMessages;
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

namespace De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ModelFileHandler modelFileHandler;
        private string pathForSerialization;
        public ICommand FeedCommand { get; }
        public ICommand MedicinCommand { get; }

        public ICommand ResetCommand { get; }


        public TamagotchiViewModel MyTamagotchi { get; set; }
       

        public MainWindowViewModel()
        {  
            modelFileHandler = new ModelFileHandler();
            pathForSerialization = Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments) +
                "\\ClientCollectionSerialization\\MyTamagotchi.cc";


            MyTamagotchi = new TamagotchiViewModel
            {
                Model = modelFileHandler.ReadModelFromFile(pathForSerialization)
            };


            FeedCommand = new RelayCommand(FeedTamagotchi);
            MedicinCommand = new RelayCommand(GiveMedicin);
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

        private void FeedTamagotchi()
        {
            if (MyTamagotchi.Hunger < 100)
            {
                MyTamagotchi.Hunger += 10;
                MyTamagotchi.Happiness += 5;
                UpdateTamagotchi();
            }
        }

        private void GiveMedicin()
        {
            if (MyTamagotchi.Health < 50)
            {
                MyTamagotchi.Health = 100;
                MyTamagotchi.Happiness += 50;
                UpdateTamagotchi();

            }
        }

        private void SetImage()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(workingDirectory, "..\\..\\..\\", "Logic.UI", "ViewModels", "Images"));
            string imagePath = "tamagotchi_"+MyTamagotchi.Hunger+".png";
            string fullPath = Path.Combine(projectDirectory, imagePath);

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
            Console.WriteLine("Difference in total hours: " + loginDifference.TotalHours);
            int sinceLogin = (int)(loginDifference.TotalHours);

            //calculate age
            int ageInDays = (int)(ageDifference.TotalDays);
            MyTamagotchi.Age = ageInDays;

            //calculate Health
            MyTamagotchi.Health -= (sinceLogin / 10);

            //calculate Hunger
            MyTamagotchi.Hunger -= (sinceLogin / 10);

            //calculate Happiness
            MyTamagotchi.Happiness -= (sinceLogin / 10);
        }

        private void CheckData()
        {
            MyTamagotchi.Health = Math.Max(0, MyTamagotchi.Health);
            MyTamagotchi.Health = Math.Min(100, MyTamagotchi.Health);
            MyTamagotchi.Hunger = Math.Max(0, MyTamagotchi.Hunger);
            MyTamagotchi.Hunger = Math.Min(100, MyTamagotchi.Hunger);
            MyTamagotchi.Hunger = 10 * (int)Math.Floor(MyTamagotchi.Hunger / 10.0);
            MyTamagotchi.Happiness = Math.Max(0, MyTamagotchi.Happiness);
            MyTamagotchi.Happiness = Math.Min(100, MyTamagotchi.Happiness);
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
