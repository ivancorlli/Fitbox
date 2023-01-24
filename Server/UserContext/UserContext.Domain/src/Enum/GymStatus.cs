namespace UserContext.Domain.src.Enum;

public enum GymStatus
{
    // El gimnasio esta usando el sistema
     Active,
    // El gimnasio no puede acceder al sistema por faltar alguna norma
    Suspended,
    // El gimnasio elimino su cuenta
    Deleted
}
