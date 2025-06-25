namespace MultiBlazorApp.Dto.Administracion.Parametros
{
    public class ParametroValorAddUpdateRequest
    {
        public string? ParametroValorId { get; set; }
        public string ParametroId { get; set; }
        public string? Descripcion { get; set; }
        public string? Valor { get; set; }
        public string? ValorExterno { get; set; }
        public int Orden { get; set; }
        public string EstadoId { get; set; }
        public string? ValorPadreId { get; set; }
		public int UsuarioAuditoriaId { get; set; }
	}
}
