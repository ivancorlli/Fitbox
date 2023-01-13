using Domain.src.Interface;
using Shared.src.Interface.Command;
using Domain.src.Entity;
using Shared.src.Error;
using AutoMapper;
using Domain.src.ValueObject;

namespace Application.src.Features.UserAccount.Command.CreateAccount
{
    public class CreateAccountHandler : IHandler<CreateAccountCommand, Result>
    {
        private readonly IAccountManager _AccountManager;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public CreateAccountHandler(IAccountManager userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _AccountManager = userManager;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        public async Task<Result> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var input = request.newAccount;

            // Creamos nombre de usuario            
            var username = Username.Create(input.username);
            if (username.IsFailure)
                return Result.Fail(username.Error);
            // Creamos emaiil
            var email = Email.Create(input.email);
            if (email.IsFailure)
                return Result.Fail(email.Error);
            // Creamos usuario
            var newAccount = await _AccountManager.CreateAccount(username.Value, email.Value, input.password);
            if (newAccount.IsFailure)
                return Result.Fail(newAccount.Error);

            // Guardamos usuario en base de datos
            await _UnitOfWork.AccountWriteRepository.AddAsync(newAccount.Value);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);
           
            return Result.Ok();
        }
    }
}