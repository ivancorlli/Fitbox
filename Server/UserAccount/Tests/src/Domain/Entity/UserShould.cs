using System.Xml;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using Domain.src.Entity;
using Xunit;
using FluentAssertions;
using Domain.src.ValueObject;
using Domain.src.Enum;
using FluentResults;


namespace Tests.src.Domain.Entity
{
    public class UserShould
    {   

        public Result<Username> username = Username.Create("ivancorlli");
        public Result<Email> email = Email.Create("ivancorlli@gmail.com");
        public string password = "qwdfrto32422";

        [Fact]
        public void Create_User(){
            var newUser = User.Create(username.Value,email.Value,password);

            newUser.Errors.Count.Should().Be(0);
            newUser.Value.Should().BeOfType<User>();
        }

        [Fact]
        public void Return_Error_When_Password_Is_Invalid(){
            string [] values = {username.Value.Value,email.Value.Value};

            for (int i = 0; i < values.Length; i++)
            {
                var newUser = User.Create(username.Value,email.Value,values[i]);
                newUser.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
            }
        }

        [Fact]
        public void Change_Password(){
            var newUser = User.Create(username.Value,email.Value,password);
            newUser.Value.ChangePassword("nueva contrasnia123.");

            newUser.Errors.Count.Should().Be(0);
            newUser.Value.Password.Should().NotBe(password);
        }

    }
}