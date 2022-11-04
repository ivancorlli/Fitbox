namespace BaseFitbox.Src
{
    public record TimeStamps
    {
        public DateTimeOffset CreatedAt {get;}
        public DateTimeOffset UpdatedAt {get;private set;}

        public TimeStamps(){
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void Updated(){
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}