using Taskforce.Domain.Interfaces.Cqrs;

namespace Taskforce.App;

public class CommandLauncher : ICommandLauncher
{
    private readonly IServiceProvider _provider;

    public CommandLauncher(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task Run<TCommand>(TCommand command, CancellationToken ct) where TCommand : ICommand
    {
        var commandHandler = _provider.GetRequiredService<ICommandHandler<TCommand>>();

        await commandHandler.HandleAsync(command, ct);
    }
}
