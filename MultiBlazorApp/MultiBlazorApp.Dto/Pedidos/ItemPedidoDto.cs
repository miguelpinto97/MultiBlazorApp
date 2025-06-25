using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Dto.Pedidos
{
	public class ItemPedidoDto
	{
        public int IdTemporal { get; set; }
        public int ProductoId { get; set; }
		public string? ProductoNombre { get; set; }
        public string? ProductoDescripcion { get; set; }
        public string? RutaImg { get; set; }
        public decimal PrecioProducto { get; set; }
		public List<ExtraItemPedidoDto> Extras { get; set; } = new List<ExtraItemPedidoDto>();
		public decimal SubTotal { get; set; }
        public string? SubCategoriaId { get; set; }
    }
}
