using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.src.ValueObject;
using FluentAssertions;
using Xunit;

namespace Tests.src.Domain.ValueObjects
{
    public class PasswordShould
    {
        [Fact]
        public void Create_Password()
        {
            var pass = "3876410036";
            var newPas = Password.Create(pass);

            newPas.Errors.Count.Should().Be(0);
            newPas.Value.Should().BeOfType<Password>();
            newPas.Value.Value.Should().NotBe(pass);
        }

        [Fact]
        public void Return_Error_When_Is_Too_Long(){
             var pass = "38764100351651fs6d3f1s35d4f3as5f13as5df18s6d4f89asd74fa31sdf1a36s8df74sdf6";
            var newPas = Password.Create(pass);

            newPas.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Too_Short(){
             var pass = "886wer";
            var newPas = Password.Create(pass);

            newPas.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Starts_With_1234(){
             var pass = "1234ivan";
            var newPas = Password.Create(pass);

            newPas.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Starts_With_asdf(){
             var pass = "asdf683";
            var newPas = Password.Create(pass);

            newPas.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }
    }
}