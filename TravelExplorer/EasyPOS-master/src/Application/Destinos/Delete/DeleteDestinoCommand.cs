namespace Application.Destinos.Delete;

public record DeleteDestinosCommand(Guid Id) : IRequest<ErrorOr<Unit>>;