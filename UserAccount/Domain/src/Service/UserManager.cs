using System.Net.Http.Headers;
using Domain.src.Interface;
using Domain.src.ValueObject;
using FluentResults;
using Domain.src.DomainError;
using Domain.src.Entity;

namespace Domain.src.Service
{
    public class UserManager
    {
        private readonly IUserReadRepository _UserRepo;

        public UserManager(IUserReadRepository repo){
            _UserRepo = repo;
        }


        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Result<User>> CreateUser(Username username, Email email, string password){
            // verificamos que el email no haya sido registrado
            var emailExists = await _UserRepo.GetUserByEmail(email);
                if(emailExists != null)
                    return Result.Fail(new UserAlreadyExists(emailExists.Email.Value));
            // Verificamos que el nombre de usuario no haya sido registrado
            var usernameExists = await _UserRepo.GetUserByUsername(username); 
                if(usernameExists != null)
                    return Result.Fail(new UserAlreadyExists(usernameExists.Username.Value));
            // Verificamos que no existan errores de valdiacion
            var newUser = User.Create(username,email,password);
                if(newUser.IsFailed){
                    return Result.Fail(new Error(newUser.Errors[0].Message));
                }
            
            return Result.Ok<User>(newUser.Value);
        }

        public async Task<Result<User>> ChangeUsername(User user, Username username){
                // Verificamos que no exista el nombre de usuario
                var usernameExists = await _UserRepo.GetUserByUsername(username);
                    if(usernameExists != null)
                        return Result.Fail(new UserAlreadyExists(usernameExists.Username.Value));
                // Cambiamos el nombre de usuario
                user.ChangeUsername(username);
            return Result.Ok<User>(user);
        }

        public async Task<Result> ChangeEmail(User user, Email email){
                // verificamos que no exista el email
                var emailExists = await _UserRepo.GetUserByEmail(email);
                    if(emailExists != null)
                        return Result.Fail(new UserAlreadyExists(emailExists.Email.Value));
                // Cambiamos email
                user.ChangeEmail(email);
            return Result.Ok();
        }

        public async Task<Result> ChangePhone(User user, Phone phone){
                // Verificamos que no existat el numero de telefono en otro usuario
                var phoneExists = await _UserRepo.GetUserByPhone(phone);
                    if(phoneExists != null)
                        return Result.Fail(new UserAlreadyExists(phoneExists.Phone!.PhoneNumber.ToString()));
                // Cambaimos el nuemero de telefono
                user.ChangePhone(phone);
                return Result.Ok();
        }

    }
}