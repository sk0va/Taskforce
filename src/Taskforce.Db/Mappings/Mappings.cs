using AutoMapper;
using Taskforce.Domain.Entities;
using Taskforce.Db.Entities;

namespace Taskforce.Db.Mappings;

public class DbProfle : Profile
{
    public DbProfle()
    {
        CreateMap<DbEntity, Entity>().ReverseMap();

        CreateMap<DbTicket, Ticket>().ReverseMap();
        CreateMap<DbTask, Domain.Entities.Task>().ReverseMap();
        CreateMap<DbEvent, Event>().ReverseMap();
    }
}
