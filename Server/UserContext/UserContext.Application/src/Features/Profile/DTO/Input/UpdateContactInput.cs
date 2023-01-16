namespace UserContext.Application.src.Features.Profile.DTO.Input;

public sealed record UpdateContactInput(
    Guid Id,
    string? name,
    string? surname,
    string? relationship,
    int? areaCode,
    long? number,
    string? prefix
);