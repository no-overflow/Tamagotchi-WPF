using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects
{
    [Serializable]
    public class ClientCollection: ObservableCollection<Client>
    {
        public ClientCollection() { 
            
        }
    }
}
