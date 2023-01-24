namespace UserContext.Domain.src.ValueObject;

public record GymName
{
    public string Value { get; }

    private GymName(string name)
    {
        this.Value = name;
    }

}
