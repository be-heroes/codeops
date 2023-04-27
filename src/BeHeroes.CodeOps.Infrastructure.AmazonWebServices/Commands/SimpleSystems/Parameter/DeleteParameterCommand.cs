using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter
{
    public sealed record DeleteParameterCommand : AwsCommand<Task>
    {
        [JsonPropertyName("name")]
        public required string Name { get; init; }

        [SetsRequiredMembers]
        public DeleteParameterCommand(string name)
        {
            if (name.EndsWith("/"))
            {
                name = name.TrimEnd('/');
            }

            Name = name;
        }
    }
}