using Domain.src.Utils;
using Domain.src.ValueObject;
using FluentAssertions;
using FluentResults;
using Xunit;

namespace Tests.src.Domain.ValueObject
{
    public class PhoneShould
        {
          [Fact]
        public void Return_Corect_Type_When_Is_Valid(){
            var areaCode = 3876;
            var number = 15410036;
            var country = "ar";

            var newPhone = Phone.Create(number,areaCode,country);

            newPhone.Should().BeOfType<Result<Phone>>();
            newPhone.Value.Should().BeOfType<Phone>();

            var phone = newPhone.Value;

            phone.Should().NotBeNull();
            phone.PhoneNumber.Should().Be(number);
            phone.AreaCode.Should().Be(areaCode);
            phone.IsVerified.Should().BeFalse();


        }

        [Fact]
        public void Return_Error_When_Is_NullOrEmpty(){
            var areaCode = 0;
            var number = -5456;
            var country = "";

            var newPhone = Phone.Create(number,areaCode,country);

            newPhone.IsSuccess.Should().BeFalse();
            newPhone.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Too_Long(){
            var areaCode = 387666;
            var number = 15410036465;
            var country = "arfdg";

            var newPhone = Phone.Create(number,areaCode,country);


            newPhone.IsSuccess.Should().BeFalse();
            newPhone.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Too_Short(){
            var areaCode = 38;
            var number = 1541;
            var country = "a";

            var newPhone = Phone.Create(number,areaCode,country);


            newPhone.IsSuccess.Should().BeFalse();
            newPhone.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }


        [Fact]
        public void Change_Number(){
            var areaCode = 3876;
            var number = 15410036;
            var country = "ar";

            var newPhone = Phone.Create(number,areaCode,country);

            var newNumber = 15436816;

            newPhone.Value.ChangeNumber(newNumber);

            newPhone.Value.Should().BeOfType<Phone>();
            newPhone.Value.PhoneNumber.Should().Be(newNumber);
        }

         [Fact]
        public void Change_AreaCode(){
            var areaCode = 3876;
            var number = 15410036;
            var country = "ar";

            var newPhone = Phone.Create(number,areaCode,country);

            var newNumber = 381;

            newPhone.Value.ChangeAreaCode(newNumber);

            newPhone.Value.Should().BeOfType<Phone>();
            newPhone.Value.AreaCode.Should().Be(newNumber);
        }

         [Fact]
        public void Change_Prefix(){
            var areaCode = 3876;
            var number = 15410036;
            var country = "ar";

            var newPhone = Phone.Create(number,areaCode,country);

            var newNumber = "br";
            var upper = newNumber.ToUpper();

            newPhone.Value.ChangePrefix(newNumber);

            newPhone.Value.Should().BeOfType<Phone>();
            newPhone.Value.CountryPrefix.Should().Be(upper);
        }

        [Fact]
         public void Verify_Phone(){
            var areaCode = 3876;
            var number = 15410036;
            var country = "ar";

            var newPhone = Phone.Create(number,areaCode,country);


            newPhone.Value.VerifyPhone();

            newPhone.Value.Should().BeOfType<Phone>();
            newPhone.Value.IsVerified.Should().BeTrue();
        }

        [Fact]
        public void UnVerify_Phone(){
            var areaCode = 3876;
            var number = 15410036;
            var country = "ar";

            var newPhone = Phone.Create(number,areaCode,country);


            newPhone.Value.UnVerifyPhone();

            newPhone.Value.Should().BeOfType<Phone>();
            newPhone.Value.IsVerified.Should().BeFalse();
        }
    }
}