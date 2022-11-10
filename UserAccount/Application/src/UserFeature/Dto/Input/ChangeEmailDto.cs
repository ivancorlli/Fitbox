using System.ComponentModel.DataAnnotations;

namespace Application.src.UserFeature.Dto.Input
{
    public record ChangeEmailDto
    {
        [Required]
        public Guid Id {get;set;} = Guid.Empty;
        [Required]
        public string Email {get;set;} = String.Empty;
    }
}