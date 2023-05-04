using MediatR;

namespace BeHeroes.CodeOps.Abstractions.Commands
{
    public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : ICommand<TResponse>
    {
        new Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default);
    }
}
