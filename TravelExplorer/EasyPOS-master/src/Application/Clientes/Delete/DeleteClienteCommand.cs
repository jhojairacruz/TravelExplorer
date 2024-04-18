namespace Application.Clientes.Delete;

public record DeleteClienteCommand(Guid Id) : IRequest<ErrorOr<Unit>>;