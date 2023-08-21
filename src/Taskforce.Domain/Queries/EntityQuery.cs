
using Skova.Repository.Abstractions;
using Skova.Repository.Abstractions.Specifications;

using Taskforce.Domain.Entities;
using Taskforce.Domain.Interfaces.Cqrs;

namespace Taskforce.Domain.Queries;

internal class EntityQuery<TEntity> : Interfaces.Cqrs.IEntityQuery<TEntity> where TEntity : Entity
{
    private readonly IRepository<TEntity> _repository;

    public EntityQuery(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TEntity>> GetListAsync(ISpecification<TEntity> specification, CancellationToken ct)
    {
        return await _repository.With(specification).ExecuteQueryAsync(ct);
    }
}
