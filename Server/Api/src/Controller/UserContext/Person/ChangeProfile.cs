using Microsoft.AspNetCore.Mvc;
using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.Person;

public static class ChangeProfile
{
    public static IEndpointRouteBuilder CreateProfileRoute(this IEndpointRouteBuilder route)
    {
        route.MapPost("/profile", async ([FromServices]IPersonController profile, PersonProfile personProfile) =>
        {
            try
            {
                Console.WriteLine(personProfile);
            var newProfile = await profile.ChangeProfile(new(Guid.Parse(personProfile.AccountId),personProfile.Name,personProfile.Surname,personProfile.Gender,DateTime.Parse(personProfile.Birth)));
            return Results.Ok(newProfile);
            }catch (Exception ex)
            {
                return Results.Problem(ex.Message.ToString());
            }

        });
        return route;
    }

    internal record PersonProfile(string AccountId,string Name,string Surname, string Gender, string Birth);


}
