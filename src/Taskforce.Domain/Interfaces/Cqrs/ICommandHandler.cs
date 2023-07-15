namespace Taskforce.Domain.Interfaces.Cqrs;

public interface ICommandHandler<T> where T : ICommand
{
    Task HandleAsync(T command, CancellationToken ct);
}
