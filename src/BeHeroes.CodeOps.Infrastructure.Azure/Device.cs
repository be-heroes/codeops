using BeHeroes.CodeOps.Abstractions.Aggregates;
using BeHeroes.CodeOps.Abstractions.Cryptography;
using BeHeroes.CodeOps.Abstractions.Grid;
using BeHeroes.CodeOps.Abstractions.Grid.Devices;

namespace BeHeroes.CodeOps.Infrastructure.Azure{
    public abstract class Device : AggregateRoot<Guid>, IDevice
    {
        public Uri Uri => throw new NotImplementedException();

        public ActorType ActorType => throw new NotImplementedException();

        public ActorStatus ActorStatus => throw new NotImplementedException();

        public IKey? SecurityKey => throw new NotImplementedException();

        public abstract KeyValuePair<string, string>? GetResourcePrincipal();

        public abstract Task<IDeviceResponse> Handle(IDeviceRequest request, CancellationToken cancellationToken = default);

        public abstract Task Handle(IDeviceEvent notification, CancellationToken cancellationToken);
    }
}