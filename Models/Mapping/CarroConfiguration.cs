using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BryanParkingLot.Models
{
    public class CarroConfiguration : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.ToTable("Carros"); 

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Marca);

            builder.Property(c => c.Modelo);

            builder.Property(c => c.Placa);

            builder.Property(c => c.Estacionado);

            builder.Property(c => c.DataEntrada);

            builder.Property(c => c.DataSaida);
        }
    }
}