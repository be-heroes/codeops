using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.UnitTest.DataTransferObjects.Shared
{
    public class OperationDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            OperationDto sut;

            //Act
            sut = new OperationDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new OperationDto()
            {
                Id = "id",
                PluginId = "pluginId",
                Url = "url"
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
            OperationDto sut;

            //Act
            sut = JsonSerializer.Deserialize<OperationDto>("{\"id\":\"id\",\"pluginId\":\"pluginId\",\"url\":\"url\"}");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("id", sut.Id);
            Assert.Equal("pluginId", sut.PluginId);
            Assert.Equal("url", sut.Url);
        }
    }
}