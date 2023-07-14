using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Domain.Interfaces;

public interface IRepository<T> where T : Entities.Entity
{
    IEntitySet<T> With(ISpecification<T> specification);

    Task<T> GetByIdAsync(Guid id);

    Task AddAsync(T entity);

    void Update(T entity);

    Task DeleteAsync(Guid id);
}
