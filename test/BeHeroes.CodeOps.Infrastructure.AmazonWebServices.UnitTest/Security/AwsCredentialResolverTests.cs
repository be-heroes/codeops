using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Identity;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Security;
using System.IO;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.UnitTest.Security
{
    public class AwsCredentialResolverTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            var sut = new AwsCredentialResolver(Directory.GetCurrentDirectory());

            //Act
            var hash = sut.GetHashCode();

            //Assert
            Assert.NotNull(sut);
            Assert.Equal(hash, sut.GetHashCode());
        }

        [Fact]
        public void CanResolve()
        {
            //Arrange
            var sut = new AwsCredentialResolver(Directory.GetCurrentDirectory());
            var profile = new AwsProfile("PROFILE", "PROFILE_NAME", "PROFILE_ARN");

            //Act
            var creds = sut.Resolve(profile);

            //Assert
            Assert.Null(creds);
        }
    }
}
