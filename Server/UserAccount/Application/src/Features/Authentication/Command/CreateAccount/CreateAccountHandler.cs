using System.Runtime.Intrinsics.X86;
using MediatR;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Domain.src.Entity;
using Application.src.Interface;
using FluentResults;
using Application.src.Error;
using Application.src.Utils;

namespace Application.src.Features.Authentication.Command.CreateAccount
{
    public class CreateAccountHandler : IHandler<CreateAccountCommand>
    {
        private readonly IUserManager _UserManager;

        public CreateAccountHandler(IUserManager userManager)
        {
            _UserManager = userManager;
        }

        public async Task<Result> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            IAppError? error = null;

            // obtenemos parametros
            var input = request.newAccount;
            // Creamos usernmae
            var username = Username.Create(input.username);
            if (username.IsFailed){
                error = ErrorHandler.GetError(username.Errors);
            }
            // Creamos email
            var email = Email.Create(input.email);
            if (email.IsFailed){
                error = ErrorHandler.GetError(email.Errors);
            }
            // Creamos nuevo usuario
            var newUser = await _UserManager.CreateUser(username.Value, email.Value, input.password);
            if (newUser.IsFailed){
                error = ErrorHandler.GetError(newUser.Errors);
            }

            return Result.Ok();
        }
    }
}