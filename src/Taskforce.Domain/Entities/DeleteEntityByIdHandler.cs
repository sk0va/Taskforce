using Skova.Repository.Abstractions;
using Skova.Repository.Abstractions.Specifications;
using Taskforce.Domain.Interfaces.Cqrs;
using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Domain.Entities;

internal class DeleteEntityByIdHandler<TEntity> : ICommandHandler<DeleteEntityByIdCommand<TEntity>>
    where TEntity : Entity
{
    public DeleteEntityByIdHandler(
        IRepository<TEntity> repository,
        SpecificationFactory<ISpecification<TEntity>> specificationFactory)
    {
        Repository = repository;
        SpecificationFactory = specificationFactory;
    }

    protected IRepository<TEntity> Repository { get; }
    protected SpecificationFactory<ISpecification<TEntity>> SpecificationFactory { get; }

    public async Task HandleAsync(DeleteEntityByIdCommand<TEntity> command, CancellationToken ct)
    {
        var spec = SpecificationFactory();

        var entitySpec = (IEntitySpecification)spec;
        entitySpec.ById(command.Id);

        await Repository.With(spec).ExecuteDeleteAllAsync(ct);
    }
}
