namespace UserContext.Application.src.Features.PersonAccount.DTO.Input;

public sealed record ChangeProfileInput(
    Guid id,
    string name,
    string surname,
    string gender,
    DateTime birth
);