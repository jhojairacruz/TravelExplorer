using Domain.PaquetesDestinos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class PaquetesDestinosRepository : IPaquetesDestinosRepository
{
    private readonly ApplicationDbContext _context;

    public PaquetesDestinosRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    //public async Task Add(Customer customer) => await _context.AddAsync(customer);

    //public async Task<Customer?> GetByIdAsync(CustomerId id) => await _context.Customers.SingleOrDefaultAsync(c => c.Id == id); 


    public void Add(PaquetesDestinos paquetesDestinos) => _context.PaquetesDestinos.Add(paquetesDestinos);
    public void Delete(PaquetesDestinos paquetesDestinos) => _context.PaquetesDestinos.Remove(paquetesDestinos);
    public void Update(PaquetesDestinos paquetesDestinos) => _context.PaquetesDestinos.Update(paquetesDestinos);
    public async Task<bool> ExistsAsync(PaquetesDestinosId id) => await _context.PaquetesDestinos.AnyAsync(paquetesDestinos => paquetesDestinos.Id == id);
    public async Task<PaquetesDestinos?> GetByIdAsync(PaquetesDestinosId id) => await _context.PaquetesDestinos.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<PaquetesDestinos>> GetAll() => await _context.PaquetesDestinos.ToListAsync();
}