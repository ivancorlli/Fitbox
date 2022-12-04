
using Domain.src.ValueObject;
using FluentAssertions;
using Xunit;

namespace Tests.src.Domain.ValueObjects
{
    public class PhoneShould
    {
            private long phone = 15554869;
            private int area = 381;
            private string prefix = "ar";
        [Fact]
        public void Create_Phone()
        {
            var newPhone  = Phone.Create(area,phone);
            var newPhone2  = Phone.Create(area,phone,prefix);

            newPhone.Errors.Count.Should().Be(0);
            newPhone.Value.Should().BeOfType<Phone>();
            newPhone2.Errors.Count.Should().Be(0);
            newPhone2.Value.Should().BeOfType<Phone>();
        }

        [Fact]
        public void Retunr_Error_When_Is_Too_Long(){
            var number = 15558996365433;
            var area = 7896546;
            var prefix = "aaars";
            var newPhone = Phone.Create(area,number,prefix);
            newPhone.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Retunr_Error_When_Is_Too_Short(){
            var number = 1555;
            var area = 78;
            var prefix = "a";
            var newPhone = Phone.Create(area,number,prefix);
            newPhone.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Retunr_Error_When_Is_Empty(){
            var number = 0;
            var area = 0;
            var prefix = "";
            var newPhone = Phone.Create(area,number,prefix);
            newPhone.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Same_With_Different_Number(){
            var newNumer = 15478962;
            var newPhone = Phone.Create(area,phone);
            newPhone = newPhone.Value.WithNumber(newNumer);
            newPhone.Errors.Count.Should().Be(0);
            newPhone.Value.Should().BeOfType<Phone>();
        }

    }
}