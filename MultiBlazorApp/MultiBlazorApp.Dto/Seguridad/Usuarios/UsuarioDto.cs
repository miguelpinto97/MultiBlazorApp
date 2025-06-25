using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Dto.Seguridad.Usuarios
{
    public class UsuarioDto
    {
        public int Id { get; set; }
		public string NombreCompleto { get; set; }
		public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public Dictionary<int,string> Perfiles  { get; set; }
        public string Correo { get; set; }
        public string TipoDocumentoId { get; set; }
        public string TipoDocumentoDescripcion { get; set; }
        public string NumeroWhatsapp { get; set; }
        public string UserName { get; set; }
        public string EstadoId { get; set; }
        public string EstadoDescripcion { get; set; }
		public int PersonaId { get; set; }
		public int EntidadId { get; set; }
		public int PuntosAcumulados { get; set; }

	}
}
