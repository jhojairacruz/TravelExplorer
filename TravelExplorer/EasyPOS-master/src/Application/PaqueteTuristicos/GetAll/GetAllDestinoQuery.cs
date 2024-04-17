using ErrorOr;
using MediatR;
using PaqueteTuristicos.Common;

namespace Application.PaqueteTuristicos.GetAll;

public record GetAllPaqueteTuristicosQuery() : IRequest<ErrorOr<IReadOnlyList<PaqueteTuristicoResponse>>>;