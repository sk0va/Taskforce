using AutoMapper;

namespace Taskforce.Db.Mappings;

public class DbProfle : Profile
{
    public DbProfle()
    {
        CreateMap<Entities.Entity, Domain.Entities.Entity>();
        CreateMap<Domain.Entities.Entity, Entities.Entity>();

        CreateMap<Entities.Task, Domain.Entities.Task>();
        CreateMap<Domain.Entities.Task, Entities.Task>();

        CreateMap<Entities.Event, Domain.Entities.Event>();
        CreateMap<Entities.Ticket, Domain.Entities.Ticket>();
    }
}
