using MultiBlazorApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace MultiBlazorApp.Data
{
    public class DataBaseContext : DbContext
    {


		public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


		}

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Parametro> Parametros { get; set; }
		public DbSet<ParametroValor> ParametroValores { get; set; }

		public DbSet<Item> Items { get; set; }
		public DbSet<Pedido> Pedidos { get; set; }
		public DbSet<ItemPedido> ItemsPedido { get; set; }
		public DbSet<ExtraItemPedido> ExtrasItemPedido { get; set; }
	}
}
