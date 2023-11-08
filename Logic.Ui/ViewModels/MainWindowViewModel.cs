using De.HsFlensburg.ClientApp042.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp042.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp042.Services.MessageBus;
using De.HsFlensburg.ClientApp042.Services.SerializationService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels
{
    public class MainWindowViewModel
    {
        public ModelFileHandler modelFileHandler;
        private string pathForSerialization;
        public ICommand RenameValueInModelCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand OpenNewClientWindowCommand { get; }
        private void OpenNewClientWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenNewClientWindowMessage());
        }
        public ClientCollectionViewModel MyList { get; set; }
        public MainWindowViewModel(ClientCollectionViewModel viewModelCollection)
        {
            RenameValueInModelCommand = new RelayCommand(RenameValueInModel);
            SaveCommand = new RelayCommand(SaveModel);
            LoadCommand = new RelayCommand(LoadModel);
            OpenNewClientWindowCommand = new RelayCommand(OpenNewClientWindowMethod);
            //MyList = new ClientCollectionViewModel();
            MyList = viewModelCollection;
            modelFileHandler = new ModelFileHandler();
            pathForSerialization = Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments) +
                "\\ClientCollectionSerialization\\MyClients.cc";
        }

        private void RenameValueInModel()
        {
            var first =
                MyList.FirstOrDefault();
            first.Model.Name =
                "Rename in the model";
        }
        private void SaveModel()
        {
            modelFileHandler.WriteModelToFile(
                pathForSerialization,
                MyList.Model);
        }
        private void LoadModel()
        {
            MyList.Model = modelFileHandler.ReadModelFromFile(
                pathForSerialization);
        }
    }
}
