using Taskforce.Domain.Entities;

namespace Taskforce.Domain.Interfaces.Specifications;

public delegate TSpec SpecificationFactory<TSpec>() where TSpec : ISpecification<Entity>;
