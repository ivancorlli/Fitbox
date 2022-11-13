using System;
using System.Collections.Generic;
using System.Linq;
using Domain.src.Enum;

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