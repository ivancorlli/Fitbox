using Api.src.Controller.UserContext.Person;

namespace Api.src.Routes.UserContext;

public static class PersonRouter
{
    public static RouteGroupBuilder ConfigurePersonRouter(this RouteGroupBuilder router)
    {
        router.MapGroup("/person")
            .CreateAccountRoute()
            .ChangeEmailRoute()
            .ChangeUsernameRoute()
            .ChangePhoneRoute()
            .ChangePasswordRoute()
            .VerifyEmailRoute()
            .VerifyPhoneRoute()
            .ChangeProfileRoute()
            .ChangeAddressRoute()
            .ChangeMedicalInfoRoute()
            .ChangeContactRoute();
        return router;
    }

}