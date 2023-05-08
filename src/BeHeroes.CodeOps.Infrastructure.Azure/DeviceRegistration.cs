using System.ComponentModel.DataAnnotations;
using BeHeroes.CodeOps.Abstractions.Aggregates;
using BeHeroes.CodeOps.Abstractions.Grid.Devices;

namespace BeHeroes.CodeOps.Infrastructure.Azure
{
    public sealed class DeviceRegistration : AggregateRoot<Guid>, IDeviceRegistration
    {
        public string Identifier { get; init; }

        public string ConnectionString  { get; init; }

        public DeviceRegistration(string identifier, string connectionString)
        {
            Identifier = identifier;
            ConnectionString = connectionString;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }
    }
}