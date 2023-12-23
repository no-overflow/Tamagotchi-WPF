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

        public override void NewModelAssigned()
        {
            throw new NotImplementedException();
        }

        public void ChangeColorToRedMethod()
        { 
            //Model.BackgroundColor = BackgroundColor;
            //Model.ButtonColor = ButtonColor;

        }

    }
}
