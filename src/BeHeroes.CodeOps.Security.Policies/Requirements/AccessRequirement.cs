using Microsoft.AspNetCore.Authorization;

namespace BeHeroes.CodeOps.Security.Policies.Requirements
{
    public abstract class AccessRequirement : IAuthorizationRequirement
    {
        public string AccessRequirementClaimName { get; protected set; }
    }
}
