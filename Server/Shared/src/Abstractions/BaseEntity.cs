using Shared.src.Interface;
using Shared.src.ValueObject;

namespace Shared.src.Abstractions
{
    public abstract class BaseEntity :IBaseEntity
    {

        public Guid Id {get;private init;}
        public TimeStamps TimeStamps {get;private set;} 
        protected BaseEntity(){
            Id = Guid.NewGuid();
            TimeStamps = new TimeStamps();
        }

        protected void EntityUpdated(){
            TimeStamps = TimeStamps.Updated();
        }

    }
}