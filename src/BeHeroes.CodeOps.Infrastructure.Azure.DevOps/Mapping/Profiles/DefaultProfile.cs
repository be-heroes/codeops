using BeHeroes.CodeOps.Abstractions.Aggregates;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Events;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Mapping.Converters;
using System.Text.Json;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Mapping.Profiles
{
    public sealed class DefaultProfile : AutoMapper.Profile
    {
        public DefaultProfile()
        {
            CreateMap<JsonElement, AdoEvent>()
            .ConvertUsing<JsonElementToAdoEventConverter>();

            CreateMap<AdoEvent, AdoDto>()
            .ConvertUsing<AdoEventToAdoDtoConverter>();

            CreateMap<AdoDto, IAggregateRoot>()
            .ConvertUsing<AdoDtoToAggregateRootConverter>();
        }
    }
}
