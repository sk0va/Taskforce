using Microsoft.AspNetCore.Mvc;
using Taskforce.Domain.Events;
using Taskforce.Domain.Interfaces.Cqrs;

namespace Taskforce.Api.Controllers;

[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly ICommandLauncher _commandLauncher;

    public EventsController(ICommandLauncher commandLauncher)
    {
        _commandLauncher = commandLauncher;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEventAsync(
        [FromBody] CreateEventCommand command, CancellationToken ct)
    {
        await _commandLauncher.Run(command, ct);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEventAsync(
        [FromBody] UpdateEventCommand command, CancellationToken ct)
    {
        await _commandLauncher.Run(command, ct);

        return NoContent();
    }
}
