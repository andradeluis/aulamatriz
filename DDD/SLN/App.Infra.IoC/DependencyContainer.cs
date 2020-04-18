using App.Banking.Application.Interfaces;
using App.Banking.Application.Services;
using App.Banking.Data.Context;
using App.Banking.Data.Repository;
using App.Banking.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus

            // Subscriptions

            // Domain Commands

            // Domain Event

            // Application Services
            services.AddTransient<IAccountService, AccountService>();

            // Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddDbContext<BankingDbContext>();
        }
    }
}
