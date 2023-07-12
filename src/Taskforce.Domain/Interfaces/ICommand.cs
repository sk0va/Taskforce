namespace Taskforce.Domain;

public interface ICommand
{
    public Guid CommandId { get; set; }
}
