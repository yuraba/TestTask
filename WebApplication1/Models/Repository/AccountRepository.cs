using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContext;
using WebApplication1.Models.DTO;
using WebApplication1.Models.Validator;

namespace WebApplication1.Models.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _db;
    private IMapper _mapper;

    public AccountRepository(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<AccountDto>> GetAccounts()
    {
        List<Account> accountList = await _db.Accounts.ToListAsync();
        return _mapper.Map<List<AccountDto>>(accountList);
    }

    public async Task<AccountDto> GetAccountsById(int accountId)
    {
        Account account = await _db.Accounts.Where(x => x.AccountId == accountId).FirstOrDefaultAsync();
        return _mapper.Map<AccountDto>(account);
    }
    
    public async Task<AccountDto> GetAccountsByName(string name)
    {
        Account account = await _db.Accounts.Where(x => x.AccountName == name).FirstOrDefaultAsync();
       
        return _mapper.Map<AccountDto>(account);
        
    }

    public async Task<Account> CreateUpdateAccount(Account accountDto)
    {
        var validator = new AccountValidator();
        var validatorResult = validator.Validate(accountDto);
        if (validatorResult.IsValid)
        {
            if (accountDto.AccountId>0)
            {
                _db.Accounts.Update(accountDto);
            }
            else
            {
                _db.Accounts.Add(accountDto);
                
            }
            
            await _db.SaveChangesAsync();
            return accountDto;
        }
        else
        {
            throw new ArgumentException("you must create contact first");
        }
    }

    public async Task<bool> DeleteAccount(int accountId)
    {
        try
        {
            Account account = await _db.Accounts.FirstOrDefaultAsync(u => u.AccountId == accountId);
            if (account==null)
            {
                return false;
            }

            _db.Accounts.Remove(account);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}