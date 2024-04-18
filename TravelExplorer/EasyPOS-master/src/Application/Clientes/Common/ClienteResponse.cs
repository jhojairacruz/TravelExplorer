namespace Clientes.Common;

public record ClienteResponse(
    Guid Id,
    string NombreCompleto,
    string Email,
    string Telefono,
    DireccionResponse Direccion,
    bool Activo);

public record DireccionResponse(
    string Calle,
    string Colonia,
    string Municipio,
    string Departamento);