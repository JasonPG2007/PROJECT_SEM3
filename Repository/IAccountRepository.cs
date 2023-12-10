using DataAccess;
using System.Collections.Generic;

namespace Repository
{
    public interface IAccountRepository
    {
        void DeleteAccount(int id);
        Account GetAccountById(int id);
        IEnumerable<Account> GetAccounts();
        void InsertAccount(Account account);
        void UpdateAccount(Account account);
    }
}
