using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.src.Features.UserAccount.DTO.Input;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.ChangeUsername
{
    public sealed record ChangeUsernameCommand(ChangeUsernameInput input) :ICommand<Result>;
}