using FluentValidation;
using MultiBlazorApp.Dto.Administracion.Parametros;

namespace MultiBlazorApp.Data.Validators
{
	public class ParametroValorAddUpdateValidator : AbstractValidator<ParametroValorAddUpdateRequest>
	{
		public ParametroValorAddUpdateValidator()
		{
			RuleFor(x => x.ParametroId)
				.NotEmpty().WithMessage("El tipo de parámetro es obligatorio");

			RuleFor(x => x.EstadoId)
				.NotEmpty().WithMessage("El estado es obligatorio");

			RuleFor(x => x.Valor)
				.NotEmpty().WithMessage("El valor es obligatorio")
				.MaximumLength(500).WithMessage("La longitud máxima del valor es 500");

			RuleFor(x => x.Descripcion)
				.MaximumLength(500).WithMessage("La longitud máxima de la descripción es 500");

			RuleFor(x => x.ValorExterno)
				.MaximumLength(500).WithMessage("La longitud máxima del valor externo es 500");

			RuleFor(x => x.Orden)
				.GreaterThanOrEqualTo(0).WithMessage("El orden debe ser menor a 9999")
				.LessThanOrEqualTo(9999).WithMessage("El orden debe ser mayor o igual a 0");

			RuleFor(x => x.UsuarioAuditoriaId)
			   .GreaterThan(0).WithMessage("Es obligatorio indicar el usuario que realiza la acción");
		}
	}

}
