namespace UserContext.Application.src.Features.Person.DTO.Output;

public class NewAccountDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public bool IsNew { get; set; }
    public bool EmailVerified { get; set; }
    public bool PhoneVerified { get; set; }
    public PhoneDto? Phone { get; set; }


}