using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PersonalContactApp.Application.MediatrPipeline;
using System.Reflection;

namespace PersonalContactApp.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
        => services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
}
