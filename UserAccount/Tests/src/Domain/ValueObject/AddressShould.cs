using Domain.src.Utils;
using Domain.src.ValueObject;
using FluentAssertions;
using FluentResults;
using Xunit;

namespace Tests.src.Domain.ValueObject
{
    public class AddressShould
        {
          [Fact]
        public void Return_Corect_Type_When_Is_Valid(){
            var country = "argentIna";
            var city = "tuCuman";
            var state = "san Miguel";
            var areCode = 4000;

            var l = areCode.ToString().Length;
            var newAddAddress =Address.Create(country,city,state,areCode);

            newAddAddress.Should().BeOfType<Result<Address>>();
            newAddAddress.Value.Should().BeOfType<Address>();
            newAddAddress.Value.Country.Should().BeEquivalentTo(country);
            newAddAddress.Value.City.Should().BeEquivalentTo(city);
            newAddAddress.Value.State.Should().BeEquivalentTo(state);
            newAddAddress.Value.AreaCode.Should().BePositive();

        }

        [Fact]
        public void Return_Error_When_Is_NullOrEmptyOrZero(){
             var country = "";
            var city = "";
            var state = "";
            var areCode = 0;
            var newAddAddress =Address.Create(country,city,state,areCode);

            newAddAddress.IsSuccess.Should().BeFalse();
            newAddAddress.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Contains_Invalid_Charactrers(){
            var country = "ivan01/_123&&@gmail54%.com";
            var city = "Corlli88974534532./.345";
            var state = "San mIchael 7989";
            var areCode = -342342;
            var newAddAddress =Address.Create(country,city,state,areCode);

            newAddAddress.IsSuccess.Should().BeFalse();
            newAddAddress.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Too_Long(){
            var country = "ivancorllivdvsdvorlliherran";
            var city = "Corllasdfasfasdfbfbklifhjgasjhgfi";
            var state = "San mIchaelasdfasdfasd";
            var areCode = 10786876;
            var newAddAddress =Address.Create(country,city,state,areCode);

            newAddAddress.IsSuccess.Should().BeFalse();
            newAddAddress.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Too_Short(){
            var country = "Iv";
            var city = "Co";
            var state = "Sa";
            var areCode = 12;
            var newAddAddress =Address.Create(country,city,state,areCode);

            newAddAddress.IsSuccess.Should().BeFalse();
            newAddAddress.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Change_Country(){
            var country = "argentIna";
            var city = "tuCuman";
            var state = "san Miguel";
            var areCode = 4000;

            var newAddAddress =Address.Create(country,city,state,areCode);

            var newFirstcountry = "Uruguay";
            var newFirstEx = Capitalize.Create(newFirstcountry);

            newAddAddress.Value.ChangeCountry(newFirstcountry);

            newAddAddress.Value.Should().BeOfType<Address>();
            newAddAddress.Value.Country.Should().BeEquivalentTo(newFirstEx);
        }

         [Fact]
        public void City(){
            var country = "argentIna";
            var city = "tuCuman";
            var state = "san Miguel";
            var areCode = 4000;

            var newAddAddress =Address.Create(country,city,state,areCode);

            var newCity = "Cordoba";
            var newFirstEx = Capitalize.Create(newCity);

            newAddAddress.Value.ChangeCity(newCity);

            newAddAddress.Value.Should().BeOfType<Address>();
            newAddAddress.Value.City.Should().BeEquivalentTo(newFirstEx);
        }

         [Fact]
        public void Change_State(){
            var country = "argentIna";
            var city = "tuCuman";
            var state = "La Veloz del Norte";
            var areCode = 4000;

            var newAddAddress =Address.Create(country,city,state,areCode);

            var newFirstcountry = "Nueva Cordoba";
            var newFirstEx = Capitalize.Create(newFirstcountry);

            newAddAddress.Value.ChangeState(newFirstcountry);

            newAddAddress.Value.Should().BeOfType<Address>();
            newAddAddress.Value.State.Should().BeEquivalentTo(newFirstEx);
        }

        [Fact]
         public void Change_AreaCode(){
            var country = "argentIna";
            var city = "tuCuman";
            var state = "La Veloz del Norte";
            var areCode = 4000;

            var newAddAddress =Address.Create(country,city,state,areCode);

            var newArea = 1000;

            newAddAddress.Value.ChangeAreaCode(newArea);

            newAddAddress.Value.Should().BeOfType<Address>();
            newAddAddress.Value.AreaCode.Should().BePositive();
        }

    }
}