using System.ComponentModel.DataAnnotations;

namespace Application.src.User.Dto.Input{

public class CreateAccountDto
{
    [Required]
    public string Username {get;set;} = string.Empty;

    [Required]
    public string Email {get;set;} = string.Empty;

    [Required]
    public string Password{get;set;}=string.Empty;
    
}
}