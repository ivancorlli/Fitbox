namespace UserContext.Domain.src.Enum
{
    public enum AccountStatus
    {
        NotSelected=0,
        // Significa que el usuario esta usando el sistema
        Active=1,
        // Significa que el usuario lleva un tiempo sin usar el sistema
        Inactive=2,
        // Significa que el usuario no puede acceder al sistema por faltar alguna norma
        Suspended = 3,
        // Siginifica que el usuario elimino su cuenta
        Deleted = 4
    }
}