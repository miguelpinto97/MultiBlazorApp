using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Data.Models
{
	public class ExtraItemPedido
	{
		public int Id { get; set; }
		public int ItemPedidoId { get; set; }
		public ItemPedido ItemPedido { get; set; }

		public int ExtraId { get; set; }
		public Item Extra { get; set; }

		public int Cantidad { get; set; }
		public decimal Precio { get; set; }
	}
}
