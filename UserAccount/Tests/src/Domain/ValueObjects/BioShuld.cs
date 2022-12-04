using System;
using System.Collections.Generic;
using System.Linq;
using Domain.src.ValueObject;
using Xunit;
using Bogus;
using FluentAssertions;

namespace Tests.src.Domain.ValueObjects
{
    public class BioShuld
    {
        [Fact]
        public void Create_BioGraphy()
        {
            var text = new Faker().Lorem;
            var newBio = Bio.Create(text.ToString()!);

            newBio.Errors.Count.Should().Be(0);
            newBio.Value.Should().NotBeNull();
            newBio.Value.Should().BeOfType<Bio>();
        }

        [Fact]
        public void Return_Error_When_Is_Invalid(){
             var text = new Faker().Lorem.ToString();
             for (int i = 0; i < 10; i++)
             {
                text += text;
             }
            var newBio = Bio.Create(text!.ToString());
            newBio.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }
    }
}