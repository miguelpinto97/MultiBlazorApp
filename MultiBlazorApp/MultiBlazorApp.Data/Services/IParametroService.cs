using MultiBlazorApp.Dto.Administracion.Parametros;

namespace MultiBlazorApp.Data.Services
{
	public interface IParametroService
    {
        public Task ValidarExistenciaValorActivo(string valorId, string parametroId);
        public Task ValidarExistenciaValor(string valorId, string parametroId);
		public Task<IDictionary<string, string>> ListarParametros();
        public Task<IEnumerable<ParametroValorDto>> ListarValoresDeParametro(string parametroId);
        public Task<IDictionary<string, string>> ListarValoresActivos(string parametroId, string? padreId = null, bool devolverDescripcion = false, int? EntidadId = null);
        public Task<IDictionary<string, string>> ListarDescripcionValorActivos(string parametroId, string? padreId = null);
        public Task<string> Guardar(ParametroValorAddUpdateRequest request);
        public Task Eliminar(ParametroValorDeleteRequest request);
		public Task<ParametroDetalleDto> ObtenerDetalle(string parametroId);
        public Task<ParametroValorDto> ObtenerValor(string valorId);
		public Task<decimal> ObtenerIGV();
        public Task<IDictionary<string, int>> ListarEquivalenciasNotas();

        public string ObtenerEquivalenciaNota(decimal Nota,IDictionary<string,int> Equivalencias);

    }
}
