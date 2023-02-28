using SharedKernell.src.Entity;
using SharedKernell.src.Result;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.Error;
using UserContext.Domain.src.Interface.Entity;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Abstractions;

public abstract class IAccount :AggregateRoot, IBaseAccount
{
    public Email Email { get; protected set; } = default!;
    public AccountStatus Status { get; protected set; }
    public AccountType AccountType { get; protected set; }
    public bool IsNew { get; protected set; }
    public bool EmailVerified { get; protected set; }
    public bool PhoneVerified { get; protected set; }
    public List<Provider>? Provider { get;protected set; }
    public Username? Username { get; protected set; } 
    public Password? Password { get; protected set; } 
    public Phone? Phone { get; protected set; }

    protected IAccount() { }
    protected IAccount(Email email)
    {
        Email = email;
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
        var validPass = ValidPasswordData(Email, password);
        if (validPass.IsFailure)
            return Result.Fail(new ValidationError(validPass.Error.Message));
        if (Username!= null)
        {
            var userp = password.Contains(Username.Value);
            if (userp)
                return Result.Fail(new ValidationError("La contraseña no puede contener tu nombre de usuario"));
        }
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

    public void AddProvider(Provider provider)
    {
        if(Provider == null)
        {
            Provider = new List<Provider> { provider };
        }
        else
        {

            Provider.Add(provider);
        }

        this.EntityUpdated();
    }
    // ============================ VALIDACIONES ================================================================ //
    protected static Result ValidPasswordData(Email email, string password)
    {
        var emailp = password.Contains(email.Value);
        if (emailp)
            return Result.Fail(new ValidationError("La contraseña no puede contener tu email"));
        return Result.Ok();
    }
    protected static Result ValidPasswordData(Username username,Email email, string password)
    {
        var userp = password.Contains(username.Value);
        if (userp)
            return Result.Fail(new ValidationError("La contraseña no puede contener tu nombre de usuario"));
        var emailp = password.Contains(email.Value);
        if (emailp)
            return Result.Fail(new ValidationError("La contraseña no puede contener tu email"));
        return Result.Ok();
    }

}