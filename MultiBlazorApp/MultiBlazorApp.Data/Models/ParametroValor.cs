using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Data.Models
{
	public class ParametroValor : AuditoriaBase
	{
		public string Id { get; set; }
		public string ParametroId { get; set; }
		public Parametro Parametro { get; set; }
		public string? Descripcion { get; set; }
		public string? Valor { get; set; }
		public string? ValorExterno { get; set; }
		public int Orden { get; set; }
		public string EstadoId { get; set; }
        public ParametroValor Estado { get; set; }
        public string? ValorPadreId { get; set; }
		public ParametroValor? ValorPadre { get; set; }

    }
}
