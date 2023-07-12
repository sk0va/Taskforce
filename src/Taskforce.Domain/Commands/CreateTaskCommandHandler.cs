
using Taskforce.Domain.Interfaces;

namespace Taskforce.Domain.Commands;

internal class CreateTaskCommandHandler : ICommandHandler<CreateTaskCommand>
{
    private readonly IRepository<Entities.Task> _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskCommandHandler(
        IUnitOfWork unitOfWork,
        IRepository<Entities.Task> taskRepository)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(CreateTaskCommand command)
    {
        var task = new Entities.Task
        {
            Id = command.TaskId,
            Title = command.Title,
            Description = command.Description,
            DueDate = command.DueDate,
            State = "New"
        };

        await _taskRepository.AddAsync(task);

        await _unitOfWork.SaveChangesAsync();
    }
}
