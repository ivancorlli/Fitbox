using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.PersonAccount.DTO.Output;

public record CreateAccountOutput(
    Username Username,
    Email Email
    );
