using WebApplication1.Models.DTO;

namespace WebApplication1.Models.Repository;

public interface IAccountRepository
{
    Task<IEnumerable<AccountDto>> GetAccounts();
    Task<AccountDto> GetAccountsById(int accountId);
    Task<AccountDto> GetAccountsByName(string name);

    Task<Account> CreateUpdateAccount(Account accountDto);
    Task<bool> DeleteAccount(int accountId);
}