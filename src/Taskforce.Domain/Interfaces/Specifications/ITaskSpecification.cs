namespace Taskforce.Domain;


public interface IEntitySpecification : ISpecification<Entities.Entity>
{
    public void ById(Guid id);

    void CreatedDateBetween(DateTime? from = null, DateTime? till = null);
    void CreatedDateIs(DateTime? exactValue = null);

    void UpdatedDateBetween(DateTime? from = null, DateTime? till = null);
    void UpdatedDateIs(DateTime? exactValue = null);

    void DeletedDateBetween(DateTime? from = null, DateTime? till = null);
    void DeletedDateIs(DateTime? exactValue = null);
}

public interface ITaskSpecification : IEntitySpecification, ISpecification<Entities.Task>
{
    public void TitleContains(string title);

    public void DescriptionContains(string description);
}
