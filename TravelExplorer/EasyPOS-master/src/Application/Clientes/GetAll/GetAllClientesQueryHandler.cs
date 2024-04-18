using Clientes.Common;
using Domain.Clientes;

namespace Application.Clientes.GetAll;


internal sealed class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, ErrorOr<IReadOnlyList<ClienteResponse>>>
{
    private readonly IClienteRepository _clienteRepository;

    public GetAllClientesQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<ClienteResponse>>> Handle(GetAllClientesQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Cliente> clientes = await _clienteRepository.GetAll();

        return clientes.Select(cliente => new ClienteResponse(
                cliente.Id.Value,
                cliente.NombreCompleto,
                cliente.Email,
                cliente.Telefono.Value,
                new DireccionResponse(cliente.Direccion.Calle,
                    cliente.Direccion.Colonia,
                    cliente.Direccion.Municipio,
                    cliente.Direccion.Departamento),
                    cliente.Activo
            )).ToList();
    }
}