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
        public Username Username {get;private set;}
        public Email Email {get;private set;}
        public AccountStatus Status {get; private set;}
        public Password Password {get;private set;}
        public bool IsNew {get; private set;}
        public bool EmailVerified {get;private set;}
        public bool PhoneVerified {get;private set;}
        public Phone? Phone {get;private set;}
        public PersonName? Name {get;private set;}
        public Gender? Gender {get;private set;}
        public DateTime? Birth {get;private set;}
        public Bio? Biography {get;private set;}
        public Address? Address {get;private set;}
        public EmergencyContact? EmergencyContact {get;private set;}
        public MedicalInfo? Medical {get;private set;}


        private User(Username username,Email email, Password password){
            Username = username;
            Email = email;
            Password = password;
            Status = AccountStatus.Active;
            IsNew = true;
            EmailVerified = false;
            PhoneVerified = false;
        }

        public static Result<User> Create(Username username, Email email, string password)
        { 
            var validPass = ValidPasswordData(username,email,password);
            if (validPass.IsFailure)
                return Result.Fail<User>(new ValidationError(validPass.Error.Message));
            var newPass = Password.Create(password);
            if (newPass.IsFailure)
                return Result.Fail<User>(new ValidationError(newPass.Error.Message));
            return Result.Ok<User>(new User(username,email,newPass.Value));
        }
        // ================================== ACCOUNT METHODS ========================================= //

        /// <summary>
        /// Cambia el nombre de usuario
        /// </summary>
        /// <param name="username"></param>
        public void ChangeUsername(Username username){
            Username = username;
        }

        /// <summary>
        /// Cambia el email
        /// </summary>
        /// <param name="email"></param>
        public void ChangeEmail(Email email){
            Email = email;
            UnverifyEmail();
        }

        /// <summary>
        /// Cambia el numero de telefono
        /// </summary>
        /// <param name="phone"></param>
        public void ChangePhone(Phone phone){
            Phone = phone;
            UnverifyPhone();
        }

        /// <summary>
        /// Cambia la contrasenia
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public Result ChangePassword(string password){
            var name = false;
            var surname = false;
            var phone = false;
            if(Name  != null){
                name = password.Contains(char.Parse(Name.FirstName));
                surname = password.Contains(char.Parse(Name.LastName));
            }
            if(Phone != null){
                phone = password.Contains(char.Parse(Phone.PhoneNumber.ToString()));
            }
            if(name)
                return Result.Fail(new ValidationError("La contraseña no puede contener tu nombre"));
            if(surname)
                return Result.Fail(new ValidationError("La contraseña no puede contener tu apellido"));
            if(phone){
                return Result.Fail(new ValidationError("La contrasña no puede contener tu numero de telefono"));
            }
            var validPass = ValidPasswordData(Username,Email,password);
            if(validPass.IsFailure)
                return Result.Fail(new ValidationError(validPass.Error.Message));
            var newPass = Password.Create(password);
            if(newPass.IsFailure)
                return Result.Fail(new ValidationError(newPass.Error.Message));
            Password= newPass.Value;
                return Result.Ok();
        }


        /// <summary>
        /// Marca al usuario como no nuevo
        /// </summary>
        public void IsNotNew(){
            IsNew = false;
        }

        /// <summary>
        /// Verifica el email
        /// </summary>
        public void VerifyEmail(){
            EmailVerified = true;
        }

        /// <summary>
        /// Desverifica el email
        /// </summary>
        private void  UnverifyEmail(){
            EmailVerified = false;
        }

        /// <summary>
        /// Verifica el telefono
        /// </summary>
        public void VerifyPhone(){
            PhoneVerified = true;
        }

        /// <summary>
        /// Desverifica el telefono
        /// </summary>
        private void  UnverifyPhone(){
            PhoneVerified = false;
        }        
        
        // ================================== PROPERTIES  METHODS ========================================= //

        /// <summary>
        /// Cambia el nombre y apellido
        /// </summary>
        /// <param name="name"></param>
        public void ChangeName(PersonName name){
            Name = name;
        }

        /// <summary>
        /// Cambia el genero
        /// </summary>
        /// <param name="gender"></param>
        public void ChangeGender(Gender gender){
            Gender = gender;
        }

        /// <summary>
        /// Cambia la fecha de nacimiento
        /// </summary>
        /// <param name="birth"></param>
        /// <returns></returns>
        public Result ChangeBirth(DateTime birth){
            var isLegal = (DateTime.UtcNow - birth).TotalDays /365;

            if(birth > DateTime.Now){
                return Result.Fail(new ValidationError("La fecha de nacimiento no puede ser mayor a la fecha de hoy"));

            }
            if(isLegal < 13){
                return Result.Fail(new ValidationError("No puedes continuar, eres menor de 13 años"));
            }
            Birth = birth;
            return Result.Ok();
            
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
        public void CreateEmergencyContact(PersonName name, RelationShip relationShip, Phone phone){
            EmergencyContact = new EmergencyContact(name,relationShip,phone);
        }

        /// <summary>
        /// Elimina el contacto de emergencia
        /// </summary>
        public void DeleteEmergencyContact(){
            EmergencyContact = null;
        }

        /// <summary>
        /// Crea un registro de informacion medica
        /// </summary>
        /// <param name="medical"></param>
        public void CreateMedicalInfo(MedicalInfo medical){
            Medical = medical;
        }

        /// <summary>
        /// Elimina la informacion medica
        /// </summary>
        public void DeleteMedicalInfo(){
            Medical= null;
        }

        // ================================================================================================================ //      

        private static Result ValidPasswordData(Username username,Email email,string password){
            var userp = password.Contains(username.Value);
            var emailp = password.Contains(email.Value);
            if(userp)
                return Result.Fail(new ValidationError("La contraseña no puede contener tu nombre de usuario"));
            if(emailp)
                return Result.Fail(new ValidationError("La contraseña no puede contener tu email")); 
            return Result.Ok();
        }

    }
}
