using System.Runtime.CompilerServices;
using Domain.src.Enum;
using Domain.src.ValueObject;
using Domain.src.Abstractions;
using Shared.src.Error;

[assembly: InternalsVisibleTo("Tests")]
namespace Domain.src.Entity
{

    public class Person:BasePerson
    {
        private Person(){}
        private Person(Guid account, PersonName name, Gender gender, DateTime birth) : base(account, name, gender, birth)
        {
        }
        public EmergencyContact? EmergencyContact {get;private set;}
        public Bio? Biography {get;private set;}
        public MedicalInfo? Medical {get;private set;}  


        internal static Result<Person> Create(Guid account,PersonName name, Gender gender, DateTime birth)
        {   
        var isValid = ValidateBirth(birth);
           if(isValid.IsFailure)
                return Result.Fail<Person>(isValid.Error);

            var newUser = new Person(account,name,gender,birth);
            return Result.Ok<Person>(newUser);
        }
        
        // ================================== PROPERTIES  METHODS ========================================= //
        
        /// <summary>
        /// Cambia la biografia
        /// </summary>
        /// <param name="bio"></param>
        public void ChangeBio(Bio bio){
            Biography = bio;
            EntityUpdated();
        }
        
         /// <summary>
        /// Crea un contacto de emergencia
        /// </summary>
        /// <param name="name"></param>
        /// <param name="relationShip"></param>
        /// <param name="phone"></param>
        public void CreateContact(PersonName name, RelationShip relationShip, ContactPhone phone){
            EmergencyContact = new EmergencyContact(name,relationShip,phone);
            EntityUpdated();
        }

        // <summary>
        // Elimina el contacto de emergencia
        // </summary>
        public void DeleteContact(){
           EmergencyContact = null;
           EntityUpdated();
        }

        /// <summary>
        /// Crea un registro de informacion medica
        /// </summary>
        /// <param name="medical"></param>
        public void CreateMedicalInfo(MedicalInfo medical){
            Medical = medical;
            EntityUpdated();
        }

        /// <summary>
        /// Elimina la informacion medica
        /// </summary>
        public void DeleteMedicalInfo(){
            Medical= null;
            EntityUpdated();
        }
    }
}
