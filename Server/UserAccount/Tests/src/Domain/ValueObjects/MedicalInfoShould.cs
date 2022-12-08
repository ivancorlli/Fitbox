using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.src.ValueObject;
using FluentAssertions;
using Xunit;

namespace Tests.src.Domain.ValueObjects
{
    public class MedicalInfoShould
    {
        [Fact]
        public void Create_MedicalInfo()
        {  
            var disabilities = "Mi papa tuvo asma de pequenio";
            var aptitude = new Uri("https://www.google.com");
            var newInfo = MedicalInfo.Create(aptitude,disabilities);
            
            newInfo.Errors.Count.Should().Be(0);
            newInfo.Value.Should().BeOfType<MedicalInfo>();
        }

        [Fact]
        public void Return_Error_When_Is_Invalid(){
            var disabilities = "Mi papa tuvo asma de pequenio 886432 ?//ds239(&(*)@#$!";
            var aptitude = new Uri("https://www.google.com");
            var newInfo = MedicalInfo.Create(aptitude,disabilities);
            
            newInfo.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Too_Long(){
            var disabilities = new Bogus.Faker().Lorem.ToString();
            for (int i = 0; i < 10; i++)
            {
             disabilities +=disabilities;   
            }
            var aptitude = new Uri("https://www.google.com");
            var newInfo = MedicalInfo.Create(aptitude,disabilities!);
            
            newInfo.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }
    }
}