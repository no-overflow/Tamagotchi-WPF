using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

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

        private int age;
        public int Age { get { return age; } set { age = value; OnPropertyChanged("Age"); } }

        private DateTime oldLogin;
        public DateTime OldLogin { get { return oldLogin; } set { oldLogin = value; OnPropertyChanged("OldLogin"); } }

        private DateTime newLogin;
        public DateTime NewLogin { get { return newLogin; } set { newLogin = value; OnPropertyChanged("NewLogin"); } }

        private string infoText;
        public String InfoText { get { return infoText; } set { infoText = value; OnPropertyChanged("InfoText"); } }

        public Image TamagotchiImage { get; set; }

        private bool alive;
        public Boolean Alive { get; set; }



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


    }
}
