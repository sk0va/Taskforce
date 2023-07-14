using Taskforce.Db;
using Taskforce.Db.Specifications;
using Taskforce.Domain;
using Taskforce.Domain.Commands;
using Taskforce.Domain.Entities;
using Taskforce.Domain.Interfaces;
using Taskforce.Domain.Queries;

namespace Taskforce.App;

internal static class DependenciesRegistrator
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IRepository<Domain.Entities.Task>, GenericRepository<Domain.Entities.Task, Db.Entities.Task>>();

        services.AddTransient<ICommandLauncher, CommandLauncher>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICommandHandler<CreateTaskCommand>, CreateTaskCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateTaskCommand>, UpdateTaskCommandHandler>();

        services.AddScoped(typeof(IEntityQuery<>), typeof(EntityQuery<>));

        services.AddSpecification<ITaskSpecification, TaskSpecification>();
    }

    private static void AddSpecification<TSpecInterface, TSpecImpl>(this IServiceCollection services)
        where TSpecInterface : ISpecification<Entity>
        where TSpecImpl: class, TSpecInterface
    {
        services.AddTransient<TSpecImpl>();
        services.AddSingleton<SpecificationFactory<TSpecInterface>>(sp => () => (TSpecInterface)sp.GetRequiredService(typeof(TSpecImpl)));
    }
}
