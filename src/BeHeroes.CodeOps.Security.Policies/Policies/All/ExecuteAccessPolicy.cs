using BeHeroes.CodeOps.Security.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace BeHeroes.CodeOps.Security.Policies.Policies.All
{
    public sealed class ExecuteAccessPolicy : AuthorizationPolicy
    {
        public const string PolicyName = "dfds.all.execute";

        public ExecuteAccessPolicy(IEnumerable<string> authenticationSchemes) : base(new IAuthorizationRequirement[] { new ExecuteAccessRequirement() }, authenticationSchemes)
        {
        }
    }
}
