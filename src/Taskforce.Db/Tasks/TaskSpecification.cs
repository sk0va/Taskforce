using Skova.Repository.Impl;

using Taskforce.Db.Entities;
using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Db.Tasks;

public class TaskSpecification : EntitySpecification<DbTask>, ITaskSpecification
{
    public void DescriptionContains(string description)
    {
        AddTranformation(query => description == null
            ? query.Where(t => t.Description == null)
            : query.Where(t => t.Description.Contains(description)));
    }

    public void TitleContains(string title)
    {
        AddTranformation(query => title == null
            ? query.Where(t => t.Title == null)
            : query.Where(t => t.Title.Contains(title)));
    }
}
