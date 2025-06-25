using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MultiBlazorApp.Common.Constants;
using MultiBlazorApp.Common.Exceptions;
using MultiBlazorApp.Common.Utils;
using MultiBlazorApp.Data;
using MultiBlazorApp.Data.Models;
using MultiBlazorApp.Dto.Administracion.Parametros;

namespace MultiBlazorApp.Data.Services
{
	public class ParametroService : IParametroService
    {
        private readonly DataBaseContext _dbContext;
        private readonly IValidator<ParametroValorAddUpdateRequest> _validatorAddUpdate;
        private const string MENSAJE_ELIMINAR = "Al menos {0} tiene asociado el parámetro que se quiere eliminar";

		public ParametroService(DataBaseContext dbContext,
            IValidator<ParametroValorAddUpdateRequest> validatorAddUpdate)
        {
            _dbContext = dbContext;
            _validatorAddUpdate = validatorAddUpdate;
        }

        public async Task<string> Guardar(ParametroValorAddUpdateRequest request)
        {
            var validationResult = await _validatorAddUpdate.ValidateAsync(request);
            if (!validationResult.IsValid) throw new BadRequestException(validationResult.ToDictionary());
            await ValidarNoExisterDuplicado(request.Descripcion, request.Valor, request.ParametroId, request.ValorPadreId, request.ParametroValorId);
            await ValidarExistenciaValorActivo(request.EstadoId, ParametrosConstants.ParametrosId.ESTADOS_GENERALES);            

            ParametroValor parametroValor;

            if (request.ParametroValorId != null)
            {
                parametroValor = await _dbContext.ParametroValores
                    .Where(x => !x.Eliminado && x.Id == request.ParametroValorId)
                    .SingleAsync() ?? throw new CustomException("El valor no existe");


                parametroValor.Descripcion = request.Descripcion?.ToUpper();
                parametroValor.Valor = request.Valor?.ToUpper();
                parametroValor.ValorExterno = request.ValorExterno?.ToUpper();
                parametroValor.ValorPadreId = request.ValorPadreId;
                parametroValor.ParametroId = request.ParametroId;
                parametroValor.Orden = request.Orden;
                parametroValor.EstadoId = request.EstadoId;
                parametroValor.UsuarioModificaId = request.UsuarioAuditoriaId;
                parametroValor.FechaModifica = FechaUtil.FechaHoraUTC();
            }
            else
            {
                var nuevoId = await ObtenerNuevoId(request.ParametroId);

                parametroValor = new ParametroValor()
                {
                    Id = nuevoId,
                    Descripcion = request.Descripcion?.ToUpper(),
                    Valor = request.Valor?.ToUpper(),
                    ValorExterno = request.ValorExterno?.ToUpper(),
                    ValorPadreId = request.ValorPadreId,
                    ParametroId = request.ParametroId,
                    Orden = request.Orden,
                    EstadoId = request.EstadoId,
                    UsuarioRegistroId = request.UsuarioAuditoriaId,
                    FechaRegistro = FechaUtil.FechaHoraUTC(),
                    UsuarioModificaId = request.UsuarioAuditoriaId,
                    FechaModifica = FechaUtil.FechaHoraUTC(),
                };
                await _dbContext.ParametroValores.AddAsync(parametroValor);
            }

            await _dbContext.SaveChangesAsync();
            return parametroValor.Id;
        }

        public async Task<IDictionary<string, string>> ListarParametros()
        {
            var parametros = await _dbContext.Parametros
                .Where(x => x.PuedeVisualizar == true)
                .OrderBy(x => x.Nombre)
                .ToListAsync();
            return parametros.ToDictionary(x => x.Id, x => x.Nombre);
        }

