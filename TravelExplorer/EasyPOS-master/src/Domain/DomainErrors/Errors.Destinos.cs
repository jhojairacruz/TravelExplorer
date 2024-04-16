using ErrorOr;

namespace Domain.DomainErrors
{
    public static partial class Errors
    {
        public static class Destino
        {
            public static Error NombreVacio =>
                Error.Validation("Destino.Nombre", "El nombre del destino no puede estar vacío.");

            public static Error DescripcionVacia =>
                Error.Validation("Destino.Descripcion", "La descripción del destino no puede estar vacía.");

            public static Error UbicacionInvalida =>
                Error.Validation("Destino.Ubicacion", "La ubicación del destino no es válida.");
        }
    }
}
