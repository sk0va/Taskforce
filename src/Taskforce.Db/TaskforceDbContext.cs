using Microsoft.EntityFrameworkCore;

using Taskforce.Db.Events;
using Taskforce.Db.Tasks;
using Taskforce.Db.Tickets;

namespace Taskforce.Db;

public class TaskforceDbContext : DbContext
{
    public TaskforceDbContext(DbContextOptions<TaskforceDbContext> options)
        : base(options)
    {
    }

    public DbSet<DbTicket> Tickets { get; set; }

    public DbSet<DbTask> Tasks { get; set; }

    public DbSet<DbEvent> Events { get; set; }
    // public DbSet<Stream> Streams { get; set; }
}
