using Taskforce.Domain.Entities;

namespace Taskforce.Domain.Interfaces.Specifications;

public interface ISpecification<out T> where T : Entity
{
}
