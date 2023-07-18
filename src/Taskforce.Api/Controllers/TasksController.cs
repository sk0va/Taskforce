using Microsoft.AspNetCore.Mvc;
using Taskforce.Domain.Interfaces.Cqrs;
using Taskforce.Domain.Tasks;

namespace Taskforce.App.Controllers;

[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ICommandLauncher _commandLauncher;

    public TasksController(ICommandLauncher commandLauncher)
    {
        _commandLauncher = commandLauncher;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTaskAsync(
        [FromBody] CreateTaskCommand command, CancellationToken ct)
    {
        await _commandLauncher.Run(command, ct);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTaskAsync(
        [FromBody] UpdateTaskCommand command, CancellationToken ct)
    {
        await _commandLauncher.Run(command, ct);

        return NoContent();
    }
}
