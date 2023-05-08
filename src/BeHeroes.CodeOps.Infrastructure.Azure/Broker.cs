using System.Linq.Expressions;
using BeHeroes.CodeOps.Abstractions.Cryptography;
using BeHeroes.CodeOps.Abstractions.Data;
using BeHeroes.CodeOps.Abstractions.Grid;
using BeHeroes.CodeOps.Abstractions.Grid.Devices;
using BeHeroes.CodeOps.Abstractions.Grid.Provisioning;
using BeHeroes.CodeOps.Abstractions.Repositories;

namespace BeHeroes.CodeOps.Infrastructure.Azure
{
    public sealed class Broker<TContext> : Repository<TContext, IDevice>, IBroker where TContext : class, IUnitOfWork
    {
        public Guid Id => throw new NotImplementedException();

        public Uri Uri => throw new NotImplementedException();

        public ActorType ActorType => throw new NotImplementedException();

        public ActorStatus ActorStatus => throw new NotImplementedException();

        public IKey? SecurityKey => throw new NotImplementedException();

        public Broker(TContext context) : base(context)
        {
        }

        public override IDevice Add(IDevice aggregate)
        {
            throw new NotImplementedException();
        }

        public override void Delete(IDevice aggregate)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<IDevice>> GetAsync(Expression<Func<IDevice, bool>> filter, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public KeyValuePair<string, string>? GetResourcePrincipal()
        {
            throw new NotImplementedException();
        }

        public Task<IProvisioningResponse> Handle(IProvisioningRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Handle(IProvisioningEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override IDevice Update(IDevice aggregate)
        {
            throw new NotImplementedException();
        }
    }
}