using BeHeroes.CodeOps.Abstractions.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace BeHeroes.CodeOps.Abstractions.Facade
{
    public interface IFacade
    {
        Task<T> Execute<T>(ICommand<T> command, CancellationToken cancellationToken = default);
    }
}
