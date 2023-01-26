namespace UserContext.Application.src.Features.Person.DTO.Input;

public sealed record CreateAccountInput(
    string username,
    string email,
    string password);