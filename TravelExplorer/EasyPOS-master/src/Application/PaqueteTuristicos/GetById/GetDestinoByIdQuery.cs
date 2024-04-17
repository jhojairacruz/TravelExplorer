using ErrorOr;
using MediatR;
using PaqueteTuristicos.Common;

namespace Application.PaqueteTuristicos.GetById;

public record GetPaqueteTuristicoByIdQuery(Guid Id) : IRequest<ErrorOr<PaqueteTuristicoResponse>>;