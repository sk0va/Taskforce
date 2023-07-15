using Taskforce.Domain.Entities;
using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Domain.Interfaces.Cqrs;

public interface IEntityQuery<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetListAsync(ISpecification<TEntity> specification, CancellationToken ct);
}
