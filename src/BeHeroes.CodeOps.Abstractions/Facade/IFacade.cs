using BeHeroes.CodeOps.Abstractions.Commands;

namespace BeHeroes.CodeOps.Abstractions.Facade
{
    public interface IFacade
    {
        Task<T> Execute<T>(ICommand<T> command, CancellationToken cancellationToken = default);
    }
}
