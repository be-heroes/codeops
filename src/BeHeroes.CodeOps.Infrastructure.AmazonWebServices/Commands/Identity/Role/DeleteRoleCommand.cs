using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role
{
    public sealed record DeleteRoleCommand : AwsCommand<Task>
    {
        [JsonPropertyName("roleName")]
        public required string RoleName { get; init; }

        [SetsRequiredMembers]
        public DeleteRoleCommand(string roleName)
        {
            RoleName = roleName;
        }
    }
}