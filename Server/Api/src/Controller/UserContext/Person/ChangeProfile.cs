using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Person;

public static class ChangeProfile
{
    public static IEndpointRouteBuilder CreateProfileRoute(this IEndpointRouteBuilder route)
    {
        route.MapGet("/profile", async (IPersonController profile) =>
        {
            try
            {

            var newProfile = await profile.ChangeProfile(new(Guid.Parse("3bb030a0-6fee-4e5f-9db1-29a12ac6e9e2"),"Ivan","Corlli","Male",DateTime.Parse("01-04-2000")));
            return Results.Ok(newProfile);
            }catch (Exception ex)
            {
                return Results.Problem(ex.Message.ToString());
            }

        });
        return route;
    }


}
