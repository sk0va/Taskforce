using Taskforce.Db.Entities;

namespace Taskforce.Db;

internal interface IQueryTransformer<T> where T : DbEntity
{
    IQueryable<T> Apply(IQueryable<T> query);
}
