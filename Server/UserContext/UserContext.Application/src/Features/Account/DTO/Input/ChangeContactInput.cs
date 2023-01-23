namespace UserContext.Application.src.Features.Account.DTO.Input;

public sealed record ChangeContactInput(
    Guid Id,
    string name,
    string surname,
    string relationship,
    int areaCode,
    long number,
    string? prefix
);