using Domain.src.Enum;

namespace Domain.src.Entity
{
    public class StaffMember
    {
        public Guid Id {get;}
        public StaffRole Role {get;private set;}
        public Guid GymRelated {get; private set;}
        public StaffStatus Status {get; private set;}      

        /// <summary>
        /// Crea un nuevo miembro del gimnasio
        /// </summary>
        /// <param name="gymRelated"></param>
        /// <param name="role"></param>
        public StaffMember(Guid gymRelated,StaffRole role){
            Id = Guid.NewGuid();
            Role = role;
            GymRelated = gymRelated;
            Status = StaffStatus.Active;
        }
    }
}