using Humanizer;
using Taskforce.Domain.Interfaces.Cqrs;

namespace Taskforce.Api.Queries;

public class QueryType : ObjectType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Name("Query");

        Configure<Domain.Tasks.Task, TaskSpecificationInput>(descriptor);
    }

    private static void Configure<TDomain, TSpecification>(IObjectTypeDescriptor descriptor)
        where TDomain : Domain.Entities.Entity
        where TSpecification : ISpecificationInput<TDomain>, new()
    {
        descriptor
            .Field(typeof(TDomain).Name.ToLowerInvariant().Pluralize())
            .Argument("specification", a => a.Type<InputObjectType<TaskSpecificationInput>>())
            .Resolve(async (ctx, ct) =>
            {
                var specification = ctx.ArgumentValue<TSpecification>("specification") ?? new TSpecification();
                var query = ctx.Service<IEntityQuery<TDomain>>();

                var res = await query.GetListAsync(specification.ToSpecification());
                return res;
            });
    }
}
