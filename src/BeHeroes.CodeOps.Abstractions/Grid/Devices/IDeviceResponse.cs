using System.Net;

namespace BeHeroes.CodeOps.Abstractions.Grid.Devices
{
    public interface IDeviceResponse
    {
        HttpStatusCode Status { get; }

        HttpContent? Content { get; }
    }
}
