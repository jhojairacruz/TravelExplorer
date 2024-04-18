using Domain.Primitives;

namespace Domain.Clientes;

public sealed class Cliente : AggregateRoot
{
    
    public Cliente(ClienteId id, string nombre, string apellido, string email, 
    Telefono telefono, Direccion direccion, bool activo)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Telefono = telefono;
        Direccion = direccion;
        Activo = activo;
    }

    private Cliente()
    {

    }

    
    public ClienteId Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string NombreCompleto => $"{Nombre} {Apellido}";
    public string Email { get; private set; } = string.Empty;
    public Telefono Telefono { get; private set; }
    public Direccion Direccion { get; private set; }
    public bool Activo { get; private set; }

    public static Cliente UpdateCliente(Guid id, string nombre, string apellido, string email, Telefono telefono, Direccion direccion, bool activo)
    {
        return new Cliente(new ClienteId(id), nombre, apellido, email, telefono, direccion, activo);
    }
}