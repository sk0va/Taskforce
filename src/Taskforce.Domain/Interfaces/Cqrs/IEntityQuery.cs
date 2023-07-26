using Skova.Repository.Abstractions.Specifications;

using Taskforce.Domain.Entities;

namespace Taskforce.Domain.Interfaces.Cqrs;

public interface IEntityQuery<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetListAsync(ISpecification<TEntity> specification, CancellationToken ct);
}
