namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Security
{
    public interface IAwsCredentials
    {
        string AccessKey { get; }

        string SecretKey { get; }

        string Token { get; }
    }
}
