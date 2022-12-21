using Domain.src.Enum;
using Domain.src.Error;
using Domain.src.Event;
using Domain.src.ValueObject;
using Shared.src.Abstractions;
using Shared.src.Error;

namespace Domain.src.Entity
{
    public class Account:AggregateRoot 
    {
        public Username Username {get;private set;}
        public Email Email {get;private set;}
        public AccountStatus Status {get; private set;}
        public Password Password {get;private set;}
        public bool IsNew {get; private set;}
        public bool EmailVerified {get;private set;}
        public bool PhoneVerified {get;private set;}
        public Phone? Phone {get;private set;}

         private Account(Username username,Email email, Password password){
            Username = username;
            Email = email;
            Password = password;
            Status = AccountStatus.Active;
            IsNew = true;
            EmailVerified = false;
            PhoneVerified = false;
        }

         public static Result<Account> Create(Username username, Email email, string password)
        { 
            var validPass = ValidPasswordData(username,email,password);
            if (validPass.IsFailure)
                return Result.Fail<Account>(new ValidationError(validPass.Error.Message));
            var newPass = Password.Create(password);
            if (newPass.IsFailure)
                return Result.Fail<Account>(new ValidationError(newPass.Error.Message));
            var newAccount = new Account(username,email,newPass.Value);
            newAccount.RaiseDomainEvent(new AccountCreated());
            return Result.Ok<Account>(newAccount);
        }

             /// <summary>
        /// Cambia el nombre de usuario
        /// </summary>
        /// <param name="username"></param>
        public void ChangeUsername(Username username){
            Username = username;
            TimeStamps = TimeStamps.Updated();
        }

        /// <summary>
        /// Cambia el email
        /// </summary>
        /// <param name="email"></param>
        public void ChangeEmail(Email email){
            Email = email;
            UnverifyEmail();
            TimeStamps = TimeStamps.Updated();
        }

        /// <summary>
        /// Cambia el numero de telefono
        /// </summary>
        /// <param name="phone"></param>
        public void ChangePhone(Phone phone){
            Phone = phone;
            UnverifyPhone();
            TimeStamps = TimeStamps.Updated();
        }

        /// <summary>
        /// Cambia la contrasenia
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public Result ChangePassword(string password){
            var phone = false;
            if(Phone != null){
                phone = password.Contains(char.Parse(Phone.PhoneNumber.ToString()));
            }
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
            TimeStamps = TimeStamps.Updated();
                return Result.Ok();
        }


        /// <summary>
        /// Marca al usuario como no nuevo
        /// </summary>
        public void IsNotNew(){
            IsNew = false;
            TimeStamps = TimeStamps.Updated();
        }

        /// <summary>
        /// Verifica el email
        /// </summary>
        public void VerifyEmail(){
            EmailVerified = true;
            TimeStamps = TimeStamps.Updated();
        }

        /// <summary>
        /// Desverifica el email
        /// </summary>
        private void  UnverifyEmail(){
            EmailVerified = false;
            TimeStamps = TimeStamps.Updated();
        }

        /// <summary>
        /// Verifica el telefono
        /// </summary>
        public void VerifyPhone(){
            PhoneVerified = true;
            TimeStamps = TimeStamps.Updated();
        }

        /// <summary>
        /// Desverifica el telefono
        /// </summary>
        private void  UnverifyPhone(){
            PhoneVerified = false;
            TimeStamps = TimeStamps.Updated();
        }  
        



        // ============================ VALIDACIONES ================================================================ //
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