using Skova.Repository.Impl;

using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Db.Entities;

public class EntitySpecification<TDb> : QueryTransformationsContainer<TDb>, IEntitySpecification
    where TDb : DbEntity
{
    public void ById(Guid taskId)
    {
        AddTranformation(query => query.Where(t => t.Id == taskId));
    }

    public void CreatedDateBetween(DateTime? from = null, DateTime? till = null)
    {
        AddTranformation(query =>
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
        AddTranformation(query => query.Where(t => t.CreatedDate == exactValue));
    }

    public void DeletedDateBetween(DateTime? from = null, DateTime? till = null)
    {
        AddTranformation(query =>
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
        AddTranformation(query => query.Where(t => t.DeletedDate == exactValue));
    }

    public void UpdatedDateBetween(DateTime? from = null, DateTime? till = null)
    {
        AddTranformation(query =>
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
        AddTranformation(query => query.Where(t => t.UpdatedDate == exactValue));
    }
}
