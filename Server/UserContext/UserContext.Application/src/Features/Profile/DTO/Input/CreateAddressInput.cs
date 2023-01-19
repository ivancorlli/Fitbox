namespace UserContext.Application.src.Features.Profile.DTO.Input;

public sealed record CreateAddressInput(
    Guid Id,
    string coutry,
    string city,
    string state,
    string zipCode,
    string? prefix

    );