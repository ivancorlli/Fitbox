using System.ComponentModel.DataAnnotations;

namespace Application.src.User.Dto.Input
{
    public record ChangeUsernameDto
    {   
        [Required]
        public Guid Id {get;set;} = Guid.Empty;
        [Required]
        public string Username {get;set;}= string.Empty;
        
    }
}