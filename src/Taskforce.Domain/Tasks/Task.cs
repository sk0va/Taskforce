using Taskforce.Domain.Tickets;

namespace Taskforce.Domain.Tasks;

public class Task : Ticket
{
    public DateTime? DueDate { get; set; }

    public DateTime? CompletedDate { get; set; }
}
