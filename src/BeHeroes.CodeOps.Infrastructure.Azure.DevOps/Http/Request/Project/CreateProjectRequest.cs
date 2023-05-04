using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Project;
using System.Text.Json;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Project
{
    public sealed class CreateProjectRequest : ApiRequest
    {
        public CreateProjectRequest(string organization, ProjectDto project) : this(organization)
        {
            Content = new StringContent(JsonSerializer.Serialize(project));
        }

        public CreateProjectRequest(string organization)
        {
            ApiVersion = "6.0";
            Method = HttpMethod.Post;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/_apis/projects?api-version={ApiVersion}");
        }
    }
}
