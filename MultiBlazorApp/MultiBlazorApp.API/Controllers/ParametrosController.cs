using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiBlazorApp.Data.Services;
using MultiBlazorApp.Common.Constants;
using MultiBlazorApp.Dto.Administracion.Parametros;
using MultiBlazorApp.Dto.Common;

namespace MultiBlazorApp.Api.Controllers.Administracion
{
	[Route("api/[controller]")]
    [ApiController]
	public class ParametrosController : ControllerBase
    {
        private readonly IParametroService _parametroService;

        public ParametrosController(IParametroService parametroService)
        {
            _parametroService = parametroService;
        }

        [HttpGet("BaseInfo")]
		public async Task<ParametroValorBaseInfo> GetBaseInfo()
        {

			var baseInfo = new ParametroValorBaseInfo();
            baseInfo.Parametros = await _parametroService.ListarParametros();
            baseInfo.Estados = await _parametroService.ListarValoresActivos(ParametrosConstants.ParametrosId.ESTADOS_GENERALES);

            return baseInfo;
        }
		
        
        [HttpGet("{parametroId}")]
		public async Task<IEnumerable<ParametroValorDto>> Get(string parametroId)
        {
            return await _parametroService.ListarValoresDeParametro(parametroId);
        }

		[HttpGet("{parametroId}/Valores")]
		public async Task<IDictionary<string,string>> GetValores(string parametroId, string? padreId = null)
		{
			int? EntidadId = null;

            if(parametroId == ParametrosConstants.ParametrosId.PAGINACION)
            {
                EntidadId = null;
            }
			return await _parametroService.ListarValoresActivos(parametroId, padreId,false,EntidadId);
		}

		[HttpGet("{parametroId}/Detalle")]
		public async Task<ParametroDetalleDto> GetDetalle(string parametroId)
        {
            return await _parametroService.ObtenerDetalle(parametroId);
        }

        [HttpPost]
		public async Task<IActionResult> Guardar(ParametroValorAddUpdateRequest request)
        {
            request.UsuarioAuditoriaId = 1; // Por Defecto

			var valorId = await _parametroService.Guardar(request);
            return Ok(new ApiResponse().Exito(valorId));
        }

        [HttpDelete("{valorId}")]
		public async Task<IActionResult> Delete(string valorId)
        {
            var request = new ParametroValorDeleteRequest { 
                ParametroValorId = valorId, 
                UsuarioAuditoriaId = 1 //Por Defecto
            };
            await _parametroService.Eliminar(request);
            return Ok(new ApiResponse().Exito());
        }


    }
}
