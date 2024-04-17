using ErrorOr;
using MediatR;

namespace Application.PaqueteTuristicos.Create
{
    public record CreatePaqueteTuristicoCommand(
        string Nombre,
        string Descripcion,
        string FechaInicio, 
        string FechaFin, 
        decimal Precio): IRequest<ErrorOr<Guid>>;

}