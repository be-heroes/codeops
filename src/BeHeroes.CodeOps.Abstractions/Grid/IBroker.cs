using BeHeroes.CodeOps.Abstractions.Commands;
using BeHeroes.CodeOps.Abstractions.Events;
using BeHeroes.CodeOps.Abstractions.Grid.Devices;
using BeHeroes.CodeOps.Abstractions.Grid.Provisioning;
using BeHeroes.CodeOps.Abstractions.Repositories;

namespace BeHeroes.CodeOps.Abstractions.Grid
{
    public interface IBroker : IActor, IRepository<IDevice>, ICommandHandler<IProvisioningRequest, IProvisioningResponse>, IEventHandler<IProvisioningEvent>
    {
        new ActorType ActorType => ActorType.System;

        async ValueTask<bool> IsSupportedDevice(IDevice device)
        {
            return await GetAsync(o => o.Equals(device)).ContinueWith<bool>(o => o.Result.Any());
        }
    }
}
