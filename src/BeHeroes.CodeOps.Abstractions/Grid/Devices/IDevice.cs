using BeHeroes.CodeOps.Abstractions.Aggregates;
using BeHeroes.CodeOps.Abstractions.Commands;
using BeHeroes.CodeOps.Abstractions.Events;

namespace BeHeroes.CodeOps.Abstractions.Grid.Devices
{
    public interface IDevice : IActor, IAggregateRoot, ICommandHandler<IDeviceRequest, IDeviceResponse>, IEventHandler<IDeviceEvent>
    {
        new ActorType ActorType => ActorType.System | ActorType.External;
    }
}
