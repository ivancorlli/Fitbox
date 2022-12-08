using Domain.src.Enum;
using Domain.src.ValueObject;
using FluentAssertions;
using Xunit;

namespace Tests.src.Domain.ValueObjects
{
    public class EmergencyContactShould
    {
        [Fact]
        public void Create_EmergencyContact()
        {
            var name = FullName.Create("fernando","corlli");
            var phone = Phone.Create(3876,5548697);
            var newContac = new EmergencyContact(name.Value,RelationShip.Father,phone.Value);

            newContac.Should().NotBeNull();
            newContac.Should().BeOfType<EmergencyContact>();
        }

        [Fact]
        public void Return_Same_With_Different_Name(){
            var name = FullName.Create("fernando","corlli");
            var phone = Phone.Create(3876,5548697);
            var newContac = new EmergencyContact(name.Value,RelationShip.Father,phone.Value);
            var newName = newContac.Name.WithName("luis");
            newContac = newContac.WithName(newName.Value);

            newContac.Name.Should().NotBe(name.Value);
        }

        [Fact]
        public void Return_Same_With_Different_Phone(){
            var name = FullName.Create("fernando","corlli");
            var phone = Phone.Create(3876,5548697);
            var newContac = new EmergencyContact(name.Value,RelationShip.Father,phone.Value);
            var newPhone = newContac.Phone.WithNumber(5548798);
            newContac = newContac.WithPhone(newPhone.Value);
            newContac.Phone.Should().NotBe(phone.Value);
        }
    }
}