using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Domain.src.Enum;

[assembly:InternalsVisibleTo("Tests")]
namespace Domain.src.ValueObject
{
    public record EmergencyContact
    {
        public FullName Name {get;}
        public RelationShip RelationShip {get;private set;}
        public Phone Phone {get;}

        internal EmergencyContact(FullName name, RelationShip relationShip,Phone phone){
            Name = name;
            RelationShip = relationShip;
            Phone = phone;
        }

        public void ChangeRelationShip(RelationShip relationShip){
            RelationShip = relationShip;
        }
    }
}