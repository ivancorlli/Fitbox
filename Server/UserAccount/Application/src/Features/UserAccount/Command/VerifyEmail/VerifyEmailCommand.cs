using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.src.Error;
using Shared.src.Interface.Command;
using Application.src.Features.UserAccount.DTO.Input;

namespace Application.src.Features.UserAccount.Command.VerifyEmail
{
    public sealed record VerifyEmailCommand(VerifyEmailInput Input):ICommand<Result>;
    
}