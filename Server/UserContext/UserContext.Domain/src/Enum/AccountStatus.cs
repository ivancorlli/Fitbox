namespace UserContext.Domain.src.Enum
{
    public enum AccountStatus
    {
        // Significa que el usuario esta usando el sistema
        Active,
        // Significa que el usuario lleva un tiempo sin usar el sistema
        Inactive,
        // Significa que el usuario no puede acceder al sistema por faltar alguna norma
        Suspended,
        // Siginifica que el usuario elimino su cuenta
        Deleted
    }
}