using BeHeroes.CodeOps.Security.Policies.Policies.All;

namespace BeHeroes.CodeOps.Security.Policies.Requirements
{
    public sealed class ExecuteAccessRequirement : AccessRequirement
    {
        public ExecuteAccessRequirement() => AccessRequirementClaimName = ExecuteAccessPolicy.PolicyName;
    }
}
