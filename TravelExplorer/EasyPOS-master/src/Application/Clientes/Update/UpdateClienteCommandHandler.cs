using Domain.Clientes;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Application.Clientes.Update;

internal sealed class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, ErrorOr<Unit>>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateClienteCommandHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateClienteCommand command, CancellationToken cancellationToken)
    {
        if (!await _clienteRepository.ExistsAsync(new ClienteId(command.Id)))
        {
            return Error.NotFound("Cliente.NotFound", "The customer with the provide Id was not found.");
        }

        if (Telefono.Create(command.Telefono) is not Telefono telefono)
        {
            return Error.Validation("Cliente.Telefono", "Formato de telefono no valido");
        }

        if (Direccion.Create(command.Calle, command.Colonia, command.Municipio, command.Departamento
                    ) is not Direccion direccion)
        {
            return Error.Validation("Cliente.Direccion", "Direccion no valida.");
        }

        Cliente cliente = Cliente.UpdateCliente(command.Id, command.Nombre,
            command.Apellido,
            command.Email,
            telefono,
            direccion,
            command.Activo);

        _clienteRepository.Update(cliente);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}