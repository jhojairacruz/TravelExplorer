namespace PaqueteTuristicos.Common
{
    public record PaqueteTuristicoResponse(
        Guid Id,
        string Nombre, 
        string Descripcion, 
        string FechaInicio, 
        string FechaFin, 
        decimal Precio, 
        bool Activo);

}
