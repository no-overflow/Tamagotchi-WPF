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
        

        private string tamagotchiColor;
        public String TamagotchiColor { get { return tamagotchiColor; } set { tamagotchiColor = value; OnPropertyChanged("TamagotchiColor"); } }

        private string backgroundColor;
        public String BackgroundColor { get { return backgroundColor; } set { backgroundColor = value; OnPropertyChanged("BackgroundColor"); } }
        private string buttonColor;
        public String ButtonColor { get { return buttonColor; } set { buttonColor = value; OnPropertyChanged("ButtonColor"); } }



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
