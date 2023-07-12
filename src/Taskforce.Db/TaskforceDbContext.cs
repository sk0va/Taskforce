using Microsoft.EntityFrameworkCore;
using Taskforce.Db.Entities;

namespace Taskforce.Db;

public class TaskforceDbContext : DbContext
{
    public TaskforceDbContext(DbContextOptions<TaskforceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }

    public DbSet<Entities.Task> Tasks { get; set; }

    public DbSet<Event> Events { get; set; }
    // public DbSet<Stream> Streams { get; set; }
}
