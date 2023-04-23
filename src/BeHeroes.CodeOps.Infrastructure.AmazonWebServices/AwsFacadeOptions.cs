using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Identity;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices
{
    public sealed class AwsFacadeOptions
    {
        public const string AwsFacade = "AwsFacade";

        public string Region { get; set; }

        public string AccessKey { get; set; }

        public string SecretKey { get; set; }

        public string ProfilesLocation { get; set; }

        public AwsProfile? Impersonate { get; set; }

        public AwsFacadeOptions(string region, string accessKey, string secretKey, string profilesLocation, AwsProfile? impersonate)
        {
            Region = region;
            AccessKey = accessKey;
            SecretKey = secretKey;
            ProfilesLocation = profilesLocation;
            Impersonate = impersonate;
        }
    }
}
