﻿using BeHeroes.CodeOps.Abstractions.Strategies;
using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Threading;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.Kafka.UnitTest
{
    public class KafkaConsumerServiceTests
    {
        public KafkaConsumerServiceTests()
        {
            var services = new ServiceCollection();
            var mockConsumerStrategy = new Mock<IStrategy<ConsumeResult<string, string>>>();
            var mockConsumer = new Mock<IConsumer<string, string>>();

            _ = mockConsumerStrategy.Setup(m => m.Apply(It.IsAny<ConsumeResult<string, string>>(), It.IsAny<CancellationToken>()));

        }

        [Fact]
        public void CanConstruct()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
