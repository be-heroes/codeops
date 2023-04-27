using BeHeroes.CodeOps.Abstractions.Commands;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Identity;
using System.Diagnostics.CodeAnalysis;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands
{
    public abstract record AwsCommand<TResult> : ICommand<TResult>
    {
        public required IAwsProfile? Impersonate
        {
            get;
            init;
        }

        [SetsRequiredMembers]
        protected AwsCommand(IAwsProfile? awsProfile = default){
            Impersonate = awsProfile;
        }
    }
}
