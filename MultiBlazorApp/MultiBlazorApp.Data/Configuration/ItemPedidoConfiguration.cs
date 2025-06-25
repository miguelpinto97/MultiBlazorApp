using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiBlazorApp.Data.Models;

namespace MultiBlazorApp.Data.Configuration
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItemsPedido");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Subtotal)
                .HasPrecision(10, 2);

            builder.Property(x => x.PrecioProducto)
                .HasPrecision(10, 2);

            // Relaciones explícitas
            builder.HasOne(x => x.Pedido)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.PedidoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Item)
                .WithMany() // Sin navegación inversa
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
