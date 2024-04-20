using PaqueteDestinos.Common;

namespace Application.PaqueteDestinos.GetAll;

public record GetAllPaqueteDestinosQuery() : IRequest<ErrorOr<IReadOnlyList<PaquetesDestinoResponse>>>;