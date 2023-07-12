using Taskforce.Domain.Entities;

namespace Taskforce.Domain.Interfaces;

public delegate TSpec SpecificationFactory<TSpec>() where TSpec : ISpecification<Entity>;

// public class SpecificationFactory<T> : ISpecificationsFactory<T>
// where T: Entity
// {
//     private readonly Dictionary<Type, Func<ISpecification<T>>> _specificationsFactories;

//     public SpecificationFactory(Dictionary<Type, Func<ISpecification<T>>> specificationsFactories)
//     {
//         _specificationsFactories = specificationsFactories;
//     }

//     public TSpec Create<TSpec>() where TSpec : ISpecification<T>
//     {
//         var t = typeof(TSpec);
//         return _specificationsFactories.Create<TSpec>();
//     }
// }
