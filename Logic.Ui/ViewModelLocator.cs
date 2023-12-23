using De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp042.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp042.Services.SerializationService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp042.Logic.Ui
{
    public class ViewModelLocator
    {
        public MainWindowViewModel TheMainWindowViewModel { get; set; }
        public EditTamagotchiWindowViewModel TheEditTamagotchiWindowViewModel { get; set; }


        public ViewModelLocator()
        {
            TheMainWindowViewModel = new MainWindowViewModel();
            TheEditTamagotchiWindowViewModel = new EditTamagotchiWindowViewModel(TheMainWindowViewModel.MyTamagotchi);
        }
    }
}
