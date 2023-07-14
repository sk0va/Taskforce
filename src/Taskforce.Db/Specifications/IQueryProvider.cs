namespace Taskforce.Db.Specifications
{
    internal interface IQueryTransformer<T> where T : Db.Entities.Entity
    {
        IQueryable<T> Apply(IQueryable<T> query);
    }
}
