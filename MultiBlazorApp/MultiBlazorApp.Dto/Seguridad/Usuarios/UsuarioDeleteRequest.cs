using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Dto.Seguridad.Usuarios
{
    public class UsuarioDeleteRequest
    {
        public int UsuarioId { get; set; }
        public int UsuarioIdAuditoria { get; set; }


    }
}
