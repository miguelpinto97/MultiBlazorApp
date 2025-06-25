using MultiBlazorApp.Dto.Administracion.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Dto.Pedidos
{
    public class PedidosBaseInfo
    {
        public IEnumerable<ItemDto> Items { get; set; }
        public IDictionary<string,string> Categorias { get; set; }
        public IEnumerable<ParametroValorDto> SubCategorias { get; set; }
        public int PorcentajePuntos { get; set; }
    }
}
