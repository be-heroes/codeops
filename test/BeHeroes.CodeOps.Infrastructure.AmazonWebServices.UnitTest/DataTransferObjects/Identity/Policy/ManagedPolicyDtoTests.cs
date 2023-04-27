using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Policy;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.UnitTest.Identity.Policy
{
    public class ManagedPolicyDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            ManagedPolicyDto sut;

            //Act
            sut = new ManagedPolicyDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new ManagedPolicyDto()
            {
                Description = "description",
                Arn = "arn",
                Path = "path",
                PolicyId = "policyId",
                PolicyName = "policyName"
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
            ManagedPolicyDto sut;

            //Act
            sut = JsonSerializer.Deserialize<ManagedPolicyDto>("{\"arn\":\"arn\",\"policyId\":\"policyId\",\"policyName\":\"policyName\",\"description\":\"description\",\"path\":\"path\"}");

            //Assert
            Assert.NotNull(sut);
        }
    }
}