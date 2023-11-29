using De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp042.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp042.Logic.Ui
{
    public class ViewModelLocator
    {
        public MainWindowViewModel TheMainWindowViewModel { get; set; }
       
        public ViewModelLocator()
        {
          TheMainWindowViewModel = new MainWindowViewModel();
        }
    }
}
