using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalContactApp.Application.Features.Contacts;
using PersonalContactApp.Infrastructure;
using PersonalContactApp.Infrastructure.Persistence;
using Xunit;

namespace PersonalContactApp.UnitTests.Infrastructure
{
    public class InfrastructureConfigurationShould
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<PersonalContactDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()));

            // Act
            var services = serviceCollection
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IContactRepository>()
                .Should()
                .NotBeNull();
        }
    }
}