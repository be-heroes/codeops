using System.Net.Http;

namespace BeHeroes.CodeOps.Abstractions.Grid.Provisioning
{
    public interface IProvisioningResponse
    {
        HttpContent Content { get; }
    }
}
