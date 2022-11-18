using System.Runtime.CompilerServices;
using Domain.src.DomainError;
using Domain.src.Enum;
using Domain.src.ValueObject;
using FluentResults;


[assembly:InternalsVisibleTo("Tests")]
namespace Domain.src.Entity
{

    public class User
    {   
        private static int _Min_Pass = 7;
        private static int _Max_Pass = 25;


        public Guid Id {get;}
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
        public MedicalInfo? Medical {get;private set;}


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

        internal static Result<User> Create(Username username, Email email, string password){
            var validPass = ValidatePassword(password);
            var userp = password.Contains(username.Value);
            var emailp = password.Contains(email.Value);
            if(userp)
                return Result.Fail(new Error("La contraseña no puede contener tu nombre de usuario"));
            if(emailp)
                return Result.Fail(new Error("La contraseña no puede contener tu email"));
            if(validPass.IsSuccess){
                return Result.Ok<User>(new User(username,email,EncryptPassword(password)));
            }else {
                return Result.Fail(new Error(validPass.Errors[0].Message));
            }
        }

        // ================================== ACCOUNT METHODS ========================================= //

        /// <summary>
        /// Cambia el email
        /// </summary>
        /// <param name="username"></param>
        internal void ChangeUsername(Username username){
            Username = username;
        }

        /// <summary>
        /// Cambia el email
        /// </summary>
        /// <param name="email"></param>
        internal void ChangeEmail(Email email){
            Email =email;
            UnVerifyEmail();
        }

        /// <summary>
        /// Cambia la contrasenia
        /// </summary>
        /// <param name="pass">Nueva contrasenia</param>
        /// <returns></returns>
        internal Result ChangePassword(string pass){
            var username = pass.Contains(Username.Value);
            var email = pass.Contains(Email.Value);
            var name = false;
            var surname = false;
            var phone = false;
            if(Name  != null){
                name = pass.Contains(char.Parse(Name.FirstName));
                surname = pass.Contains(char.Parse(Name.LastName));
            }
            if(Phone != null){
                phone = pass.Contains(char.Parse(Phone.PhoneNumber.ToString()));
            }
            if(username)
                return Result.Fail(new Error("La contraseña no puede contener tu nombre de usuario"));
            if(email)
                return Result.Fail(new Error("La contraseña no puede contener tu email"));
            if(name)
                return Result.Fail(new Error("La contraseña no puede contener tu nombre"));
            if(surname)
                return Result.Fail(new Error("La contraseña no puede contener tu apellid"));
            if(phone){
                return Result.Fail(new Error("La contrasña no puede contener tu numero de telefono"));
            }
            Password = EncryptPassword(pass);
            return Result.Ok();
        }

        /// <summary>
        /// Suspende la cuenta 
        /// </summary>
        internal Result SuspendAccount(){
            if(Status == AccountStatus.Deleted)
                return Result.Fail(new Error("No puedes suspender una cuenta eliminada"));
            if(Status == AccountStatus.Suspended)
                return Result.Ok();
            Status = AccountStatus.Suspended;
            return Result.Ok();
        }

        /// <summary>
        /// Desactiva la cuenta
        /// </summary>
        public Result InactivateAccount(){
            if(Status == AccountStatus.Deleted)
                return Result.Fail(new Error("No puedes desactivar una cuenta eliminada"));
            if(Status == AccountStatus.Suspended)
                return Result.Fail(new Error("No puedes desactivar una cuenta suspendida"));
            if(Status == AccountStatus.Inactive)
                return Result.Ok();
            Status = AccountStatus.Inactive;
            return Result.Ok();
        }

        /// <summary>
        /// Reactiva la cuenta
        /// </summary>
        public Result ReactivateAccount(){
            if(Status == AccountStatus.Deleted){
                return Result.Fail(new Error("No puedes reactivar una cuenta eliminada"));
            }
            Status = AccountStatus.Active;
            return Result.Ok();
        }

        /// <summary>
        /// Elimina la cuenta
        /// </summary>
        /// <returns></returns>
        internal Result DeleteAccount(){
            if(Status == AccountStatus.Deleted){
                return Result.Fail(new Error("No puedes eliminar esta cuenta por que ya ha sido eliminada"));
            }

            if(Status == AccountStatus.Suspended){
                return Result.Fail(new Error("No puedes eliminar una cuenta suspendida"));
            }

            Status = AccountStatus.Deleted;
            return Result.Ok();
        }
        
        // ================================================================================================================ //      
    

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
            var isLegal = (DateTime.UtcNow - birth).TotalDays /365;

            if(birth > DateTime.Now){
                return Result.Fail(new Error("La fecha de nacimiento no puede ser mayor a la fecha de hoy"));

            }
            if(isLegal < 13){
                return Result.Fail(new Error("No puedes continuar, tienes menos de 13 años"));
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
        public void CreateEmergencyContact(FullName name, RelationShip relationShip, Phone phone){
            EmergencyContact = new EmergencyContact(name,relationShip,phone);
        }

        /// <summary>
        /// Elimina el contacto de emergencia
        /// </summary>
        public void DeleteEmergencyContact(){
            EmergencyContact = null;
        }

        /// <summary>
        /// Cambia el numero de telefono
        /// </summary>
        /// <param name="phone"></param>
        internal void ChangePhone(Phone phone){
            Phone = phone;
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

        /// <summary>
        /// Verifica el email
        /// </summary>
        public void VerifyEmail(){
            EmailVerified = true;
        }

        /// <summary>
        /// Invalida el email
        /// </summary>
        private void UnVerifyEmail(){
            EmailVerified = false;
        }
        
        /// <summary>
        /// El usuario deja de ser nuevo
        /// </summary>
        /// <returns></returns>
        public void IsNotNew(){
            IsNew= false;
        }


        /// <summary>
        /// Verifica la contrasenia ingresada
        /// </summary>
        /// <param name="inputPassword"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public Result<bool> VerifyPassword(string inputPassword,string hash){
            var verified = BCrypt.Net.BCrypt.Verify(inputPassword,hash);

            if(!verified)
                return Result.Fail(new IncorrectPassword());

            return Result.Ok(verified);
        }
        // ---------------------------------------------- Validation ------------------------------------------------------------ //
        
        /// <summary>
        /// Valida la contrasenia
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        private static Result ValidatePassword(string pass){
            return Result.Merge(
                Result.FailIf(pass.StartsWith("1234"),new Error("Contraseña insegura, no puede iniciar con 1234")),
                Result.FailIf(pass.StartsWith("qwer"),new Error("Contraseña insegura, no puede iniciar con qwer")),
                Result.FailIf(pass.StartsWith("asdf"), new Error("Contraseña insegura, no puede iniciar con asdf")),
                Result.FailIf(pass.Length > _Max_Pass,new Error("Contraseña demasiado larga")),
                Result.FailIf(pass.Length < _Min_Pass,new Error($"La Contraseña debe tener mas de {_Min_Pass} caracteres"))
            );

        }
        /// <summary>
        /// Encirpta la contraseña
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string EncryptPassword(string password){
            var salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            var passEncrypted = BCrypt.Net.BCrypt.HashPassword(password,salt);
            return passEncrypted;
        }
    }
}