        public async Task<IEnumerable<ParametroValorDto>> ListarValoresDeParametro(string parametroId)
        {
            return await _dbContext.ParametroValores
                .Include(x => x.ValorPadre)
                .Include(x => x.UsuarioModifica)
				.Include(x => x.UsuarioRegistro)
				.Where(x => (x.ParametroId == parametroId || parametroId == "")
                            && !x.Eliminado)
                .Select(x => new ParametroValorDto()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    Valor = x.Valor,
                    ValorExterno = x.ValorExterno,
                    ValorPadreId = x.ValorPadreId,
                    ValorPadre = x.ValorPadre == null ? "" : x.ValorPadre.Valor,
                    EstadoId = x.EstadoId,
                    Estado = x.EstadoId == ParametrosConstants.EstadosGenerales.ACTIVO ? "ACTIVO" : "INACTIVO",
                    Orden = x.Orden,
                    FechaModifica = x.FechaModifica ?? x.FechaRegistro,
                    UsuarioModifica = x.UsuarioModifica != null ? x.UsuarioModifica.NombreCorto : x.UsuarioRegistro.NombreCorto,
                })
				.OrderByDescending(x => x.FechaModifica)
                .ToListAsync();
        }

        public async Task<IDictionary<string, string>> ListarValoresActivos(string parametroId, string? padreId = null, bool devolverDescripcion = false, int? EntidadId = null)
        {
            var valores = await _dbContext.ParametroValores
                .Where(x => x.ParametroId == parametroId 
                    && !x.Eliminado 
                    && x.EstadoId == ParametrosConstants.EstadosGenerales.ACTIVO
                    && (x.ValorPadreId == padreId || padreId == null))
                .OrderBy(x => x.Orden).ThenBy(x => devolverDescripcion ? x.Descripcion : x.Valor)
                .ToListAsync();

            return valores.ToDictionary(x => x.Id, x => devolverDescripcion ? x.Descripcion : x.Valor);
        }

        public async Task<IDictionary<string, string>> ListarDescripcionValorActivos(string parametroId, string? padreId = null)
        {
            var valores = await _dbContext.ParametroValores
                .Where(x => x.ParametroId == parametroId
                    && !x.Eliminado
                    && x.EstadoId == ParametrosConstants.EstadosGenerales.ACTIVO
                    && x.ValorPadreId == padreId)
				.OrderBy(x => x.Orden).ThenBy(x => x.Descripcion)
				.ToListAsync();

            return valores.ToDictionary(x => x.Valor, x => x.Descripcion);
        }

