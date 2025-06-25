using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MultiBlazorApp.Dto.Administracion.Colaborador;

namespace MultiBlazorApp.Dto.Seguridad.Usuarios
{
    public class UsuariosFiltrosBaseInfo
    {
        public IDictionary<string, string> TiposDoc { get; set; }
        public IDictionary<string, string> Estados { get; set; }
        //public IEnumerable<ColaboradorSinUsuarioDto> ColaboradoresSinUsuario { get; set; }
    }
}
