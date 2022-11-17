using System;
using System.Collections.Generic;
using System.Linq;
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

        public UserManagerShould(){
            var mockEmail = Email.Create("ivancorlli@gmail.com");
            var mokcusername = Username.Create("ivancorlli13");
            var mockuser = User.Create(mokcusername.Value,mockEmail.Value,"15410036").Value;
            _MockRepo.Setup(user => user.GetUserByEmail(mockuser.Email))
            .ReturnsAsync(mockuser);
            _Manager = new UserManager(_MockRepo.Object);
        }

        [Fact]
        public async Task Create_Valid_User()
        {   

            // expected
            var email = Email.Create("ivancorlli13@gmail.com");
            var username = Username.Create("ivancorlli.ok");
            var newUser = await _Manager.CreateUser(username.Value,email.Value,"3876410036");

            
        }
    }
}