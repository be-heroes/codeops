using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using BeHeroes.CodeOps.Abstractions.Cryptography;
using BeHeroes.CodeOps.Abstractions.Data;
using BeHeroes.CodeOps.Abstractions.Grid;
using BeHeroes.CodeOps.Abstractions.Grid.Devices;
using BeHeroes.CodeOps.Abstractions.Repositories;

namespace BeHeroes.CodeOps.Infrastructure.Azure.Devices
{
    public sealed class Hub<TContext> : Repository<TContext, IDeviceRegistration>, IHub where TContext : class, IUnitOfWork
    {
        public Guid Id => throw new NotImplementedException();

        public Uri Uri => throw new NotImplementedException();

        public ActorType ActorType => throw new NotImplementedException();

        public ActorStatus ActorStatus => throw new NotImplementedException();

        public IKey? SecurityKey => throw new NotImplementedException();

        public Hub(TContext context) : base(context)
        {
        }

        public override IDeviceRegistration Add(IDeviceRegistration aggregate)
        {
            throw new NotImplementedException();
        }

        public override void Delete(IDeviceRegistration aggregate)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<IDeviceRegistration>> GetAsync(Expression<Func<IDeviceRegistration, bool>> filter, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public IDeviceClient GetDeviceClient(string connectionString)
        {
            throw new NotImplementedException();
        }

        public KeyValuePair<string, string>? GetResourcePrincipal()
        {
            throw new NotImplementedException();
        }

        public override IDeviceRegistration Update(IDeviceRegistration aggregate)
        {
            throw new NotImplementedException();
        }
    }
}