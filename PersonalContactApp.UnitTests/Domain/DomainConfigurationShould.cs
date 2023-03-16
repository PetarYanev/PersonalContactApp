using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PersonalContactApp.Domain;
using PersonalContactApp.Domain.Factories;
using Xunit;

namespace PersonalContactApp.UnitTests.Domain
{
    public class DomainConfigurationShould
    {
        [Fact]
        public void AddDomainShouldRegisterFactories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IContactFactory>()
                .Should()
                .NotBeNull();
        }
    }
}
