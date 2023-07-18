using Taskforce.Domain.Entities;
using Taskforce.Domain.Interfaces;
using Taskforce.Domain.Queries;

using Taskforce.Db;
using Taskforce.Domain.Interfaces.Cqrs;
using Taskforce.Domain.Interfaces.Specifications;
using Taskforce.Db.Tasks;
using Taskforce.Domain.Tasks;
using Taskforce.Db.Events;
using Taskforce.Domain.Events;

namespace Taskforce.App;

internal static class DependenciesRegistrator
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IRepository<Domain.Tasks.Task>, GenericRepository<Domain.Tasks.Task, DbTask>>();
        services.AddScoped<IRepository<Event>, GenericRepository<Event, DbEvent>>();

        services.AddTransient<ICommandLauncher, CommandLauncher>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICommandHandler<CreateTaskCommand>, CreateTaskCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateTaskCommand>, UpdateTaskCommandHandler>();

        services.AddScoped<ICommandHandler<CreateEventCommand>, CreateEventCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateEventCommand>, UpdateEventCommandHandler>();

        services.AddScoped(typeof(IEntityQuery<>), typeof(EntityQuery<>));

        services.AddSpecification<ITaskSpecification, TaskSpecification>();
        services.AddSpecification<IEventSpecification, EventSpecification>();
    }

    private static void AddSpecification<TSpecInterface, TSpecImpl>(this IServiceCollection services)
        where TSpecInterface : ISpecification<Entity>
        where TSpecImpl : class, TSpecInterface
    {
        services.AddTransient<TSpecImpl>();
        services.AddSingleton<SpecificationFactory<TSpecInterface>>(sp => () => (TSpecInterface)sp.GetRequiredService(typeof(TSpecImpl)));
    }
}
