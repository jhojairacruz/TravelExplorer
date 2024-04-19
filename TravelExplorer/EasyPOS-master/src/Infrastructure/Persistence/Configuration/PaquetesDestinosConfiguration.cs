using Domain.PaquetesDestinos;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class PaquetesDestinosConfiguration : IEntityTypeConfiguration<PaquetesDestinos>
{
    public void Configure(EntityTypeBuilder<PaquetesDestinos> builder)
    {
        builder.ToTable("PaquetesDestinos");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            paquetesDestinosId => paquetesDestinosId.Value,
            value => new PaquetesDestinosId(value));

        builder.Property(c => c.PaqueteTuristicoId);

        builder.Property(c => c.DestinoId);
    }
}
