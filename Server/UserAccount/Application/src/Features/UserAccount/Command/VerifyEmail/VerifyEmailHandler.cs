using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        var userExist = await _UnitOfWork.AccountReadRepository.GetById(input.Id);
        var user = userExist.Value;
        user.VerifyEmail();
        await _UnitOfWork.AccountWriteRepository.Update(user);
        await _UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}