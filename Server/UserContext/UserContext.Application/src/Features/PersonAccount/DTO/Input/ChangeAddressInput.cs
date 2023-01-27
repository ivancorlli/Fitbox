namespace UserContext.Application.src.Features.PersonAccount.DTO.Input;

public sealed record ChangeAddressInput(
    Guid Id,
    string coutry,
    string city,
    string state,
    string zipCode,
    string? prefix

    );