
using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.PersonAccount.DTO.Input;
using UserContext.Application.src.Features.PersonAccount.DTO.Output;

namespace UserContext.Application.src.Features.PersonAccount.Command.CreateProfile;

public record CreateProfileCommand(CreateProfileInput Input ):ICommand<Result<CreateProfileOutput>>;

