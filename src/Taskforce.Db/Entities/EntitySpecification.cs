using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Db.Entities;

public class EntitySpecification : IEntitySpecification, IQueryTransformer<DbEntity>
{
    protected readonly SpecificationContainer<Domain.Entities.Entity, DbEntity> _entitySpecifications = new();

    public IQueryable<DbEntity> Apply(IQueryable<DbEntity> query)
    {
        return _entitySpecifications.Apply(query);
    }

    public void ById(Guid taskId)
    {
        _entitySpecifications.AddTranformation(query => query.Where(t => t.Id == taskId));
    }

    public void CreatedDateBetween(DateTime? from = null, DateTime? till = null)
    {
        _entitySpecifications.AddTranformation(query =>
        {
            if (from != null)
                query = query.Where(t => t.CreatedDate > from);

            if (till != null)
                query = query.Where(t => t.CreatedDate < till);

            return query;
        });
    }

    public void CreatedDateIs(DateTime? exactValue = null)
    {
        _entitySpecifications.AddTranformation(query => query.Where(t => t.CreatedDate == exactValue));
    }

    public void DeletedDateBetween(DateTime? from = null, DateTime? till = null)
    {
        _entitySpecifications.AddTranformation(query =>
        {
            if (from != null)
                query = query.Where(t => t.DeletedDate > from);

            if (till != null)
                query = query.Where(t => t.DeletedDate < till);

            return query;
        });
    }

    public void DeletedDateIs(DateTime? exactValue = null)
    {
        _entitySpecifications.AddTranformation(query => query.Where(t => t.DeletedDate == exactValue));
    }

    public void UpdatedDateBetween(DateTime? from = null, DateTime? till = null)
    {
        _entitySpecifications.AddTranformation(query =>
        {
            if (from != null)
                query = query.Where(t => t.UpdatedDate > from);

            if (till != null)
                query = query.Where(t => t.UpdatedDate < till);

            return query;
        });
    }

    public void UpdatedDateIs(DateTime? exactValue = null)
    {
        _entitySpecifications.AddTranformation(query => query.Where(t => t.UpdatedDate == exactValue));
    }
}
