﻿using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.UnitTest.DataTransferObjects.Cost
{
    public class MetricValueDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            MetricValueDto sut;

            //Act
            sut = new MetricValueDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new MetricValueDto()
            {
                Amount = "10",
                Unit = "kg"
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
            MetricValueDto sut;

            //Act
            sut = JsonSerializer.Deserialize<MetricValueDto>("{\"amount\": \"10\",\"unit\":\"kg\"}");

            //Assert
            Assert.NotNull(sut);
        }
    }
}