using SharedKernell.src.Entity;
using SharedKernell.src.Result;
using UserContext.Domain.src.Entity;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.Error;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Abstractions;

public abstract class BaseAccount : AggregateRoot, IAccount
{
    protected BaseAccount() { }
    public Username Username { get; protected set; } = default!;
    public Email Email { get; protected set; } = default!;
    public AccountStatus Status { get; protected set; }
    public Password Password { get; protected set; } = default!;
    public bool IsNew { get; protected set; }
    public bool EmailVerified { get; protected set; }
    public bool PhoneVerified { get; private set; }
    public Phone? Phone { get; private set; }
    public Person? Profile { get; protected set; }

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
    internal void ChangeUsername(Username username)
    {
        Username = username;
        this.EntityUpdated();
    }

    /// <summary>
    /// Cambia el email
    /// </summary>
    /// <param name="email"></param>
    internal void ChangeEmail(Email email)
    {
        Email = email;
        UnverifyEmail();
        this.EntityUpdated();
    }

    /// <summary>
    /// Cambia la contrasenia
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public Result ChangePassword(string password)
    {
        var validPass = ValidPasswordData(Username, Email, password);
        if (validPass.IsFailure)
            return Result.Fail(new ValidationError(validPass.Error.Message));
        var newPass = Password.Create(password);
        if (newPass.IsFailure)
            return Result.Fail(new ValidationError(newPass.Error.Message));
        Password = newPass.Value;
        this.EntityUpdated();
        return Result.Ok();
    }


    /// <summary>
    /// Marca al usuario como no nuevo
    /// </summary>
    public void IsNotNew()
    {
        IsNew = false;
        this.EntityUpdated();
    }

    /// <summary>
    /// Verifica el email
    /// </summary>
    public void VerifyEmail()
    {
        EmailVerified = true;
        this.EntityUpdated();
    }

    /// <summary>
    /// Desverifica el email
    /// </summary>
    private void UnverifyEmail()
    {
        EmailVerified = false;
        this.EntityUpdated();
    }

    /// <summary>
    /// Cambia el numero de telefono
    /// </summary>
    /// <param name="phone"></param>
    internal void ChangePhone(Phone phone)
    {
        Phone = phone;
        UnverifyPhone();
        this.EntityUpdated();
    }

    /// <summary>
    /// Verifica el telefono
    /// </summary>
    public void VerifyPhone()
    {
        PhoneVerified = true;
        this.EntityUpdated();
    }

    /// <summary>
    /// Desverifica el telefono
    /// </summary>
    private void UnverifyPhone()
    {
        PhoneVerified = false;
        this.EntityUpdated();
    }

    /// <summary>
    /// Crea un nuevo perfil
    /// </summary>
    /// <param name="name"></param>
    /// <param name="gender"></param>
    /// <param name="birth"></param>
    /// <returns></returns>
    public Result AddProfile(PersonName name, Gender gender, DateTime birth)
    {
        if (Profile != null)
        {
            var newPerson = Person.Create(name,gender,birth);
            if(newPerson.IsFailure) return Result.Fail(newPerson.Error);
            Profile = newPerson.Value;
            this.EntityUpdated();
            return Result.Ok();
        }else
        {
            return Result.Fail(new ProfileExists(Username.Value));
        }
    }

    // ============================ VALIDACIONES ================================================================ //
    protected static Result ValidPasswordData(Username username, Email email, string password)
    {
        var userp = password.Contains(username.Value);
        var emailp = password.Contains(email.Value);
        if (userp)
            return Result.Fail(new ValidationError("La contraseña no puede contener tu nombre de usuario"));
        if (emailp)
            return Result.Fail(new ValidationError("La contraseña no puede contener tu email"));
        return Result.Ok();
    }

}