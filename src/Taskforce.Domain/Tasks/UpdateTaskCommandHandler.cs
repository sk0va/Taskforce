using Skova.Repository.Abstractions;
using Skova.Repository.Abstractions.Specifications;

using Taskforce.Domain.Interfaces.Cqrs;
using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Domain.Tasks;

internal class UpdateTaskCommandHandler : ICommandHandler<UpdateTaskCommand>
{
    private readonly IRepository<Task> _taskRepository;
    private readonly SpecificationFactory<ITaskSpecification> _specificationsFactory;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTaskCommandHandler(
        IUnitOfWork unitOfWork,
        IRepository<Task> taskRepository,
        SpecificationFactory<ITaskSpecification> specificationsFactory)
    {
        _taskRepository = taskRepository;
        _specificationsFactory = specificationsFactory;
        _unitOfWork = unitOfWork;
    }

    public async System.Threading.Tasks.Task HandleAsync(UpdateTaskCommand command, CancellationToken ct)
    {
        var spec = _specificationsFactory();
        spec.ById(command.TaskId);
        var task = (await _taskRepository.With(spec).ExecuteQueryAsync(ct)).FirstOrDefault()
            ?? throw new KeyNotFoundException($"Task with id {command.TaskId} not found");

        spec = _specificationsFactory();
        spec.ById(command.TaskId);

        await _taskRepository.With(spec)
            .ExecuteUpdateAsync(
                task => task
                    .Set(t => t.Title, command.Title)
                    .Set(t => t.Description, command.Description)
                    .Set(t => t.DueDate, command.DueDate),
                ct);

        await _unitOfWork.SaveChangesAsync(ct);
    }
}
