using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Mapping.Profiles;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Mapping.Profiles
{
    public class DefaultProfileTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            DefaultProfile sut;

            //Act
            sut = new DefaultProfile();

            //Assert
            Assert.NotNull(sut);
        }
    }
}
