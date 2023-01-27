namespace UserContext.Application.src.Features.PersonAccount.DTO.Input;

public sealed record CreateAccountInput(
    string username,
    string email,
    string password);