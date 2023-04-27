using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Role;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role
{
    public sealed record CreateRoleCommand : AwsCommand<RoleDto>
    {
        [JsonPropertyName("roleName")]
        public required string RoleName { get; init; }

        [JsonPropertyName("policyDocument")]
        public required string PolicyDocument { get; init; }

        [JsonPropertyName("description")]
        public required string Description { get; init; }

        [JsonPropertyName("tags")]
        public IEnumerable<KeyValuePair<string, string>>? Tags { get; }

        [SetsRequiredMembers]
        public CreateRoleCommand(string roleName, string policyDocument, string description, IEnumerable<KeyValuePair<string, string>>? tags = default)
        {
            RoleName = roleName;
            PolicyDocument = policyDocument;
            Tags = tags;
            Description = description;
        }
    }
}