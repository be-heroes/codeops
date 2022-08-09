using BeHeroes.CodeOps.Abstractions.Entities;

namespace BeHeroes.CodeOps.Abstractions.Aggregates
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot where TKey : struct
    {

    }
}
