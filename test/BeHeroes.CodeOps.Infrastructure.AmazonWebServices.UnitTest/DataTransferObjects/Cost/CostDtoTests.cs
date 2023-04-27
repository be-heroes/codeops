using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.UnitTest.DataTransferObjects.Cost
{
    public class CostDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            CostDto sut;

            //Act
            sut = new CostDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new CostDto()
            {
                DimensionValueAttributes = new List<DimensionValueAttributeDto>(),
                ResultsByTime = new List<ResultByTimeDto>()
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
            CostDto sut;

            //Act
            sut = JsonSerializer.Deserialize<CostDto>("{\"dimensionValueAttributes\":[],\"resultByTime\":[]}");

            //Assert
            Assert.NotNull(sut);
        }
    }
}