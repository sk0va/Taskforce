namespace Taskforce.Domain.Commands;

public interface ICommandLauncher
{
    Task Run<TCommand>(TCommand command) where TCommand : ICommand;
}
