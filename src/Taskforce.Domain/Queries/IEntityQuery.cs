using Taskforce.Domain.Entities;

namespace Taskforce.Domain.Queries;

public interface IEntityQuery<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetListAsync(ISpecification<TEntity> specification);
}
