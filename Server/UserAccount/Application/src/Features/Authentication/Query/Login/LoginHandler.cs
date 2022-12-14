using System.Reflection.Metadata.Ecma335;
using Domain.src.Enum;
using Domain.src.Error;
using Domain.src.Interface;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Authentication.Query.Login
{
    public class LoginHandler : IHandler<LoginCommand, Result>
    {
        private readonly IUserReadRepository _ReadRepo;

        public LoginHandler(IUserReadRepository readRepo)
        {
            _ReadRepo = readRepo;
        }

        public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var input = request.Login;
            // Buscamos al usuario
            var user = await _ReadRepo.FindByEmailOrUsername(input.access);
            if(user == null)
                return Result.Fail(new UserNotFound(input.access));
            // Verificamos el estado del email
            if(user.EmailVerified == false)
                return Result.Fail(new UserUnverified());
            // Verificamos el estado
            if (user.Status == AccountStatus.Deleted)
                return Result.Fail(new UserDeleted(user.Username.Value));
            if(user.Status == AccountStatus.Suspended)
                return Result.Fail(new UserSuspended(user.Username.Value));
            if(user.Status == AccountStatus.Inactive)
                return Result.Fail(new UserInactive(user.Username.Value));
            // Verificamos la contrasenia
            var validPassword = user.Password.VerifyPassword(input.password);
            if(!validPassword)
                return Result.Fail(new IncorrectPassword());

            return Result.Ok();
        }
    }
}