using PersonalContactApp.Domain.Common;

namespace PersonalContactApp.Application.Contracts;

public interface IRepository<in TEntity>
    where TEntity : IAggregateRoot
{
    Task Save(TEntity entity, CancellationToken cancellationToken = default);
}
