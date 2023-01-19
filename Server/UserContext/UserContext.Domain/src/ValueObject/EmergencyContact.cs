using System.Runtime.CompilerServices;
using UserContext.Domain.src.Enum;

[assembly: InternalsVisibleTo("Tests")]
namespace UserContext.Domain.src.ValueObject
{
    public record EmergencyContact
    {
        private EmergencyContact() { }
        public PersonName Name { get; init; } = default!;
        public RelationShip RelationShip { get; init; } = default!;
        public ContactPhone Phone { get; init; } = default!;

        /// <summary>
        /// Crea un nuevo contacto
        /// </summary>
        /// <param name="name"></param>
        /// <param name="relationShip"></param>
        /// <param name="phone"></param>
        internal EmergencyContact(PersonName name, RelationShip relationShip, ContactPhone phone)
        {
            Name = name;
            RelationShip = relationShip;
            Phone = phone;
        }
    }
}