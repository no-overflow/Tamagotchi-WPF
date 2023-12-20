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
        public String Name { get { return Model.Name; } set { Model.Name = value; OnPropertyChanged("Name"); } }

        public int Hunger { get { return Model.Hunger; } set { Model.Hunger = value; OnPropertyChanged("Hunger"); } }
        public int Health { get { return Model.Health; } set { Model.Health = value; OnPropertyChanged("Health"); } }

        public int Happiness { get { return Model.Happiness; } set { Model.Happiness = value; OnPropertyChanged("Happiness"); } }

        public long Age { get { return Model.Age; } set { Model.Age = value; OnPropertyChanged("Age"); } }

        public DateTime LoginTime { get { return Model.LoginTime; } set { Model.LoginTime = value; OnPropertyChanged("LoginTime"); } }
       
        public DateTime Birthday { get { return Model.Birthday; } set { Model.Birthday = value; OnPropertyChanged("Birthday"); } }

        public Boolean Alive { get; set; }

        public String InfoText { get { return Model.InfoText; } set { Model.InfoText = value; OnPropertyChanged("InfoText"); } }


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

        public void FeedStrawberry()
        {
            Model.FeedStrawberry();
        }

        public void FeedBrocolli()
        {
            Model.FeedBrocolli();
        }

        public void FeedCheese()
        {
            Model.FeedCheese();
        }

        public void FeedLollipop()
        {
            Model.FeedLollipop();
        }

        public void GiveMedicin()
        {
            Model.GiveMedicin();
        }

        public void CalculateData()
        {
            Model.CalculateData();
        }

        public void UpdateTamagotchi()
        {
            Model.UpdateTamagotchi();
        }
    }
}
