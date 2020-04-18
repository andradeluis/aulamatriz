using App.Domain.Core.Bus;
using App.Domain.Core.Commands;
using App.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Bus
{
    public class RabbitMQBus : IEventBus
    {
        public void Publish<T>(T @event) where T : Event
        {
            throw new NotImplementedException();
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            throw new NotImplementedException();
        }
    }
}
