using System.Runtime.CompilerServices;
using Domain.src.Enum;

[assembly:InternalsVisibleTo("Tests")]
namespace Domain.src.ValueObject
{
    public record EmergencyContact
    {
        public FullName Name {get;init;}
        public RelationShip RelationShip {get;init;}
        public Phone Phone {get;init;}

        /// <summary>
        /// Crea un nuevo contacto
        /// </summary>
        /// <param name="name"></param>
        /// <param name="relationShip"></param>
        /// <param name="phone"></param>
        internal EmergencyContact(FullName name, RelationShip relationShip,Phone phone){
            Name = name;
            RelationShip = relationShip;
            Phone = phone;
        }

        /// <summary>
        /// Cambia el nombre
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
       public EmergencyContact WithName(FullName name){
        var newContact = new EmergencyContact(name,RelationShip,Phone);
        return newContact;
       }

        /// <summary>
        /// Cambia el telefono
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
       public EmergencyContact WithPhone(Phone phone ){
        var newContac = new EmergencyContact(Name,RelationShip,phone);
        return newContac;
       }

    }
}