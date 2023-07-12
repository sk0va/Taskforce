using Taskforce.Domain.Interfaces;

namespace Taskforce.Db;

public class UnitOfWork : IUnitOfWork
{
    private readonly TaskforceDbContext _context;

    public UnitOfWork(TaskforceDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
