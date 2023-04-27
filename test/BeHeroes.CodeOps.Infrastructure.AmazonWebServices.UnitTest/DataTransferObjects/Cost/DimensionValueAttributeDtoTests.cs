using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.UnitTest.DataTransferObjects.Cost
{
    public class DimensionValueAttributeDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            DimensionValueAttributeDto sut;

            //Act
            sut = new DimensionValueAttributeDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new DimensionValueAttributeDto()
            {
                Attributes = new Dictionary<string, string>(),
                Value = "foo"
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
            DimensionValueAttributeDto sut;

            //Act
            sut = JsonSerializer.Deserialize<DimensionValueAttributeDto>("{\"attributes\":[],\"value\":\"foo\"}");

            //Assert
            Assert.NotNull(sut);
        }
    }
}