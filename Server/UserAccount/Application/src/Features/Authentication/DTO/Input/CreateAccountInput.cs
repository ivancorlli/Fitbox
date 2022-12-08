
namespace Application.src.Features.Authentication.DTO.Input
{
    public sealed record CreateAccountInput(
        string username,
        string email,
        string password);
}