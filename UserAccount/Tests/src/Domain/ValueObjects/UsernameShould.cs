using Domain.src.ValueObject;
using FluentAssertions;
using Xunit;

namespace Tests.src.Domain.ValueObjects
{
    public class UsernameShould
    {
        [Fact]
        public void Create_Username()
        {
            var username = "ivan.corlli";
            var newUsername = Username.Create(username);

            newUsername.Errors.Count.Should().Be(0);
            newUsername.Value.Should().BeOfType<Username>();
        }

        [Fact]
        public void Return_Error_When_Is_Invalid(){
            string[] username = {"ivan Corlli","ivanCorlli?>","!@#$%^&()&)>?<{}"};

            for (int i = 0; i < username.Length; i++)
            {
                var newUsername = Username.Create(username[i]);
                newUsername.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
            }
        }

        [Fact]
        public void Return_Error_When_Is_Long(){
            string username = "asjdklfhasldkfjhalsdf.aljhdflkajshdflasdf651";
            var newUsername = Username.Create(username);
            newUsername.Errors.Count.Should().BeGreaterThanOrEqualTo(1);   
        }

        [Fact]
        public void Return_Error_When_Is_Shoert(){
            string username = "asj";
            var newUsername = Username.Create(username);
            newUsername.Errors.Count.Should().BeGreaterThanOrEqualTo(1);   
        }
    }
}