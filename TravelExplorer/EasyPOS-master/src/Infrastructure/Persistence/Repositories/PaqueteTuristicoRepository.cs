using Domain.PaqueteTuristicos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class PaqueteTuristicoRepository : IPaqueteTuristicoRepository
{
    private readonly ApplicationDbContext _context;

    public PaqueteTuristicoRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    //public async Task Add(Customer customer) => await _context.AddAsync(customer);

    //public async Task<Customer?> GetByIdAsync(CustomerId id) => await _context.Customers.SingleOrDefaultAsync(c => c.Id == id); 


    public void Add(PaqueteTuristico paqueteTuristico) => _context.PaqueteTuristicos.Add(paqueteTuristico);
    public void Delete(PaqueteTuristico paqueteTuristico) => _context.PaqueteTuristicos.Remove(paqueteTuristico);
    public void Update(PaqueteTuristico paqueteTuristico) => _context.PaqueteTuristicos.Update(paqueteTuristico);
    public async Task<bool> ExistsAsync(PaqueteTuristicoId id) => await _context.PaqueteTuristicos.AnyAsync(customer => customer.Id == id);
    public async Task<PaqueteTuristico?> GetByIdAsync(PaqueteTuristicoId id) => await _context.PaqueteTuristicos.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<PaqueteTuristico>> GetAll() => await _context.PaqueteTuristicos.ToListAsync();
}