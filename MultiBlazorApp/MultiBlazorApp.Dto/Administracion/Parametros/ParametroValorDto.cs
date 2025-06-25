namespace MultiBlazorApp.Dto.Administracion.Parametros
{
    public class ParametroValorDto
    {
        public string Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Valor { get; set; }
        public string? ValorExterno { get; set; }
        public string? ValorPadreId { get; set; }
        public string? ValorPadre { get; set; }
        public string Estado { get; set; }
        public string EstadoId { get; set; }
        public int Orden { get; set; }
        public DateTime FechaModifica { get; set; }
        public string UsuarioModifica { get; set; }

        /* Valores para Sub Categoria */
        public string? RutaImg { get; set; }
        public int MaximoCremas { get; set; }
    }
}
