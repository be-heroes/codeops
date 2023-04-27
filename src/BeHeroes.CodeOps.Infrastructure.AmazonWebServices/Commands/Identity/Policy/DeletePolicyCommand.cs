using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Policy
{
    public sealed record DeletePolicyCommand : AwsCommand<Task>
    {
        [JsonPropertyName("policyArn")]
        public required string PolicyArn { get; init; }

        [SetsRequiredMembers]
        public DeletePolicyCommand(string policyArn)
        {
            PolicyArn = policyArn;
        }
    }
}