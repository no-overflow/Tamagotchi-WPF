using De.HsFlensburg.ClientApp042.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp042.Logic.Ui.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace De.HsFlensburg.ClientApp042.Logic.Ui.Wrapper
{
    public class ClientViewModel: ViewModelBase<Client>
    {

        public String Name
        {
            get
            {
                return Model.Name;
            }

            set
            {
                Model.Name = value;
            }
        }

        public int Id
        {
            get
            {
                return Model.Id;
            }

            set
            {
                Model.Id = value;
            }
        }

        public override void NewModelAssigned()
        {
            throw new NotImplementedException();
        }
    }
}
