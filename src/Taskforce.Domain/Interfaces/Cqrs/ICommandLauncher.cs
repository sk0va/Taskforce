namespace Taskforce.Domain.Interfaces.Cqrs;

public interface ICommandLauncher
{
    Task Run<TCommand>(TCommand command, CancellationToken ct) where TCommand : ICommand;
}
