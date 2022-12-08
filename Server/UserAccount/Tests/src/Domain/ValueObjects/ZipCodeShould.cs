using System;
using System.Collections.Generic;
using FluentAssertions;
using Domain.src.ValueObject;
using Xunit;

namespace Tests.src.Domain.ValueObjects
{
    public class ZipCodeShould
    {
        [Fact]
        public void Create_ZipCode()
        {
            var newZip = ZipCode.Create("AR-4000");
            newZip.Errors.Count.Should().Be(0);
            newZip.Value.Should().NotBeNull();
            newZip.Value.Should().BeOfType<ZipCode>();
        }

        [Fact]
        public void Return_Error_When_Is_Invalid(){
            string [] values = {"Ar535.s","46548763","452","35%$@"};

            for (int i = 0; i < values.Length; i++)
            {
            var newZip = ZipCode.Create(i.ToString());
            newZip.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
            }
        }
    }
}