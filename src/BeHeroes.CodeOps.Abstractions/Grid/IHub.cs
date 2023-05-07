using BeHeroes.CodeOps.Abstractions.Grid.Devices;
using BeHeroes.CodeOps.Abstractions.Repositories;

namespace BeHeroes.CodeOps.Abstractions.Grid
{
    public interface IHub : IActor, IRepository<IDeviceRegistration>
    {
        new ActorType ActorType => ActorType.System;

        IDeviceClient GetDeviceClient(IDeviceRegistration registration)
        {
            return GetDeviceClient(registration.ConnectionString);
        }

        IDeviceClient GetDeviceClient(string connectionString);
    }
}
