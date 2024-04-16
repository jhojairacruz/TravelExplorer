using Domain.Primitives;
namespace Application.Destinos.Update;

public record UpdateDestinoCommand(
    Guid Id,
    string Nombre,
    string Descripcion,
    string Pais,
    string Estado,
    string CodigoPostal,
    bool Activo) : IRequest<ErrorOr<Unit>>;
