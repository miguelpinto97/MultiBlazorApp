using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Dto.Pedidos
{
	public class ItemAddRequest
	{
		public int? UsuarioId { get; set; }
		public int? EntidadId { get; set; }
		public string? Direccion { get; set; }
		public string? NumeroWhatsapp { get; set; }
		public string? NombreReceptor { get; set; }

		public List<ItemPedidoDto> Productos { get; set; }

		public bool CanjeaPuntos { get; set; } = false;
    }
}
