namespace Taskforce.Domain.Interfaces.Cqrs;

public interface ICommandLauncher
{
    Task Run<TCommand>(TCommand command) where TCommand : ICommand;
}
