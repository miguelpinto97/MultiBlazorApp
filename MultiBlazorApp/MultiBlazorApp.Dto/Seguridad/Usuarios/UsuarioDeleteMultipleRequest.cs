using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Dto.Seguridad.Usuarios
{
    public class UsuarioDeleteMultipleRequest
    {
        public List<int> UsuariosId { get; set; }
        public int UsuarioIdAuditoria { get; set; }
    }
}
