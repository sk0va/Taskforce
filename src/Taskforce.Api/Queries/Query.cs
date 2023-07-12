using Humanizer;
using Taskforce.Domain.Interfaces;

namespace Taskforce.Api.Queries;

public class QueryType : ObjectType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Name("Query");

        Configure<Domain.Entities.Task, TaskSpecificationInput>(descriptor);
    }

    private static void Configure<TDomain, TSpecification>(IObjectTypeDescriptor descriptor)
        where TDomain:  Domain.Entities.Entity
        where TSpecification: ISpecificationInput<TDomain>
    {
        descriptor
            .Field(typeof(TDomain).Name.ToLowerInvariant().Pluralize())
            .Argument("specification", a => a.Type<InputObjectType<TaskSpecificationInput>>())
            .Resolve((ctx, ct) => {
                var specification = ctx.ArgumentValue<TSpecification>("specification");
                var repository = ctx.Service<IRepository<TDomain>>();

                var res = repository.With(specification.ToSpecification()).ToListAsync();
                return res;
            });
    }
}
