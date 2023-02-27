namespace UserContext.Domain.src.ValueObject;

public record OperatingTime
{
    public string StartTime { get; }
    public string EndTime { get; }
    public DayOfWeek Day { get; }

    private OperatingTime(string start,string end,DayOfWeek day)
    { 
        StartTime = start;
        EndTime = end;
        Day = day; 
    }
}
