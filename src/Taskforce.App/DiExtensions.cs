using Taskforce.Db.Specifications;
using Taskforce.Domain;
using Taskforce.Domain.Entities;
using Taskforce.Domain.Interfaces;

namespace Taskforce.App;

internal static class DiExtensions
{
    public static IServiceCollection AddSpecifications(this IServiceCollection services)
    {
        services.AddSpec<ITaskSpecification, TaskSpecification>();
        
        return services;
    }

    private static void AddSpec<TSpecInterface, TSpecImpl>(this IServiceCollection services)
        where TSpecInterface : ISpecification<Entity>
        where TSpecImpl: class, TSpecInterface
    {
        services.AddTransient<TSpecImpl>();
        services.AddSingleton<SpecificationFactory<TSpecInterface>>(sp => () => (TSpecInterface)sp.GetRequiredService(typeof(TSpecImpl)));
    }
}
