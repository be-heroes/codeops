using BeHeroes.CodeOps.Abstractions.Events;

namespace BeHeroes.CodeOps.Abstractions.Grid.Provisioning
{
    public interface IProvisioningBroker : IProvisioningHandler, IEventHandler<IProvisioningEvent>
    {
    }
}
