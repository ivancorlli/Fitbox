using Domain.src.Enum;
using Domain.src.ValueObject;

namespace Domain.src.Entity
{
    public record EmergencyContact
    {
        public Name Name {get; private set;}
        public Relationship Relationship {get; private set;}
        public PhoneNumber PhoneNumber {get;private set;}

        /// <summary>
        /// Crea un nuevo contacto de emergencia
        /// </summary>
        /// <param name="name"></param>
        /// <param name="relationship"></param>
        /// <param name="phoneNumber"></param>        
        internal EmergencyContact(Name name,Relationship relationship,PhoneNumber phoneNumber){
            Name = name;
            Relationship = relationship;
            PhoneNumber = phoneNumber;
        }
        
        /// <summary>
        /// Cambia la relacion
        /// </summary>
        /// <param name="relationship"></param>
        public void ChangeRelationship(Relationship relationship){
            Relationship = relationship;
        }

        /// <summary>
        /// Cambia el numero de telef
        /// </summary>
        /// <param name="phone"></param>
        public void ChangePhone(PhoneNumber phone){
            PhoneNumber = phone;
        }

    }
}