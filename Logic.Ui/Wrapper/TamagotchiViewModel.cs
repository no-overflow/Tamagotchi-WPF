using De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp042.Logic.Ui.Base;
using De.HsFlensburg.ClientApp042.Services.SerializationService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace De.HsFlensburg.ClientApp042.Logic.Ui.Wrapper
{
    public class TamagotchiViewModel : ViewModelBase<Tamagotchi>
    {
        public String Name { get { return Model.Name; } set { Model.Name = value; OnPropertyChanged("Name"); } }

        public int Hunger { get { return Model.Hunger; } set { Model.Hunger = value; OnPropertyChanged("Hunger"); } }
        public int Health { get { return Model.Health; } set { Model.Health = value; OnPropertyChanged("Health"); } }
        public int Happiness { get { return Model.Happiness; } set { Model.Happiness = value; OnPropertyChanged("Happiness"); } }

        public long Age { get { return Model.Age; } set { Model.Age = value; OnPropertyChanged("Age"); } }

        public DateTime LoginTime { get { return Model.LoginTime; } set { Model.LoginTime = value; OnPropertyChanged("LoginTime"); } }
       
        public DateTime Birthday { get { return Model.Birthday; } set { Model.Birthday = value; OnPropertyChanged("Birthday"); } }

        public Boolean Alive { get; set; }

        public String InfoText { get { return Model.InfoText; } set { Model.InfoText = value; OnPropertyChanged("InfoText"); } }

        //public ColorsViewModel MyColors { get; set; }

        public BitmapImage BindableTamagotchiImage
        {
            get
            {
                if (Model.TamagotchiImage != null)
                {
                    MemoryStream localMemoryStream =
                        new MemoryStream();
                    Model.TamagotchiImage.Save(
                        localMemoryStream,
                        System.Drawing.Imaging.ImageFormat.Png);
                    localMemoryStream.Position = 0;
                    BitmapImage localBitmapImage =
                        new BitmapImage();
                    localBitmapImage.BeginInit();
                    localBitmapImage.StreamSource =
                        localMemoryStream;
                    localBitmapImage.EndInit();
                    return localBitmapImage;
                }
                else return null;
            }
            private set { }
        }


        public Image TamagotchiImage
        {
            get
            {
                return Model.TamagotchiImage;
            }
            set
            {
                Model.TamagotchiImage = value;
                OnPropertyChanged("TamagotchiImage");
                OnPropertyChanged("BindableTamagotchiImage");
            }
        }


        public override void NewModelAssigned()
        {
            throw new NotImplementedException();
        }

        private string pathForSerialization;
        private ModelFileHandler modelFileHandler;

        public TamagotchiViewModel()
        {
            modelFileHandler = new ModelFileHandler();

        }

        public void UpdateTamagotchi()
        {

            CheckHealth();
            CheckData();
            SetImage();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(workingDirectory, "..\\..\\..\\", "Logic.UI", "ViewModels", "Data", "MyTamagotchi.cc"));
            

            pathForSerialization = projectDirectory;

            modelFileHandler.WriteModelToFile(
                pathForSerialization,
                Model);
            

            Console.WriteLine("------ Update Tamagotchi ------");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("LoginTime: " + LoginTime);
            Console.WriteLine("Hunger: " + Hunger);
            Console.WriteLine("Health: " + Health);
            Console.WriteLine("Happiness: " + Happiness);
            Console.WriteLine("InfoText: " + InfoText);
            Console.WriteLine("Birthday: " + Birthday);

            Console.WriteLine("TamagotchiColor: " + Model.TamagotchiColor);
        }

        public void ResetTamagotchi()
        {
            Name = "Tamagotchi";
            Hunger = 0;
            Happiness = 0;
            Health = 0;
            UpdateTamagotchi();
        }

        public void FeedStrawberry()
        {
            if (Hunger < 100)
            {
                Hunger += 15;
                Happiness += 5;
                Health += 5;
                UpdateTamagotchi();
            }
        }

        public void FeedBrocolli()
        {
            if (Hunger < 100)
            {
                Hunger += 20;
                Happiness += 5;
                Health += 5;
                UpdateTamagotchi();
            }
        }

        public void FeedCheese()
        {
            if (Hunger < 100)
            {
                Hunger += 20;
                Happiness += 5;
                Health += 2;
                UpdateTamagotchi();
            }
        }

        public void FeedLollipop()
        {
            if (Hunger < 100)
            {
                Hunger += 10;
                Happiness += 20;
                Health -= 5;
                UpdateTamagotchi();
            }
        }
        public void GiveMedicin()
        {
            if (Health < 50)
            {
                Health = 100;
                Happiness += 20;
                UpdateTamagotchi();
            }
        }

        private void SetImage()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(workingDirectory, "..\\..\\..\\", "Logic.UI", "ViewModels", "Images"));
            string imagePath = "tamagotchi_" + Model.TamagotchiColor + "_" + Hunger + ".png";
            string fullPath = Path.Combine(projectDirectory, imagePath);

            TamagotchiImage = System.Drawing.Image.FromFile(fullPath);
        }

        public void CalculateData()
        {
            TimeSpan loginDifference = DateTime.Now.Subtract(LoginTime);
            TimeSpan ageDifference = DateTime.Now.Subtract(Birthday);
            int sinceLogin = (int)(loginDifference.TotalMinutes);

            //calculate age
            Age = (int)(ageDifference.TotalDays);

            //calculate Health
            Health -= (sinceLogin / 5);

            //calculate Hunger
            Hunger -= (sinceLogin / 5);

            //calculate Happiness
            Happiness -= (sinceLogin / 5);
        }

        private void CheckData()
        {
            Health = Health < 0 ? 0 : (Health > 100 ? 100 : Health);
            Hunger = Hunger < 0 ? 0 : (Hunger > 100 ? 100 : Hunger);
            Hunger = 10 * (int)Math.Floor(Hunger / 10.0);
            Happiness = Happiness < 0 ? 0 : (Happiness > 100 ? 100 : Happiness);
        }

        private void CheckHealth()
        {
            if (Health < 20)
            {
                InfoText = "Your Tamagotchi is sick!";
            }
            else
            {
                InfoText = "Your Tamagotchi is healthy.";
            }
        }

    }
}
