using Skova.Repository.Abstractions;

using Taskforce.Domain.Interfaces.Cqrs;

namespace Taskforce.Domain.Tasks;

internal class CreateTaskCommandHandler : ICommandHandler<CreateTaskCommand>
{
    private readonly IRepository<Task> _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskCommandHandler(
        IUnitOfWork unitOfWork,
        IRepository<Task> taskRepository)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }

    public async System.Threading.Tasks.Task HandleAsync(CreateTaskCommand command, CancellationToken ct)
    {
        var task = new Task
        {
            Id = command.TaskId,
            Title = command.Title,
            Description = command.Description,
            DueDate = command.DueDate,
            State = "New",
            
            CreatedDate = DateTime.UtcNow
        };

        await _taskRepository.AddAsync(task, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
