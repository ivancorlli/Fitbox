using Domain.src.Enum;
using Domain.src.Entity;
using Domain.src.ValueObject;

namespace Domain.src.Aggregate.UserAggregate
{
    public class User
    {

        public Guid Id {get; private set;}
        public Email Email {get; private set;}
        public Username Username {get; private set;}
        public string Password {get; private set;}
        public UserStatus Status {get;private set;}
        public bool EmailVerified {get; private set;}
        public bool IsNew {get; private set;}
        public FullName? Name {get; private set;}
        public Gender? Gender {get;private set;}
        public DateTime? Birth {get;private set;}
        public Biography? Biography {get; private set;}
        public Address? Address {get; private set;}
        public PhoneNumber? PhoneNumber {get; private set;}
        public bool? PhoneVerified {get; private set;}
        public Uri? FrontImage {get; private set;}
        public Uri? ProfileImage {get; private set;}
        public MedicalRecord? MedicalRecord {get; private set;}
        public EmergencyContact? EmergencyContact {get;private set;}

        /// <summary>
        /// Crea un nuevo usuario 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User(Email email, Username username, string password){
            Id = Guid.NewGuid();
            Email = email;
            Username = username;
            Password = password;
            Status = UserStatus.Active;
            EmailVerified = false;
            IsNew = true;
        }

        // ------------------------------------------ Own Methods ----------------------------------------- //

            /// <summary>
            /// Actualiza la cuenta 
            /// </summary>
            /// <param name="email"></param>
            /// <param name="username"></param>
            /// <param name="password"></param>
            public void UpdateAccount(Email email, Username username, string password){
                if(email != null && username != null && !string.IsNullOrEmpty(password)){
                Email = email;
                Username = username;
                Password = password;
                } else {
                    // Error: Email, username, password necesarios
                }
            }
            
            /// <summary>
            /// Cambia el email 
            /// </summary>
            /// <param name="email"></param>
            public void ChangeEmail(Email email){
                if(email != null){
                    Email = email;
                } else{
                    // Error : Email necesario
                }
            }

            /// <summary>
            /// Cambia el nombre de usuario
            /// </summary>
            /// <param name="username"></param>
            public void ChangeUsername(Username username){
                if(username!=null){
                Username = username;
                }else{
                    // Error : Nombre de usuario necesario
                }
            }

            /// <summary>
            /// Cambia la contraseña
            /// </summary>
            /// <param name="password"></param>
            public void ChangePassword(string password){
                if(!string.IsNullOrEmpty(password)){
                Password = password;
                }else{
                    // Erro: Contrasenia necesaria
                }
            }

            /// <summary>
            /// Verifica el email 
            /// </summary>
            public void VerifyEmail(){
                EmailVerified = true;
            }

            /// <summary>
            /// Desverifica/Desaprueba el email
            /// </summary>
            public void UnverifyEmail(){
                EmailVerified = false;
            }

            /// <summary>
            /// El usuario no es nuevo
            /// </summary>
            public void NotIsNew(){
                IsNew = false;
            }
            
            /// <summary>
            /// Suspende la cuenta
            /// </summary>
            public void SuspendAccount(){
                Status = UserStatus.Suspended;
            }

            /// <summary>
            /// Elimina la cuenta del usuario
            /// </summary>
            public void DeleteAccount(){
                Status = UserStatus.Deleted;
            }

            public void DisactiveAccount(){
                Status = UserStatus.Inactive;
            }
            
            /// <summary>
            /// Revisa si la cuenta esta inactiva
            /// </summary>
            /// <returns>True or False</returns>
            public bool IsInactive(){
                if (Status == UserStatus.Inactive){
                    return true;
                }else{
                    return false;
                }
            }

            /// <summary>
            /// Revisa si la cuenta esta suspendida
            /// </summary>
            /// <returns>True or False</returns>
            public bool IsSuspended(){
                if (Status == UserStatus.Suspended){
                    return true;
                }else{
                    return false;
                }
            }


            /// <summary>
            /// Actualiza el nombre
            /// </summary>
            /// <param name="name"></param>
            public void UpdateName(FullName name){
                if(name != null){

                Name = name;
                }else{

                }
            }

            /// <summary>
            /// Actualiza el genero
            /// </summary>
            /// <param name="gender"></param>
            public void UpdateGender(Gender gender){
                if(gender != null){

                Gender = gender;
                }else{

                }
            }

            /// <summary>
            /// Actualiza fecha de nacimiento
            /// </summary>
            /// <param name="birth"></param>
            public void UpdateBirth(DateTime birth){
                if(birth != null){

                Birth = birth;
                }else {

                }
            }

            /// <summary>
            /// Actualiza la biografia
            /// </summary>
            /// <param name="biography"></param>
            public void UpdateBiography(Biography biography){
                if(biography != null){
                    Biography = biography;
                }else {

                }
            }




        // ------------------------------------------ Other Methods ----------------------------------------- //

        /// <summary>
        /// Crea contacto de emergencia
        /// </summary>
        /// <param name="contact"></param>
        public void CreateEmergencyContact(EmergencyContact contact){
            EmergencyContact = contact;
        }

        /// <summary>
        /// Elimina el contacto de emergencia
        /// </summary>
        public void DeleteEmergencyContact(){
            EmergencyContact = null;
        }
       
        
    }
}
