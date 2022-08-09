using BeHeroes.CodeOps.Security.Policies.Policies.All;

namespace BeHeroes.CodeOps.Security.Policies.Requirements
{
    public sealed class WriteAccessRequirement : AccessRequirement
    {
        public WriteAccessRequirement() => AccessRequirementClaimName = WriteAccessPolicy.PolicyName;
    }
}
