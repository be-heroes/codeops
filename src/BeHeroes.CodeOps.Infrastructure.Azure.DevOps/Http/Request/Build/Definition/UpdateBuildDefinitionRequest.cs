﻿using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Build;
using System.Text.Json;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Build
{
    public sealed class UpdateBuildDefinitionRequest : ApiRequest
    {
        public UpdateBuildDefinitionRequest(string organization, string project, BuildDefinitionDto definition) : this(organization, project, definition.Id ?? 0)
        {
            Content = new StringContent(JsonSerializer.Serialize(definition));
        }

        public UpdateBuildDefinitionRequest(string organization, string project, int definitionId)
        {
            ApiVersion = "6.1-preview.7";
            Method = HttpMethod.Put;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/{project}/_apis/build/builds/definitions/{definitionId}?api-version={ApiVersion}");
        }
    }
}
