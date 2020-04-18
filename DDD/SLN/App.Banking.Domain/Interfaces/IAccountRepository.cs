using App.Banking.Domain.Models;
using System.Collections.Generic;

namespace App.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
