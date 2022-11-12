using Domain.src.Entity;
using Xunit;
using FluentAssertions;
using Domain.src.ValueObject;
using Domain.src.Enum;
using FluentResults;
using System.Collections.Generic;
using System;


namespace Tests.src.Domain.Entity
{
    public class UserShould
    {   

        public Result<Username> username = Username.Create("ivancorlli");
        public Result<Email> email = Email.Create("ivancorlli@gmail.com");
        public string password = "qwdfrto32422";

        [Fact]
        public void Return_Correct_ValueType()
        {   
            var newUser = User.Create(username.Value,email.Value,password);

            newUser.Should().BeOfType<Result<User>>();

            var user = newUser.Value;
            user.Should().BeOfType<User>();


            user.Id.Should().NotBeEmpty();

            user.Email.Value.Should().NotBeEmpty();
            user.Email.Should().BeOfType<Email>();

            user.Username.Value.Should().NotBeEmpty();
            user.Username.Should().BeOfType<Username>();

            user.Password.Should().NotBeEmpty();
            user.Password.Should().BeOfType<string>();

            user.IsNew.Should().BeTrue();
            user.EmailVerified.Should().BeFalse();

            user.Status.Should().BeOneOf(AccountStatus.Active,AccountStatus.Deleted,AccountStatus.Inactive,AccountStatus.Suspended);
            user.Status.Should().BeDefined();
            user.Status.Should().Be(AccountStatus.Active);

            user.UserType.Should().BeOneOf(AccountType.Personal,AccountType.Professional);
            user.UserType.Should().BeDefined();
            user.UserType.Should().Be(AccountType.Personal);
            
        }

        [Fact]
        public void Return_Error_When_Password_Is_Invalid(){
            List<string> password = new List<string>(){"123456","qwerty","asdf","12314523huiglhlkjhlkshdgfhgsdfg4589070987125987023987590374509234875090897"};

            foreach (var item in password)
            {
            var newUser = User.Create(username.Value,email.Value,item);

            newUser.IsSuccess.Should().BeFalse();
            newUser.Errors.Count.Should().BeGreaterThanOrEqualTo(1);                
            }
        }

        [Fact]
        public void Return_Optionals_In_Null(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            user.Name.Should().BeNull();
            user.Gender.Should().BeNull();
            user.Birth.Should().BeNull();
            user.Biography.Should().BeNull();
            user.Address.Should().BeNull();
        }

        [Fact]
        public void Change_Name(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            var newName = FullName.Create("Ivan","Corlli");

            user.ChangeName(newName.Value);

            user.Name.Should().NotBeNull();
            user.Name.Should().BeOfType<FullName>();
            user.Name!.FirstName.Should().Be("Ivan");
            user.Name!.LastName.Should().Be("Corlli");
        }

        [Fact]
        public void Change_Gender()
        {
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            var newGender = Gender.Male;

            user.ChangeGender(newGender);

            user.Gender.Should().NotBeNull();
            user.Gender.Should().BeOneOf(Gender.Male,Gender.Female);
            user.Gender.Should().Be(Gender.Male);
        }

        [Fact]
        public void Chande_Birth(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            var newBirth = DateTime.Parse("2000/04/01");

            user.ChangeBirth(newBirth);

            user.Birth.Should().NotBeNull();
            user.Birth.Should().BeBefore(DateTime.Now);
        }
        [Fact]
        public void Return_Error_If_Birth_Is_After_Today(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            var newBirth = DateTime.Parse("2030/04/01");

            var brithChanged = user.ChangeBirth(newBirth);

            brithChanged.IsSuccess.Should().BeFalse();
            brithChanged.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
            user.Birth.Should().BeNull();
        }

        [Fact]
        public void Change_Biograpgy(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            var text = "Hola mi nombre es ivan corlli :>, soy programador y me gusta hacer actividad fisica, siganme para ver rutinas";

            var newBio = Bio.Create(text);

            user.ChangeBio(newBio.Value);

            user.Biography.Should().NotBeNull();
            user.Biography.Should().BeOfType<Bio>();
            user.Biography!.Value.Should().Be(text);
        }

        [Fact]
        public void Change_Address(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            var newAddress = Address.Create("arGentina","tuCuman","San Miguel De Tucuman",4000);

            user.ChangeAddress(newAddress.Value);

            user.Address.Should().NotBeNull();
            user.Address.Should().BeOfType<Address>();    

        }

    }
}