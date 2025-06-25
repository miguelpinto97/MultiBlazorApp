using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Dto.Seguridad.Usuarios
{
    public class UsuarioPerfilAddUpdateRequest
    {
        public int UsuarioIdAuditoria { get; set; } 
        public List<UsuarioPerfilDto> UsuariosPerfiles { get; set; } = new List<UsuarioPerfilDto>();

    }
}
