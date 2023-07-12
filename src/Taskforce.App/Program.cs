using Microsoft.EntityFrameworkCore;
using Taskforce.Db;
using AutoMapper;
using Taskforce.Domain.Commands;
using AutoMapper.Extensions.ExpressionMapping;
using Taskforce.Domain.Interfaces;
using Taskforce.Api.Queries;

namespace Taskforce.App;

internal static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder);

        var app = builder.Build();

        // Configure the HTTP request pipeline.            
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGraphQL();
        app.MapControllers();

        PrepareApp(app);

        app.Run();
    }

    private static void PrepareApp(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        // Check Automapper configuration
        scope.ServiceProvider.GetService<IMapper>()
            .ConfigurationProvider
            .AssertConfigurationIsValid();

        // Run DB migrations
        var db = scope.ServiceProvider.GetRequiredService<TaskforceDbContext>().Database;
        var isRelational = db.IsRelational();
        db.Migrate();
    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper(
            c => c.AddExpressionMapping(),
            typeof(TaskforceDbContext).Assembly);

        services.AddDbContext<TaskforceDbContext>(b =>
            b.UseNpgsql(
                builder.Configuration.GetConnectionString("TaskforceDb"),
                b => b.MigrationsAssembly(typeof(Db.Migrations.InitMigration).Assembly.FullName)));

        services
            .AddGraphQLServer()
            .ConfigureSchema(schemaBuilder =>
            {
                schemaBuilder.ModifyOptions(opt => opt.StrictValidation = false);
                schemaBuilder.AddQueryType<QueryType>();
            });

        services.AddTransient<ICommandLauncher, CommandLauncher>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICommandHandler<CreateTaskCommand>, CreateTaskCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateTaskCommand>, UpdateTaskCommandHandler>();

        services.AddSpecifications();
        services.AddScoped(typeof(IRepository<Domain.Entities.Task>), typeof(GenericRepository<Domain.Entities.Task, Db.Entities.Task>));
    }
}
