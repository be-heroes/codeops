﻿using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Project;
using System.Text.Json;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Project
{
    public sealed class UpdateProjectRequest : ApiRequest
    {
        public UpdateProjectRequest(string organization, ProjectDto project) : this(organization, project.Id.ToString() ?? string.Empty)
        {
            Content = new StringContent(JsonSerializer.Serialize(project));
        }

        public UpdateProjectRequest(string organization, string projectId)
        {
            ApiVersion = "6.0";
            Method = HttpMethod.Patch;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/_apis/projects/{projectId}?api-version={ApiVersion}");
        }
    }
}
