using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter
{
    public sealed record AddOrUpdateParameterCommand : AwsCommand<ParameterDto>
    {
        [JsonPropertyName("parameter")]
        public required ParameterDto Parameter { get; init; }

        [SetsRequiredMembers]
        public AddOrUpdateParameterCommand(string name, string value, string type = "string", bool overwrite = false, params KeyValuePair<string, string>[] tags)
        {
            if (name.EndsWith("/"))
            {
                name = name.TrimEnd('/');
            }

            Parameter = new ParameterDto()
            {
                Name = name,
                Value = value,
                Overwrite = overwrite,
                Tags = tags,
                ParamType = type
            };
        }
    }
}