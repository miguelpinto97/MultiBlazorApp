using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiBlazorApp.Data.Models;

namespace MultiBlazorApp.Data.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.EstadoPedidoId)
                .HasDefaultValue("ESPE0001");

            builder.Property(x => x.PrecioTotal)
                .HasPrecision(10, 2);
        }
    }
}
