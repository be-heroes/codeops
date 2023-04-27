using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter
{
    public sealed record GetParameterCommand : AwsCommand<ParameterDto>
    {
        [JsonPropertyName("name")]
        public required string Name { get; init; }

        [SetsRequiredMembers]
        public GetParameterCommand(string name)
        {
            if (name.EndsWith("/"))
            {
                name = name.TrimEnd('/');
            }

            Name = name;
        }
    }
}