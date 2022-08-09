using MediatR;

namespace BeHeroes.CodeOps.Abstractions.Commands
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}
