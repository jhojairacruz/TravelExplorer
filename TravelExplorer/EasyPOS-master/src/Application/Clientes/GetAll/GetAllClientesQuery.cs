using Clientes.Common;

namespace Application.Clientes.GetAll;

public record GetAllClientesQuery() : IRequest<ErrorOr<IReadOnlyList<ClienteResponse>>>;