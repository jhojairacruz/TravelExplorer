
using Domain.Clientes;
using Domain.Destinos;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Cliente> Clientes { get; set; }
    DbSet<Destino> Destinos { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
}