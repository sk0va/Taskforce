using Skova.Repository.Impl;

using Taskforce.Db.Entities;
using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Db.Events;

public class EventSpecification : EntitySpecification<DbEvent>, IEventSpecification
{
}
