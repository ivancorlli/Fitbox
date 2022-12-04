using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.src.Authentication.DTO.Input;
using Domain.src.Entity;
using MediatR;

namespace Application.src.Authentication.Command.CreateAccount
{
    public record CreateAccountCommand(CreateAccountInput input):IRequest<User> {}
}