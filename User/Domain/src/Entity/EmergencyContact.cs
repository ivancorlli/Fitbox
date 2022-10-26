using Domain.src.Enum;
using Domain.src.ValueObject;

namespace Domain.src.Entity
{
    public class EmergencyContact
    {
        public Guid Id {get ;private set;}
        public Guid UserId {get; private set;}
        public FullName Name {get; private set;}
        public Relationship Relationship {get; private set;}
        public PhoneNumber PhoneNumber {get;private set;}


        /// <summary>
        /// Crea un nuevo contacto de emergencia
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="relationship"></param>
        /// <param name="phoneNumber"></param>
        internal EmergencyContact(Guid userId, FullName name,Relationship relationship,PhoneNumber phoneNumber){
            Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
            Relationship = relationship;
            PhoneNumber = phoneNumber;
        }


        // ------------------------------- Methods ------------------------------------------------------------ //


        /// <summary>
        /// Actualiza todos los parametros del contacto
        /// </summary>
        /// <param name="name"></param>
        /// <param name="relationship"></param>
        /// <param name="phoneNumber"></param>
        internal void Update(FullName name, Relationship relationship, PhoneNumber phoneNumber){
            Name = name;
            Relationship = relationship;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Cambia el nombre
        /// </summary>
        /// <param name="name"></param>
         internal void ChangeName(FullName name){
            Name = name;

        }

        /// <summary>
        /// Cambia la relacion
        /// </summary>
        /// <param name="relationship"></param>
         internal void ChangeRelationship(Relationship relationship){
            Relationship = relationship;
        }

        /// <summary>
        /// Cambia el numero de telefono
        /// </summary>
        /// <param name="phoneNumber"></param>
         internal void ChangePhone(PhoneNumber phoneNumber){
            PhoneNumber = phoneNumber;
        }
    }
}