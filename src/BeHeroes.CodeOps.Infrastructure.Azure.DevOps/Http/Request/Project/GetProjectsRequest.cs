﻿namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Project
{
    public sealed class GetProjectsRequest : ApiRequest
    {
        public GetProjectsRequest(string organization)
        {
            ApiVersion = "6.0";
            Method = HttpMethod.Get;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/_apis/projects?api-version={ApiVersion}");
        }
    }
}
