using System;
using System.Collections.Generic;
using Application.src.Utils;
using System.Threading.Tasks;
using Domain.src.Entity;
using Domain.src.Interface;
using Domain.src.Service;
using Domain.src.ValueObject;
using Moq;
using Xunit;

namespace Tests.src.Application.Utils
{
    public class GetErrorShould
    {

        private readonly UserManager _Manager;
        private readonly Mock<IUserReadRepository> _MockRepo = new Mock<IUserReadRepository>();

        public GetErrorShould() => _Manager = new UserManager(_MockRepo.Object);


        [Fact]
        public async Task Return_Error()
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
            ErrorHandler.GetError(newUser.Errors);

            _MockRepo.Verify(x=>x.GetUserByEmail(email.Value));
            _MockRepo.VerifyNoOtherCalls();

        }
    }
}