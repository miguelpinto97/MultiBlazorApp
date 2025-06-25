namespace MultiBlazorApp.Data.Models
{
    public class AuditoriaBase
    {
        public bool Eliminado { get; set; }
        public int? UsuarioRegistroId { get; set; }
        public Usuario? UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? UsuarioModificaId { get; set; }
        public Usuario? UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }


    }
}
