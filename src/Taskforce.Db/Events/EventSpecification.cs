using Taskforce.Db.Entities;
using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Db.Events;

public class EventSpecification : EntitySpecification, IEventSpecification, IQueryTransformer<DbEvent>
{
    public IQueryable<DbEvent> Apply(IQueryable<DbEvent> query)
    {
        return base.Apply(query).Cast<DbEvent>();
    }
}
