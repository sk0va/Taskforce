using Taskforce.Db.Entities;
using Taskforce.Domain;

namespace Taskforce.Db.Specifications;

public class EntitySpecification : IEntitySpecification, IQueryTransformer<Entities.Entity>
{
    protected readonly SpecificationContainer<Domain.Entities.Entity, Entities.Entity> _entitySpecifications = new();

    public IQueryable<Entity> Apply(IQueryable<Entity> query)
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

public class TaskSpecification : EntitySpecification, ITaskSpecification, IQueryTransformer<Entities.Task>
{
    private readonly SpecificationContainer<Domain.Entities.Task, Entities.Task> _taskSpecifications = new();

    public IQueryable<Entities.Task> Apply(IQueryable<Entities.Task> query)
    {
        query = base.Apply(query).Cast<Entities.Task>();
        return _taskSpecifications.Apply(query);
    }

    public void DescriptionContains(string description)
    {
        _taskSpecifications.AddTranformation(query => description == null
            ? query.Where(t => t.Description == null)
            : query.Where(t => t.Description.Contains(description)));
    }

    public void TitleContains(string title)
    {
        _taskSpecifications.AddTranformation(query => title == null
            ? query.Where(t => t.Title == null)
            : query.Where(t => t.Title.Contains(title)));
    }

}
