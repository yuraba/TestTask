using AutoMapper;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1;

public class mappingconfig
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AccountDto, Account>();
                config.CreateMap<Account, AccountDto>();
                config.CreateMap<ContactDto, Contact>();
                config.CreateMap<Contact, ContactDto>();
                config.CreateMap<IncidentDto, Incident>();
                config.CreateMap<Incident, IncidentDto>();
            });
            return mappingConfig;
        }
    }
}