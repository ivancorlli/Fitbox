using UserContext.Domain.src.Enum;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.PersonAccount.DTO.Output;

public record CreateProfileOutput(
    PersonName Name,
    Gender Gender,
    DateTime Birth
    );

