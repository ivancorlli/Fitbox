using Api.src.Controller.UserContext.PersonAccount;

namespace Api.src.Routes.UserContext;

public static class PersonRouter
{
    public static IEndpointRouteBuilder ConfigurePersonRouter(this IEndpointRouteBuilder router)
    {
        var person = router.MapGroup("/person");
        person.CreateAccountController();
        return person;
    }

}