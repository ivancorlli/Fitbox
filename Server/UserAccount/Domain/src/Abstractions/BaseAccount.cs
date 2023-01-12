using Domain.src.Enum;
using Domain.src.Error;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Abstractions;
using Shared.src.Error;

namespace Domain.src.Abstractions;

public abstract class BaseAccount : AggregateRoot, IAccount
{
    public Username Username { get; protected set; }
    public Email Email { get; protected set; }
    public AccountStatus Status { get; protected set; }
    public Password Password { get; protected set; }
    public bool IsNew { get; protected set; }
    public bool EmailVerified { get; protected set; }
    public bool PhoneVerified {get;private set;}
    public Phone? Phone {get;private set;}

    protected BaseAccount(Username username, Email email, Password password)
    {
        Username = username;
        Email = email;
        Password = password;
        Status = AccountStatus.Active;
        IsNew = true;
        EmailVerified = false;
    }

    /// <summary>
        /// Cambia el nombre de usuario
        /// </summary>
        /// <param name="username"></param>
        internal void ChangeUsername(Username username){
            Username = username;
            EntityUpdated();
        }

        /// <summary>
        /// Cambia el email
        /// </summary>
        /// <param name="email"></param>
        internal void ChangeEmail(Email email){
            Email = email;
            UnverifyEmail();
            EntityUpdated();
        }

        /// <summary>
        /// Cambia la contrasenia
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public Result ChangePassword(string password){
            var validPass = ValidPasswordData(Username,Email,password);
            if(validPass.IsFailure)
                return Result.Fail(new ValidationError(validPass.Error.Message));
            var newPass = Password.Create(password);
            if(newPass.IsFailure)
                return Result.Fail(new ValidationError(newPass.Error.Message));
            Password= newPass.Value;
            EntityUpdated();
                return Result.Ok();
        }


        /// <summary>
        /// Marca al usuario como no nuevo
        /// </summary>
        public void IsNotNew(){
            IsNew = false;
            EntityUpdated();
        }

        /// <summary>
        /// Verifica el email
        /// </summary>
        public void VerifyEmail(){
            EmailVerified = true;
            EntityUpdated();
        }

        /// <summary>
        /// Desverifica el email
        /// </summary>
        private void  UnverifyEmail(){
            EmailVerified = false;
            EntityUpdated();
        }

     /// <summary>
        /// Cambia el numero de telefono
        /// </summary>
        /// <param name="phone"></param>
        internal void ChangePhone(Phone phone){
            Phone = phone;
            UnverifyPhone();
            EntityUpdated();
        }

        /// <summary>
        /// Verifica el telefono
        /// </summary>
        public void VerifyPhone(){
            PhoneVerified = true;
            EntityUpdated();
        }

        /// <summary>
        /// Desverifica el telefono
        /// </summary>
        private void  UnverifyPhone(){
            PhoneVerified = false;
            EntityUpdated();
        }  

        // ============================ VALIDACIONES ================================================================ //
         protected static Result ValidPasswordData(Username username,Email email,string password){
            var userp = password.Contains(username.Value);
            var emailp = password.Contains(email.Value);
            if(userp)
                return Result.Fail(new ValidationError("La contraseña no puede contener tu nombre de usuario"));
            if(emailp)
                return Result.Fail(new ValidationError("La contraseña no puede contener tu email")); 
            return Result.Ok();
        }

}