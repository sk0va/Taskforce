using Taskforce.Domain.Queries;
using Taskforce.Domain.Interfaces.Cqrs;
using Taskforce.Domain.Interfaces.Specifications;
using Taskforce.Domain.Tasks;
using Taskforce.Domain.Events;

using Taskforce.Db;
using Taskforce.Db.Tasks;
using Taskforce.Db.Events;

using Skova.Repository.DependencyInjection;

namespace Taskforce.App;

internal static class DependenciesRegistrator
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddTransient<ICommandLauncher, CommandLauncher>();

        services.AddScoped<ICommandHandler<CreateTaskCommand>, CreateTaskCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateTaskCommand>, UpdateTaskCommandHandler>();

        services.AddScoped<ICommandHandler<CreateEventCommand>, CreateEventCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateEventCommand>, UpdateEventCommandHandler>();

        services.AddScoped(typeof(IEntityQuery<>), typeof(EntityQuery<>));

        services.AddUnitOfWorkAsScoped<TaskforceDbContext>()
            .AddRepositoryAsScoped<Domain.Tasks.Task, DbTask>()
            .AddSpecificationAsTransient<ITaskSpecification, TaskSpecification>()

            .AddRepositoryAsScoped<Event, DbEvent>()
            .AddSpecificationAsTransient<IEventSpecification, EventSpecification>();
    }
}
