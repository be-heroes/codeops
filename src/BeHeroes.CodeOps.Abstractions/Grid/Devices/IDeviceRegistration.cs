using BeHeroes.CodeOps.Abstractions.Aggregates;

namespace BeHeroes.CodeOps.Abstractions.Grid.Devices
{
    public interface IDeviceRegistration : IAggregateRoot
    {
        DecentralizedIdentifier Identifier { get; }

        string ConnectionString { get; }
    }
}
