using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Data.Models
{
	public class Item : AuditoriaBase
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public string TipoId { get; set; }
		public ParametroValor Tipo { get; set; }

		public string CategoriaId { get; set; }
		public ParametroValor Categoria { get; set; }

        
		public decimal Precio { get; set; }
		public decimal? PrecioPromo { get; set; }

		public string RutaImg { get; set; }

        public string EstadoId { get; set; }
        public ParametroValor Estado { get; set; }
		public int OrdenPorDefecto { get; set; }

		[NotMapped]
		public decimal PrecioFinal { get { return PrecioPromo == null? Precio : PrecioPromo??0; }  set { } }
		
		[NotMapped]
		public bool EsPromo { get { return PrecioPromo != null ; } set { } }
	}
}
