namespace MultiBlazorApp.Dto.Administracion.Parametros
{
	public class ParametroDetalleDto
	{
		public string Id { get; set; }
		public string Nombre { get; set; }
		public bool PuedeAgregar { get; set; }
		public bool PuedeModificar { get; set; }
		public bool PuedeEliminar { get; set; }
		public string? ParametroPadreId { get; set; }
	}
}
