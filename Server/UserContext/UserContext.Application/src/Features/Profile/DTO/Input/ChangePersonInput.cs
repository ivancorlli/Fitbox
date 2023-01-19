namespace UserContext.Application.src.Features.Profile.DTO.Input;

public sealed record ChangePersonInput(
    Guid Id,
    string? name,
    string? surname,
    string? gender,
    DateTime? birth
);