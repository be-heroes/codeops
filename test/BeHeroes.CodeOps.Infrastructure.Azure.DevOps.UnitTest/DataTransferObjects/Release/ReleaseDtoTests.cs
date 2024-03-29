﻿using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Release;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.UnitTest.DataTransferObjects.Release
{
    public class ReleaseDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            ReleaseDto sut;

            //Act
            sut = new ReleaseDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new ReleaseDto()
            {
                Id = 1,
                Name = "MyName"
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
            ReleaseDto sut;

            //Act
            sut = JsonSerializer.Deserialize<ReleaseDto>("{\"id\": 1,\"name\":\"MyName\"}");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal(1, sut.Id);
            Assert.Equal("MyName", sut.Name);
        }
    }
}