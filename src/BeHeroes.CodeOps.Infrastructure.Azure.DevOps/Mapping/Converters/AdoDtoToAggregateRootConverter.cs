using AutoMapper;
using BeHeroes.CodeOps.Abstractions.Aggregates;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Build;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Project;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Release;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Mapping.Converters
{
    public class AdoDtoToAggregateRootConverter : ITypeConverter<AdoDto, IAggregateRoot>
    {
        public readonly IMapper _mapper;

        public AdoDtoToAggregateRootConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IAggregateRoot Convert(AdoDto source, IAggregateRoot destination, ResolutionContext context)
        {
            return source switch
            {
                BuildDto build => _mapper.Map<IAggregateRoot>(build),
                ProjectDto project => _mapper.Map<IAggregateRoot>(project),
                ReleaseDto release => _mapper.Map<IAggregateRoot>(release),
                _ => null,
            };
        }
    }
}
