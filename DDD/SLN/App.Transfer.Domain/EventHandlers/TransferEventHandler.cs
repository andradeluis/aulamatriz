using App.Domain.Core.Bus;
using App.Transfer.Domain.Events;
using System.Threading.Tasks;

namespace App.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        public Task Handle(TransferCreatedEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
