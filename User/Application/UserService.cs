using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.src.Aggregate.UserAggregate;
using Domain.src.Enum;
using Domain.src.ValueObject;

namespace Application
{
    public class UserService
    {
        void main(){
            var newUser = new User(
                new Email("ivancorlli"),
                new Username("icorlli"),
                "123456"
                );

            newUser.CreateEmergencyContact(
                new FullName("Fernando", "Corlli"),
                Relationship.Father,
                new PhoneNumber(3876,410036)
            );

            newUser.UpdateEmergencyContact(new PhoneNumber(3876,554865));
        }



        
    }
}