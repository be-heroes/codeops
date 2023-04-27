using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.UnitTest.DataTransferObjects.Shared
{
    public class WorkItemDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            WorkItemDto sut;

            //Act
            sut = new WorkItemDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new WorkItemDto()
            {
                Id = "id",
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
            WorkItemDto sut;

            //Act
            sut = JsonSerializer.Deserialize<WorkItemDto>("{\"id\":\"id\",\"url\":\"url\"}");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("id", sut.Id);
            Assert.Equal("url", sut.Url);
        }
    }
}