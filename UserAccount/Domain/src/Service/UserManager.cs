using Domain.src.Aggregate.UserAggregate;
using Domain.src.Entity;
using Domain.src.Enum;
using Domain.src.Interface;
using Domain.src.Specification;
using Domain.src.ValueObject;
using Domain.src.DomainError;
using FluentResults;

namespace Domain.src.Service
{
    public class UserManager
    {
        private IUserRepository _User ;


        public UserManager(IUserRepository user){
            _User = user;
        }


        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Usuario Creado</returns>
        public async Task<Result<User>> CreateUser(Email email,Username username, string password){
            // Buscamos que el nombre de usuario y el email no hayan registrados
            var userExists = await this._User.Find(new UserByEmailOrUsername(email,username)); 

            if(userExists.Count() > 0){
                var lUser = userExists[0];

                if(lUser.Email.Value == email.Value)
                    return Result.Fail(new EmailAlredyUsed(email));
                if(lUser.Username.Value == username.Value)
                    return Result.Fail(new UsernameAlreadyUsed(username));
            }

            // Creamos un nuevo usuario
            User user = new User(email,username,password);

            // Hasheamos la contrasenia 
            this.CryptPassword(user);

            // Retornamos el nuevo usuario
            return Result.Ok<User>(user);
        }

        /// <summary>
        /// Cambia el email 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newEmail"></param>
        public async Task<Result> ChangeEmail(User user, Email newEmail){
            // Buscamos si el email no ha sido utilizado por otro usuario
            var emailExists = await this._User.Find();

            if(emailExists.Count() > 0){
                return Result.Fail(new EmailAlredyUsed(newEmail));
            }

            user.ChangeEmail(newEmail);
            return Result.Ok();
        }

        /// <summary>
        /// Cambia el nombre de usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newUsername"></param>
        public async Task<Result> ChangeUsername(User user, Username newUsername){
            // Buscamos si el nombre de usuario no ha sido utilizado por otro usuario
            var usernameExists = await this._User.Find();

            if(usernameExists.Count() > 0){
                return Result.Fail(new UsernameAlreadyUsed(newUsername));
            }

            user.ChangeUsername(newUsername);
            return Result.Ok();
        }

        /// <summary>
        /// Crea contacto de emergencia
        /// </summary>
        /// <param name="user"></param>
        /// <param name="name"></param>
        /// <param name="relationship"></param>
        /// <param name="phone"></param>
        public async Task CreateEmergencyContact(User user,FullName name, Relationship relationship, PhoneNumber phone){
            // MAXIMO 1 CONTACTO POR USUARIO
            // Buscamos si el usuario ya tiene un contacto de emergencia creado.
            var contactExists = await this._User.Find();

            if(contactExists.Count() > 0){
            // - Si ya posee arrojamos error
            }

            user.CreateEmergencyContact(new EmergencyContact(name,relationship,phone));
        }



        /// <summary>
        /// Encripta la contreña
        /// </summary>
        /// <param name="user"></param>
        private void CryptPassword(User user){
            // Encriptamos contrasenia
            string passwordHashed = BCrypt.Net.BCrypt.HashPassword(user.Password);

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
            bool result = BCrypt.Net.BCrypt.Verify(password, user.Password);

            // Si las contrasenias no coinciden arrojamos error de contrasenia incorrecta
            if(!result){
            }

        }

    
    
    
    
    
    
    }

}