﻿using AutoMapper;
using BeHeroes.CodeOps.Abstractions.Aggregates;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Build;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Mapping.Converters;
using Moq;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Mapping.Converters
{
    public class AdoDtoToAggregateRootConverterTests
    {
        [Fact]
        public void CanConvert()
        {
            //Arrange
            var mockMapper = new Mock<IMapper>();
            var mockAggregate = new Mock<IAggregateRoot>();

            mockMapper.Setup(m => m.Map<IAggregateRoot>(It.IsAny<AdoDto>())).Returns(mockAggregate.Object);

            ITypeConverter<AdoDto, IAggregateRoot> sut = new AdoDtoToAggregateRootConverter(mockMapper.Object);

            //Act
            var result = sut.Convert(new BuildDto(), mockAggregate.Object, null);
            var result2 = sut.Convert(new BuildDto(), null, null);

            //Assert
            Assert.NotNull(sut);
            Assert.NotNull(result);
            Assert.Equal(result, mockAggregate.Object);
            Assert.Equal(result, result2);

            Mock.VerifyAll(mockMapper, mockAggregate);
        }
    }
}
