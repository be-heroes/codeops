using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.UnitTest.DataTransferObjects.Cost
{
    public class GroupDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            GroupDto sut;

            //Act
            sut = new GroupDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new GroupDto()
            {
                Metrics = new Dictionary<string, MetricValueDto>(),
                Keys = new List<string>()
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
            GroupDto sut;

            //Act
            sut = JsonSerializer.Deserialize<GroupDto>("{\"keys\":[],\"metrics\":[]}");

            //Assert
            Assert.NotNull(sut);
        }
    }
}