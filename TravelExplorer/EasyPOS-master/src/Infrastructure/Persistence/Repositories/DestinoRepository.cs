using Domain.Destinos;

namespace Infrastructure.Persistence.Repositories;

public class DestinoRepository : IDestinoRepository
{
    private readonly ApplicationDbContext _context;

    public DestinoRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Destino destino) => _context.Destinos.Add(destino);
    public void Delete(Destino destino) => _context.Destinos.Remove(destino);
    public void Update(Destino destino) => _context.Destinos.Update(destino);

public async Task<bool> ExistsAsync(DestinoId id)
{
    return await _context.Destinos.AnyAsync(d => d.Id == id);
}

    public async Task<Destino?> GetByIdAsync(DestinoId id) => 
        await _context.Destinos.SingleOrDefaultAsync(d => d.Id == id);

    public async Task<List<Destino>> GetAll() => await _context.Destinos.ToListAsync();

  
}

