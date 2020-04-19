using App.Banking.Application.Interfaces;
using App.Banking.Application.Services;
using App.Banking.Data.Context;
using App.Banking.Data.Repository;
using App.Banking.Domain.CommandHandlers;
using App.Banking.Domain.Commands;
using App.Banking.Domain.Interfaces;
using App.Domain.Core.Bus;
using App.Infra.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp => {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            // Subscriptions
            services.AddTransient<Transfer.Domain.EventHandlers.TransferEventHandler>();

            // Domain Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Domain Event
            services.AddTransient<
                IEventHandler<Transfer.Domain.Events.TransferCreatedEvent>, 
                Transfer.Domain.EventHandlers.TransferEventHandler>();

            // Application Services
            services.AddTransient<IAccountService, AccountService>();

            // Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddDbContext<BankingDbContext>();
        }
    }
}
