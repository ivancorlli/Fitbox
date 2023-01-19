namespace UserContext.Application.src.Features.Profile.DTO.Input;

public sealed record CreatePersonInput(
    Guid AccountID,
    string name,
    string surname,
    string gender,
    DateTime birth
);