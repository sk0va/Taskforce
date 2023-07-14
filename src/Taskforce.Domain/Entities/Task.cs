namespace Taskforce.Domain.Entities;

public class Task : Ticket
{
    public DateTime? DueDate { get; set; }

    public DateTime? CompletedDate { get; set; }
}
