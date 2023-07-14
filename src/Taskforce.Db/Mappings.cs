using AutoMapper;
using Taskforce.Domain.Entities;
using Taskforce.Db.Entities;
using Taskforce.Domain.Events;
using Taskforce.Db.Tasks;
using Taskforce.Db.Tickets;
using Taskforce.Db.Events;
using Taskforce.Domain.Tickets;

namespace Taskforce.Db;

public class DbProfle : Profile
{
    public DbProfle()
    {
        CreateMap<DbEntity, Entity>().ReverseMap();

        CreateMap<DbTicket, Ticket>().ReverseMap();
        CreateMap<DbTask, Domain.Tasks.Task>().ReverseMap();
        CreateMap<DbEvent, Event>().ReverseMap();
    }
}
