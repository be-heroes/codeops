using BeHeroes.CodeOps.Abstractions.Commands;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Factories;
using System.Threading;
using System.Threading.Tasks;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands
{
    public abstract class AwsCommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        protected readonly IAwsClientFactory _awsClientFactory;

        protected AwsCommandHandler(IAwsClientFactory awsClientFactory = default)
        {
            _awsClientFactory = awsClientFactory;
        }

        public abstract Task<TResult> Handle(TCommand command, CancellationToken cancellationToken = default);
    }
}
