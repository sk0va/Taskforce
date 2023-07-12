using Taskforce.Db.Specifications;
using Taskforce.Domain;

namespace Taskforce.Api.Queries;

public class TaskSpecificationInput : EntitySpecificationInput, ISpecificationInput<Domain.Entities.Task>
{
    public Optional<string> Title { get; set; }

    [GraphQLName(nameof(Domain.Entities.Task.Description))]
    public Optional<string> TaskDescription { get; set; }

    protected void FillSpecification(ITaskSpecification specification)
    {
        if (Title.HasValue)
            specification.TitleContains(Title.Value);

        if (TaskDescription.HasValue)
            specification.DescriptionContains(TaskDescription.Value);
    }

    new public ISpecification<Domain.Entities.Task> ToSpecification()
    {
        var specification = new TaskSpecification();

        FillSpecification(specification);
        base.FillSpecification(specification);

        return specification;
    }
}
