using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.src.ValueObject;
using FluentAssertions;
using Xunit;

namespace Tests.src.Domain.ValueObjects
{
    public class FullNameShould
    {
        [Fact]
        public void Create_FullName()
        {
            var name = FullName.Create("ivan","corlli");
            name.Errors.Count.Should().Be(0);
            name.Value.Should().BeOfType<FullName>();       
        }

        [Fact]
        public void Return_Error_When_Is_Invalid(){
            var name = FullName.Create("ivan543","corlli");
            var name2 = FullName.Create("ivan","corlli86");
            name.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
            name2.Errors.Count.Should().BeGreaterThanOrEqualTo(1);     
        }

        [Fact]
        public void Return_Error_When_Is_To_Long(){
            var name = FullName.Create("ivancorlliherrandoylos","corlli");
            var name2 = FullName.Create("ivan","corllijkdhglkhdueofkl");
            name.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
            name2.Errors.Count.Should().BeGreaterThanOrEqualTo(1);     
        }

        [Fact]
        public void Return_Error_When_Is_To_Short(){
            var name = FullName.Create("iv","corlli");
            var name2 = FullName.Create("ivan","co");
            name.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
            name2.Errors.Count.Should().BeGreaterThanOrEqualTo(1);     
        }

        [Fact]
        public void Return_Same_With_Different_Name(){
            var txt= "ivan";
            var name = FullName.Create(txt,"corlli");
            name = name.Value.WithName("julian");
            name.Value.FirstName.Should().NotBe(txt);
        }

        [Fact]
        public void Return_Error_When_Change_Name(){
            var txt= "ivan";
            var name = FullName.Create(txt,"corlli");
            name = name.Value.WithName("julian798");
            name.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }
        [Fact]
        public void Return_Same_With_Different_Surname(){
            var txt= "corlli";
            var name = FullName.Create("ivan",txt);
            name = name.Value.WithSurname("julian");
            name.Value.LastName.Should().NotBe(txt);
        }

        [Fact]
        public void Return_Error_hen_Change_Surname(){
            var txt= "corlli";
            var name = FullName.Create("ivan",txt);
            name = name.Value.WithSurname("julian798");
            name.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }
    }
}