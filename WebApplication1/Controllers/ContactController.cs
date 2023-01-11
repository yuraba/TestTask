using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTO;
using WebApplication1.Models.Repository;
using WebApplication1.Models.ResponseDto;

namespace WebApplication1.Controllers;
[Route("api/contacts")]
public class ContactController : Controller
{
        protected ResponseDto _response;
        private IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ContactDto> contactDtos = await _contactRepository.GetContacts();
                _response.Result = contactDtos;
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
                ContactDto contactDto = await _contactRepository.GetContactsById(id);
                _response.Result = contactDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
        
        [HttpPost]
        public async Task<object> Post([FromBody] Contact contactDto)
        {
            try
            {
                Contact model = await _contactRepository.CreateUpdateContact(contactDto);
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
        public async Task<object> Put([FromBody] Contact contactDto)
        {
            try
            {
                Contact model = await _contactRepository.CreateUpdateContact(contactDto);
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
                bool isSuccess = await _contactRepository.DeleteContact(id);
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