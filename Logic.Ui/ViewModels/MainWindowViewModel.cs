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


        public TamagotchiViewModel MyTamagotchi { get; set; }
       

        public MainWindowViewModel()
        {
            //if (MyTamagotchi.Alive == null)
            //{
            //    MyTamagotchi = new TamagotchiViewModel
            //    {
            //        Alive = true,
            //        Age = 0,
            //        Happiness = 100,
            //        Hunger = 100,
            //        Health = 100
            //    };

            //}
            

            
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


            UpdateTamagotchi();
        }

        private void UpdateTamagotchi()
        {
            SetImage();
            CheckHealth();

            modelFileHandler.WriteModelToFile(
                pathForSerialization,
                MyTamagotchi.Model);
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
            string imagePath = "tamagotchi_"+ MyTamagotchi.Hunger+".png";
            string fullPath = Path.Combine(projectDirectory, imagePath);

            MyTamagotchi.TamagotchiImage = System.Drawing.Image.FromFile(fullPath);
        }


        public void CalculateData()
        {

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
            Console.WriteLine(MyTamagotchi.InfoText);
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
