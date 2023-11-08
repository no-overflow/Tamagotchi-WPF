using De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp042.Logic.Ui.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp042.Logic.Ui.Wrapper
{
    public class ClientCollectionViewModel :
        ViewModelSyncCollection<
            ClientViewModel,
            Client,
            ClientCollection>
    {
        /*private ClientCollection myClients;
        public ClientCollectionViewModel()
        {
            myClients = new ClientCollection();

            foreach (Client client in myClients)
            {
                this.Add(new ClientViewModel(client));
            }
        }*/
        public override void NewModelAssigned()
        {
            foreach (var cvm in this)
            {
                var modelPropChanged =
                    cvm.Model as INotifyPropertyChanged;
                if (modelPropChanged != null)
                {
                    modelPropChanged.PropertyChanged +=
                        cvm.OnPropertyChangedInModel;
                }
            }
        }
    }
}
