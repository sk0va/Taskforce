using Skova.Repository.Abstractions;
using Skova.Repository.Abstractions.Specifications;

using Taskforce.Domain.Interfaces.Cqrs;
using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Domain.Events;

public class UpdateEventCommandHandler : ICommandHandler<UpdateEventCommand>
{
    private readonly IRepository<Event> _eventRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly SpecificationFactory<IEventSpecification> _specificationsFactory;

    public UpdateEventCommandHandler(
        IUnitOfWork unitOfWork,
        IRepository<Event> eventRepository,
        SpecificationFactory<IEventSpecification> specificationsFactory)
    {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
        _specificationsFactory = specificationsFactory;
    }

    public async Task HandleAsync(UpdateEventCommand command, CancellationToken ct)
    {
        var @event = await _eventRepository.GetByIdAsync(command.EventId, ct);

        var spec = _specificationsFactory();
        spec.ById(command.EventId);

        await _eventRepository.With(spec)
            .UpdateAsync(
                @event => @event
                    .Set(e => e.IsTemplate, command.IsTemplate)
                    .Set(e => e.Title, command.Title)
                    .Set(e => e.Type, command.Type)
                    .Set(e => e.Description, command.Description)
                    .Set(e => e.StartDate, command.StartDate)
                    .Set(e => e.EndDate, command.EndDate)
                    .Set(e => e.UpdatedDate, DateTime.UtcNow),
                ct);

        await _unitOfWork.SaveChangesAsync(ct);
    }
}
