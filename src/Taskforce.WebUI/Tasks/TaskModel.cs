namespace Taskforce.WebUI.Tasks;

public class TaskModel
{    
    public Guid Id { get; set; }

    public Guid TaskId => Id;

    public bool IsDeleted { get; set; }

    public bool IsTemplate { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string State { get; set; }

    public DateTimeOffset? DueDate { get; set; }

    public DateTimeOffset? CompletedDate { get; set; }
}
