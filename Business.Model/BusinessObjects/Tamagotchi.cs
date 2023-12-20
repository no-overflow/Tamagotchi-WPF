using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.IO;


namespace De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects
{
    [Serializable]
    public class Tamagotchi : INotifyPropertyChanged
    {
        private string name;
        public String Name {  get { return name; } set { name = value; OnPropertyChanged("Name"); } }

        private int hunger;
        public int Hunger { get {  return hunger; } set {  hunger = value; OnPropertyChanged("Hunger"); } }

        private int health;
        public int Health { get { return health; } set { health = value; OnPropertyChanged("Health"); } }

        private int happiness;
        public int Happiness { get { return happiness; } set { happiness = value; OnPropertyChanged("Happiness"); } }

        private long age;
        public long Age { get { return age; } set { age = value; OnPropertyChanged("Age"); } }


        private DateTime loginTime;
        public DateTime LoginTime { get { return loginTime; } set { loginTime = value; OnPropertyChanged("LoginTime"); } }
        private DateTime birthday;
        public DateTime Birthday { get { return birthday; } set { birthday = value; OnPropertyChanged("Birthday"); } }

        private string infoText;
        public String InfoText { get { return infoText; } set { infoText = value; OnPropertyChanged("InfoText"); } }

        public Image TamagotchiImage { get; set; }

        private bool alive;
        public Boolean Alive { get; set; }

        private string pathForSerialization;
        private ModelFileHandler modelFileHandler;

        public Tamagotchi()
        {
            modelFileHandler = new ModelFileHandler();
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
                MyTamagotchi.Model);

            Console.WriteLine("------ Update Tamagotchi ------");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("LoginTime: " + LoginTime);
            Console.WriteLine("Hunger: " + Hunger);
            Console.WriteLine("Health: " + Health);
            Console.WriteLine("Happiness: " + Happiness);
            Console.WriteLine("InfoText: " + InfoText);
            Console.WriteLine("Birthday: " + Birthday);
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
            string imagePath = "tamagotchi_" + Hunger + ".png";
            string fullPath = Path.Combine(projectDirectory, imagePath);
            Console.WriteLine(fullPath);

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
