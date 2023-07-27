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

internal static class DependenciesRegistrar
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddUnitOfWorkAsScoped<TaskforceDbContext>()
            .AddRepositoryAsScoped<Domain.Tasks.Task, DbTask>()
            .AddSpecificationAsTransient<ITaskSpecification, TaskSpecification>()

            .AddRepositoryAsScoped<Event, DbEvent>()
            .AddSpecificationAsTransient<IEventSpecification, EventSpecification>();

        services.AddTransient<ICommandLauncher, CommandLauncher>();
        services.AddScoped(typeof(IEntityQuery<>), typeof(EntityQuery<>));

        void AddCommandHandler<TCommand, THandler>()
            where TCommand : ICommand
            where THandler: class, ICommandHandler<TCommand>
            => services.AddScoped<ICommandHandler<TCommand>, THandler>();

        AddCommandHandler<CreateTaskCommand, CreateTaskCommandHandler>();
        AddCommandHandler<UpdateTaskCommand, UpdateTaskCommandHandler>();

        AddCommandHandler<CreateEventCommand, CreateEventCommandHandler>();
        AddCommandHandler<UpdateEventCommand, UpdateEventCommandHandler>();
    }
}
