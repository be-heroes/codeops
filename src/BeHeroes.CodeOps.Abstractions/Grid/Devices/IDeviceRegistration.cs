using BeHeroes.CodeOps.Abstractions.Aggregates;

namespace BeHeroes.CodeOps.Abstractions.Grid.Devices
{
    public interface IDeviceRegistration : IAggregateRoot
    {
        string Identifier { get; }

        string ConnectionString { get; }
    }
}
