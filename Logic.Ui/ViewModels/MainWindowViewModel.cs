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
using De.HsFlensburg.ClientApp042.Logic.Ui.MessageBusMessages;

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

        public ICommand OpenEditTamagotchiWindowCommand { get; }


        public TamagotchiViewModel MyTamagotchi { get; set; }
        public GameViewModel MyGame { get; set; }
        public ColorsViewModel MyColors { get; set; }
        


        private void OpenEditTamagotchiWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenEditTamagotchiWindowMessage());
        }

        public MainWindowViewModel()
        {  
            modelFileHandler = new ModelFileHandler();
            
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(workingDirectory, "..\\..\\..\\", "Logic.UI", "ViewModels", "Data", "MyTamagotchi.cc"));
            string projectDirectory2 = Path.GetFullPath(Path.Combine(workingDirectory, "..\\..\\..\\", "Logic.UI", "ViewModels", "Data", "MyColors.cc"));

            pathForSerialization = projectDirectory;

            
            MyTamagotchi = new TamagotchiViewModel
            {
                Model = modelFileHandler.ReadModelFromFile(pathForSerialization)
            };

            MyGame = new GameViewModel(MyTamagotchi);
            MyColors = new ColorsViewModel(MyTamagotchi);

            Console.WriteLine("MWVM TamagotchiColor1: " + MyTamagotchi.Model.TamagotchiColor);
            Console.WriteLine("MWVM BackgroundColor1: " + MyTamagotchi.Model.BackgroundColor);


            OpenEditTamagotchiWindowCommand = new RelayCommand(OpenEditTamagotchiWindowMethod);

            MedicinCommand = new RelayCommand(MyTamagotchi.GiveMedicin);

            FeedStrawberryCommand = new RelayCommand(MyTamagotchi.FeedStrawberry);
            FeedBrocolliCommand = new RelayCommand(MyTamagotchi.FeedBrocolli);
            FeedCheeseCommand = new RelayCommand(MyTamagotchi.FeedCheese);
            FeedLollipopCommand = new RelayCommand(MyTamagotchi.FeedLollipop);

            StartGameCommand = new RelayCommand(MyGame.StartGame);
            LowerCommand = new RelayCommand(MyGame.LowerGuess);
            HigherCommand = new RelayCommand(MyGame.HigherGuess);

            MyTamagotchi.CalculateData();
            MyTamagotchi.UpdateTamagotchi();

            Console.WriteLine("MWVM TamagotchiColor: "+MyTamagotchi.Model.TamagotchiColor);
            Console.WriteLine("MWVM BackgroundColor: " + MyTamagotchi.Model.BackgroundColor);
            //MyTamagotchi.LoginTime = DateTime.Now;
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
