using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTO;
using WebApplication1.Models.Repository;
using WebApplication1.Models.ResponseDto;

namespace WebApplication1.Controllers;
[Route("api/accounts")]
public class AccountController : Controller
{
        protected ResponseDto _response;
        private IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<AccountDto> accountDtos = await _accountRepository.GetAccounts();
                _response.Result = accountDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                AccountDto accountDto = await _accountRepository.GetAccountsById(id);
                _response.Result = accountDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
        
        [HttpGet]
        [Route("{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                AccountDto accountDto = await _accountRepository.GetAccountsByName(name);
                if (accountDto==null)
                {
                    return NotFound();
                }
                _response.Result = accountDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
        
        [HttpPost]
        
        public async Task<object> Post([FromBody] Account accountDto)
        {
            try
            {
                Account model = await _accountRepository.CreateUpdateAccount(accountDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
        [HttpPut]
        public async Task<object> Put([FromBody] Account accountDto)
        {
            try
            {
                Account model = await _accountRepository.CreateUpdateAccount(accountDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
        
        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _accountRepository.DeleteAccount(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
}