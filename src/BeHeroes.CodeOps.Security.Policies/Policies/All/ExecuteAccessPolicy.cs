using BeHeroes.CodeOps.Security.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace BeHeroes.CodeOps.Security.Policies.Policies.All
{
    public sealed class ExecuteAccessPolicy : AuthorizationPolicy
    {
        public const string PolicyName = "beheroes.all.execute";

        public ExecuteAccessPolicy(IEnumerable<string> authenticationSchemes) : base(new IAuthorizationRequirement[] { new ExecuteAccessRequirement() }, authenticationSchemes)
        {
        }
    }
}
