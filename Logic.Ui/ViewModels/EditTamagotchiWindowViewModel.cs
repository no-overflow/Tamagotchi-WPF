using De.HsFlensburg.ClientApp042.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp042.Services.SerializationService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels
{
    public class EditTamagotchiWindowViewModel : INotifyPropertyChanged
    {
        public TamagotchiViewModel MyTamagotchiViewModel { get; set; }
        public ICommand EditTamagotchiColorCommand { get; }

       

        public EditTamagotchiWindowViewModel(TamagotchiViewModel MyTamagotchi)
        {
            EditTamagotchiColorCommand = new RelayCommand(EditTamagotchiColorMethod);
            MyTamagotchiViewModel = MyTamagotchi;
            Console.WriteLine(MyTamagotchiViewModel.Name);

             
        }
        private void EditTamagotchiColorMethod()
        {
            
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
