using PersonalContactApp.Domain.Common;

namespace PersonalContactApp.Domain.Factories;

public interface IFactory<out TEntity>
        where TEntity : IAggregateRoot
{
    TEntity Build();
}
