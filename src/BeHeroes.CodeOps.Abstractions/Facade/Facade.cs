using BeHeroes.CodeOps.Abstractions.Commands;
using MediatR;

namespace BeHeroes.CodeOps.Abstractions.Facade
{
    public abstract class Facade : IFacade
    {
        private readonly IMediator _mediator;

        public Facade(IMediator mediator)
        {
            _mediator = mediator;    
        }

        public virtual async Task<T> Execute<T>(ICommand<T> command, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(command, cancellationToken);
        }
    }
}
