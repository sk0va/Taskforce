using Taskforce.Domain.Entities;
using Taskforce.Domain.Interfaces;
using Taskforce.Domain.Interfaces.Cqrs;
using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Domain.Queries;

internal class EntityQuery<TEntity> : IEntityQuery<TEntity> where TEntity : Entity
{
    private readonly IRepository<TEntity> _repository;

    public EntityQuery(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TEntity>> GetListAsync(ISpecification<TEntity> specification)
    {
        return await _repository.With(specification).ToListAsync();
    }
}
