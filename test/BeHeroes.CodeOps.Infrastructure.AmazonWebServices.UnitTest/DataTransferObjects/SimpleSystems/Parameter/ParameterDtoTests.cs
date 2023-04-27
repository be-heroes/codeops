using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.UnitTest.Identity.Policy.Role
{
    public class ParameterDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            ParameterDto sut;

            //Act
            sut = new ParameterDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new ParameterDto()
            {
                Name = "name",
                ParamType = "type",
                Value = "value",
                Overwrite = true,
                Tags = new Dictionary<string, string>().ToArray(),
                Version = 1
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
            ParameterDto sut;

            //Act
            sut = JsonSerializer.Deserialize<ParameterDto>("{\"version\":1,\"value\":\"value\",\"paramType\":\"type\",\"name\":\"name\",\"tags\":[],\"overwrite\":true}");

            //Assert
            Assert.NotNull(sut);
        }
    }
}