using Domain.src.Aggregate.UserAggregate;
using Domain.src.Enum;
using Domain.src.Interface;
using Domain.src.ValueObject;

namespace Domain.src.Service
{
    public class UserManager
    {
        private IUserRepository _UserRepository ;


        public UserManager(IUserRepository userRepository){
            _UserRepository = userRepository;
        }


        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Usuario Creado</returns>
        public User CreateUser(Email email,Username username, string password){
            // Buscamos que el nombre de usuario y el email no hayan registrados
            // - Si ya han sido utilizados arrojamos un error

            // Creamos un nuevo usuario
            var user = new User(email,username,password);

            // Hasheamos la contrasenia 

            // Retornamos el nuevo usuario
            return user;
        }

        /// <summary>
        /// Cambia el email 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newEmail"></param>
        public void ChangeEmail(User user, Email newEmail){
            // Buscamos si el email no ha sido utilizado por otro usuario
            // - si ya ha sido utilizado arrojamo un error

            user.ChangeEmail(newEmail);
        }

        /// <summary>
        /// Cambia el nombre de usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newUsername"></param>
        public void ChangeUsername(User user, Username newUsername){
            // Buscamos si el nombre de usuario no ha sido utilizado por otro usuario
            // - si ya ha sido utilizado arrojamo un error

            user.ChangeUsername(newUsername);
        }

        /// <summary>
        /// Crea contacto de emergencia
        /// </summary>
        /// <param name="user"></param>
        /// <param name="name"></param>
        /// <param name="relationship"></param>
        /// <param name="phone"></param>
        public void CreateEmergencyContact(User user,FullName name, Relationship relationship, PhoneNumber phone){
            // MAXIMO 1 CONTACTO POR USUARIO
            // Buscamos si el usuario ya tiene un contacto de emergencia creado.
            // - Si ya posee arrojamos error
            user.CreateEmergencyContact(name,relationship,phone);
        }



        /// <summary>
        /// Encripta la contreña
        /// </summary>
        /// <param name="user"></param>
        private void CryptPassword(User user){
            // Encriptamos contrasenia
            var passwordHashed = "Random";

            // Asignamos contrasenia encriptada al usuario

            user.ChangePassword(passwordHashed);
        }

        /// <summary>
        /// Desencripta la contraseña
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        private void DecryptPassword(User user, string password){
            // Comparamos las contrasenias
            // Si las contrasenias no coinciden arrojamos error de contrasenia incorrecta

        }

    
    
    
    
    
    
    }

}