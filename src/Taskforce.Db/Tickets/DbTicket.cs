using Taskforce.Db.Entities;

namespace Taskforce.Db.Tickets;

public class DbTicket : DbEntity
{
    public bool IsTemplate { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public string State { get; set; }
}
