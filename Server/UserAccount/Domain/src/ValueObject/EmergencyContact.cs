using System.Runtime.CompilerServices;
using Domain.src.Enum;

[assembly:InternalsVisibleTo("Tests")]
namespace Domain.src.ValueObject
{
    public record EmergencyContact
    {
        public PersonName Name {get;init;}
        public RelationShip RelationShip {get;init;}
        public Phone Phone {get;init;}

        /// <summary>
        /// Crea un nuevo contacto
        /// </summary>
        /// <param name="name"></param>
        /// <param name="relationShip"></param>
        /// <param name="phone"></param>
        internal EmergencyContact(PersonName name, RelationShip relationShip,Phone phone){
            Name = name;
            RelationShip = relationShip;
            Phone = phone;
        }
    }
}