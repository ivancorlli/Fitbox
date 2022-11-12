using System;
using FluentResults;
using FluentAssertions;
using Domain.src.ValueObject;
using Xunit;

namespace Tests.src.Domain.ValueObject
{
    public class UsernameShould
    {
          [Fact]
        public void Return_Corect_Type_When_Is_Valid(){
            var username = "ivancorlli";
            var newUsername = Username.Create(username);

            newUsername.Should().BeOfType<Result<Username>>();
            newUsername.Value.Should().BeOfType<Username>();

        }

        [Fact]
        public void Return_Error_When_Is_NullOrEmpty(){
            var username = "";
            var newusername = Username.Create(username);

            newusername.IsSuccess.Should().BeFalse();
            newusername.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Contains_Invalid_Charactrers(){
            var username = "ivan01/_123&&@gmail54%.com";
            var newusername = Username.Create(username);

            newusername.IsSuccess.Should().BeFalse();
            newusername.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Too_Long(){
            var username = "ivancorlli1230509234908corlliherrandoivanylosfresnosgmail.com";
            var newusername = Username.Create(username);

            newusername.IsSuccess.Should().BeFalse();
            newusername.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Too_Short(){
            var username = "com";
            var newusername = Username.Create(username);

            newusername.IsSuccess.Should().BeFalse();
            newusername.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Value_Lower_Cased(){
            var username = "IvancorlLI";
            var newusername = Username.Create(username);

            newusername.Value.Should().BeOfType<Username>();
            newusername.Value.Value.Should().BeEquivalentTo(username.ToLower());
        }
    }
}