using Skova.Repository.Abstractions.Specifications;

namespace Taskforce.Api.Queries;

public interface ISpecificationInput<TDomain>
    where TDomain : Domain.Entities.Entity
{
    ISpecification<TDomain> ToSpecification();
}
