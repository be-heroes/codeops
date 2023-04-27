using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.UnitTest.DataTransferObjects.Shared
{
    public class ArtifactDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            ArtifactDto sut;

            //Act
            sut = new ArtifactDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new ArtifactDto()
            {
                Alias = "alias",
                Type = "type"
            };

            //Act
            var payload = JsonSerializer.Serialize(sut, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

            //Assert
            Assert.NotNull(JsonDocument.Parse(payload));
        }

        [Fact]
        public void CanBeDeserialized()
        {
            //Arrange
            ArtifactDto sut;

            //Act
            sut = JsonSerializer.Deserialize<ArtifactDto>("{\"alias\":\"alias\",\"type\":\"type\"}");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("alias", sut.Alias);
            Assert.Equal("type", sut.Type);
        }
    }
}