using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.UnitTest.DataTransferObjects.Shared
{
    public class ChangeDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            ChangeDto sut;

            //Act
            sut = new ChangeDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new ChangeDto()
            {
                Id = "id",
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
            ChangeDto sut;

            //Act
            sut = JsonSerializer.Deserialize<ChangeDto>("{\"id\":\"id\",\"type\":\"type\"}");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("id", sut.Id);
            Assert.Equal("type", sut.Type);
        }
    }
}