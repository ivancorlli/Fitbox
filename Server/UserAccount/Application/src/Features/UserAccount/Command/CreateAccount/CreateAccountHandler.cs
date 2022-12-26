using Domain.src.Interface;
using Shared.src.Interface.Command;
using Domain.src.Entity;
using Shared.src.Error;
using AutoMapper;

namespace Application.src.Features.UserAccount.Command.CreateAccount
{
    public class CreateAccountHandler : IHandler<CreateAccountCommand, Result>
    {
        private readonly IAccountManager _UserManager;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public CreateAccountHandler(IAccountManager userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UserManager = userManager;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        public async Task<Result> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var input = request.newAccount;

            // Creamos nombre de usuario            
            var Username = await _UserManager.CreateUsername(input.username);
            if (Username.IsFailure)
                return Result.Fail(Username.Error);
            // Creamos emaiil
            var Email = await _UserManager.CreateEmail(input.email);
            if (Email.IsFailure)
                return Result.Fail(Email.Error);
            // Creamos usuario
            var newAccount = Account.Create(Username.Value, Email.Value, input.password);
            if (newAccount.IsFailure)
                return Result.Fail(newAccount.Error);
            // Guardamos usuario en base de datos
            Task.WaitAll(
            _UnitOfWork.AccountWriteRepository.AddAccount(newAccount.Value),
            _UnitOfWork.SaveChangesAsync(cancellationToken)
            );
            return Result.Ok();
        }
    }
}