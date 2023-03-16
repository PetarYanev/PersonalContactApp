using Microsoft.Extensions.DependencyInjection;
using PersonalContactApp.Domain.Factories;

namespace PersonalContactApp.Domain;

public static class DomainConfiguration
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
        => services
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IFactory<>)))
                .AsMatchingInterface()
                .WithTransientLifetime());
}
