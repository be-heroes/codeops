using BeHeroes.CodeOps.Abstractions.Facade;

namespace BeHeroes.CodeOps.Abstractions.Grid.Devices
{
    public interface IDeviceClient : IFacade, IActor
    {
        new ActorType ActorType => ActorType.User | ActorType.External;        
    }
}
