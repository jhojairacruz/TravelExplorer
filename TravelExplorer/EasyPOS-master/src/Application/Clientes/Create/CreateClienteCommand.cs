namespace Application.Clientes.Create;

public record CreateClienteCommand(
    string Nombre,
    string Apellido,
    string Email,
    string Telefono,
    string Calle,
    string Colonia,
    string Municipio,
    string Departamento) : IRequest<ErrorOr<Guid>>;
