using System;
using Domain.src.Entity;
using Xunit;
using FluentAssertions;

namespace Tests.src.Domain.Entity
{
    public class UserShould
    {
        [Fact]
        public void Return_Correct_ValueType()
        {   
            var username = "ivancorlli";
            var email = "ivancorlli@gmail.com";
            var password = "123456";

            var user = new User(username,email,password);


            user.Id.Should().NotBeEmpty();
            user.Id.Should().Be(user.Id);

            user.Email.Should().NotBeEmpty();
            user.Email.Should().BeOfType<string>();

            user.Username.Should().NotBeEmpty();
            user.Username.Should().BeOfType<string>();

            user.Password.Should().NotBeEmpty();
            user.Password.Should().BeOfType<string>();

            user.Status.Should().NotBeEmpty();
            user.Status.Should().BeOfType<string>();
        }
    }
}