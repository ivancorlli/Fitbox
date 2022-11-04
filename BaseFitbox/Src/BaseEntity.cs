using BaseFitbox.Src.ValueObject;

namespace BaseFitbox.Src
{
    public abstract class  BaseEntity
    {
        public Id Id;

        public TimeStamps Timestamps;

        public List<DomainEvent> Events = new List<DomainEvent>();

        public BaseEntity(){
            Id = new Id();
            Timestamps = new TimeStamps();
        }

    }
}