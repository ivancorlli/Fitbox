using Api.src.Utils;
using UserContext.Presentation.src.Interface;

namespace Api.src.Controller.UserContext.PersonAccount;

public static class CreateProfile
{
    public static IEndpointRouteBuilder CreateProfileController(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("/profile", async (
            IPersonController controller,
            CreateProfileBody Body
            ) =>
        {
            try
            {
                var accountId = Guid.NewGuid();
                var person = await controller.CreateProfile(new(accountId,Body.Name, Body.Surname, Body.Gender,Body.Birth));
                if (person.IsFailure)
                    return ResponseHandler.HandleError(person.Error);
                return Results.Created("Response", person.Value);
            }
            catch (Exception ex)
            {
                return ResponseHandler.HandleEx(ex);
            }

        });
        return builder;
    }
}

    internal record CreateProfileBody(string Name, string Surname, string Gender,DateTime Birth);
