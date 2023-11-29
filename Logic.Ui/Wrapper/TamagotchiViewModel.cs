using De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp042.Logic.Ui.Base;
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

        public string name;
        private String Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }

        private int hunger;
        public int Hunger { get { return hunger; } set { hunger = value; OnPropertyChanged("Hunger"); } }

        private int health;
        public int Health { get { return health; } set { health = value; OnPropertyChanged("health"); } }

        private int happiness;
        public int Happiness { get { return happiness; } set { happiness = value; OnPropertyChanged("happiness"); } }

        private int age;
        public int Age { get { return age; } set { age = value; OnPropertyChanged("age"); } }

        public DateTime lastLogin;
        public DateTime LastLogin { get; set; }

       
        
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
    }
}
