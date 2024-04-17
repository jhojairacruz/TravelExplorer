using Domain.PaqueteTuristicos;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class PaqueteTuristicoConfiguration : IEntityTypeConfiguration<PaqueteTuristico>
{
    public void Configure(EntityTypeBuilder<PaqueteTuristico> builder)
    {
        builder.ToTable("PaqueteTuristicos");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            customerId => customerId.Value,
            value => new PaqueteTuristicoId(value));

        builder.Property(c => c.Nombre).HasMaxLength(50);

        builder.Property(c => c.Descripcion).HasMaxLength(50);

        builder.Property(c => c.FechaInicio).HasMaxLength(255);

        builder.Property(c => c.FechaFin).HasMaxLength(255);

        builder.Property(c => c.Precio).IsRequired();

        builder.Property(c => c.Activo);
    }
}
