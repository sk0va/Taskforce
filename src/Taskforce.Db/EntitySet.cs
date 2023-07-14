using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taskforce.Db.Entities;
using Taskforce.Domain.Interfaces.Specifications;
using Taskforce.Domain.Interfaces;

namespace Taskforce.Db;

internal record struct EntitySet<TDomain, TDb>(
    TaskforceDbContext DbContext,
    IMapper Mapper,
    ISpecification<TDomain> Specification)

 : IEntitySet<TDomain>
    where TDomain : Domain.Entities.Entity
    where TDb : DbEntity
{
    private readonly IQueryTransformer<TDb> DbQueryTransformer => (IQueryTransformer<TDb>)Specification;

    public async Task DeleteAllAsync()
    {
        var q = Apply();
        await q.ExecuteDeleteAsync();
    }

    private readonly IQueryable<TDb> Apply()
    {
        return DbQueryTransformer.Apply(DbContext.Set<TDb>());
    }

    public async Task<IList<TDomain>> ToListAsync()
    {
        var q = Apply();
        return Mapper.Map<List<TDomain>>(await q.ToListAsync());
    }

    public async Task UpdateAsync(Func<IEntityUpdater<TDomain>, IEntityUpdater<TDomain>> configureEntityUpdater)
    {
        var q = Apply();

        IEntityUpdater<TDomain> updater = new EntityUpdater<TDomain, TDb>(Mapper);
        updater = configureEntityUpdater(updater);

        var updateExpression = ((EntityUpdater<TDomain, TDb>)updater).GenerateUpdateExpression();

        await q.ExecuteUpdateAsync(updateExpression);
    }
}
