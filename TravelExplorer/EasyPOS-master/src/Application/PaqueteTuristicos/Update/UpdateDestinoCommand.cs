using Domain.Primitives;
using ErrorOr;
using MediatR;
namespace Application.PaqueteTuristicos.Update;

public record UpdatePaqueteTuristicoCommand(
    Guid Id,
    string Nombre,
    string Descripcion,
    string FechaInicio, 
    string FechaFin, 
    decimal Precio,
    bool Activo) : IRequest<ErrorOr<Unit>>;
