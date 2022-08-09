using AutoMapper;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Events;
using System.Text.Json;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Mapping.Converters
{
    public class JsonElementToAdoEventConverter : ITypeConverter<JsonElement, AdoEvent>
    {
        public AdoEvent Convert(JsonElement source, AdoEvent destination, ResolutionContext context)
        {
            return JsonSerializer.Deserialize<AdoEvent>(source.GetRawText());
        }
    }
}
