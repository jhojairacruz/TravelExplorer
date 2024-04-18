namespace Application.Clientes.Update;

public record UpdateClienteCommand(
    Guid Id,
    string Nombre,
    string Apellido,
    string Email,
    string Telefono,
    string Calle,
    string Colonia,
    string Municipio,
    string Departamento,
    bool Activo) : IRequest<ErrorOr<Unit>>;