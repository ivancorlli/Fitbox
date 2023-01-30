namespace SharedKernell.src.ValueObject;

public sealed record TimeStamps
{
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    public TimeStamps()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    private TimeStamps(DateTime created,DateTime updated)
    {
        CreatedAt = created;
        UpdatedAt = updated;
    }

    public TimeStamps Updated()
    {
        return new TimeStamps(CreatedAt,DateTime.Now);
    }

}