using PersonalContactApp.Application.Contracts;
using PersonalContactApp.Domain.Common;

namespace PersonalContactApp.Infrastructure.Persistence.Repositories;

internal abstract class DataRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
{
    protected DataRepository(PersonalContactDbContext db) => Data = db;

    protected PersonalContactDbContext Data { get; }

    protected IQueryable<TEntity> All() => Data.Set<TEntity>();

    public async Task Save(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        Data.Update(entity);

        await Data.SaveChangesAsync(cancellationToken);
    }
}
