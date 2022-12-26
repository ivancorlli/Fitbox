using System.Runtime.CompilerServices;
using Domain.src.Enum;
using Domain.src.Error;
using Domain.src.ValueObject;
using Shared.src.Abstractions;
using Shared.src.Error;

[assembly: InternalsVisibleTo("Tests")]
namespace Domain.src.Entity
{

    public class User:AggregateRoot 
    {   
        public Guid AccountId {get;init;}
        public PersonName Name {get;private set;}
        public Gender Gender {get;private set;}
        public DateTime Birth {get;private set;}
        public Address? Address {get;private set;}
        public EmergencyContact? EmergencyContact {get;private set;}
        public Bio? Biography {get;private set;}
        public MedicalInfo? Medical {get;private set;}  

        private User(Guid account,PersonName name, Gender gender, DateTime birth)
        {   
            AccountId = account;
            Name=name;
            Gender=gender;
            Birth=birth;
        }

        public static Result<User> Create(Guid account,PersonName name, Gender gender, DateTime birth)
        {   
        var isValid = ValidateBirth(birth);
           if(isValid.IsFailure)
                return Result.Fail<User>(isValid.Error);

            var newUser = new User(account,name,gender,birth);
            return Result.Ok<User>(newUser);
        }
        
        // ================================== PROPERTIES  METHODS ========================================= //

        /// <summary>
        /// Cambia el nombre y apellido
        /// </summary>
        /// <param name="name"></param>
        public void ChangeName(PersonName name){
            Name = name;
            TimeStamps = TimeStamps.Updated();
        }

        /// <summary>
        /// Cambia el genero
        /// </summary>
        /// <param name="gender"></param>
        public void ChangeGender(Gender gender){
            Gender = gender;
            TimeStamps = TimeStamps.Updated();
        }

        /// <summary>
        /// Cambia la fecha de nacimiento
        /// </summary>
        /// <param name="birth"></param>
        /// <returns></returns>
        public Result ChangeBirth(DateTime birth){
           var isValid = ValidateBirth(birth);
           if(isValid.IsFailure)
           {
                return Result.Fail(isValid.Error);
           }else{
            Birth = birth;
            TimeStamps = TimeStamps.Updated();
                return Result.Ok();
           }
            
        }
        
        /// <summary>
        /// Cambia la biografia
        /// </summary>
        /// <param name="bio"></param>
        public void ChangeBio(Bio bio){
            Biography = bio;
            TimeStamps = TimeStamps.Updated();
        }

        /// <summary>
        /// Cambia la direccion
        /// </summary>
        /// <param name="address"></param>
        public void ChangeAddress(Address address)
        {
            Address = address;
            TimeStamps = TimeStamps.Updated();
        }
        
         /// <summary>
        /// Crea un contacto de emergencia
        /// </summary>
        /// <param name="name"></param>
        /// <param name="relationShip"></param>
        /// <param name="phone"></param>
        public void CreateContact(PersonName name, RelationShip relationShip, ContactPhone phone){
            EmergencyContact = new EmergencyContact(name,relationShip,phone);
            TimeStamps = TimeStamps.Updated();
        }

        // <summary>
        // Elimina el contacto de emergencia
        // </summary>
        public void DeleteEmergencyContact(){
           EmergencyContact = null;
           TimeStamps = TimeStamps.Updated();
        }

        /// <summary>
        /// Crea un registro de informacion medica
        /// </summary>
        /// <param name="medical"></param>
        public void CreateMedicalInfo(MedicalInfo medical){
            Medical = medical;
            TimeStamps = TimeStamps.Updated();
        }

        /// <summary>
        /// Elimina la informacion medica
        /// </summary>
        public void DeleteMedicalInfo(){
            Medical= null;
            TimeStamps = TimeStamps.Updated();
        }

        // ================================================================================================================ //      
        public static Result ValidateBirth(DateTime birth)
        {
            var isLegal = (DateTime.UtcNow - birth).TotalDays /365;

            if(birth > DateTime.Now){
                return Result.Fail(new ValidationError("La fecha de nacimiento no puede ser mayor a la fecha de hoy"));

            }
            if(isLegal < 13){
                return Result.Fail(new ValidationError("No puedes continuar, eres menor de 13 años"));
            }
            return Result.Ok();

        }
    }
}
