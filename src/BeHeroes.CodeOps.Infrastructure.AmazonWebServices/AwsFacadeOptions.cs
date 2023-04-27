using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Identity;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices
{
    public sealed class AwsFacadeOptions
    {
        public const string AwsFacade = "AwsFacade";

        public string Region { get; set; } = "eu-central-1";

        public string AccessKey { get; set; } = string.Empty;

        public string SecretKey { get; set; } = string.Empty;

        public string ProfilesLocation { get; set; } = ".//awsfacade";

        public AwsProfile? Impersonate { get; set; }
    }
}