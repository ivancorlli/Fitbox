using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.src.Errors;
using Domain.src.Interface;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.VerifyEmail;

public class VerifyEmailHandler : IHandler<VerifyEmailCommand, Result>
{
    private readonly IUnitOfWork _UnitOfWork;

    public VerifyEmailHandler(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        var accountExist = await _UnitOfWork.AccountReadRepository.GetByIdAsync(input.Id);
        if(accountExist == null)
            return Result.Fail(new AccountNotExists());
        accountExist.VerifyEmail();
        _UnitOfWork.AccountWriteRepository.Update(accountExist);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}