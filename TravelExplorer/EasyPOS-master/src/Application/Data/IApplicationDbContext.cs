
using Domain.Destinos;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Destino> Destinos { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
}