namespace Taskforce.Domain.Entities;

public class Event : Entity
{
    public bool IsTemplate { get; set; }

    public string Title { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
