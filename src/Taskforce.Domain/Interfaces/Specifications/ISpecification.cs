using Taskforce.Domain.Entities;

namespace Taskforce.Domain;

public interface ISpecification<out T> where T : Entity
{
}
