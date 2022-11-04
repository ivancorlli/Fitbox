
namespace BaseFitbox.Src
{
    public abstract class DomainEvent
    {
        public DateTimeOffset EventTime {get; protected set;} = DateTimeOffset.UtcNow;
    }
}