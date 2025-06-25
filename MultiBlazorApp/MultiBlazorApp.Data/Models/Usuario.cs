using MultiBlazorApp.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiBlazorApp.Data.Models
{
    public class Usuario : AuditoriaBase
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public string NumeroWhatsapp { get; set; }
        public string Direccion { get; set; }
        public string EstadoId { get; set; }
        public ParametroValor Estado { get; set; }
        public string RolId { get; set; }
        public ParametroValor Rol { get; set; }

        [NotMapped]
        public string NombreCorto { get { return Nombre + " " + ApellidoPaterno; } set { } }

    }
}
