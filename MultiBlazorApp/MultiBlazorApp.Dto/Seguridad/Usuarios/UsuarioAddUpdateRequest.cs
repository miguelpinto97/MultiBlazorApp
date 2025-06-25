using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Dto.Seguridad.Usuarios
{
    public class UsuarioAddUpdateRequest
    {
        public int UsuarioId { get; set; }
        public int UsuarioIdAuditoria { get; set; }
        public int PersonaId { get; set; }
        public string UserName { get; set; } = "";
        public string EstadoId { get; set; } = "";
        public string Password { get; set; } = "";


        public string NombreCompleto { get; set; } = "";
        public string Correo { get; set; } = "";
        public string TipoDocumento { get; set; } = "";
        public string NumeroWhatsapp { get; set; } = "";

		public int PerfilId { get; set; }

	}
}
