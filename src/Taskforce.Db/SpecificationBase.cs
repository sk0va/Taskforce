using Taskforce.Db.Entities;
using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Db;

public class SpecificationContainer<TDomain, TDb> : ISpecification<TDomain>, IQueryTransformer<TDb>
    where TDomain : Domain.Entities.Entity
    where TDb : DbEntity
{
    private readonly List<Func<IQueryable<TDb>, IQueryable<TDb>>> _transformations = new();

    public void AddTranformation(Func<IQueryable<TDb>, IQueryable<TDb>> transformation)
    {
        _transformations.Add(transformation);
    }

    public IQueryable<TDb> Apply(IQueryable<TDb> query)
    {
        foreach (var transformation in _transformations)
        {
            query = transformation(query);
        }

        return query;
    }
}
