using Clientes.Common;

namespace Application.Clientes.GetById;

public record GetClienteByIdQuery(Guid Id) : IRequest<ErrorOr<ClienteResponse>>;