using Domain.Clientes;
using Domain.Primitives;
using Domain.ValueObjects;
using Domain.DomainErrors;

namespace Application.Clientes.Create;

public sealed class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, ErrorOr<Guid>>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateClienteCommandHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Guid>> Handle(CreateClienteCommand command, CancellationToken cancellationToken)
    {
        if (Telefono.Create(command.Telefono) is not Telefono telefono)
        {
            return Errors.Cliente.TelefonoWithBadFormat;
        }

        if (Direccion.Create(command.Calle, command.Colonia, command.Municipio, command.Departamento) is not Direccion direccion)
        {
          return Errors.Cliente.DireccionWithBadFormat;
        }

        var cliente = new Cliente(
            new ClienteId(Guid.NewGuid()),
            command.Nombre,
            command.Apellido,
            command.Email,
            telefono,
            direccion,
            true
        );

        _clienteRepository.Add(cliente);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return cliente.Id.Value;
    }
}