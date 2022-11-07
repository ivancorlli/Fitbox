using Domain.src.Enum;
using Domain.src.ValueObject;

namespace Domain.src.Entity
{
    public class Plan
    {
        public Guid Id {get;}
        public Guid GymOwner {get;}
        public string Name {get;private set;}
        public string? Description {get;private set;}
        public int Price {get;private set;}
        public int DaysQuantity {get;private set;}
        public PlanStatus Status {get; private set;}
        public PlanType Type {get;private set;}
    public Plan(Guid gymOwner,string name,PlanType type,int daysQuantity,int price, string? description){
        GymOwner = gymOwner;
        Name = name;
        Type= type;
        DaysQuantity =daysQuantity;
        Price = price;
        Status = PlanStatus.Enabled;
        Description = description;
    }
    }

}