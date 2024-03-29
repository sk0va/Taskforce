using Taskforce.Db.Entities;

namespace Taskforce.Db.Events;

public class DbEvent : DbEntity
{
    public bool IsTemplate { get; set; }

    public string Title { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
