
using Domain.Clientes;
using Domain.Destinos;
using Domain.PaqueteTuristicos;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Cliente> Clientes { get; set; }
    DbSet<Destino> Destinos { get; set; }
    public DbSet<PaqueteTuristico> PaqueteTuristicos { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
}