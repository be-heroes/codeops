using BeHeroes.CodeOps.Security.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace BeHeroes.CodeOps.Security.Policies.Policies.All
{
    public sealed class ReadAccessPolicy : AuthorizationPolicy
    {
        public const string PolicyName = "dfds.all.read";

        public ReadAccessPolicy(IEnumerable<string> authenticationSchemes) : base(new IAuthorizationRequirement[] { new ReadAccessRequirement() }, authenticationSchemes)
        {
        }
    }
}
