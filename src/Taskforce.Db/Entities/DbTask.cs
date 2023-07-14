
namespace Taskforce.Db.Entities;

public class DbTask : DbTicket
{
    public DateTime? DueDate { get; set; }
    public DateTime? CompletedDate { get; set; }
}
