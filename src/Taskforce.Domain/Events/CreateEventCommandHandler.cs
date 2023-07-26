using Skova.Repository.Abstractions;

using Taskforce.Domain.Interfaces.Cqrs;

namespace Taskforce.Domain.Events;

public class CreateEventCommandHandler : ICommandHandler<CreateEventCommand>
{
    private readonly IRepository<Event> _eventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEventCommandHandler(
        IUnitOfWork unitOfWork,
        IRepository<Event> eventRepository)
    {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(CreateEventCommand command, CancellationToken ct)
    {
        var @event = new Event
        {
            Id = command.EventId,
            IsTemplate = command.IsTemplate,
            Title = command.Title,
            Type = command.Type,
            Description = command.Description,
            StartDate = command.StartDate,
            EndDate = command.EndDate,

            CreatedDate = DateTime.UtcNow
        };

        await _eventRepository.AddAsync(@event, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
