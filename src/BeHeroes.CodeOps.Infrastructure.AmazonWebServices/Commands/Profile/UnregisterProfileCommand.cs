using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile
{
    public sealed record UnregisterProfileCommand : AwsCommand<Task>
    {
        [JsonPropertyName("profileName")]
        public required string ProfileName { get; init; }

        [SetsRequiredMembers]
        public UnregisterProfileCommand(string profileName)
        {
            ProfileName = profileName;
        }
    }
}
