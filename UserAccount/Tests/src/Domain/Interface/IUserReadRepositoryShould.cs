using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Domain.src.Interface;
using Domain.src.Entity;
using Domain.src.ValueObject;
using FluentAssertions;
using FluentResults;

namespace Tests.src.Domain.Interface
{
    public class IUserRepositoryShould
    {
            private readonly Mock<IUserReadRepository> _Mock = new Mock<IUserReadRepository>();

        [Fact]
        public async Task Get_User_By_Id_If_Exists()
        {
            var email = Email.Create("ivancorlli@gmail.com");
            var username = Username.Create("ivancorlli");
            var user = User.Create(username.Value,email.Value,"15410036"); 

            _Mock.Setup(repo => repo.GetUserById(user.Value.Id)).ReturnsAsync(user.Value).Verifiable();
            
            var userFound = await _Mock.Object.GetUserById(user.Value.Id);

            _Mock.Verify(x=>x.GetUserById(user.Value.Id));
            userFound.Should().Be(user.Value);
        }

        [Fact]
        public async Task Return_Null_If_Id_Not_Match(){
            var email = Email.Create("ivancorlli@gmail.com");
            var username = Username.Create("ivancorlli");
            var user = User.Create(username.Value,email.Value,"15410036"); 

            _Mock.Setup(repo => repo.GetUserById(user.Value.Id)).Verifiable();

            var userFound = await _Mock.Object.GetUserById(user.Value.Id);

            _Mock.Verify(x=>x.GetUserById(user.Value.Id));
            _Mock.VerifyNoOtherCalls();
            userFound.Should().BeNull();
        }

        [Fact]
        public async Task Get_User_By_Email_If_Exists()
        {
            var email = Email.Create("ivancorlli@gmail.com");
            var username = Username.Create("ivancorlli");
            var user = User.Create(username.Value,email.Value,"15410036"); 

            _Mock.Setup(repo => repo.GetUserByEmail(user.Value.Email)).ReturnsAsync(user.Value).Verifiable();
            
            var userFound = await _Mock.Object.GetUserByEmail(user.Value.Email);

            _Mock.Verify(x=>x.GetUserByEmail(user.Value.Email));
            userFound.Should().Be(user.Value);
        }

        [Fact]
        public async Task Return_Null_If_Email_Not_Match(){
            var email = Email.Create("ivancorlli@gmail.com");
            var username = Username.Create("ivancorlli");
            var user = User.Create(username.Value,email.Value,"15410036"); 

            _Mock.Setup(repo => repo.GetUserByEmail(user.Value.Email)).Verifiable();

            var userFound = await _Mock.Object.GetUserByEmail(user.Value.Email);

            _Mock.Verify(x=>x.GetUserByEmail(user.Value.Email));
            _Mock.VerifyNoOtherCalls();
            userFound.Should().BeNull();
        }

         [Fact]
        public async Task Get_User_By_Phone_If_Exists()
        {
            var email = Email.Create("ivancorlli@gmail.com");
            var username = Username.Create("ivancorlli");
            var user = User.Create(username.Value,email.Value,"15410036"); 
            var phone = Phone.Create(410036,3876,"Ar");

            _Mock.Setup(repo => repo.GetUserByPhone(phone.Value)).ReturnsAsync(user.Value).Verifiable();
            
            var userFound = await _Mock.Object.GetUserByPhone(phone.Value);

            _Mock.Verify(x=>x.GetUserByPhone(phone.Value));
            userFound.Should().Be(user.Value);
        }

        [Fact]
        public async Task Return_Null_If_Phone_Not_Match(){
            var email = Email.Create("ivancorlli@gmail.com");
            var username = Username.Create("ivancorlli");
            var user = User.Create(username.Value,email.Value,"15410036"); 
            var phone = Phone.Create(410036,3876,"Ar");

            _Mock.Setup(repo => repo.GetUserByPhone(phone.Value)).Verifiable();
            
            var searchPhone = Phone.Create(410036,3876,"Ar");
            var userFound = await _Mock.Object.GetUserByPhone(searchPhone.Value);

            _Mock.Verify(x=>x.GetUserByPhone(searchPhone.Value));
            _Mock.VerifyNoOtherCalls();
            userFound.Should().BeNull();
        }

    }
}