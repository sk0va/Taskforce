
using System.Linq.Expressions;

namespace Taskforce.Domain.Interfaces;

public interface IEntityUpdater<T> where T : Entities.Entity
{
    IEntityUpdater<T> Set<TValue>(Expression<Func<T, TValue>> property, TValue value);
}
