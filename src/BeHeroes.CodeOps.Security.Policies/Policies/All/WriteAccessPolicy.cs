using BeHeroes.CodeOps.Security.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace BeHeroes.CodeOps.Security.Policies.Policies.All
{
    public sealed class WriteAccessPolicy : AuthorizationPolicy
    {
        public const string PolicyName = "beheroes.all.write";

        public WriteAccessPolicy(IEnumerable<string> authenticationSchemes) : base(new IAuthorizationRequirement[] { new WriteAccessRequirement() }, authenticationSchemes)
        {
        }
    }
}
