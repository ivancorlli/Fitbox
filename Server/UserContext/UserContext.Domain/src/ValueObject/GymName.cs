namespace UserContext.Domain.src.ValueObject;

public record GymName
{
    public GymName() { }
    public string Value { get; } = default!;
    public GymName(string name)
    {
        this.Value = name;
    }

}
