﻿using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Project;
using System.Net.Http;
using Xunit;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Http.Request.Project
{
    public class GetProjectsRequestTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            GetProjectsRequest sut;

            //Act
            sut = new GetProjectsRequest("my-org");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.0", sut.ApiVersion);
            Assert.Equal(HttpMethod.Get, sut.Method);
            Assert.Equal("https://dev.azure.com/my-org/_apis/projects?api-version=6.0", sut.RequestUri.AbsoluteUri);
        }
    }
}