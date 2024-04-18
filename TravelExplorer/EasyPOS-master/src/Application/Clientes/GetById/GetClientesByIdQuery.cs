using Clientes.Common;
using Domain.Clientes;

namespace Application.Clientes.GetById;


internal sealed class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, ErrorOr<ClienteResponse>>
{
    private readonly IClienteRepository _clienteRepository;

    public GetClienteByIdQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
    }

    public async Task<ErrorOr<ClienteResponse>> Handle(GetClienteByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _clienteRepository.GetByIdAsync(new ClienteId(query.Id)) is not Cliente cliente)
        {
            return Error.NotFound("Cliente.NotFound", "No se ha encontrado el cliente con el Id proporcionado.");
        }

        return new ClienteResponse(
            cliente.Id.Value, 
            cliente.NombreCompleto, 
            cliente.Email, 
            cliente.Telefono.Value, 
            new DireccionResponse(cliente.Direccion.Calle,
            cliente.Direccion.Colonia,
            cliente.Direccion.Municipio,
            cliente.Direccion.Departamento),
            cliente.Activo);
    }
}