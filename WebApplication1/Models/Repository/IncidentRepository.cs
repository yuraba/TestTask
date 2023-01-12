using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContext;
using WebApplication1.Models.DTO;
using WebApplication1.Models.Validator;

namespace WebApplication1.Models.Repository;

public class IncidentRepository : IIncidentRepository
{
    private readonly AppDbContext _db;
    private IMapper _mapper;

    public IncidentRepository(AppDbContext db, IMapper mapper)
    {
        _mapper = mapper;
        _db = db;
    }
    
    public async Task<IEnumerable<IncidentDto>> GetIncidents()
    {
        List<Incident> incidentList = await _db.Incidents.ToListAsync();
        return _mapper.Map<List<IncidentDto>>(incidentList);
    }

    public async Task<IncidentDto> GetIncidentsById(string incidentName)
    {
        Incident incident = await _db.Incidents.Where(x => x.IncidentName == incidentName).FirstOrDefaultAsync();
        return _mapper.Map<IncidentDto>(incident);
    }

    public async Task<IncidentDto> CreateUpdateIncident(IncidentDto incidentDto)
    {
        var validator = new IncidentValidator();
        Incident incident = _mapper.Map<IncidentDto, Incident>(incidentDto);
        var validatorResult = validator.Validate(incident);
        if (validatorResult.IsValid)
        {
            if (incident.IncidentName == null)
            {
                 _db.Incidents.Add(incident);
            }
            else
            {
               _db.Incidents.Update(incident);
            }

            await _db.SaveChangesAsync();
            return _mapper.Map<Incident, IncidentDto>(incident);
        }
        else
        {
            throw new ArgumentException("you must create account");
        }
    }

    public async Task<bool> DeleteIncident(string incidentName)
    {
        try
        {
            Incident incident = await _db.Incidents.FirstOrDefaultAsync(u => u.IncidentName == incidentName);
            if (incident==null)
            {
                return false;
            }

            _db.Incidents.Remove(incident);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}