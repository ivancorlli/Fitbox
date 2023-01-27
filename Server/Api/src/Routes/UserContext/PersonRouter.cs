using Api.src.Controller.UserContext.Person;

namespace Api.src.Routes.UserContext;

public static class PersonRouter
{
    public static IEndpointRouteBuilder ConfigurePersonRouter(this IEndpointRouteBuilder router)
    {
        var person = router.MapGroup("/person");
        person.CreateAccountRoute();
            //.CreateAccountRoute()
            //.ChangeEmailRoute()
            //.ChangeUsernameRoute()
            //.ChangePhoneRoute()
            //.ChangePasswordRoute()
            //.VerifyEmailRoute()
            //.VerifyPhoneRoute()
            //.ChangeProfileRoute()
            //.ChangeAddressRoute()
            //.ChangeMedicalInfoRoute()
            //.ChangeContactRoute();
        return person;
    }

}