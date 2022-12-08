using System;
using System.Collections.Generic;
using FluentAssertions;
using Domain.src.ValueObject;
using Xunit;

namespace Tests.src.Domain.ValueObjects
{
    public class AddressShould
    {
            private string  country = "argentina";
            private string  city = "tucuman";
            private string  state = "san miguel";
            private ZipCode  zipCode = ZipCode.Create("4000").Value;
        [Fact]
        public void Create_Address()
        {
            var newAdrres = Address.Create(country,city,state,zipCode);

            newAdrres.Errors.Count.Should().Be(0);
            newAdrres.Value.Should().NotBeNull();
            newAdrres.Value.Country.Should().BeOfType<string>();
            newAdrres.Value.City.Should().BeOfType<string>();
            newAdrres.Value.State.Should().BeOfType<string>();
            newAdrres.Value.ZipCode.Should().BeOfType<ZipCode>();
        }

        [Fact]
        public void Return_Error_When_Coutry_Is_Invalid(){
            string[] invalidC = {"Argen ?/tina2","SanMiguelDe Tucuman Y lOs Fresnos uno","ho"};
            for (int i = 0; i < invalidC.Length; i++)
            {
            var newAddres = Address.Create(invalidC[i].ToString(),city,state,zipCode);
            newAddres.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
                
            }
        }

        [Fact]
        public void Return_Error_When_City_Is_Invalid(){
            string[] invalidC = {"Tucu2342","New YorkCity in the air","re"};
            for (int i = 0; i < invalidC.Length; i++)
            {
            var newAddres = Address.Create(invalidC[i].ToString(),city,state,zipCode);
            newAddres.Errors.Count.Should().BeGreaterThanOrEqualTo(1);   
            }
        }

        [Fact]
        public void Return_Error_When_State_Is_Invalid(){
            string [] invalidC = {"Tucu234200","Belgrano Oeste Y Los Fresnos uno barrio amec y san jose de metan","fd"};
            for (int i = 0; i < invalidC.Length; i++)
            {
            var newAddres = Address.Create(invalidC[i].ToString(),city,state,zipCode);
            newAddres.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
            }
        }

        [Fact]
        public void Return_New_Address_With_Different_City_State_Zip(){
            var newCity = "salta";
            var newState = "san jose de menta";
            var newZip = ZipCode.Create("4440");

            var newAddres = Address.Create(country,city,state,zipCode);
            newAddres = newAddres.Value.WithCity(newCity,newState,newZip.Value);

            newAddres.Value.Should().BeOfType<Address>();
            newAddres.Value.City.Should().BeEquivalentTo(newCity);
            newAddres.Value.State.Should().BeEquivalentTo(newState);
            newAddres.Value.ZipCode.Should().BeEquivalentTo(newZip.Value);
        }

        [Fact]
        public void Return_New_Address_With_Different_State_Zip(){
            var newState = "san jose de menta";
            var newZip = ZipCode.Create("4440");

            var newAddres = Address.Create(country,city,state,zipCode);
            newAddres = newAddres.Value.WithState(newState,newZip.Value);

            newAddres.Value.Should().BeOfType<Address>();
            newAddres.Value.State.Should().BeEquivalentTo(newState);
            newAddres.Value.ZipCode.Should().BeEquivalentTo(newZip.Value);
        }
    }
}