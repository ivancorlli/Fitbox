using System.Security.Cryptography;
using System;
using System.Linq;
using Xunit;
using FluentAssertions;
using FluentResults;
using Domain.src.ValueObject;
using Domain.src.Enum;
using Bogus;


namespace Tests.src.Domain.ValueObject
{
    public class EmergencyContactShould
    {
        [Theory]
        [InlineData(79123)]
        public void Return_Valid_Types(int num)
        {   
            var fake = new Faker();
            var name = FullName.Create(fake.Person.FirstName,fake.Person.LastName);
            var phone = Phone.Create(num*87,5555);

            var newContact = new EmergencyContact(name.Value,RelationShip.Auncle,phone.Value);

            newContact.Name.Should().NotBeNull();
            newContact.Name.Should().BeOfType<FullName>();

            newContact.RelationShip.Should().BeDefined();

            newContact.Phone.Should().NotBeNull();
            newContact.Phone.Should().BeOfType<Phone>();
        }

        [Theory]
        [InlineData(1548)]
        public void Change_RelationShip(int num){
            var fake = new Faker();
            var name = FullName.Create(fake.Person.FirstName,fake.Person.LastName);
            var phone = Phone.Create(num*87,5555);

            var newContact = new EmergencyContact(name.Value,RelationShip.Auncle,phone.Value);

            newContact.ChangeRelationShip(RelationShip.Cousin);

            newContact.RelationShip.Should().NotHaveSameValueAs(RelationShip.Auncle);

        }
    }


}