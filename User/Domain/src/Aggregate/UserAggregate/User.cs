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
        public string? FrontImage {get; private set;}
        public string? ProfileImage {get; private set;}
        public MedicalRecord? MedicalRecord {get; private set;}

        // Other Properties
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
            /// Verifica la cuenta 
            /// </summary>
            public void VerifyAccount(){
                EmailVerified = true;
            }

            /// <summary>
            /// El usuario no es nuevo
            /// </summary>
            public void NotIsNew(){
                IsNew = false;
            }

            /// <summary>
            /// Actualiza el estado 
            /// </summary>
            /// <param name="status"></param>
            public void UpdateStatus(UserStatus status){
                if(string.IsNullOrEmpty(status.ToString())){
                Status = status;
                }else{
                    // Error: estado necesario
                }
            }

            /// <summary>
            /// Actualiza el nombre
            /// </summary>
            /// <param name="name"></param>
            public void UpdateName(FullName name){
                Name = name;
            }

            /// <summary>
            /// Actualiza el genero
            /// </summary>
            /// <param name="gender"></param>
            public void UpdateGender(Gender gender){
                Gender = gender;
            }

            /// <summary>
            /// Actualiza fecha de nacimiento
            /// </summary>
            /// <param name="birth"></param>
            public void UpdateBirth(DateTime birth){
                Birth = birth;
            }


        // ------------------------------------------ Other Methods ----------------------------------------- //

        /// <summary>
        /// Crea un contacto de emergencia
        /// </summary>
        /// <param name="name"></param>
        /// <param name="relationship"></param>
        /// <param name="phone"></param>
        public void CreateEmergencyContact(FullName name,Relationship relationship,PhoneNumber phone){
            EmergencyContact newContact = new (Id,name,relationship,phone);
            this.EmergencyContact = newContact;
        }

        /// <summary>
        /// Actualiza el contacto de emergencia
        /// </summary>
        /// <param name="name"></param>
        /// <param name="relationship"></param>
        /// <param name="phone"></param>
        public void UpdateEmergencyContact(FullName name, Relationship relationship, PhoneNumber phone){
            // Si existe un contacto de emergencia lo actualizamos
            if( EmergencyContact != null){
                EmergencyContact.Update(name, relationship, phone);
            }
        }

        /// <summary>
        /// Cambia el nombre del contacto de emergencia
        /// </summary>
        /// <param name="name"></param>
        public void UpdateEmergencyContact(FullName name){
            // Si existe un contacto de emergencia lo actualizamos
            if( EmergencyContact != null){
                EmergencyContact.ChangeName(name);
            }
        }

        /// <summary>
        /// Cambia la relacion del contacto de emergencia
        /// </summary>
        /// <param name="relationship"></param>
        public void UpdateEmergencyContact(Relationship relationship){
            // Si existe un contacto de emergencia lo actualizamos
            if( EmergencyContact != null){
                EmergencyContact.ChangeRelationship(relationship);
            }
        }

        /// <summary>
        /// Cambia el telefono del contacto de emergencia
        /// </summary>
        /// <param name="phone"></param>
        public void UpdateEmergencyContact(PhoneNumber phone){
            // Si existe un contacto de emergencia lo actualizamos
            if( EmergencyContact != null){
                EmergencyContact.ChangePhone(phone);
            }
        }
        
    }
}