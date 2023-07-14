namespace Taskforce.Domain.Interfaces.Cqrs;

public interface ICommand
{
    public Guid CommandId { get; set; }
}
