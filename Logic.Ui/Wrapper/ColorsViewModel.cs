using De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp042.Logic.Ui.Base;
using De.HsFlensburg.ClientApp042.Services.SerializationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp042.Logic.Ui.Wrapper
{
    public class ColorsViewModel : ViewModelBase<Tamagotchi>
    {
        public String TamagotchiColor { get { return Model.TamagotchiColor; } set { Model.TamagotchiColor = value; OnPropertyChanged("TamagotchiColor"); } }
        public String BackgroundColor { get { return Model.BackgroundColor; } set { Model.BackgroundColor = value; OnPropertyChanged("BackgroundColor"); } }
        public String ButtonColor { get { return Model.ButtonColor; } set { Model.ButtonColor = value; OnPropertyChanged("ButtonColor"); } }

        private TamagotchiViewModel MyTamagotchi;
        public override void NewModelAssigned()
        {
            throw new NotImplementedException();
        }

        public ColorsViewModel(TamagotchiViewModel MyTamagotchi1)
        {
            MyTamagotchi = MyTamagotchi1;
        }

        public void ChangeColorToRedMethod()
        {
            MyTamagotchi.Model.TamagotchiColor = "Red";
            MyTamagotchi.Model.BackgroundColor = "#f11d1d";
            MyTamagotchi.Model.ButtonColor = "#cf1717";
            MyTamagotchi.UpdateTamagotchi();
        }

        public void ChangeColorToOrangeMethod()
        {
            MyTamagotchi.Model.TamagotchiColor = "Orange";
            MyTamagotchi.Model.BackgroundColor = "#f99b23";
            MyTamagotchi.Model.ButtonColor = "#e78200";
            MyTamagotchi.UpdateTamagotchi();
        }

        public void ChangeColorToYellowMethod()
        {
            MyTamagotchi.Model.TamagotchiColor = "Yellow";
            MyTamagotchi.Model.BackgroundColor = "#ffff3d";
            MyTamagotchi.Model.ButtonColor = "#dcdc00";
            MyTamagotchi.UpdateTamagotchi();
        }

        public void ChangeColorToGreenMethod()
        {
            MyTamagotchi.Model.TamagotchiColor = "Green";
            MyTamagotchi.Model.BackgroundColor = "#30e400";
            MyTamagotchi.Model.ButtonColor = "#23a600";
            MyTamagotchi.UpdateTamagotchi();
        }

        public void ChangeColorToBlueMethod()
        {
            MyTamagotchi.Model.TamagotchiColor = "Blue";
            MyTamagotchi.Model.BackgroundColor = "#1E90FF";
            MyTamagotchi.Model.ButtonColor = "#1e6cff";
            MyTamagotchi.UpdateTamagotchi();
        }

        public void ChangeColorToVioletMethod()
        {
            MyTamagotchi.Model.TamagotchiColor = "DarkViolet";
            MyTamagotchi.Model.BackgroundColor = "#820dff";
            MyTamagotchi.Model.ButtonColor = "#5b00bd";
            MyTamagotchi.UpdateTamagotchi();
        }

        public void ChangeColorToRainbowMethod()
        {
            MyTamagotchi.Model.TamagotchiColor = "Rainbow";
            MyTamagotchi.Model.BackgroundColor = "RainbowBackground";
            MyTamagotchi.Model.ButtonColor = "RainbowButton";
            MyTamagotchi.UpdateTamagotchi();
        }
    }
}
