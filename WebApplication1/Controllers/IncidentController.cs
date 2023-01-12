using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTO;
using WebApplication1.Models.Repository;
using WebApplication1.Models.ResponseDto;

namespace WebApplication1.Controllers;
[Route("api/incidents")]
public class IncidentController : Controller
{
        protected ResponseDto _response;
        protected MainResponse _mainResponse;

        private IIncidentRepository _incidentRepository;

        public IncidentController(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
            this._response = new ResponseDto();
            this._mainResponse = new MainResponse();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<IncidentDto> incidentDtos = await _incidentRepository.GetIncidents();
                _response.Result = incidentDtos;
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
        public async Task<object> Get(string id)
        {
            try
            {
                IncidentDto incidentDto = await _incidentRepository.GetIncidentsById(id);
                _response.Result = incidentDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
        
        [HttpPost]
        public async Task<object> Post([FromBody] IncidentDto incidentDto)
        {
            try
            {
                IncidentDto model = await _incidentRepository.CreateUpdateIncident(incidentDto);
                _mainResponse.Description = model.Description;
                _mainResponse.AccountBody = model.Accounts;

            }
            catch (Exception ex)
            { 
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }

            return _mainResponse;
        }
        [HttpPut]
        public async Task<object> Put([FromBody] IncidentDto incidentDto)
        {
            try
            {
                IncidentDto model = await _incidentRepository.CreateUpdateIncident(incidentDto);
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
        public async Task<object> Delete(string id)
        {
            try
            {
                bool isSuccess = await _incidentRepository.DeleteIncident(id);
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