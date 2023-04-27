using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role
{
    public sealed record UpdateRoleCommand : AwsCommand<Task>
    {
        [JsonPropertyName("roleName")]
        public required string RoleName { get; init; }

        [JsonPropertyName("description")]
        public string? Description { get; init; }

        [SetsRequiredMembers]
        public UpdateRoleCommand(string roleName, string? description = default)
        {
            RoleName = roleName;
            Description = description;
        }
    }
}