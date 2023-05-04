using BeHeroes.CodeOps.Abstractions.Aggregates;
using BeHeroes.CodeOps.Abstractions.Data;
using System.Linq.Expressions;

namespace BeHeroes.CodeOps.Abstractions.Repositories
{
    public interface IRepository<TAggregate> : IRepository where TAggregate : IAggregateRoot
    {
        Task<IEnumerable<TAggregate>> GetAsync(Expression<Func<TAggregate, bool>> filter, CancellationToken ct = default);

        TAggregate Add(TAggregate aggregate);

        TAggregate Update(TAggregate aggregate);

        void Delete(TAggregate aggregate);
    }

    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
