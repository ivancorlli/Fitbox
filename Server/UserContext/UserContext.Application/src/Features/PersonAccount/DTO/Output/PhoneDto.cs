namespace UserContext.Application.src.Features.PersonAccount.DTO.Output;

public sealed record PhoneDto
{
    public int AreaCode { get; set; }
    public long Number { get; set; }
    public string Prefix { get; set; } = string.Empty;
}