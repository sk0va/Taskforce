using Taskforce.Db.Entities;
using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Db.Tasks;

public class TaskSpecification : EntitySpecification, ITaskSpecification, IQueryTransformer<DbTask>
{
    private readonly SpecificationContainer<Domain.Tasks.Task, DbTask> _taskSpecifications = new();

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
