namespace UserContext.Domain.src.ValueObject;

public record Provider
{
    public string UserId { get; }
    public string Email { get; }
    public string ProviderName { get; }
    public DateTime CreationTime { get; }
    public string? Name { get; }
    public string? Surname { get; }
    public string? ProviderType { get; }
    public string? ProviderUrl { get; }

    public Provider(string providerName,string userId,string email)
    {
        ProviderName = providerName;
        UserId = userId;
        Email= email;
        CreationTime= DateTime.Now;
    }

}
