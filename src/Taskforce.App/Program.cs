using Microsoft.EntityFrameworkCore;
using Taskforce.Db;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Taskforce.Api.Queries;
using Taskforce.App.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

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

            // app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGraphQL();
        app.MapControllers();

        // blazor section

        app.UseStaticFiles();
        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        PrepareApp(app);

        app.Run();
    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddControllers()
            .PartManager
            .ApplicationParts
            .Add(new AssemblyPart(typeof(TasksController).Assembly));

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


        // Add services to the container.
        services.AddRazorPages();
        services.AddServerSideBlazor();

        DependenciesRegistrator.RegisterServices(services);
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
}
