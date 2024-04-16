using Domain.Destinos;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class DestinoConfiguration : IEntityTypeConfiguration<Destino>
    {
        public void Configure(EntityTypeBuilder<Destino> builder)
        {
            builder.ToTable("Destinos");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).HasConversion(
                destinoId => destinoId.Value,
                value => new DestinoId(value));

            builder.Property(d => d.Nombre).HasMaxLength(50);

            builder.Property(d => d.Descripcion).HasMaxLength(255);

            builder.OwnsOne(d => d.Ubicacion, ubicacionBuilder =>
            {
                ubicacionBuilder.Property(u => u.Pais).HasMaxLength(50);
                ubicacionBuilder.Property(u => u.Estado).HasMaxLength(50);
                ubicacionBuilder.Property(u => u.CodigoPostal).HasMaxLength(10);
            });

            builder.Property(d => d.Activo);
        }
    }
}
