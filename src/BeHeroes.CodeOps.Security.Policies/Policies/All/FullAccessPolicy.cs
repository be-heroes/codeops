﻿using BeHeroes.CodeOps.Security.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace BeHeroes.CodeOps.Security.Policies.Policies.All
{
    public sealed class FullAccessPolicy : AuthorizationPolicy
    {
        public const string PolicyName = "dfds.all.full";

        public FullAccessPolicy(IEnumerable<string> authenticationSchemes) : base(new IAuthorizationRequirement[] { new WriteAccessRequirement(), new ReadAccessRequirement(), new ExecuteAccessRequirement() }, authenticationSchemes)
        {
        }
    }
}
