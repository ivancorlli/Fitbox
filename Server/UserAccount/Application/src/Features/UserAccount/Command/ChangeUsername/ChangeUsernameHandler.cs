using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.src.Errors;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.ChangeUsername
{
    public class ChangeUsernameHandler : IHandler<ChangeUsernameCommand, Result>
    {   
        private readonly IAccountManager _AccountManager;
        private readonly IUnitOfWork _UnitOfWork;

        public ChangeUsernameHandler(IAccountManager manager,IUnitOfWork unitOfWork)
        {
            _AccountManager = manager;
            _UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangeUsernameCommand request, CancellationToken cancellationToken)
        {
            var input = request.input;
            var username = Username.Create(input.username);
            if(username.IsFailure)
                return Result.Fail(username.Error);
            var accountExist = await _UnitOfWork.AccountReadRepository.GetByIdAsync(input.id);
            if(accountExist == null)
                return Result.Fail(new AccountNotExists());
            var usernameChanged = await _AccountManager.ChangeUsername(accountExist,username.Value);
            if (usernameChanged.IsFailure)
                return Result.Fail(usernameChanged.Error);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}