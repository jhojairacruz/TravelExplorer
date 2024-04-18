namespace Domain.Clientes;

public interface IClienteRepository
{
    Task<List<Cliente>> GetAll();
    Task<Cliente?> GetByIdAsync(ClienteId id);
    Task<bool> ExistsAsync(ClienteId id);
    void Add(Cliente cliente);
    void Update(Cliente cliente);
    void Delete(Cliente cliente);
}