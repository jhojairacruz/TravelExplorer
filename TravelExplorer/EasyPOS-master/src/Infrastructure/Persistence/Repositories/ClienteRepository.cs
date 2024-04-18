using Domain.Clientes;

namespace Infrastructure.Persistence.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Cliente cliente) => _context.Clientes.Add(cliente);
    public void Delete(Cliente cliente) => _context.Clientes.Remove(cliente);
    public void Update(Cliente cliente) => _context.Clientes.Update(cliente);
    public async Task<bool> ExistsAsync(ClienteId id) => await _context.Clientes.AnyAsync(cliente => cliente.Id == id);
    public async Task<Cliente?> GetByIdAsync(ClienteId id) => await _context.Clientes.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<Cliente>> GetAll() => await _context.Clientes.ToListAsync();
}