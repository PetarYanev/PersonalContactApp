using Microsoft.EntityFrameworkCore;
using PersonalContactApp.Domain.Models.Entities;
using PersonalContactApp.Infrastructure.Utils;
using System.Reflection;

namespace PersonalContactApp.Infrastructure.Persistence;

public class PersonalContactDbContext : DbContext
{
    public PersonalContactDbContext(DbContextOptions<PersonalContactDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }
}
