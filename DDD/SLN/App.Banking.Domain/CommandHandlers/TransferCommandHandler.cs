using App.Banking.Domain.Commands;
using App.Banking.Domain.Events;
using App.Domain.Core.Bus;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _bus;

        public TransferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken) 
        {
            _bus.Publish(new TransferCreatedEvent(
                from: request.From,
                to: request.To,
                amount: request.Amount));

            return Task.FromResult(true);
        }
    }
}
