using De.HsFlensburg.ClientApp042.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp042.Services.SerializationService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels
{
    public class EditTamagotchiWindowViewModel : INotifyPropertyChanged
    {
        public TamagotchiViewModel MyTamagotchi { get; set; }
        public ColorsViewModel MyColors { get; set; }
  
        public ICommand SaveTamagotchiNameCommand { get; }
        public ICommand ChangeColorToRedCommand { get; }
        public ICommand ChangeColorToOrangeCommand { get; }
        public ICommand ChangeColorToYellowCommand { get; }
        public ICommand ChangeColorToGreenCommand { get; }
        public ICommand ChangeColorToBlueCommand { get; }
        public ICommand ChangeColorToVioletCommand { get; }
        public ICommand ChangeColorToRainbowCommand { get; }


        public EditTamagotchiWindowViewModel(TamagotchiViewModel EditMyTamagotchi)
        {
            MyTamagotchi = EditMyTamagotchi;
            MyColors = new ColorsViewModel(EditMyTamagotchi);

            SaveTamagotchiNameCommand = new RelayCommand(SaveTamagotchiNameMethod);
            ChangeColorToRedCommand = new RelayCommand(MyColors.ChangeColorToRedMethod);
            ChangeColorToOrangeCommand = new RelayCommand(MyColors.ChangeColorToOrangeMethod);
            ChangeColorToYellowCommand = new RelayCommand(MyColors.ChangeColorToYellowMethod);
            ChangeColorToGreenCommand = new RelayCommand(MyColors.ChangeColorToGreenMethod);
            ChangeColorToBlueCommand = new RelayCommand(MyColors.ChangeColorToBlueMethod);
            ChangeColorToVioletCommand = new RelayCommand(MyColors.ChangeColorToVioletMethod);
            ChangeColorToRainbowCommand = new RelayCommand(MyColors.ChangeColorToRainbowMethod);


        }

        public void SaveTamagotchiNameMethod()
        {
            MyTamagotchi.UpdateTamagotchi();
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
