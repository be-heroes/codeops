﻿using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Release;
using System.Text.Json;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Release
{
    public sealed class UpdateReleaseRequest : ApiRequest
    {
        public UpdateReleaseRequest(string organization, string project, ReleaseDto release) : this(organization, project, release.Id ?? 0)
        {
            Content = new StringContent(JsonSerializer.Serialize(release));
        }

        public UpdateReleaseRequest(string organization, string project, int releaseId)
        {
            ApiVersion = "6.1-preview.8";
            Method = HttpMethod.Put;
            RequestUri = new Uri($"https://vsrm.dev.azure.com/{organization}/{project}/_apis/release/releases/{releaseId}?api-version={ApiVersion}");
        }
    }
}
