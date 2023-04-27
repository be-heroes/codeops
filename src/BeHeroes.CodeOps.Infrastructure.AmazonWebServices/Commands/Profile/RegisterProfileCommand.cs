using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Identity;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile
{
    public sealed record RegisterProfileCommand : AwsCommand<Task>
    {
        [JsonPropertyName("profile")]
        public required IAwsProfile Profile { get; init; }

        internal string AccessKey { get; init; }

        internal string SecretKey { get; init; }

        [SetsRequiredMembers]
        public RegisterProfileCommand(IAwsProfile profile, string accessKey, string secretKey)
        {
            Profile = profile;
            AccessKey = accessKey;
            SecretKey = secretKey;
        }
    }
}
