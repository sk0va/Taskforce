using Skova.Repository.Abstractions.Specifications;

using Taskforce.Domain.Entities;
using Taskforce.Domain.Interfaces.Specifications;
using Taskforce.Db.Entities;

namespace Taskforce.Api.Queries;

public class EntitySpecificationInput : ISpecificationInput<Entity>
{
    public ISpecification<Entity> ToSpecification()
    {
        var specification = new EntitySpecification<DbEntity>();

        FillSpecification(specification);

        return specification;
    }

    public Optional<Guid?> Id { get; set; }

    public Optional<DateTime?> CreatedDate { get; set; }
    public Optional<DateTime?> CreatedDateFrom { get; set; }
    public Optional<DateTime?> CreatedDateTill { get; set; }

    public Optional<DateTime?> UpdatedDate { get; set; }
    public Optional<DateTime?> UpdatedDateFrom { get; set; }
    public Optional<DateTime?> UpdatedDateTill { get; set; }

    public Optional<DateTime?> DeletedDate { get; set; }
    public Optional<DateTime?> DeletedDateFrom { get; set; }
    public Optional<DateTime?> DeletedDateTill { get; set; }

    protected void FillSpecification(IEntitySpecification specification)
    {
        if (Id.HasValue && Id.Value.HasValue)
            specification.ById(Id.Value.Value);

        if (CreatedDate.HasValue)
            specification.CreatedDateIs(CreatedDate.Value);

        if (CreatedDateFrom.HasValue || CreatedDateTill.HasValue)
            specification.CreatedDateBetween(CreatedDateFrom.Value, CreatedDateTill.Value);

        if (UpdatedDate.HasValue)
            specification.UpdatedDateIs(UpdatedDate.Value);

        if (UpdatedDateFrom.HasValue || UpdatedDateTill.HasValue)
            specification.UpdatedDateBetween(UpdatedDateFrom.Value, UpdatedDateTill.Value);

        if (DeletedDate.HasValue)
            specification.DeletedDateIs(DeletedDate.Value);

        if (DeletedDateFrom.HasValue || DeletedDateTill.HasValue)
            specification.DeletedDateBetween(DeletedDateFrom.Value, DeletedDateTill.Value);
    }
}
