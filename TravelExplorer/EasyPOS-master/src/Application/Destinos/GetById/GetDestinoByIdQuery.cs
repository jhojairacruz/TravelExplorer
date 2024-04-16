using Destinos.Common;

namespace Application.Destinos.GetById;

public record GetDestinoByIdQuery(Guid Id) : IRequest<ErrorOr<DestinoResponse>>;