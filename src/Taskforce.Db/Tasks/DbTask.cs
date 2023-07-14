using Taskforce.Db.Tickets;

namespace Taskforce.Db.Tasks;

public class DbTask : DbTicket
{
    public DateTime? DueDate { get; set; }
    public DateTime? CompletedDate { get; set; }
}
