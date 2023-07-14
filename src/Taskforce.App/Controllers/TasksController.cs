using Microsoft.AspNetCore.Mvc;
using Taskforce.Domain.Commands;

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
        [FromBody] CreateTaskCommand command)
    {
        await _commandLauncher.Run(command);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTaskAsync(
        [FromBody] UpdateTaskCommand command)
    {
        await _commandLauncher.Run(command);

        return Ok();
    }
}
