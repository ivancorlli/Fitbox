namespace UserContext.Application.src.Features.UserAccount.DTO.Input;

public sealed record CreateAccountInput(
    string username,
    string email,
    string password);