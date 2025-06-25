using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Data.Models
{
	public class Parametro
	{
		public string Id { get; set; }
		public string Nombre { get; set; }
		public bool PuedeAgregar { get; set; }
		public bool PuedeModificar { get; set; }
		public bool PuedeEliminar { get; set; }
		public bool PuedeVisualizar { get; set; }
		public string? ParametroPadreId { get; set; }
		public Parametro? ParametroPadre { get; set; }
	}
}
