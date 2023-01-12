using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.src.Interface;
using Domain.src.ValueObject;
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
            var phone = Phone.Create(input.area,input.number);
            if(phone.IsFailure)
                return Result.Fail(phone.Error);
            var accountExist = await _UnitOfWork.AccountReadRepository.GetById(input.id);
            var account = accountExist.Value;
            var phoneChanged = await _AccountManager.ChangePhone(account,phone.Value);
            if(phoneChanged.IsFailure)
                return Result.Fail(phoneChanged.Error);

            _UnitOfWork.AccountWriteRepository.Update(account);
            await _UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}