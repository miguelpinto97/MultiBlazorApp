using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace MultiBlazorApp.Common.Utils
{
	public static class NumberUtil
	{
		public const string FormatoLocal = "#,##0.00";
		public const string FormatoInputNumber = "0.00";


		public static string ToStringLocal(this decimal numero, string formato = null)
		{
			if(formato != null)
			{
				return numero.ToString(formato, CultureInfo.InvariantCulture);
			}
			return numero.ToString(FormatoLocal, CultureInfo.InvariantCulture);
		}

		public static string ToStringInputNumber(this decimal numero)
		{
			return numero.ToString(FormatoInputNumber, CultureInfo.InvariantCulture);
		}

		public static int ToInt(this string texto)
		{
			if (string.IsNullOrEmpty(texto))
				return 0;
			return Convert.ToInt32(texto, CultureInfo.InvariantCulture);
		}

		public static decimal Redondeado(this decimal numero, int decimales = 2)
		{
			return Math.Round(numero, decimales);
		}


		public static decimal ToDecimal(this string? texto)
		{
			if (string.IsNullOrEmpty(texto))
				return 0;

			if (decimal.TryParse(texto, NumberStyles.Number | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal resultado))
			{
				return resultado;
			}
			return 0;
		}

		public static decimal Absoluto(this decimal valor)
		{
			return Math.Abs(valor);
		}

		public static string FormatoDecimal(this string texto)
		{
			var numero = Convert.ToDecimal(texto, CultureInfo.InvariantCulture);
			return numero.ToStringLocal();
        }

        public static decimal QuitarIgv(this decimal importe, decimal porcentajeIgv)
        {
			var importeSeparado = SepararImporteDeIgv(importe, porcentajeIgv, true);
			return importeSeparado.Item1;

		}

		public static decimal SoloIgv(this decimal importe, decimal porcentajeIgv)
		{
			var importeSeparado = SepararImporteDeIgv(importe, porcentajeIgv, true);
			return importeSeparado.Item2;
		}

		public static (decimal, decimal) SepararImporteDeIgv(decimal importe, decimal porcentajeIgv, bool afectoIgv)
		{
			if (afectoIgv)
			{
				var importeBruto = Math.Round(importe / (1 + porcentajeIgv), 2);
				var igv = importeBruto * porcentajeIgv;
				importeBruto = Math.Round(importeBruto, 2);
				igv = Math.Round(igv, 2);

				var diferencia = importe - importeBruto - igv;
				if (diferencia != 0)
					importeBruto = importeBruto + diferencia;

				return (importeBruto, igv);
			}
			else
			{
				return (Math.Round(importe, 2), 0);
			}
		}
	}
}
