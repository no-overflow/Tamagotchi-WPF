using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp042.Services.MessageBus
{
    interface IServiceBus
    {
        void Register<TNotification>(object listener, Action action);
        void Send<TNotification>(TNotification notification);
        void Unregister<TNotification>(object listener);
    }
}
