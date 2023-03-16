using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalContactApp.Application.Contracts;
using PersonalContactApp.Infrastructure.Persistence;

namespace PersonalContactApp.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDatabase(configuration)
            .AddRepositories();

    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<PersonalContactDbContext>(options => options
                .UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlServer => sqlServer
                        .MigrationsAssembly(typeof(PersonalContactDbContext)
                            .Assembly.FullName)));

    public static IServiceCollection AddRepositories(this IServiceCollection services)
        => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IRepository<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime());
}
