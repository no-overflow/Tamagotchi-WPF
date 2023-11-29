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
        public string name;
        private String Name {  get { return name; } set { name = value; OnPropertyChanged("Name"); } }

        private int hunger;
        public int Hunger { get {  return hunger; } set {  hunger = value; OnPropertyChanged("Hunger"); } }

        private int health;
        public int Health { get { return health; } set { health = value; OnPropertyChanged("health"); } }

        private int happiness;
        public int Happiness { get { return happiness; } set { happiness = value; OnPropertyChanged("happiness"); } }

        private int age;
        public int Age { get { return age; } set { age = value; OnPropertyChanged("age"); } }

        public DateTime lastLogin;
        public DateTime LastLogin { get; set; }

        public Image TamagotchiImage { get; set; }


        public void GiveMedicin()
        {
            health = 100;
        }

        public void PlayGame() 
        { 
            
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


    }
}
