using System.Threading.Tasks;
using System.Reflection.Metadata;
using Domain.src.Entity;
using Xunit;
using FluentAssertions;
using Domain.src.ValueObject;
using Domain.src.Enum;
using FluentResults;
using System.Collections.Generic;
using System;
using Bogus;

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
            user.Phone.Should().BeNull();
        }

        [Fact]
        public void Change_Password(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;
            var newPass = "NuevaContrasenia156";

            user.ChangePassword(newPass);

            user.Password.Should().NotBe(newPass);

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
        public void Change_Birth(){
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

            var newBirth = (DateTime.Now).AddDays(5);

            var brithChanged = user.ChangeBirth(newBirth);

            brithChanged.IsSuccess.Should().BeFalse();
            brithChanged.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
            user.Birth.Should().BeNull();
        }

        [Fact]
        public void Return_Error_If_Age_Is_Lower_Than_13(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            var newBirth = DateTime.Now;

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

        [Fact]
        public void Should_Create_EmeregencyContact(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            var name = FullName.Create("fernando", "corlli");
            var relation = RelationShip.Father;
            var phone = Phone.Create(410036,3876,"ar");

            user.CreateEmergencyContact(name.Value,relation,phone.Value);

            user.EmergencyContact.Should().NotBeNull();
            user.EmergencyContact.Should().BeOfType<EmergencyContact>();
 
        }

         [Fact]
        public void Should_Delete_EmeregencyContact(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            var name = FullName.Create("fernando", "corlli");
            var relation = RelationShip.Father;
            var phone = Phone.Create(410036,3876,"ar");

            user.CreateEmergencyContact(name.Value,relation,phone.Value);

            user.DeleteEmergencyContact();
            user.EmergencyContact.Should().BeNull();
 
        }

        [Fact]
        public void Change_Phone(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            var phone = Phone.Create(410036,38765,"AR");

            user.ChangePhone(phone.Value);
            user.Phone.Should().BeOfType<Phone>();
            user.Phone!.PhoneNumber.Should().Be(410036);
        }

        [Fact]
        public void Create_MedicalInfo(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            var medical = MedicalInfo.Create(new Uri("http://www.contoso.com/"));

            user.CreateMedicalInfo(medical.Value);

            user.Medical.Should().BeOfType<MedicalInfo>();
        }

        [Fact]
        public void Verify_Email(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            user.VerifyEmail();

            user.EmailVerified.Should().BeTrue();
        }

        [Fact]
        public void UnVerify_Email(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            user.VerifyEmail();
            user.ChangeEmail(Email.Create("pedro@gmail.com").Value);
            user.EmailVerified.Should().BeFalse();
        }

        [Fact]
        public void Not_Be_New(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            user.IsNotNew();
            user.IsNew.Should().BeFalse();
        }

        [Fact]
        public void Change_Username(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            var newusename= Username.Create("ivancorlli13"); 
            
            user.ChangeUsername(newusename.Value);

            user.Username.Value.Should().Be(newusename.Value.Value);
        }

        [Fact]
        public void ChangeEmail(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            var newEmail= Email.Create("ivancorlli13@gmail.com");
            user.ChangeEmail(newEmail.Value);

            user.Email.Value.Should().Be(newEmail.Value.Value); 
        }

        [Fact]
        public void SuspendAccount(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            user.SuspendAccount();
            
            user.Status.Should().Be(AccountStatus.Suspended);
        }

        [Fact]
        public void InactiveAccount(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            user.InactivateAccount();
            
            user.Status.Should().Be(AccountStatus.Inactive);
        }
        [Fact]
        public void ReactivateAccount(){
            var newUser = User.Create(username.Value,email.Value,password);
            var user = newUser.Value;

            user.ReactivateAccount();
            
            user.Status.Should().Be(AccountStatus.Active);
        }
    }
}