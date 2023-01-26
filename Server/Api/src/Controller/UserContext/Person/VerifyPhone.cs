using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Person
{
    public static class VerifyPhone
    {
        public static RouteGroupBuilder VerifyPhoneRoute(this RouteGroupBuilder route)
        {
            route.MapPatch("/", VerifyPhoneController);
            return route;
        }

        internal static async void VerifyPhoneController(IPersonController account)
        {
            var phoneVerified = await account.VerifyPhone(new(new()));
        }
    }
}
