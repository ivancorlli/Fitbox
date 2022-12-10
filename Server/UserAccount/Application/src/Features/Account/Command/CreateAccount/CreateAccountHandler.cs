using Domain.src.Interface;
using Shared.src.Interface.Command;
using Domain.src.Entity;
using Shared.src.Error;

namespace Application.src.Features.Account.Command.CreateAccount
{
    public class CreateAccountHandler : IHandler<CreateAccountCommand,Result>
    {
        private readonly IUserManager _UserManager;
        private readonly IUnitOfWork _UnitOfWork;

        public CreateAccountHandler(IUserManager userManager,IUnitOfWork unitOfWork)
        {
            _UserManager = userManager;
            _UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var input = request.newAccount;

            // Creamos nombre de usuario            
            var Username = await _UserManager.CreateUsername(input.username);
                if(Username.IsFailure)
                    return Result.Fail(Username.Error);
            // Creamos emaiil
            var Email = await _UserManager.CreateEmail(input.email);
                if(Email.IsFailure)
                    return Result.Fail(Email.Error);
            // Creamos usuario
            var newUser = User.Create(Username.Value,Email.Value,input.password);
                if(newUser.IsFailure)
                    return Result.Fail(newUser.Error);
            // Guardamos usuario en base de datos
            await _UnitOfWork.UserWriteRepository.AddUser(newUser.Value);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);
           return Result.Ok(newUser.Value);
        }
    }
}