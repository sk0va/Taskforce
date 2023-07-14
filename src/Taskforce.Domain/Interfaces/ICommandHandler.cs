
namespace Taskforce.Domain.Commands;

public interface ICommandHandler<T> where T : ICommand
{
    Task HandleAsync(T command);
}
