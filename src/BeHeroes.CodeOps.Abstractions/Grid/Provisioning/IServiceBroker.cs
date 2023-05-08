using BeHeroes.CodeOps.Abstractions.Commands;
using BeHeroes.CodeOps.Abstractions.Events;
using BeHeroes.CodeOps.Abstractions.Services;

namespace BeHeroes.CodeOps.Abstractions.Grid.Provisioning
{
    public interface IServiceBroker : IActor, IService, ICommandHandler<IProvisioningRequest, IProvisioningResponse>, IEventHandler<IProvisioningEvent>
    {
        new ActorType ActorType => ActorType.System;
    }
}
