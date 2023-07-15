namespace Taskforce.Domain.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken ct);
}
