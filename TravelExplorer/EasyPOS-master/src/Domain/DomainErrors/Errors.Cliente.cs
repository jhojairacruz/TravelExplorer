using ErrorOr;

namespace Domain.DomainErrors;

public static partial class Errors
{
    public static class Cliente
    {
        public static Error TelefonoWithBadFormat => 
            Error.Validation("Cliente.Telefono", "Telefono no es un formato valido");

        public static Error DireccionWithBadFormat => 
            Error.Validation("Cliente.Direccion", "La Direccion no es valida");
    }
}