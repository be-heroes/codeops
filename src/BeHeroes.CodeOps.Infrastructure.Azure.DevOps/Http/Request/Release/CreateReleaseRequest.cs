using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Release;
using System.Text.Json;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Release
{
    public sealed class CreateReleaseRequest : ApiRequest
    {
        public CreateReleaseRequest(string organization, string project, ReleaseDto release) : this(organization, project)
        {
            Content = new StringContent(JsonSerializer.Serialize(release));
        }

        public CreateReleaseRequest(string organization, string project)
        {
            ApiVersion = "6.1-preview.8";
            Method = HttpMethod.Post;
            RequestUri = new Uri($"https://vsrm.dev.azure.com/{organization}/{project}/_apis/release/releases?api-version={ApiVersion}");
        }
    }
}
