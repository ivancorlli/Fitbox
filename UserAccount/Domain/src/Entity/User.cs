using Domain.src.Enum;
using Domain.src.ValueObject;
using FluentResults;

namespace Domain.src.Entity
{
    public class User
    {   
        private static int _Min_Pass = 7;
        private static int _Max_Pass = 25;


        public Guid Id {get; private set;}
        public Username Username {get;private set;}
        public Email Email {get;private set;}
        public string Password {get; private set;}
        public AccountStatus Status {get; private set;}
        public bool IsNew {get; private set;}
        public bool EmailVerified {get;private set;}
        public AccountType UserType {get;private set;}
        public FullName? Name {get;private set;}
        public Gender? Gender {get;private set;}
        public DateTime? Birth {get;private set;}
        public Bio? Biography {get;private set;}
        public Address? Address {get;private set;}
        public Phone? Phone {get;private set;}
        public EmergencyContact? EmergencyContact {get;private set;}


        private User(Username username,Email email, string password){
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            Password = password;
            Status = AccountStatus.Active;
            UserType = AccountType.Personal;
            IsNew = true;
            EmailVerified = false;

        }

        public static Result<User> Create(Username username, Email email, string password){
            var validPass = ValidatePassword(password);

            if(validPass.IsSuccess){
                return Result.Ok<User>(new User(username,email,password));
            }else {
                return Result.Fail(new Error(validPass.Errors[0].Message));
            }

        }

        /// <summary>
        /// Cambia el nombre 
        /// </summary>
        /// <param name="name"></param>
        public void ChangeName(FullName name){
            Name = name;
        }

        /// <summary>
        /// Cambia el genero
        /// </summary>
        /// <param name="gender"></param>
        public void ChangeGender(Gender gender){
            Gender=gender;
        }

        /// <summary>
        /// Cambia la fecha de nacimiento
        /// </summary>
        /// <param name="birth"></param>
        /// <returns></returns>
        public Result ChangeBirth(DateTime birth){
            if(birth > DateTime.Now){
                return Result.Fail(new Error("La fecha de nacimiento no puede ser mayor a la fecha de hoy"));
            }else{
                Birth = birth;
                return Result.Ok();
            }
        }

        /// <summary>
        /// Cambia la biografia
        /// </summary>
        /// <param name="bio"></param>
        public void ChangeBio(Bio bio){
            Biography = bio;
        }

        /// <summary>
        /// Cambia la direccion
        /// </summary>
        /// <param name="address"></param>
        public void ChangeAddress(Address address)
        {
            Address = address;
        }

        /// <summary>
        /// Crea un contacto de emergencia
        /// </summary>
        /// <param name="name"></param>
        /// <param name="relationShip"></param>
        /// <param name="phone"></param>
        public void CreateEmergencyContact(FullName name, RelationShip relationShip, Phone phone){
            EmergencyContact = new EmergencyContact(name,relationShip,phone);
        }

        /// <summary>
        /// Elimina el contacto de emergencia
        /// </summary>
        public void DeleteEmergencyContact(){
            EmergencyContact = null;
        }

        internal void ChangePhone(Phone phone){
            Phone = phone;
        }

        // ---------------------------------------------- Validation ------------------------------------------------------------ //
        private static Result ValidatePassword(string pass){
            return Result.Merge(
                Result.FailIf(pass.StartsWith("1234"),new Error("Contraseña insegura, no puede iniciar con 1234")),
                Result.FailIf(pass.StartsWith("qwer"),new Error("Contraseña insegura, no puede iniciar con qwer")),
                Result.FailIf(pass.StartsWith("asdf"), new Error("Contraseña insegura, no puede iniciar con asdf")),
                Result.FailIf(pass.Length > _Max_Pass,new Error("Contraseña demasiado larga")),
                Result.FailIf(pass.Length < _Min_Pass,new Error($"La Contraseña debe tener mas de {_Min_Pass} caracteres"))
            );

        }
    }
}
