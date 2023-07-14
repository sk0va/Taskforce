namespace Taskforce.Domain.Interfaces;

public interface IEntitySet<T> where T : Entities.Entity
{
    Task UpdateAsync(Func<IEntityUpdater<T>, IEntityUpdater<T>> configureEntityUpdater);

    Task DeleteAllAsync();

    Task<IList<T>> ToListAsync();
}
