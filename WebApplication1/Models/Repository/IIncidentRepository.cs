using WebApplication1.Models.DTO;

namespace WebApplication1.Models.Repository;

public interface IIncidentRepository
{
    Task<IEnumerable<IncidentDto>> GetIncidents();
    Task<IncidentDto> GetIncidentsById(string incidentName);
    Task<IncidentDto> CreateUpdateIncident(IncidentDto incidentDto);
    Task<bool> DeleteIncident(string incidentName);
}