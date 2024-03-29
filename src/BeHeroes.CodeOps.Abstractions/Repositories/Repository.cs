﻿using BeHeroes.CodeOps.Abstractions.Aggregates;
using BeHeroes.CodeOps.Abstractions.Data;
using System.Linq.Expressions;

namespace BeHeroes.CodeOps.Abstractions.Repositories
{
    public abstract class Repository<TContext, TAggregate> : IRepository<TAggregate>
        where TContext : class, IUnitOfWork
        where TAggregate : IAggregateRoot
    {
        protected readonly TContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        protected Repository(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public abstract TAggregate Add(TAggregate aggregate);

        public abstract TAggregate Update(TAggregate aggregate);

        public abstract void Delete(TAggregate aggregate);

        public abstract Task<IEnumerable<TAggregate>> GetAsync(Expression<Func<TAggregate, bool>> filter, CancellationToken ct = default);
    }
}
