using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Data.Models
{
	public class ItemPedido
	{
		public int Id { get; set; }
		public int PedidoId { get; set; }
		public Pedido Pedido { get; set; }
		public int ItemId { get; set; }
		public Item Item { get; set; }
		public ICollection<ExtraItemPedido> Extras { get; set; }
		public decimal Subtotal { get; set; }
		public decimal PrecioProducto { get; set; }
        public string? SubCategoriaId { get; set; }
        public ParametroValor? SubCategoria { get; set; }
    }
}
