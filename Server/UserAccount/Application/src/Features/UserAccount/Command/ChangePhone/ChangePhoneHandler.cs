using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.src.Interface;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.ChangePhone
{
    public class ChangePhoneHandler : IHandler<ChangePhoneCommand, Result>
    {
        private readonly IAccountManager _AccountManager;
        private readonly IUnitOfWork _UnitOfWork;

        public ChangePhoneHandler(IAccountManager accountManager, IUnitOfWork unitOfWork)
        {
            _AccountManager = accountManager;
            _UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangePhoneCommand request, CancellationToken cancellationToken)
        {
            var input = request.input;
            var phone = await _AccountManager.CreatePhone(input.area,input.number,input.prefix);
            if(phone.IsFailure)
                return Result.Fail(phone.Error);
            var userExist = await _UnitOfWork.AccountReadRepository.GetById(input.id);
            var user = userExist.Value;
            user.ChangePhone(phone.Value);
            await _UnitOfWork.AccountWriteRepository.Update(user);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}