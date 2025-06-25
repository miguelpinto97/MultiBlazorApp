using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Dto.Pedidos
{
	public class PedidoDto
	{
		public int Id { get; set; }
        public int EntidadId { get; set; }
        public string CodigoPedido { get; set; }
		public int? UsuarioId { get; set; }
		public string? Direccion { get; set; }
		public string? NumeroWhatsapp { get; set; }
		public string? NombreReceptor { get; set; }
        public string? FechaPedido { get; set; }
        public decimal PrecioTotal { get; set; }
		public int PuntosAcumulados { get; set; }
        public string EstadoDescripcion { get; set; }
        public string EstadoId { get; set; }
        public List<ItemPedidoDto> Productos { get; set; }
		public bool EsPromo { get; set; }
        public bool CanjeaPuntos { get; set; }
    }
}
