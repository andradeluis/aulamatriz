using App.Banking.Application.Interfaces;
using App.Banking.Application.Models;
using App.Banking.Domain.Commands;
using App.Banking.Domain.Interfaces;
using App.Banking.Domain.Models;
using App.Domain.Core.Bus;
using System.Collections.Generic;

namespace App.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                from: accountTransfer.FromAccount,
                to: accountTransfer.ToAccount,
                amount: accountTransfer.TransferAmount
            );

            _bus.SendCommand(createTransferCommand);
        }
    }
}
