using SharedKernell.src.Entity;
using SharedKernell.src.Result;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.Error;
using UserContext.Domain.src.Interface.Entity;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Abstractions
{
    public abstract class IPersonProfile : BaseEntity, IBasePerson
    {
        protected IPersonProfile() { }
        public PersonName Name { get; protected set; } = default!;
        public Gender Gender { get; protected set; }
        public DateTime Birth { get; protected set; }
        public Address? Address { get; protected set; }
        public EmergencyContact? EmergencyContact { get; protected set; }
        public Bio? Bio { get; protected set; }
        public MedicalInfo? Medical { get; protected set; }

        /// <summary>
        /// Create a base person
        /// </summary>
        /// <param name="account"></param>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="birth"></param>
        protected IPersonProfile(PersonName name, Gender gender, DateTime birth)
        {
            Name = name;
            Gender = gender;
            Birth = birth;
        }
        //

        /// <summary>
        /// Change name and surname
        /// </summary>
        /// <param name="name"></param>
        public void ChangeName(PersonName name)
        {
            Name = name;
            EntityUpdated();
        }

        /// <summary>
        /// Change gender
        /// </summary>
        /// <param name="gender"></param>
        public void ChangeGender(Gender gender)
        {
            Gender = gender;
            EntityUpdated();
        }

        /// <summary>
        /// Change Birth
        /// </summary>
        /// <param name="birth"></param>
        /// <returns></returns>
        public Result ChangeBirth(DateTime birth)
        {
            var isValid = ValidateBirth(birth);
            if (isValid.IsFailure)
            {
                return Result.Fail(isValid.Error);
            }
            else
            {
                Birth = birth;
                EntityUpdated();
                return Result.Ok();
            }

        }

        /// <summary>
        /// Create Adress
        /// </summary>
        /// <param name="address"></param>
        public void CreateAddress(Address address)
        {
            Address = address;
            EntityUpdated();
        }

        /// <summary>
        /// Delete Address
        /// </summary>
        public void DeleteAddress()
        {
            Address = null;
            EntityUpdated();
        }

        /// <summary>
        /// Cambia la biografia
        /// </summary>
        /// <param name="bio"></param>
        public void ChangeBio(Bio bio)
        {
            Bio = bio;
            EntityUpdated();
        }

        /// <summary>
        /// Crea un contacto de emergencia
        /// </summary>
        /// <param name="name"></param>
        /// <param name="relationShip"></param>
        /// <param name="phone"></param>
        public void CreateContact(PersonName name, RelationShip relationShip, ContactPhone phone)
        {
            EmergencyContact = new EmergencyContact(name, relationShip, phone);
            EntityUpdated();
        }

        // <summary>
        // Elimina el contacto de emergencia
        // </summary>
        public void DeleteContact()
        {
            EmergencyContact = null;
            EntityUpdated();
        }

        /// <summary>
        /// Crea un registro de informacion medica
        /// </summary>
        /// <param name="medical"></param>
        public void CreateMedicalInfo(MedicalInfo medical)
        {
            Medical = medical;
            EntityUpdated();
        }

        /// <summary>
        /// Elimina la informacion medica
        /// </summary>
        public void DeleteMedicalInfo()
        {
            Medical = null;
            EntityUpdated();
        }
        // ================================================================================================================ //      

        /// <summary>
        /// Validate a person age, It needs to be 13 years older
        /// </summary>
        /// <param name="birth"></param>
        /// <returns></returns>
        public static Result ValidateBirth(DateTime birth)
        {
            var isLegal = (DateTime.UtcNow - birth).TotalDays / 365;

            if (birth > DateTime.Now)
            {
                return Result.Fail(new ValidationError("La fecha de nacimiento no puede ser mayor a la fecha de hoy"));

            }
            if (isLegal < 13)
            {
                return Result.Fail(new ValidationError("No puedes continuar, eres menor de 13 años"));
            }
            return Result.Ok();

        }
    }

}