using Skova.Repository.Abstractions.Specifications;

namespace Taskforce.Domain.Interfaces.Specifications;

public interface ITaskSpecification : IEntitySpecification, ISpecification<Tasks.Task>
{
    public void TitleContains(string title);

    public void DescriptionContains(string description);
}
