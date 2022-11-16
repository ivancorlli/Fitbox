using Domain.src.ValueObject;
using FluentAssertions;
using FluentResults;
using System;
using Bogus;
using Xunit;




/// <summary>
/// -> Purpose  Muestra la informacion medica del usuario, esto sirve para conocer si el usuario  esta en       condiciones de realizar actividad fisica. Tambien sirve para tener en cuenta alergias y dificultades que pueda tener el usuario.
/// -> Check
///   - Debe tener aptitud fisica, un registro de dificultades y alergias
/// </summary>
namespace Tests.src.Domain.ValueObject
{
    public class MedicalInfoShould

    {

        private Faker _Fake = new Faker();

        [Fact]
        public void Return_ValidTypes()
        {   
            var medical = MedicalInfo.Create(new Uri("http://www.contoso.com/"));

            medical.IsSuccess.Should().BeTrue();
            medical.Value.Should().BeOfType<MedicalInfo>();
            medical.Value.Aptitude.Should().BeOfType<Uri>();
            medical.Value.Disabilities.Should().BeNull();
            medical.Value.Allergies.Should().BeNull();

            var medial2 = MedicalInfo.Create("Niguna","Penicilina");
            medial2.IsSuccess.Should().BeTrue();
            medial2.Value.Should().BeOfType<MedicalInfo>();
            medial2.Value.Aptitude.Should().BeNull();
            medial2.Value.Allergies.Should().BeOfType<string>();
            medial2.Value.Disabilities.Should().BeOfType<string>();
        }

        [Fact]
        public void Return_Error_When_Text_Is_Invalid(){
            var text = "jkhd 938/>=-,.@#$%";
            var medical = MedicalInfo.Create(text);

            medical.IsSuccess.Should().BeFalse();
            medical.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Return_Error_When_Text_Is_Too_Long(){
            var text = _Fake.Lorem;
            var medical = MedicalInfo.Create(text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!+text.ToString()!);

            medical.IsSuccess.Should().BeFalse();
            medical.Errors.Count.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public void Change_Aptitude(){
            var medical = MedicalInfo.Create(new Uri("http://www.contoso.com/"));

            medical.Value.ChangeAptitude(new Uri("http://www.google.com/"));

            medical.Value.Aptitude.Should().Be(new Uri("http://www.google.com/"));

        }

        [Fact]
        public void Change_Disabilities(){
            var medical = MedicalInfo.Create("Niguna");
            medical.Value.ChangeDisabilites("Tengo el ligamento izquierdo operado, tengo operacion de menisccos");

            medical.Value.Disabilities.Should().NotBe("Ninguna");
        }

        [Fact]
        public void Change_Allergies(){
            var medical = MedicalInfo.Create("Niguna","Ninguna");
            medical.Value.ChangeAllergies("Penicilina");

            medical.Value.Disabilities.Should().NotBe("Ninguna");
        }
    }
}