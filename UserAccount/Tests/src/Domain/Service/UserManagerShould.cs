using System;
using Domain.src.DomainError;
using FluentAssertions;
using System.Threading.Tasks;
using Domain.src.Entity;
using Domain.src.Interface;
using Domain.src.Service;
using Domain.src.ValueObject;
using Moq;
using Xunit;

namespace Tests.src.Domain.Service
{
    public class UserManagerShould
    {

        private readonly UserManager _Manager;
        private readonly Mock<IUserReadRepository> _MockRepo = new Mock<IUserReadRepository>();

        public UserManagerShould() => _Manager = new UserManager(_MockRepo.Object);

        [Fact]
        public async Task Not_Create_User_If__Email_Exists()
        {   
            var mockEmail = Email.Create("ivancorlli@gmail.com");
            var mokcusername = Username.Create("ivancorlli13");
            var mockuser = User.Create(mokcusername.Value,mockEmail.Value,"15410036").Value;
            _MockRepo.Setup(user => user.GetUserByEmail(mockuser.Email))
            .ReturnsAsync(mockuser)
            .Verifiable();

            // expected
            var email = Email.Create(mockEmail.Value.Value);
            var username = Username.Create("ivancorlli.ok");
            var newUser = await _Manager.CreateUser(username.Value,email.Value,"3876410036");

            _MockRepo.Verify(x=>x.GetUserByEmail(email.Value));
            _MockRepo.VerifyNoOtherCalls();

            newUser.IsSuccess.Should().BeFalse();
            newUser.Errors[0].Should().BeOfType<UserAlreadyExists>();
            
        }

        [Fact]
        public async Task Not_Create_User_If_Username_Exists(){
            var mockEmail = Email.Create("ivancorlli@gmail.com");
            var mokcusername = Username.Create("ivancorlli13");
            var mockuser = User.Create(mokcusername.Value,mockEmail.Value,"15410036").Value;
            _MockRepo.Setup(user => user.GetUserByUsername(mockuser.Username))
            .ReturnsAsync(mockuser)
            .Verifiable();
            _MockRepo.Setup(user => user.GetUserByEmail(mockuser.Email))
            .Verifiable();
            
            var email = Email.Create("ivancorlli13@gmail.com");
            var username = Username.Create("ivancorlli13");
            var newUser = await _Manager.CreateUser(username.Value,email.Value,"3876410036");

            _MockRepo.Verify(x=>x.GetUserByUsername(username.Value));
            _MockRepo.Verify(x=>x.GetUserByEmail(email.Value));
            _MockRepo.VerifyNoOtherCalls();

            newUser.IsSuccess.Should().BeFalse();
            newUser.Errors[0].Should().BeOfType<UserAlreadyExists>();
        }

        [Fact]
        public async Task Change_Email(){
            var mockEmail = Email.Create("ivancorlli@gmail.com").Value;
            var mokcusername = Username.Create("ivancorlli13").Value;
            var mockuser = User.Create(mokcusername,mockEmail,"15410036").Value;
            _MockRepo.Setup(user => user.GetUserByEmail(mockuser.Email))
            .ReturnsAsync(mockuser)
            .Verifiable();

            var email = Email.Create("ivancorlli13@gmail.com").Value;
            var username = Username.Create("ivancorlli").Value;
            var user = User.Create(username,email,"1564687632").Value;

            var newEmail = Email.Create("ivancor@gmail.com").Value;

            await _Manager.ChangeEmail(user,newEmail);
            
            _MockRepo.Verify(x=>x.GetUserByEmail(newEmail));
            _MockRepo.VerifyNoOtherCalls();

            user.Email.Should().Be(newEmail);
        }

        [Fact]
        public async Task Not_Change_Email_If_Email_Exists(){
            var mockEmail = Email.Create("ivancorlli@gmail.com").Value;
            var mokcusername = Username.Create("ivancorlli13").Value;
            var mockuser = User.Create(mokcusername,mockEmail,"15410036").Value;
            _MockRepo.Setup(user => user.GetUserByEmail(mockuser.Email))
            .ReturnsAsync(mockuser)
            .Verifiable();

            var email = Email.Create("ivancorlli13@gmail.com").Value;
            var username = Username.Create("ivancorlli").Value;
            var user = User.Create(username,email,"1564687632").Value;

            var newEmail = Email.Create(mockEmail.Value).Value;

            var result = await _Manager.ChangeEmail(user,newEmail);
            
            _MockRepo.Verify(x=>x.GetUserByEmail(newEmail));
            _MockRepo.VerifyNoOtherCalls();

            result.IsSuccess.Should().BeFalse();
            result.Errors[0].Should().BeOfType<UserAlreadyExists>();
            
        }

        [Fact]
        public async Task Change_Username(){
            var mockEmail = Email.Create("ivancorlli@gmail.com").Value;
            var mokcusername = Username.Create("ivancorlli13").Value;
            var mockuser = User.Create(mokcusername,mockEmail,"15410036").Value;
            _MockRepo.Setup(user => user.GetUserByUsername(mockuser.Username))
            .ReturnsAsync(mockuser)
            .Verifiable();

            var email = Email.Create("ivancorlli13@gmail.com").Value;
            var username = Username.Create("ivancorlli").Value;
            var user = User.Create(username,email,"1564687632").Value;

            var newUsername = Username.Create("icorlli").Value;

            await _Manager.ChangeUsername(user,newUsername);
            
            _MockRepo.Verify(x=>x.GetUserByUsername(newUsername));
            _MockRepo.VerifyNoOtherCalls();

            user.Username.Should().Be(newUsername);
        }
        [Fact]
        public async Task Not_Change_Username_If_Username_Exists(){
            var mockEmail = Email.Create("ivancorlli@gmail.com").Value;
            var mokcusername = Username.Create("ivancorlli13").Value;
            var mockuser = User.Create(mokcusername,mockEmail,"15410036").Value;
            _MockRepo.Setup(user => user.GetUserByUsername(mockuser.Username))
            .ReturnsAsync(mockuser)
            .Verifiable();


            var email = Email.Create("ivancorlli13@gmail.com").Value;
            var username = Username.Create("ivancorlli").Value;
            var user = User.Create(username,email,"1564687632").Value;

            var newUsername = Username.Create(mokcusername.Value).Value;


            var result = await _Manager.ChangeUsername(user,newUsername);
            
            _MockRepo.Verify(x=>x.GetUserByUsername(newUsername));
            _MockRepo.VerifyNoOtherCalls();

            result.IsSuccess.Should().BeFalse();
            result.Errors[0].Should().BeOfType<UserAlreadyExists>();
            
        }
    }
}