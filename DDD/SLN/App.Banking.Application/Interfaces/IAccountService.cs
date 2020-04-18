using App.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
    }
}
