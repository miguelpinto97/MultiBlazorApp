using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Data.Models
{
	public class Pedido:AuditoriaBase
	{
		public int Id { get; set; }
		public string CodigoPedido { get; set; }

		public int? UsuarioId { get; set; }
		public Usuario? Usuario { get; set; }
		public string? Direccion { get; set; }
		public string? NumeroWhatsapp { get; set; }
		public string? NombreReceptor { get; set; }
		public ICollection<ItemPedido> Items { get; set; }
		public decimal PrecioTotal { get; set; }
		public string EstadoPedidoId { get; set; }
		public ParametroValor EstadoPedido { get; set; }

    }
}
