using Taskforce.Domain.Interfaces.Cqrs;

namespace Taskforce.Domain.Events;

public class CreateEventCommand : ICommand
{
    public Guid CommandId { get; set; }

    public Guid EventId { get; set; }

    public bool IsTemplate { get; set; }

    public string Title { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Name { get; }
}
