namespace Application.src.Features.Profile.DTO.Input;

public sealed record UpdateUserInput(
    Guid Id,
    string? name,
    string? surname,
    string? gender,
    DateTime? birth
);