using BeHeroes.CodeOps.Security.Policies.Handlers;
using BeHeroes.CodeOps.Security.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Xunit;

namespace BeHeroes.CodeOps.Security.Policies.UnitTest.Handlers
{
    public class AccessRequirementHandlerTests
    {
        [Fact]
        public void CanHandleAccessRequirements()
        {
            //Arrange
            var fakeRequirements = new AccessRequirement[] { new ExecuteAccessRequirement(), new ReadAccessRequirement(), new WriteAccessRequirement() };
            var fakeIdentity = new ClaimsIdentity(new[] { new Claim("beheroes.access", "beheroes.all.execute"), new Claim("beheroes.access", "beheroes.all.read"), new Claim("beheroes.access", "beheroes.all.write") });
            var fakePrincipal = new ClaimsPrincipal(fakeIdentity);
            var fakeAuthorizationHandlerContext = new AuthorizationHandlerContext(fakeRequirements, fakePrincipal, null);
            var sut = new AccessRequirementHandler();

            //Act
            var task = sut.HandleAsync(fakeAuthorizationHandlerContext);

            //Assert
            Assert.True(task.IsCompletedSuccessfully);
            Assert.True(fakeAuthorizationHandlerContext.HasSucceeded);
        }
    }
}
