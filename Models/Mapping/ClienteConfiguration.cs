using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BryanParkingLot.Models
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome);

            builder.Property(c => c.Sobrenome);

            builder.Property(c => c.Documento);

            builder.Property(c => c.Pais);

            builder.Property(c => c.Endereco);
            
            builder.HasOne(c => c.Carro)
                .WithOne(c => c.Cliente)
                .HasForeignKey<Carro>(c => c.ClienteId)
                .IsRequired();
        }
    }
}