using De.HsFlensburg.ClientApp042.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp042.Services.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp042.Ui.Desktop.MessageBusLogic
{
    class MessageListener
    {
        public bool BindableProperty => true;
        public MessageListener()
        {
            InitMessenger();
        }
        private void InitMessenger()
        {
            ServiceBus.Instance.Register<OpenEditTamagotchiWindowMessage>
                (this, OpenEditTamagotchiWindow
                );
        }
        private void OpenEditTamagotchiWindow()
        {
            EditTamagotchiWindow myWindow = new EditTamagotchiWindow();
            myWindow.ShowDialog();
        }

    }
}
