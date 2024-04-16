namespace Application.Destinos.Create
{
    public record CreateDestinoCommand(
        string Nombre,
        string Descripcion,
        string Pais,
        string Estado,
        string CodigoPostal): IRequest<ErrorOr<Guid>>;

}