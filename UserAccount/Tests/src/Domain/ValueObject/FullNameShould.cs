using Domain.src.ValueObject;
using FluentAssertions;
using FluentResults;
using Xunit;
using Domain.src.Utils;

namespace Tests.src.Domain.ValueObject
{
    public class FullNameShould
     {
          [Fact]
        public void Return_Corect_Type_When_Is_Valid(){
            var name = "ivan";
            var surname = "Corlli";
            var newFullName = FullName.Create(name,surname);

            newFullName.Should().BeOfType<Result<FullName>>();
            newFullName.Value.Should().BeOfType<FullName>();

        }

        [Fact]
        public void Return_Error_When_Is_NullOrEmpty(){
            var name = "";
            var newFullName = FullName.Create(name,"");

            newFullName.IsSuccess.Should().BeFalse();
            newFullName.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Contains_Invalid_Charactrers(){
            var name = "ivan01/_123&&@gmail54%.com";
            var surname = "Corlli88974534532./.345";
            var newFullName = FullName.Create(name,surname);

            newFullName.IsSuccess.Should().BeFalse();
            newFullName.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Too_Long(){
            var name = "ivancorllivdvsdvorlliherran";
            var surname = "Corllasdfasfasdfbfbklifhjgasjhgfi";
            var newFullName = FullName.Create(name,surname);

            newFullName.IsSuccess.Should().BeFalse();
            newFullName.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Is_Too_Short(){
            var name = "Iv";
            var surname = "Co";
            var newFullName = FullName.Create(name,surname);

            newFullName.IsSuccess.Should().BeFalse();
            newFullName.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Value_Capitalized(){
            var name = "iVaN";
            var surname = "cOrllI";
            var newFullName = FullName.Create(name,surname);

            var nameEx = Capitalize.Create(name);
            var surnEx = Capitalize.Create(surname);

            newFullName.Value.Should().BeOfType<FullName>();
            newFullName.Value.FirstName.Should().BeEquivalentTo(nameEx);
            newFullName.Value.LastName.Should().BeEquivalentTo(surnEx);
        }

        [Fact]
        public void Change_FirstName(){
            var name = "iVaN";
            var surname = "cOrllI";
            var newFullName = FullName.Create(name,surname);

            var newFirstName = "julian";
            var newFirstEx = Capitalize.Create(newFirstName);

            newFullName.Value.ChangeFirstName(newFirstName);

            newFullName.Value.Should().BeOfType<FullName>();
            newFullName.Value.FirstName.Should().BeEquivalentTo(newFirstEx);
        }

         [Fact]
        public void Change_LastName(){
            var name = "iVaN";
            var surname = "cOrllI";
            var newFullName = FullName.Create(name,surname);

            var newLats = "julian";
            var newLastEx = Capitalize.Create(newLats);

            newFullName.Value.ChangeLastName(newLats);

            newFullName.Value.Should().BeOfType<FullName>();
            newFullName.Value.LastName.Should().BeEquivalentTo(newLastEx);
        }
    }
}