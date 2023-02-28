namespace UserContext.Application.src.Features.PersonAccount.DTO.Input;

public record CreateProfileInput(
    Guid AccountId,
    string Name,
    string Surname,
    string Gender,
    DateTime Birth
    );

