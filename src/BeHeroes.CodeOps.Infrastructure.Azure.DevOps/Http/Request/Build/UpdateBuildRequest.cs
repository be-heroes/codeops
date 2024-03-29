﻿using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Build;
using System.Text.Json;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Build
{
    public sealed class UpdateBuildRequest : ApiRequest
    {
        public UpdateBuildRequest(string organization, string project, BuildDto build) : this(organization, project, build.Id ?? 0)
        {
            Content = new StringContent(JsonSerializer.Serialize(build));
        }

        public UpdateBuildRequest(string organization, string project, int buildId)
        {
            ApiVersion = "6.1-preview.6";
            Method = HttpMethod.Patch;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/{project}/_apis/build/builds/{buildId}?api-version={ApiVersion}");
        }
    }
}
