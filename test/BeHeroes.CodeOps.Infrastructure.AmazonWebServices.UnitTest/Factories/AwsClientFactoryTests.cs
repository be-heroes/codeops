﻿using Amazon.CostExplorer;
using Amazon.IdentityManagement;
using Amazon.SimpleSystemsManagement;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Factories;
using Microsoft.Extensions.Options;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.UnitTest.Factories
{
    public class AwsClientFactoryTests
    {
        private readonly IOptions<AwsFacadeOptions> _options = Options.Create(new AwsFacadeOptions()
        {
            Region = "eu-central-1", 
            AccessKey = "unit_test_access_key", 
            SecretKey = "unit_test_secret_key"
        });

        [Fact]
        public void CanCreateAmazonCostExplorerClient()
        {
            //Arrange
            var sut = new AwsClientFactory(_options);

            //Act
            var result = sut.Create<AmazonCostExplorerClient>();

            //Assert
            Assert.NotNull(sut);
            Assert.NotNull(result);
            Assert.Equal(result.Config.RegionEndpoint.SystemName, _options.Value.Region);
        }

        [Fact]
        public void CanCreateAmazonSimpleSystemsManagementClient()
        {
            //Arrange
            var sut = new AwsClientFactory(_options);

            //Act
            var result = sut.Create<AmazonSimpleSystemsManagementClient>();

            //Assert
            Assert.NotNull(sut);
            Assert.NotNull(result);
            Assert.Equal(result.Config.RegionEndpoint.SystemName, _options.Value.Region);
        }

        [Fact]
        public void CanCreateAmazonIdentityManagementServiceClient()
        {
            //Arrange
            var sut = new AwsClientFactory(_options);

            //Act
            var result = sut.Create<AmazonIdentityManagementServiceClient>();

            //Assert
            Assert.NotNull(sut);
            Assert.NotNull(result);
            Assert.Equal(result.Config.RegionEndpoint.SystemName, _options.Value.Region);
        }
    }
}
