using Taskforce.Domain;
using Taskforce.Db.Entities;

namespace Taskforce.Db.Specifications;

public class TaskSpecification : EntitySpecification, ITaskSpecification, IQueryTransformer<DbTask>
{
    private readonly SpecificationContainer<Domain.Entities.Task, DbTask> _taskSpecifications = new();

    public IQueryable<DbTask> Apply(IQueryable<DbTask> query)
    {
        query = base.Apply(query).Cast<DbTask>();
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
