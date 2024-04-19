using ErrorOr;
using MediatR;

namespace Application.PaqueteDestinos.Create
{
    public record CreatePaquetesDestinosCommand(
        string PaqueteTuristicoId,
        string DestinoId): IRequest<ErrorOr<Guid>>;

}