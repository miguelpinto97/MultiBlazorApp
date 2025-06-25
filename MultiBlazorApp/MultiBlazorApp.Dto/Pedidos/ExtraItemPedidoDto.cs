using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Dto.Pedidos
{
	public class ExtraItemPedidoDto
	{
		public int ProductoPedidoId { get; set; }
		public int ExtraId { get; set; }
		public string? ExtraDescripcion { get; set; }
		public int Cantidad { get; set; }
		public decimal Precio { get; set; }
        public ExtraItemPedidoDto Clone()
        {
            return new ExtraItemPedidoDto
            {
                ExtraId = this.ExtraId,
                ExtraDescripcion = this.ExtraDescripcion,
                Cantidad = this.Cantidad,
                Precio = this.Precio
            };
        }
    }
}
