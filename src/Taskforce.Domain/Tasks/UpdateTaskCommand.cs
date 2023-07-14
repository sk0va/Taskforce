using Taskforce.Domain.Interfaces.Cqrs;

namespace Taskforce.Domain.Tasks;

public class UpdateTaskCommand : ICommand
{
    public Guid CommandId { get; set; }

    public Guid TaskId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime? DueDate { get; set; }
}
