namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Identity
{
    public interface IAwsProfile
    {
        string Name { get; }

        string SourceProfile { get; }

        string? RoleArn { get; }
    }

}
