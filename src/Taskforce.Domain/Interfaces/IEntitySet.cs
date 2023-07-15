namespace Taskforce.Domain.Interfaces;

public interface IEntitySet<T> where T : Entities.Entity
{
    Task UpdateAsync(Func<IEntityUpdater<T>, IEntityUpdater<T>> configureEntityUpdater, CancellationToken ct);

    Task DeleteAllAsync(CancellationToken ct);

    Task<IList<T>> ToListAsync(CancellationToken ct);
}
