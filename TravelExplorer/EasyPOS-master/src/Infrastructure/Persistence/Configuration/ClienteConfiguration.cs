using Domain.Clientes;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasConversion(
                clienteId => clienteId.Value,
                value => new ClienteId(value));

            builder.Property(c => c.Nombre).HasMaxLength(50);

            builder.Property(c => c.Apellido).HasMaxLength(50);

            builder.Ignore(c => c.NombreCompleto);

            builder.Property(c => c.Email).HasMaxLength(255);

            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.Telefono).HasConversion(
                telefono => telefono.Value,
                value => Telefono.Create(value)!)
                .HasMaxLength(9);

            builder.OwnsOne(c => c.Direccion, direccionBuilder => {

                direccionBuilder.Property(a => a.Calle).HasMaxLength(50); // Ajustado para calle

                direccionBuilder.Property(a => a.Colonia).HasMaxLength(50); // Ajustado para colonia

                direccionBuilder.Property(a => a.Municipio).HasMaxLength(50); // Ajustado para municipio

                direccionBuilder.Property(a => a.Departamento).HasMaxLength(50); // Ajustado para departamento
            });

            builder.Property(c => c.Activo);
        }
    }
}
