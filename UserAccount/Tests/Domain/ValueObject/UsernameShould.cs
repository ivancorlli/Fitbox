using Domain.src.ValueObject;
using Xunit;

namespace Tests.Domain.ValueObject
{
    public class UsernameShould
    {
        [Fact]
        public void CreateValidUsername()
        {
            // Arrage
            var mkUsername = "ivancorlli";
            // Act
            var username = new Username(mkUsername);
            // Assert
            Assert.Equal(new Username(mkUsername),username);
            Assert.Same(username.Value,mkUsername);
        }
    }
}