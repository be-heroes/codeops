﻿using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Build;
using System.Text.Json;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Build.Definition
{
    public sealed class CreateBuildDefinitionRequest : ApiRequest
    {
        public CreateBuildDefinitionRequest(string organization, string project, BuildDefinitionDto definition)
        {
            ApiVersion = "6.1-preview.7";
            Method = HttpMethod.Post;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/{project}/_apis/build/definitions?api-version={ApiVersion}");
            Content = new StringContent(JsonSerializer.Serialize(definition));
        }
    }
}
