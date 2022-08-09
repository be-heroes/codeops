using BeHeroes.CodeOps.Abstractions.Commands;

namespace BeHeroes.CodeOps.Abstractions.Grid.Provisioning
{
    public interface IProvisioningHandler : ICommandHandler<IProvisioningRequest, IProvisioningResponse>, IGridActor
    {

    }
}
