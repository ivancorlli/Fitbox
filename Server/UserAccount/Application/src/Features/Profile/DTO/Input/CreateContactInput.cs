namespace Application.src.Features.Profile.DTO.Input;

public sealed record CreateContactInput(
    Guid Id,
    string name,
    string surname,
    string relationship,
    int areaCode,
    long number,
    string? prefix
);