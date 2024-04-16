namespace Destinos.Common
{
    public record DestinoResponse(
        Guid Id,
        string Nombre,
        string Descripcion,
        UbicacionResponse Ubicacion,
        bool Activo);

    public record UbicacionResponse(
        string Pais,
        string Estado,
        string CodigoPostal);
}
