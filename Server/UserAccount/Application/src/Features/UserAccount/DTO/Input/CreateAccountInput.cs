namespace Application.src.Features.Account.DTO.Input
{
    public sealed record CreateAccountInput(
        string username,
        string email,
        string password);
}