using BeHeroes.CodeOps.Abstractions.Commands;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Identity;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands
{
    public abstract class AwsCommand<TResult> : ICommand<TResult>
    {
        public IAwsProfile AssumeProfile
        {
            get;
            init;
        }
    }
}
