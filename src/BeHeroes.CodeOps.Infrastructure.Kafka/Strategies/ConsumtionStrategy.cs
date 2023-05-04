using AutoMapper;
using BeHeroes.CodeOps.Abstractions.Facade;
using BeHeroes.CodeOps.Abstractions.Strategies;
using Confluent.Kafka;

namespace BeHeroes.CodeOps.Infrastructure.Kafka.Strategies
{
    public abstract class ConsumtionStrategy : IStrategy<ConsumeResult<string, string>>
    {
        protected readonly IFacade _applicationFacade;
        protected readonly IMapper _mapper;

        protected ConsumtionStrategy(IMapper mapper, IFacade applicationFacade)
        {
            _mapper = mapper ?? throw new ArgumentException(null, nameof(mapper));
            _applicationFacade = applicationFacade ?? throw new ArgumentException(null, nameof(applicationFacade));
        }

        public abstract Task Apply(ConsumeResult<string, string> target, CancellationToken cancellationToken = default);
    }
}
