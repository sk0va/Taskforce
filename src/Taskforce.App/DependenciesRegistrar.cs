using Taskforce.Domain.Queries;
using Taskforce.Domain.Interfaces.Cqrs;
using Taskforce.Domain.Interfaces.Specifications;
using Taskforce.Domain.Tasks;
using Taskforce.Domain.Events;

using Taskforce.Db;
using Taskforce.Db.Tasks;
using Taskforce.Db.Events;

using Skova.Repository.DependencyInjection;
using Taskforce.Domain.Entities;
using Skova.Repository.Abstractions.Specifications;

namespace Taskforce.App;

internal static class DependenciesRegistrar
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddUnitOfWorkAsScoped<TaskforceDbContext>()
            .AddRepositoryAsScoped<Domain.Tasks.Task, DbTask>(c => c.AddKeyRecognizer(e => new object[]{ e.Id }))
            .AddSpecificationAsTransient<ITaskSpecification, TaskSpecification>()
            .AddSpecificationAsTransient<ISpecification<Domain.Tasks.Task>, TaskSpecification>()

            .AddRepositoryAsScoped<Event, DbEvent>(c => c.AddKeyRecognizer(e => new object[]{ e.Id }))
            .AddSpecificationAsTransient<IEventSpecification, EventSpecification>()
            .AddSpecificationAsTransient<ISpecification<Event>, EventSpecification>();

        services.AddTransient<ICommandLauncher, CommandLauncher>();
        services.AddScoped(typeof(IEntityQuery<>), typeof(EntityQuery<>));

        void AddCommandHandler<TCommand, THandler>()
            where TCommand : ICommand
            where THandler: class, ICommandHandler<TCommand>
            => services.AddScoped<ICommandHandler<TCommand>, THandler>();

        AddCommandHandler<CreateTaskCommand, CreateTaskCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteEntityByIdCommand<Domain.Tasks.Task>>, DeleteEntityByIdHandler<Domain.Tasks.Task>>();

        AddCommandHandler<UpdateTaskCommand, UpdateTaskCommandHandler>();

        AddCommandHandler<CreateEventCommand, CreateEventCommandHandler>();
        AddCommandHandler<UpdateEventCommand, UpdateEventCommandHandler>();
    }
}
