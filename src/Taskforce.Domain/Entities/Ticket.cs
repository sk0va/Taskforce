namespace Taskforce.Domain.Entities;

public class Ticket : Entity
{
    public bool IsTemplate { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string State { get; set; }
}
