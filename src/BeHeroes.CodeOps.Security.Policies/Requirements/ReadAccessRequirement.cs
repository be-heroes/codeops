using BeHeroes.CodeOps.Security.Policies.Policies.All;

namespace BeHeroes.CodeOps.Security.Policies.Requirements
{
    public sealed class ReadAccessRequirement : AccessRequirement
    {
        public ReadAccessRequirement() => AccessRequirementClaimName = ReadAccessPolicy.PolicyName;
    }
}
