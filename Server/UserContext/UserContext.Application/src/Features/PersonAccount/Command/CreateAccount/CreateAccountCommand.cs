using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.PersonAccount.DTO.Input;
using UserContext.Application.src.Features.PersonAccount.DTO.Output;

namespace UserContext.Application.src.Features.PersonAccount.Command.CreateAccount;

public sealed record CreateAccountCommand(CreateAccountInput Input):ICommand<Result<CreateAccountOutput>>;

