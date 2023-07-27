using Skova.Repository.Abstractions.Specifications;

using Taskforce.Domain.Events;

namespace Taskforce.Domain.Interfaces.Specifications;

public interface IEventSpecification : IEntitySpecification, ISpecification<Event>
{
}
