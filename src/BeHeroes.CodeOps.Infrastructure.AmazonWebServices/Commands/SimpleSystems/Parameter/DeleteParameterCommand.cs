using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter
{
    public sealed class DeleteParameterCommand : AwsCommand<Task>
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        public DeleteParameterCommand(string name)
        {
            if (name.EndsWith("/"))
            {
                name = name.TrimEnd('/');
            }

            Name = name;
        }
    }
}