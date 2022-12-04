
using Domain.src.ValueObject;
using FluentAssertions;
using Xunit;

namespace Tests.src.Domain.ValueObjects
{
    public class EmailShould
    {
        [Fact]
        public void Create_Email()
        {
            var email = "ivancorlli13@gmail.com";
            var newEmail = Email.Create(email);

            newEmail.Errors.Count.Should().Be(0);
            newEmail.Value.Should().NotBeNull();
            newEmail.Value.Should().BeOfType<Email>();
        }

        [Fact]
        public void Return_Error_when_Is_Invalid(){
            string [] values = {"ivnac..corlii12?@gmail.com.aer","11243))_@gmial.com","belgranoOesteYlosfresnos1.Amec.Metan.Salta.Argentina@gmail.com"};
            for (int i = 0; i < values.Length; i++)
            {
                var email = Email.Create(values[i]);

                email.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
            }
        }
    }
}