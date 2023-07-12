using Taskforce.Domain.Interfaces;

namespace Taskforce.Domain.Commands;

internal class UpdateTaskCommandHandler : ICommandHandler<UpdateTaskCommand>
{
    private readonly IRepository<Entities.Task> _taskRepository;
    private readonly SpecificationFactory<ITaskSpecification> _specificationsFactory;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTaskCommandHandler(
        IUnitOfWork unitOfWork,
        IRepository<Entities.Task> taskRepository,
        SpecificationFactory<ITaskSpecification> specificationsFactory)
    {
        _taskRepository = taskRepository;
        _specificationsFactory = specificationsFactory;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(UpdateTaskCommand command)
    {
        var task = await _taskRepository.GetByIdAsync(command.TaskId)
            ?? throw new KeyNotFoundException($"Task with id {command.TaskId} not found");

        var spec = _specificationsFactory();
        spec.ById(command.TaskId);

        await _taskRepository.With(spec)
            .UpdateAsync(task => task
                .Set(t => t.Title, command.Title)
                .Set(t => t.Description, command.Description)
                .Set(t => t.DueDate, command.DueDate)
            );

        await _unitOfWork.SaveChangesAsync();
    }
}
