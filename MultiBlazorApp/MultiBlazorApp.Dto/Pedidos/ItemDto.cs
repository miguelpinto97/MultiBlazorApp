using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Dto.Pedidos
{
	public class ItemDto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public string TipoId { get; set; }
		public string CategoriaId { get; set; }
		public decimal Precio { get; set; }
		public decimal? PrecioPromo { get; set; } 
		public bool EsPromo { get; set; }
		public string RutaImg { get; set; }
		public int MaximoCremas { get; set; }
	}
}
