
using Domain.Clientes;
using Domain.Destinos;
using Domain.PaquetesDestinos;
using Domain.PaqueteTuristicos;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Cliente> Clientes { get; set; }
    DbSet<Destino> Destinos { get; set; }
    DbSet<PaqueteTuristico> PaqueteTuristicos { get; set; }
    DbSet<PaquetesDestinos> PaquetesDestinos { get; set; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
}