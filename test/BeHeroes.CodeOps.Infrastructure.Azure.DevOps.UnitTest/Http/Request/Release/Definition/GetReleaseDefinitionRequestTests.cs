﻿using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Release.Definition;
using System.Net.Http;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Http.Request.Release.Definition
{
    public class GetReleaseDefinitionRequestTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            GetReleaseDefinitionRequest sut;

            //Act
            sut = new GetReleaseDefinitionRequest("my-org", "my-project", 1);

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.0", sut.ApiVersion);
            Assert.Equal(HttpMethod.Get, sut.Method);

            Assert.Equal("https://vsrm.dev.azure.com/my-org/my-project/_apis/release/definitions/1?api-version=6.0", sut.RequestUri.AbsoluteUri);
        }
    }
}