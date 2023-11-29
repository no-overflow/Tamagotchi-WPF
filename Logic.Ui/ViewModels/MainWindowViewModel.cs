using De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp042.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp042.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp042.Services.MessageBus;
using De.HsFlensburg.ClientApp042.Services.SerializationService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.IO;

namespace De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ModelFileHandler modelFileHandler;
        private string pathForSerialization;
        public ICommand RenameValueInModelCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }


        public TamagotchiViewModel MyTamagotchi { get; set; }
       

        public MainWindowViewModel()
        {
            MyTamagotchi = new TamagotchiViewModel();

            string workingDirectory = Environment.CurrentDirectory;
            Console.WriteLine("wd: " + workingDirectory);
            string projectDirectory = Path.GetFullPath(Path.Combine(workingDirectory, "..\\..\\..\\"));
            string imagePath = Path.Combine(projectDirectory, "Logic.UI", "ViewModels", "Images", "path1247.png");
            Console.WriteLine("pd: " + projectDirectory);
            Console.WriteLine("ip: " + imagePath);

            MyTamagotchi.TamagotchiImage = System.Drawing.Image.FromFile(imagePath);
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
