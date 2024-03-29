﻿namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Project
{
    public sealed class GetProjectRequest : ApiRequest
    {
        public GetProjectRequest(string organization, string projectIdentifier)
        {
            ApiVersion = "6.0";
            Method = HttpMethod.Get;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/_apis/projects/{projectIdentifier}?api-version={ApiVersion}");
        }
    }
}
