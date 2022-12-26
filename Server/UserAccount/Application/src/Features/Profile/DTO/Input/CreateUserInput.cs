namespace Application.src.Features.Profile.DTO.Input;

public sealed record CreateUserInput(
    Guid Id,
    Guid AccountID,
    string name,
    string surname,
    string gender,
    DateTime birth
);