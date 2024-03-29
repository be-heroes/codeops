﻿using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Release;
using System.Text.Json;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Release.Definition
{
    public sealed class UpdateReleaseDefinitionRequest : ApiRequest
    {
        public UpdateReleaseDefinitionRequest(string organization, string project, ReleaseDefinitionDto definition) : this(organization, project)
        {
            Content = new StringContent(JsonSerializer.Serialize(definition));
        }

        public UpdateReleaseDefinitionRequest(string organization, string project)
        {
            ApiVersion = "6.0";
            Method = HttpMethod.Put;
            RequestUri = new Uri($"https://vsrm.dev.azure.com/{organization}/{project}/_apis/release/definitions?api-version={ApiVersion}");
        }
    }
}