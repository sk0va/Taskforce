using Taskforce.Db.Tasks;
using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Api.Queries;

public class TaskSpecificationInput : EntitySpecificationInput, ISpecificationInput<Domain.Tasks.Task>
{
    public Optional<string> Title { get; set; }

    [GraphQLName(nameof(Domain.Tasks.Task.Description))]
    public Optional<string> TaskDescription { get; set; }

    protected void FillSpecification(ITaskSpecification specification)
    {
        if (Title.HasValue)
            specification.TitleContains(Title.Value);

        if (TaskDescription.HasValue)
            specification.DescriptionContains(TaskDescription.Value);
    }

    new public ISpecification<Domain.Tasks.Task> ToSpecification()
    {
        var specification = new TaskSpecification();

        FillSpecification(specification);
        base.FillSpecification(specification);

        return specification;
    }
}
