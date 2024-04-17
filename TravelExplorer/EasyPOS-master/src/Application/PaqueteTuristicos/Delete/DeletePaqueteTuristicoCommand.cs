using ErrorOr;
using MediatR;

namespace Application.PaqueteTuristicos.Delete;

public record DeletePaqueteTuristicosCommand(Guid Id) : IRequest<ErrorOr<Unit>>;