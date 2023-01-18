using MediatR;
using UserContext.Presentation.src.Controller.Account;

namespace Api.src.Routes.UserContext.Account;

internal static class NewAccount
{
internal static RouteGroupBuilder NewAccountController(this RouteGroupBuilder router, ISender sender)
{
    router.MapPost("/", async() => {
        
        var newUser = await CreateAccount.Exec(new("ivancorlli","corlliivan@gmail.com","A1jc8D62"));

    });
    return router;
}
}