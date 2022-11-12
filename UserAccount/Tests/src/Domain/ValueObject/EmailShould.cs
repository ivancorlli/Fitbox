using Xunit;
using Domain.src.ValueObject;
using FluentAssertions;
using FluentResults;

namespace Tests.src.Domain.ValueObject
{
    public class EmailShould
    {
        [Fact]
        public void Return_Corect_Type_When_Is_Valid(){
            var email = "ivancorlli@gmail.com";
            var newEmail = Email.Create(email);

            newEmail.Should().BeOfType<Result<Email>>();
            newEmail.Value.Should().BeOfType<Email>();

        }

        [Fact]
        public void Return_Error_When_Is_NullOrEmpty(){
            var email = "";
            var newEmail = Email.Create(email);

            newEmail.IsSuccess.Should().BeFalse();
            newEmail.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Contains_Invalid_Charactrers(){
            var email = "ivan01/_123&&@gmail54%.com";
            var newEmail = Email.Create(email);

            newEmail.IsSuccess.Should().BeFalse();
            newEmail.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Too_Long(){
            var email = "ivancorlli1230509234908corlliherrandoivanylosfresnos@gmail.com";
            var newEmail = Email.Create(email);

            newEmail.IsSuccess.Should().BeFalse();
            newEmail.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Too_Short(){
            var email = "l.com";
            var newEMail = Email.Create(email);

            newEMail.IsSuccess.Should().BeFalse();
            newEMail.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Value_Lower_Cased(){
            var email = "IvancorlLI@gmail.com";
            var newEMail = Email.Create(email);

            newEMail.Value.Should().BeOfType<Email>();
            newEMail.Value.Value.Should().BeEquivalentTo(email.ToLower());
        }
    }
}