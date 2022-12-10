using Shared.src.Interface;

namespace Shared.src.Abstractions
{
    public abstract class BaseEntity :IBaseEntity
    {

        public Guid Id {get;private init;}
        protected BaseEntity(){
            Id = Guid.NewGuid();
        }
    }
}