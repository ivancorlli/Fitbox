using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.ChangeUsername
{
    public class ChangeUsernameHandler : IHandler<ChangeUsernameCommand, Result>
    {   
        private readonly IAccountManager _UserManager;
        private readonly IUnitOfWork _UnitOfWork;

        public ChangeUsernameHandler(IAccountManager manager,IUnitOfWork unitOfWork)
        {
            _UserManager = manager;
            _UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangeUsernameCommand request, CancellationToken cancellationToken)
        {
            var input = request.input;
            var username = await _UserManager.CreateUsername(input.username);
            if(username.IsFailure)
                return Result.Fail(username.Error);
            var userExist = await _UnitOfWork.AccountReadRepository.GetUserById(input.id);
            var user = userExist.Value;
            user.ChangeUsername(username.Value);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}