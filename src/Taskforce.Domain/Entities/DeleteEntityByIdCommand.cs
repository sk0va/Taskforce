using Taskforce.Domain.Interfaces.Cqrs;

namespace Taskforce.Domain.Entities;

public class DeleteEntityByIdCommand<TEntity> : ICommand
    where TEntity : Entity
{
    public Guid CommandId { get; set; }

    public Guid Id { get; set; }
}
