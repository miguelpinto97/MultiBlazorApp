using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiBlazorApp.Data.Models;

namespace MultiBlazorApp.Data.Configuration
{
    public class ExtraItemPedidoConfiguration : IEntityTypeConfiguration<ExtraItemPedido>
    {
        public void Configure(EntityTypeBuilder<ExtraItemPedido> builder)
        {
            builder.ToTable("ExtrasItemPedido");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Precio)
                .HasPrecision(10, 2);

            builder.HasOne(x => x.ItemPedido)
                .WithMany(x => x.Extras)
                .HasForeignKey(x => x.ItemPedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Extra)
                .WithMany() // 👈 Sin navegación inversa para evitar ciclos
                .HasForeignKey(x => x.ExtraId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