        public async Task Eliminar(ParametroValorDeleteRequest request)
        {
            
            var valor = await _dbContext.ParametroValores.FindAsync(request.ParametroValorId) ?? throw new CustomException("El valor no existe");

			if (await _dbContext.ParametroValores.AnyAsync(x => x.ValorPadreId == request.ParametroValorId && !x.Eliminado))
				throw new CustomException(string.Format(MENSAJE_ELIMINAR, "un parámetro"));

			valor.UsuarioModificaId = request.UsuarioAuditoriaId;
            valor.FechaModifica = FechaUtil.FechaHoraUTC();
            valor.Eliminado = true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task ValidarExistenciaValorActivo(string valorId, string parametroId)
        {
            var parametro = await _dbContext.Parametros.FindAsync(parametroId);

            var existeValor = await _dbContext.ParametroValores
                .AnyAsync(x => !x.Eliminado
                        && x.EstadoId == ParametrosConstants.EstadosGenerales.ACTIVO
                        && x.Id == valorId
                        && x.ParametroId == parametroId);

            if (!existeValor) throw new CustomException($"No existe el valor \"{valorId}\" enviado para {parametro.Nombre}");
        }

		public async Task ValidarExistenciaValor(string valorId, string parametroId)
		{
			var parametro = await _dbContext.Parametros.FindAsync(parametroId);

			var existeValor = await _dbContext.ParametroValores
				.AnyAsync(x => !x.Eliminado
						&& x.Id == valorId
						&& x.ParametroId == parametroId);

			if (!existeValor) throw new CustomException($"No existe el valor \"{valorId}\" enviado para {parametro.Nombre}");
		}

		public async Task<ParametroDetalleDto> ObtenerDetalle(string parametroId)
        {
			var parametro = await _dbContext.Parametros.FindAsync(parametroId) ?? throw new CustomException("El parámetro no existe");
            return new ParametroDetalleDto()
            {
                Id = parametro.Id,
                Nombre = parametro.Nombre,
                ParametroPadreId = parametro.ParametroPadreId,
                PuedeAgregar = parametro.PuedeAgregar,
                PuedeEliminar = parametro.PuedeEliminar,
                PuedeModificar = parametro.PuedeModificar
            };
		}


		private async Task ValidarNoExisterDuplicado(string? descripcion, string? valor, string parametroId, string? padreId = null, string? parametroValorId = null)
        {
            var existeDuplicado = await _dbContext.ParametroValores
                .AnyAsync(x => !x.Eliminado 
                    && x.Id != parametroValorId
                    && x.ParametroId == parametroId
                    && x.ValorPadreId == padreId
                    && x.Descripcion == descripcion
					&& x.Valor == valor);

            if (existeDuplicado) throw new CustomException("Existe otro valor con el mismo nombre");
        }

        private async Task<string> ObtenerNuevoId(string parametroId)
        {
            var ultimoId = await _dbContext.ParametroValores.Where(x => x.ParametroId == parametroId).MaxAsync(x => x.Id);

            var nuevoCorrelativo = Convert.ToInt32((ultimoId??"0").Replace(parametroId, "")) + 1;

            var nuevoId = parametroId + nuevoCorrelativo.ToString().PadLeft(4, '0');
            return nuevoId;
        }


        public async Task<ParametroValorDto> ObtenerValor(string valorId)
        {
            return await _dbContext.ParametroValores
               .Where(x => x.Id == valorId && !x.Eliminado)
               .Select(x => new ParametroValorDto()
               {
                   Id = x.Id,
                   Descripcion = x.Descripcion,
                   Valor = x.Valor,
                   ValorExterno = x.ValorExterno,
                   ValorPadreId = x.ValorPadreId,
                   EstadoId = x.EstadoId,                   
                   Orden = x.Orden
               })
               .FirstOrDefaultAsync() ?? throw new CustomException("El valor no existe");
        }

		public async Task<decimal> ObtenerIGV()
		{
			return await _dbContext.ParametroValores
			   .Where(x => x.Id == ParametrosConstants.ValoresContables.IGV && !x.Eliminado)
			   .Select(x => decimal.Parse(x.Valor??"o"))
			   .FirstOrDefaultAsync();
		}

        public async Task<IDictionary<string, int>> ListarEquivalenciasNotas()
        {
            int value = 0;

            var parametroId = ParametrosConstants.ParametrosId.EQUIVALENCIAS_NOTAS;  
            
            var valores = await _dbContext.ParametroValores
            .Where(x => x.ParametroId == parametroId
                && !x.Eliminado
                && x.EstadoId == ParametrosConstants.EstadosGenerales.ACTIVO
                )     
            .ToListAsync();

            return valores.OrderBy(x => int.TryParse(x.Valor, out value) ? int.Parse(x.Valor) : 0)
                          .ToDictionary(x => x.Descripcion??"", x => int.TryParse(x.Valor, out value) ? int.Parse(x.Valor) : 0);
        }

        public string ObtenerEquivalenciaNota(decimal Nota, IDictionary<string, int> Equivalencias)
        {
            var EquivalenciasOrdenadas = Equivalencias.OrderBy(x=>x.Value);

            if(Nota == Equivalencias.Max(x => x.Value))
            {
                return Equivalencias.MaxBy(x => x.Value).Key;
            }

            foreach(var equivalencia in EquivalenciasOrdenadas)
            {
                if(Nota < equivalencia.Value)
                {
                    return equivalencia.Key;
                }
            }
            return "";
        }
    }
}
