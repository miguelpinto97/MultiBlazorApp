using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Dto.Pedidos
{
    public class PedidoCambiarEstadoRequest
    {
        public int PedidoId { get; set; }
        public int EntidadId { get; set; }
        public string EstadoPedidoId { get; set; }
    }
}
